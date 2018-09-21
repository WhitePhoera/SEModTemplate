#line 2
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using VRage.Game.ModAPI;
using VRage.Game.ModAPI.Interfaces;
using VRage.Utils;
using VRageMath;

namespace Phoera.Framework
{
    public class HitInfo
    {
        public object Target { get; }
        public Vector3D Position { get; }
        public Vector3D Normal { get; }
        public HitInfo(object target, Vector3D position)
        {
            Target = target;
            Position = position;
        }
        public bool? ApplyDamageBeam(ref float damage, MyStringHash damageType, long attackerId = 0)
        {
            var des = Target as IMyDestroyableObject;
            var dmg = damage;
            if (des != null)
            {
                damage = Math.Max(damage - des.Integrity, 0);
                return des.ApplyDamage(dmg, damageType, Position, attackerId);
            }
            var grid = Target as MyCubeGrid;
            if (grid != null && grid.BlocksDestructionEnabled)
            {
                var block = grid.GetTargetedBlock(Position) as IMySlimBlock;
                if (block != null)
                {
                    damage = Math.Max(damage - block.Integrity, 0);
                    var res = block.ApplyDamage(dmg, damageType, Position, attackerId);
                    if ((block.FatBlock != null) || res)
                        (grid as IMyCubeGrid).ApplyDestructionDeformation(block);
                    return res;
                }
            }
            return null;
        }
        public bool? ApplyDamage(float damage, MyStringHash damageType, long attackerId = 0)
        {
            return ApplyDamageBeam(ref damage, damageType, attackerId);
        }
        public HitInfo<N> As<N>() where N : class
        {
            var target = Target as N;
            if (target != null)
                return new HitInfo<N>(target, Position);
            return null;
        }
        public bool Is<N>() where N : class
        {
            return Target is N;
        }
        public static IComparer<HitInfo> GetComparer(ref Vector3D start)
        {
            return new Comparer(start);
        }
        public static IComparer<HitInfo> GetComparer(Vector3D start)
        {
            return GetComparer(ref start);
        }
        class Comparer : IComparer<HitInfo>
        {
            private Vector3D _start;

            public Comparer(Vector3D start)
            {
                _start = start;
            }

            public int Compare(HitInfo x, HitInfo y)
            {
                double xd = Vector3D.DistanceSquared(_start, x.Position);
                double yd = Vector3D.DistanceSquared(_start, y.Position);
                return xd.CompareTo(yd);
            }
        }
        public override string ToString()
        {
            return $"{Position}:{Target}";
        }
    }
    public class HitInfo<T> : HitInfo where T : class
    {
        public new T Target { get; }

        public HitInfo(T target, Vector3D position) : base(target, position)
        {
            Target = target;
        }
        public static new IComparer<HitInfo<T>> GetComparer(ref Vector3D start)
        {
            return new Comparer<T>(start);
        }
        public static new IComparer<HitInfo<T>> GetComparer(Vector3D start)
        {
            return GetComparer(ref start);
        }
        class Comparer<TC> : IComparer<HitInfo<TC>> where TC : class
        {
            private Vector3D _start;

            public Comparer(Vector3D start)
            {
                _start = start;
            }

            public int Compare(HitInfo<TC> x, HitInfo<TC> y)
            {
                double xd = Vector3D.DistanceSquared(_start, x.Position);
                double yd = Vector3D.DistanceSquared(_start, y.Position);
                return xd.CompareTo(yd);
            }
        }
    }
}
