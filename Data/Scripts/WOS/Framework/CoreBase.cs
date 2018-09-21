#line 2

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Phoera.Framework.Drawing;
using Phoera.Framework.Interfaces;
using Phoera.Framework.Utils;
using Phoera.Network;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRageMath;

/// <summary>
/// This file not public, you cannot copy it or use it parts without my permission.
/// Copyright - Phoera - 2016
/// </summary>
namespace Phoera.Framework
{
    //TODO: add identity and global vars persistance and easy custom serializers(to file)
    public abstract class CoreBase : MySessionComponentBase
    {
        public static CoreBase Instance { get; private set; }
        private bool _initialized = false;
        private HashSet<IBeforeUpdatable> _toBeforeUpdate = new HashSet<IBeforeUpdatable>();
        private HashSet<IScreenDrawable> _toDrawScreen = new HashSet<IScreenDrawable>();
        private HashSet<IAfterUpdatable> _toAfterUpdate = new HashSet<IAfterUpdatable>();
        private HashSet<ISimulatable> _toSimulate = new HashSet<ISimulatable>();
        private HashSet<IComponent> _disposables = new HashSet<IComponent>();
        private HashSet<ISaveable> _saveables = new HashSet<ISaveable>();
        private AABBTree<IDrawable> _toDraw = new AABBTree<IDrawable>();

        public bool InInitialization { get; private set; } = false;

        public abstract void Deinitialize();

        protected CoreBase()
        {
            Instance = this;
            saveType = GetType();
            timer.ActionRemoved += Timer_ActionRemoved;
        }

        private void Timer_ActionRemoved()
        {
            if (timer.ActiveCount == 0)
                RequestOrderChange();
        }
        public NetworkHandlerSystem Network { get { return lazyNetwork.Value; } }
        Utils.Lazy<NetworkHandlerSystem> lazyNetwork = new Utils.Lazy<NetworkHandlerSystem>(() => Register(new NetworkHandlerSystem()));
        Utils.Lazy<StringHasher> lazyHasher = new Utils.Lazy<StringHasher>(() => new StringHasher());
        public StringHasher StringHasher { get { return lazyHasher.Value; } }

        private static Type saveType;
        private bool uoRequestActive = false;

        public abstract void Initialize();

        public override string ToString()
        {
            return "Phoera's Core " + base.ToString();
        }

        public override void BeforeStart()
        {
            if (!_initialized)
            {
                InInitialization = true;
                _realUpdateOrder = UpdateOrder;
                ModId = MyAPIGateway.Session.Mods.FirstOrDefault(m => m.Name == ModContext.ModName).PublishedFileId;
                if (ModId == 0)
                {
                    ModId = 1503;
                }
                Initialize();
                InInitialization = false;
                _initialized = true;
                foreach (var cmp in _disposables)
                    cmp.Init();
                visibilityRange = MyAPIGateway.Session.SessionSettings.ViewDistance;
                visibilityRangeSqr = visibilityRange * visibilityRange;
                _world = MyAPIGateway.Session.WorldBoundaries;
                Vector3D.MinMax(ref _world.Min, ref _world.Max);
                AfterInitialized();
            }
        }

        class Disposable2ComponentWrapper : IComponent
        {
            public readonly IDisposable Value;

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                    return true;
                var i = obj as Disposable2ComponentWrapper;
                if (i != null)
                    return i.Value == Value;
                return false;
            }

            public override int GetHashCode() => Value?.GetHashCode() ?? 0;

            public Disposable2ComponentWrapper(IDisposable value)
            {
                if (value != null)
                {
                    Value = value;
                }
                else
                {
                    throw new Exception(nameof(value));
                }
            }

            public void Dispose()
            {
                Value?.Dispose();
            }

            public void Init()
            {
            }
        }


        private List<object> forAdd = new List<object>();
        private List<object> forRemove = new List<object>();
        private bool haveAdd = false, haveRemove = false;

        public static T Register<T>(T obj) where T : class
        {
            Instance.forAdd.Add(obj);
            Instance.haveAdd = true;
            Instance.RequestOrderChange();
            return obj;
        }

        public static T UnregisterComponent<T>(T obj) where T : class
        {
            Instance.forRemove.Add(obj);
            Instance.haveRemove = true;
            Instance.RequestOrderChange();
            return obj;
        }

        private void HandleComponentChanges()
        {
            if (haveAdd)
            {
                foreach (var obj in forAdd)
                {
                    AddToLists(obj);
                }
                forAdd.Clear();
            }
            if (haveRemove)
            {
                foreach (var obj in forRemove)
                {
                    RemoveFromLists(obj);
                }
                forRemove.Clear();
            }
            if (haveAdd || haveRemove)
                RequestOrderChange();
            haveAdd = haveRemove = false;
        }

