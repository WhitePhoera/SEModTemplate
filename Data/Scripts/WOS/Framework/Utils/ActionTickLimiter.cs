#line 2
using System;

namespace Phoera.Framework.Utils
{
    public class ActionTickLimiter
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action _action;
        readonly ulong _allowedPeriod;

        public ActionTickLimiter(Action action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction()
        {
            if(_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction();
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _action();
            }
            else
            {
                _pendingExecute = true;
            }
        }
    }
    public class ActionTickLimiter<T1>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;

        public ActionTickLimiter(Action<T1> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _action(arg1);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;


        public ActionTickLimiter(Action<T1, T2> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _action(arg1, arg2);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;


        public ActionTickLimiter(Action<T1, T2, T3> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _action(arg1, arg2, arg3);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;


        public ActionTickLimiter(Action<T1, T2, T3, T4> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _action(arg1, arg2, arg3, arg4);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _action(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _action(arg1, arg2, arg3, arg4, arg5, arg6);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;
        T12 _savedArg12;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11, _savedArg12);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _savedArg12 = default(T12);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                    _savedArg12 = arg12;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;
        T12 _savedArg12;
        T13 _savedArg13;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11, _savedArg12, _savedArg13);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _savedArg12 = default(T12);
                _savedArg13 = default(T13);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                    _savedArg12 = arg12;
                    _savedArg13 = arg13;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;
        T12 _savedArg12;
        T13 _savedArg13;
        T14 _savedArg14;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11, _savedArg12, _savedArg13, _savedArg14);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _savedArg12 = default(T12);
                _savedArg13 = default(T13);
                _savedArg14 = default(T14);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                    _savedArg12 = arg12;
                    _savedArg13 = arg13;
                    _savedArg14 = arg14;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;
        T12 _savedArg12;
        T13 _savedArg13;
        T14 _savedArg14;
        T15 _savedArg15;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11, _savedArg12, _savedArg13, _savedArg14, _savedArg15);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _savedArg12 = default(T12);
                _savedArg13 = default(T13);
                _savedArg14 = default(T14);
                _savedArg15 = default(T15);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                    _savedArg12 = arg12;
                    _savedArg13 = arg13;
                    _savedArg14 = arg14;
                    _savedArg15 = arg15;
                }
            }
        }
    }
    public class ActionTickLimiter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        bool _canExecute = true;
        bool _pendingExecute = false;
        readonly bool _canHavePendingExecute = true;
        readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> _action;
        readonly ulong _allowedPeriod;
        T1 _savedArg1;
        T2 _savedArg2;
        T3 _savedArg3;
        T4 _savedArg4;
        T5 _savedArg5;
        T6 _savedArg6;
        T7 _savedArg7;
        T8 _savedArg8;
        T9 _savedArg9;
        T10 _savedArg10;
        T11 _savedArg11;
        T12 _savedArg12;
        T13 _savedArg13;
        T14 _savedArg14;
        T15 _savedArg15;
        T16 _savedArg16;


        public ActionTickLimiter(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action, ulong allowedPeriod, bool allowPending)
        {
            _allowedPeriod = allowedPeriod;
            _canHavePendingExecute = allowPending;
            _action = action;
        }

        public void DoAction(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            if (_canExecute)
            {
                _canExecute = false;
                if (_canHavePendingExecute)
                {
                    _pendingExecute = false;
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                        if (_pendingExecute)
                            DoAction(_savedArg1, _savedArg2, _savedArg3, _savedArg4, _savedArg5, _savedArg6, _savedArg7, _savedArg8, _savedArg9, _savedArg10, _savedArg11, _savedArg12, _savedArg13, _savedArg14, _savedArg15, _savedArg16);
                    }, _allowedPeriod);
                }
                else
                {
                    CoreBase.Instance.AddDelayedActionInTicks(c =>
                    {
                        _canExecute = true;
                    }, _allowedPeriod);
                }
                _savedArg1 = default(T1);
                _savedArg2 = default(T2);
                _savedArg3 = default(T3);
                _savedArg4 = default(T4);
                _savedArg5 = default(T5);
                _savedArg6 = default(T6);
                _savedArg7 = default(T7);
                _savedArg8 = default(T8);
                _savedArg9 = default(T9);
                _savedArg10 = default(T10);
                _savedArg11 = default(T11);
                _savedArg12 = default(T12);
                _savedArg13 = default(T13);
                _savedArg14 = default(T14);
                _savedArg15 = default(T15);
                _savedArg16 = default(T16);
                _action(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            }
            else
            {
                if (_canHavePendingExecute)
                {
                    _pendingExecute = true;
                    _savedArg1 = arg1;
                    _savedArg2 = arg2;
                    _savedArg3 = arg3;
                    _savedArg4 = arg4;
                    _savedArg5 = arg5;
                    _savedArg6 = arg6;
                    _savedArg7 = arg7;
                    _savedArg8 = arg8;
                    _savedArg9 = arg9;
                    _savedArg10 = arg10;
                    _savedArg11 = arg11;
                    _savedArg12 = arg12;
                    _savedArg13 = arg13;
                    _savedArg14 = arg14;
                    _savedArg15 = arg15;
                    _savedArg16 = arg16;
                }
            }
        }
    }

}
