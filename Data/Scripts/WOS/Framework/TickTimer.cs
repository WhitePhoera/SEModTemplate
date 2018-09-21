#line 2
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Phoera.Framework
{
    public class TickTimer
    {
        class TickTimerCancelToken : IDisposable, IEquatable<TickTimerCancelToken>
        {
            public ulong Timeout;
            public readonly Action<TickTimerCancelToken> Action;
            public TickTimer Timer;
            public readonly ulong Period;

            public TickTimerCancelToken(ulong timeout, Action<TickTimerCancelToken> action, TickTimer timer, ulong repeatAfter)
            {
                Timeout = timeout;
                Action = action;
                Timer = timer;
                this.Period = repeatAfter;
            }

            public void Cancel()
            {
                Timer?.CancelAction(this);
                Timer = null;
            }

            void IDisposable.Dispose()
            {
                Cancel();
            }

            bool IEquatable<TickTimerCancelToken>.Equals(TickTimerCancelToken other)
            {
                return Timer == other.Timer && Timeout == other.Timeout && Action == other.Action;
            }

            public override int GetHashCode()
            {
                return Action.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                    return true;
                var e = obj as TickTimerCancelToken;
                if (e == null)
                    return false;
                return (this as IEquatable<TickTimerCancelToken>).Equals(e);
            }
        }
        SortedDictionary<ulong, HashSet<TickTimerCancelToken>> _delays = new SortedDictionary<ulong, HashSet<TickTimerCancelToken>>();
        ConcurrentQueue<TickTimerCancelToken> _toRemove = new ConcurrentQueue<TickTimerCancelToken>();
        ConcurrentQueue<TickTimerCancelToken> _toAdd = new ConcurrentQueue<TickTimerCancelToken>();

        public static ulong SecondsToTicks(double seconds)
        {
            return (ulong)Math.Round(seconds / TickLength);
        }
        public static ulong TimeSpanToTicks(TimeSpan time)
        {
            return (ulong)Math.Round(time.TotalSeconds / TickLength);
        }

        public int ActiveCount
        {
            get
            {
                return _delays.Count + _toAdd.Count + _toRemove.Count;
            }
        }
        public bool IsActive => ActiveCount > 0;
        ulong tick = 0;
        public ulong TickCount { get { return tick; } }

        public void Reset()
        {
            tick = 0;
        }

        const double TickLength = 1.0 / 60.0;

        public IDisposable AddRepeatableActionInTicks(Action<IDisposable> action, ulong period)
        {
            var tmp = new TickTimerCancelToken(period, action, this, period);
            _toAdd.Enqueue(tmp);
            return tmp;
        }
        public IDisposable AddRepeatableActionInSeconds(Action<IDisposable> action, double period)
        {
            return AddRepeatableActionInTicks(action, Math.Max(1, (ulong)Math.Round(period / TickLength)));
        }
        public IDisposable AddRepeatableActionInTimeSpan(Action<IDisposable> action, TimeSpan period)
        {
            return AddRepeatableActionInSeconds(action, period.TotalSeconds);
        }
        void CancelAction(TickTimerCancelToken token)
        {
            if (token.Timer != this)
                return;
            _toRemove.Enqueue(token);
        }
        public event Action ActionRemoved;

        public IDisposable AddDelayedActionInTicks(Action<IDisposable> action, ulong delay)
        {
            var tmp = new TickTimerCancelToken(delay, action, this, 0);
            _toAdd.Enqueue(tmp);
            return tmp;
        }
        public IDisposable AddDelayedActionInSeconds(Action<IDisposable> action, double delay)
        {
            return AddDelayedActionInTicks(action, Math.Max(1, (ulong)Math.Round(delay / TickLength)));
        }
        public IDisposable AddDelayedActionInTimeSpan(Action<IDisposable> action, TimeSpan delay)
        {
            return AddDelayedActionInSeconds(action, delay.TotalSeconds);
        }
        void AddAction(TickTimerCancelToken token)
        {
            HashSet<TickTimerCancelToken> actions;
            if (!_delays.TryGetValue(tick + token.Timeout, out actions))
            {
                _delays[tick + token.Timeout] = actions = new HashSet<TickTimerCancelToken>(EqualityComparer<TickTimerCancelToken>.Default);
            }
            actions.Add(token);
        }
        void RemoveAction(TickTimerCancelToken token)
        {
            HashSet<TickTimerCancelToken> actions;
            if (_delays.TryGetValue(token.Timeout, out actions))
            {
                if (actions.Remove(token))
                {
                    if (actions.Count == 0)
                        _delays.Remove(token.Timeout);
                    ActionRemoved?.Invoke();
                }
            }
        }
        ulong minTick = 0;
        public void Tick()
        {
            if (_toRemove.Count > 0)
            {
                foreach (var rem in _toRemove.DequeueAll())
                {
                    RemoveAction(rem);
                }
            }
            tick++;
            bool needRecalc = false;
            if (_delays.Count > 0 && minTick == tick)
            {
                HashSet<TickTimerCancelToken> actions;
                if (_delays.TryGetValue(tick, out actions))
                {
                    foreach (var act in actions)
                    {
                        act.Action(act);
                        if (act.Period > 0 && act.Timer != null)
                        {
                            act.Timeout = act.Period;
                            AddAction(act);
                        }
                    }
                    _delays.Remove(tick);
                }
                needRecalc = true;
            }
            if (_toAdd.Count > 0)
            {
                needRecalc = true;
                foreach (var add in _toAdd.DequeueAll())
                {
                    AddAction(add);
                }
            }
            if (needRecalc)
            {
                if (_delays.Count > 0)
                {
                    minTick = _delays.First().Key;
                }
                else
                {
                    minTick = 0;
                }
            }
        }
    }
}