        protected void RequestOrderChange()
        {
            if (!uoRequestActive)
            {
                uoRequestActive = true;
                MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                {
                    ChangeOrderFromLists();
                    uoRequestActive = false;
                });
            }
        }

        public override MyObjectBuilder_SessionComponent GetObjectBuilder()
        {
            foreach (var sav in _saveables)
            {
                sav.Save();
            }
            return base.GetObjectBuilder();
        }

        protected void AddToLists<T>(T obj) where T : class
        {
            var col = obj as IComponentCollection;
            if (col != null && col.Components != null)
            {
                $"R:IComponentCollection:{obj}".Log(true);
                foreach (var comp in col.Components.Where(c => c != obj).Distinct())
                    AddToLists(comp);
            }
            var com = obj as IComponent;
            if (com != null)
            {
                $"R:IComponent:{obj}".Log(true);
                if (_disposables.Add(com))
                {
                    if (Initialized)
                    {
                        com.Init();
                    }
                }
            }
            else
            {
                var dis = obj as IDisposable;
                _disposables.Add(new Disposable2ComponentWrapper(dis));
            }
            var bef = obj as IBeforeUpdatable;
            if (bef != null)
            {
                $"R:IBeforeUpdatable:{obj}".Log(true);
                _toBeforeUpdate.Add(bef);
            }
            var sim = obj as ISimulatable;
            if (sim != null)
            {
                $"R:ISimulatable:{obj}".Log(true);
                _toSimulate.Add(sim);
            }
            var save = obj as ISaveable;
            if (save != null)
            {
                $"R:ISaveable:{obj}".Log(true);
                _saveables.Add(save);
            }
            var aft = obj as IAfterUpdatable;
            if (aft != null)
            {
                $"R:IAfterUpdatable:{obj}".Log(true);
                _toAfterUpdate.Add(aft);
            }
            var screen = obj as IScreenDrawable;
            if (screen != null)
            {
                $"R:IScreenDrawable:{obj}".Log(true);
                _toDrawScreen.Add(screen);
            }
            var draw = obj as IDrawable;
            if (draw != null)
            {
                $"R:IDrawable:{obj}".Log(true);
                draw.Init(_toDraw);
            }
            var tmp = obj as ITemporal;
            if (tmp != null)
            {
                $"R:ITemporal:{obj}".Log(true);
                timer.AddDelayedActionInTicks((t) =>
                {
                    RemoveFromLists(obj);
                    tmp.Expired();
                }, tmp.LifeTime);
            }
        }

        public IDisposable AddDelayedActionInTicks(Action<IDisposable> action, ulong timeout)
        {
            RequestOrderChange();
            return timer.AddDelayedActionInTicks(action, timeout);
        }

        public IDisposable AddRepeatableActionInTicks(Action<IDisposable> action, ulong timeout)
        {
            RequestOrderChange();
            return timer.AddRepeatableActionInTicks(action, timeout);
        }

        public IDisposable AddDelayedActionInSeconds(Action<IDisposable> action, double timeout)
        {
            RequestOrderChange();
            return timer.AddDelayedActionInSeconds(action, timeout);
        }

        public IDisposable AddRepeatableActionInSeconds(Action<IDisposable> action, double timeout)
        {
            RequestOrderChange();
            return timer.AddRepeatableActionInSeconds(action, timeout);
        }

        public IDisposable AddDelayedActionInTimeSpan(Action<IDisposable> action, TimeSpan timeout)
        {
            RequestOrderChange();
            return timer.AddDelayedActionInTimeSpan(action, timeout);
        }

        public IDisposable AddRepeatableActionInTimeSpan(Action<IDisposable> action, TimeSpan timeout)
        {
            RequestOrderChange();
            return timer.AddRepeatableActionInTimeSpan(action, timeout);
        }

        public override void Simulate()
        {
            foreach (var sim in _toSimulate)
                sim.Simulate();
            HandleComponentChanges();
        }

        public static bool IsComponent<T>(T obj) where T : class
        {
            return obj is IComponentCollection || obj is IBeforeUpdatable || obj is ISimulatable || obj is IScreenDrawable || obj is IAfterUpdatable || obj is IDrawable;
        }

        protected void RemoveFromLists<T>(T obj) where T : class
        {
            var col = obj as IComponentCollection;
            if (col != null && col.Components != null)
            {
                $"U:IComponentCollection:{obj}".Log(true);
                foreach (var comp in col.Components.Where(c => c != obj).Distinct())
                    RemoveFromLists(comp);
            }
            var upd = obj as IBeforeUpdatable;
            if (upd != null)
            {
                $"U:IBeforeUpdatable:{obj}".Log(true);
                _toBeforeUpdate.Remove(upd);
            }
            var sim = obj as ISimulatable;
            if (sim != null)
            {
                $"U:ISimulatable:{obj}".Log(true);
                _toSimulate.Remove(sim);
            }
            var screen = obj as IScreenDrawable;
            if (screen != null)
            {
                $"U:IScreenDrawable:{obj}".Log(true);
                _toDrawScreen.Remove(screen);
            }
            var aft = obj as IAfterUpdatable;
            if (aft != null)
            {
                $"U:IAfterUpdatable:{obj}".Log(true);
                _toAfterUpdate.Remove(aft);
            }
            var draw = obj as IDrawable;
            if (draw != null)
            {
                $"U:IDrawable:{obj}".Log(true);
                _toDraw.Remove(draw);
            }
        }

        private void ChangeOrderFromLists()
        {
            var uo = UpdateOrder;
            if (_toBeforeUpdate.Count > 0)
            {
                uo |= MyUpdateOrder.BeforeSimulation;
            }
            else
            {
                uo &= (~MyUpdateOrder.BeforeSimulation | (_realUpdateOrder & MyUpdateOrder.BeforeSimulation));
            }
            if (_toAfterUpdate.Count > 0 || timer.ActiveCount > 0)
            {
                uo |= MyUpdateOrder.AfterSimulation;
            }
            else
            {
                uo &= (~MyUpdateOrder.AfterSimulation | (_realUpdateOrder & MyUpdateOrder.AfterSimulation));
            }
            if (_toSimulate.Count > 0)
            {
                uo |= MyUpdateOrder.Simulation;
            }
            else
            {
                uo &= (~MyUpdateOrder.Simulation | (_realUpdateOrder & MyUpdateOrder.Simulation));
            }
            ChangeUpdateOrder(uo);
        }

        private MyUpdateOrder _realUpdateOrder;
        private TickTimer timer = new TickTimer();
        public ulong ModId { get; private set; }

        public override void UpdateBeforeSimulation()
        {
            if (!_initialized)
            {
                return;
            }
            foreach (var upd in _toBeforeUpdate)
                upd.UpdateBefore();
            HandleComponentChanges();
        }

        public static bool IsInCameraRange(Vector3D position)
        {
            return Vector3D.DistanceSquared(position, MyAPIGateway.Session.Camera.WorldMatrix.Translation) <= Instance.visibilityRangeSqr;
        }

        public BoundingBoxD WorldBox { get { return _world; } }

        public static ContainmentType WorldContains(Vector3D point)
        {
            return Instance._world.Contains(point);
        }

        public static bool WorldIntersects(LineD move)
        {
            ContainmentType ct;
            Instance._world.Contains(ref move.To, out ct);
            return ct != ContainmentType.Contains;
        }

        protected void ChangeUpdateOrder(MyUpdateOrder value)
        {
            if (value != UpdateOrder)
            {
                MyAPIGateway.Utilities.InvokeOnGameThread(() => SetUpdateOrder(value));
            }
        }

        private List<IDrawable> tmpToDraw = new List<IDrawable>();
        private HashSet<IDrawable> inRange = new HashSet<IDrawable>();
        private ScreenDrawer drawer = new ScreenDrawer();

        protected virtual void AfterInitialized()
        {
        }

        protected virtual void BeforeDeinitialized()
        {
        }

        public override void Draw()
        {
            if (!_initialized)
                return;
            if (NetworkHandlerSystem.IsClient && _toDraw.Count > 0)
            {
                tmpToDraw.Clear();
                var sp = new BoundingSphereD(MyAPIGateway.Session.Camera.Position, visibilityRange);
                _toDraw.GetAllInSphere(tmpToDraw, ref sp);
                var oldRange = inRange;
                inRange = new HashSet<IDrawable>();
                foreach (var draw in tmpToDraw)
                {
                    if (draw.NeedDraw && _toDraw.IsVisible(draw))
                    {
                        draw.Draw();
                    }
                    if (draw.NeedSphere)
                    {
                        inRange.Add(draw);
                        oldRange.Remove(draw);
                        draw.InSphere.Value = true;
                    }
                }
                foreach (var draw in oldRange)
                {
                    draw.InSphere.Value = false;
                }
                oldRange.Clear();
            }
            if (_toDrawScreen.Count > 0)
            {
                drawer.Prepare();
                foreach (var draw in _toDrawScreen)
                    draw.Draw(drawer);
            }
            HandleComponentChanges();
        }

        private float visibilityRange;
        private double visibilityRangeSqr;

        public static TextReader ReadFile(string file)
        {
            return MyAPIGateway.Utilities.ReadFileInWorldStorage(file, saveType);
        }

        public static TextWriter WriteFile(string file)
        {
            return MyAPIGateway.Utilities.WriteFileInWorldStorage(file, saveType);
        }

        private BoundingBoxD _world;

        //public override MyObjectBuilder_SessionComponent GetObjectBuilder()
        //{
        //    if (!_initialized)
        //        return null;
        //    return null;
        //}

        public override void UpdateAfterSimulation()
        {
            foreach (var update in _toAfterUpdate)
                update.UpdateAfter();
            timer.Tick();
            HandleComponentChanges();
        }

        protected override void UnloadData()
        {
            if (_initialized)
            {
                BeforeDeinitialized();
                foreach (var component in _disposables)
                {
                    try
                    {
                        component.Dispose();
                    }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
                    catch
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
                    {
                    }
                }
                Deinitialize();
                Instance = null;
            }
            _initialized = false;
        }
    }
}