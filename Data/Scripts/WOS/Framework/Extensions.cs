#line 2
using Phoera.Framework.Utils;
using Phoera.Network;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.Game.ModAPI.Interfaces;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace Phoera.Framework
{
    public static class Extensions
    {
        #region Compression
        public static byte[]  Compress(this byte[] data)
        {
            return MyCompression.Compress(data);
        }
        public static byte[] Decompress(this byte[] data)
        {
            return MyCompression.Decompress(data);
        }
        #endregion
        #region Base64
        public static string ToBase64(this byte[] data)
        {
            return Convert.ToBase64String(data);
        }
        public static byte[] FromBase64(this string data)
        {
            return Convert.FromBase64String(data);
        }
        #endregion
        #region Arrays
        public static void SetAll<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = value;
        }
        public static IEnumerable<object> IterateArray(this Array array)
        {
            var ranks = new int[array.Rank];
            for (int i = 0; i < ranks.Length; i++)
                ranks[i] = array.GetLowerBound(i);
            while (ranks[0] <= array.GetUpperBound(0))
            {
                yield return array.GetValue(ranks);
                for (int i = ranks.Length - 1; i > 0; i--)
                {
                    ranks[i]++;
                    if (ranks[i] > array.GetUpperBound(i))
                    {
                        ranks[i - 1]++;
                        ranks[i] = array.GetLowerBound(i);
                    }
                    else
                        break;
                }
                if (ranks.Length == 1)
                    ranks[0]++;
            }
        }
        public static void IterateSetArray(this Array array, Func<object> factory)
        {
            var ranks = new int[array.Rank];
            for (int i = 0; i < ranks.Length; i++)
                ranks[i] = array.GetLowerBound(i);
            while (ranks[0] <= array.GetUpperBound(0))
            {
                array.SetValue(factory(), ranks);
                for (int i = ranks.Length - 1; i > 0; i--)
                {
                    ranks[i]++;
                    if (ranks[i] > array.GetUpperBound(i))
                    {
                        ranks[i - 1]++;
                        ranks[i] = array.GetLowerBound(i);
                    }
                    else
                        break;
                }
                if (ranks.Length == 1)
                    ranks[0]++;
            }
        }
        public static IEnumerable<T> IterateCircular<T>(this T[] arr, int start)
        {
            int len = arr.Length - 1;
            if (len < 0)
                yield break;
            start = start.SeqClamp(0, len);
            for (int i = arr.Length; i > 0; i--)
            {
                yield return arr[start++];
                start = start.SeqClamp(0, len);
            }
        }
        public static IEnumerable<int> IterateCircularIndexes<T>(this T[] arr, int start)
        {
            int len = arr.Length - 1;
            if (len < 0)
                yield break;
            start = start.SeqClamp(0, len);
            for (int i = arr.Length; i > 0; i--)
            {
                yield return start++;
                start = start.SeqClamp(0, len);
            }
        }
        #endregion
        #region Clamps
        public static double Clamp(this double value, double min = double.MinValue, double max = double.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public static double ClampAround(this double val, double end)
        {
            while (val >= end)
                val -= end;
            while (val < 0)
                val += end;
            return val;
        }
        public static double SeqClamp(this double value, double min = double.MinValue, double max = double.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return min;
            return value;
        }
        public static int Clamp(this int value, int min = int.MinValue, int max = int.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public static int SeqClamp(this int value, int min = int.MinValue, int max = int.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return min;
            return value;
        }
        public static long Clamp(this long value, long min = long.MinValue, long max = long.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public static long SeqClamp(this long value, long min = long.MinValue, long max = long.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return min;
            return value;
        }
        public static long ClampDec(this long value, ref bool needMoreDec, long min = long.MinValue)
        {
            if (value == min)
                return value;
            if (value == (min + 1))
                return value;
            needMoreDec = true;
            return value - 1;
        }
        public static ulong Clamp(this ulong value, ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
        public static ulong SeqClamp(this ulong value, ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
        {
            if (value < min)
                return min;
            if (value > max)
                return min;
            return value;
        }
        public static ulong ClampDec(this ulong value, ref bool needMoreDec, ulong min = ulong.MinValue)
        {
            if (value == min)
                return value;
            if (value == (min + 1))
                return value - 1;
            needMoreDec = true;
            return value - 1;
        }
        #endregion
        #region Math
        public static BoundingBoxD ToAABB(this IEnumerable<Vector3D> points)
        {
            Vector3D max = new Vector3D();
            Vector3D min = new Vector3D();
            bool first = true;
            foreach (var pnt in points)
            {
                if (first)
                {
                    first = false;
                    max = pnt;
                    min = pnt;
                }
                else
                {
                    var pn = pnt;
                    var pn2 = pnt;
                    Vector3D.MinMax(ref min, ref pn);
                    Vector3D.MinMax(ref pn2, ref max);
                }
            }
            return new BoundingBoxD(min, max);
        }
        public static ContainmentType ContainsAdv(this MyOrientedBoundingBoxD obb, BoundingFrustumD frust, HashSet<Vector3D> internalPoints)
        {
            bool noCorners;
            var ct = ContainsAdv(obb, frust, internalPoints, out noCorners);
            if (!noCorners)
            {
                var points = new HashSet<Vector3D>(internalPoints);
                var planes = new PlaneD[] { frust.Bottom, frust.Far, frust.Left, frust.Right, frust.Top, frust.Near };
                var lines = obb.GetLines().Where(l => internalPoints.Contains(l.From) || internalPoints.Contains(l.To)).Select(l => new { Line = l, LengthSquared = l.Length * l.Length }).ToArray();
                var intersects = new List<MyTuple<LineD, double, Vector3D>>();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (internalPoints.Contains(lines[i].Line.From) && internalPoints.Contains(lines[i].Line.To))
                    {
                        points.Add(lines[i].Line.From);
                        points.Add(lines[i].Line.To);
                        continue;
                    }
                    for (int j = 0; j < planes.Length; j++)
                    {
                        var line = lines[i];
                        if (internalPoints.Contains(line.Line.To))
                            line = new { Line = new LineD(line.Line.To, line.Line.From), LengthSquared = line.LengthSquared };
                        var ln = line.Line;
                        var res = planes[j].Intersection(ref ln.From, ref ln.Direction);
                        if (res.IsValid())
                        {
                            double len;
                            Vector3D.DistanceSquared(ref ln.From, ref res, out len);
                            if (len <= line.LengthSquared)
                            {
                                intersects.Add(MyTuple.Create(ln, len, res));
                            }
                        }
                    }
                }
                foreach (var pnt in intersects.GroupBy(k => k.Item1, LineDEqualityComparer.Instance).Select(k => k.OrderBy(x => x.Item2).First().Item3))
                    points.Add(pnt);
                internalPoints.Clear();
                foreach (var pnt in internalPoints)
                    internalPoints.Add(pnt);
            }
            return ct;
        }
        static ContainmentType ContainsAdv(this MyOrientedBoundingBoxD obb, BoundingFrustumD frust, HashSet<Vector3D> internalPoints, out bool noCorners)
        {
            var points = new Vector3D[8];
            obb.GetCorners(points, 0);
            int inside = 0;
            for (int i = 0; i < points.Length; i++)
                if (frust.Contains(points[i]) != ContainmentType.Disjoint)
                {
                    inside++;
                    internalPoints.Add(points[i]);
                }
            noCorners = false;
            switch (inside)
            {
                case (8):
                    return ContainmentType.Contains;
                default:
                    if (internalPoints.Count != 0 || frust.Contains(obb.GetAABB()) != ContainmentType.Disjoint)
                    {
                        noCorners = true;
                        var res = new HashSet<Vector3D>();
                        var lines = frust.GetLines();
                        for (int i = 0; i < lines.Length; i++)
                        {
                            var from = obb.Contains(ref lines[i].From);
                            var to = obb.Contains(ref lines[i].To);
                            if (from && to)
                            {
                                res.Add(lines[i].From);
                                res.Add(lines[i].To);
                            }
                            else if (from)
                            {
                                res.Add(lines[i].From);
                                res.Add(lines[i].GetPoint(obb.Intersects(ref lines[i]).Value));
                            }
                            else if (to)
                            {
                                res.Add(lines[i].To);
                                var back = lines[i].Reverse();
                                res.Add(back.GetPoint(obb.Intersects(ref back).Value));
                            }
                            else
                            {
                                var first = obb.Intersects(ref lines[i]);
                                var back = lines[i].Reverse();
                                var second = obb.Intersects(ref back);
                                if (first != null)
                                {
                                    res.Add(lines[i].GetPoint(first.Value));
                                }
                                if (second != null)
                                {
                                    res.Add(back.GetPoint(second.Value));
                                }
                            }
                        }
                        lines = obb.GetLines();
                        for (int i = 0; i < lines.Length; i++)
                        {
                            var from = frust.Contains(lines[i].From) != ContainmentType.Disjoint;
                            var to = frust.Contains(lines[i].To) != ContainmentType.Disjoint;
                            if (from && to)
                            {
                                res.Add(lines[i].From);
                                res.Add(lines[i].To);
                            }
                            else if (from)
                            {
                                res.Add(lines[i].From);
                                res.Add(lines[i].GetPoint(frust.Intersects(lines[i].ToRay()).Value));
                            }
                            else if (to)
                            {
                                res.Add(lines[i].To);
                                res.Add(lines[i].Reverse().GetPoint(frust.Intersects(lines[i].ToReversedRay()).Value));
                            }
                            else
                            {
                                var first = frust.Intersects(lines[i].ToRay());
                                var second = frust.Intersects(lines[i].ToReversedRay());
                                if (first != null)
                                {
                                    res.Add(lines[i].GetPoint(first.Value));
                                }
                                if (second != null)
                                {
                                    res.Add(lines[i].Reverse().GetPoint(second.Value));
                                }
                            }
                        }

                        foreach (var r in res)
                            internalPoints.Add(r);
                        if (internalPoints.Count > 0)
                            return ContainmentType.Intersects;
                    }
                    return ContainmentType.Disjoint;
            }
        }
        public static LineD Reverse(this LineD line)
        {
            return new LineD(line.To, line.From);
        }
        public static RayD ToRay(this LineD line)
        {
            return new RayD(line.From, line.Direction);
        }
        public static RayD ToReversedRay(this LineD line)
        {
            return new RayD(line.To, -line.Direction);
        }
        public static MyOrientedBoundingBoxD GetOBB(this IMySlimBlock block)
        {
            Quaternion quaternion = Quaternion.CreateFromForwardUp(
                block.CubeGrid.WorldMatrix.Forward,
                block.CubeGrid.WorldMatrix.Up);
            float blocksize = block.CubeGrid.GridSize;
            var def = block.BlockDefinition as MyCubeBlockDefinition;
            var halfExtents = new Vector3D(
                (def.Size.X + 1) * blocksize / 2,
                (def.Size.Y + 1) * blocksize / 2,
                (def.Size.Z + 1) * blocksize / 2);
            Vector3D center;
            MyTexts.Clear();
            block.ComputeWorldCenter(out center);
            return new MyOrientedBoundingBoxD(center, halfExtents, quaternion);
        }
        //Thanks to rexxar
        public static MyOrientedBoundingBoxD GetOBB(this IMyCubeGrid grid)
        {
            //quaternion to rotate the box
            Quaternion gridQuaternion = Quaternion.CreateFromForwardUp(
                grid.WorldMatrix.Forward,
                grid.WorldMatrix.Up);

            //get the width of blocks for this grid size
            float blocksize = grid.GridSize;

            //get the halfextents of the grid, then multiply by block size to get world halfextents
            //add one so the line sits on the outside edge of the block instead of the center
            var halfExtents = new Vector3D(
                (Math.Abs(grid.Max.X - grid.Min.X) + 1) * blocksize / 2,
                (Math.Abs(grid.Max.Y - grid.Min.Y) + 1) * blocksize / 2,
                (Math.Abs(grid.Max.Z - grid.Min.Z) + 1) * blocksize / 2);

            return new MyOrientedBoundingBoxD(grid.PositionComp.WorldAABB.Center, halfExtents, gridQuaternion);
        }
        public static MyOrientedBoundingBoxD GetOBB(this IMyCubeGrid grid, double add)
        {
            //quaternion to rotate the box
            Quaternion gridQuaternion = Quaternion.CreateFromForwardUp(
                grid.WorldMatrix.Forward,
                grid.WorldMatrix.Up);

            //get the width of blocks for this grid size
            float blocksize = grid.GridSize;

            //get the halfextents of the grid, then multiply by block size to get world halfextents
            //add one so the line sits on the outside edge of the block instead of the center
            var halfExtents = new Vector3D(
                ((Math.Abs(grid.Max.X - grid.Min.X) + 1) * blocksize / 2) + add,
                ((Math.Abs(grid.Max.Y - grid.Min.Y) + 1) * blocksize / 2) + add,
                ((Math.Abs(grid.Max.Z - grid.Min.Z) + 1) * blocksize / 2)) + add;

            return new MyOrientedBoundingBoxD(grid.PositionComp.WorldAABB.Center, halfExtents, gridQuaternion);
        }
        public static BoundingSphereD ToSphere(this MyOrientedBoundingBoxD obb)
        {
            var corners = new Vector3D[8];
            obb.GetCorners(corners, 0);
            double dist = Vector3D.Distance(corners[0], obb.Center);
            return new BoundingSphereD(obb.Center, dist);
        }
        public static BoundingSphereD ToSphere(this MyOrientedBoundingBoxD obb, double add)
        {
            var corners = new Vector3D[8];
            obb.GetCorners(corners, 0);
            double dist = Vector3D.Distance(corners[0], obb.Center);
            return new BoundingSphereD(obb.Center, dist + add);
        }
        public static Vector3D GetPoint(this LineD line, double value)
        {
            return line.From + line.Direction * value;
        }
        public static LineD[] GetLines(this MyOrientedBoundingBoxD obb)
        {
            var corners = new Vector3D[8];
            obb.GetCorners(corners, 0);
            var lines = new LineD[12];
            lines[0] = new LineD(corners[0], corners[1]);
            lines[1] = new LineD(corners[1], corners[2]);
            lines[2] = new LineD(corners[2], corners[3]);
            lines[3] = new LineD(corners[3], corners[0]);
            lines[4] = new LineD(corners[4], corners[5]);
            lines[5] = new LineD(corners[5], corners[6]);
            lines[6] = new LineD(corners[6], corners[7]);
            lines[7] = new LineD(corners[7], corners[4]);
            lines[8] = new LineD(corners[0], corners[4]);
            lines[9] = new LineD(corners[1], corners[5]);
            lines[10] = new LineD(corners[2], corners[6]);
            lines[11] = new LineD(corners[3], corners[7]);
            return lines;
        }
        public static LineD[] GetLines(this BoundingFrustumD frust)
        {
            var corners = new Vector3D[8];
            frust.GetCorners(corners);
            var lines = new LineD[12];
            lines[0] = new LineD(corners[0], corners[1]);
            lines[1] = new LineD(corners[1], corners[2]);
            lines[2] = new LineD(corners[2], corners[3]);
            lines[3] = new LineD(corners[3], corners[0]);
            lines[4] = new LineD(corners[4], corners[5]);
            lines[5] = new LineD(corners[5], corners[6]);
            lines[6] = new LineD(corners[6], corners[7]);
            lines[7] = new LineD(corners[7], corners[4]);
            lines[8] = new LineD(corners[0], corners[4]);
            lines[9] = new LineD(corners[1], corners[5]);
            lines[10] = new LineD(corners[2], corners[6]);
            lines[11] = new LineD(corners[3], corners[7]);
            return lines;
        }
        public static BoundingBoxD ToAABB(this Vector3D origin, double size = 0)
        {
            if (Math.Abs(size) < double.Epsilon)
            {
                return new BoundingBoxD(origin, origin);
            }
            Vector3D len = new Vector3D(Math.Abs(size));
            return new BoundingBoxD(origin - len, origin + len);
        }
        #endregion
        #region Serialization
        public static T FromXML<T>(this string data)
        {
            return (MyAPIUtilities.Static as IMyUtilities).SerializeFromXML<T>(data);
        }

        public static string ToXML<T>(this T obj)
        {
            return (MyAPIUtilities.Static as IMyUtilities).SerializeToXML(obj);
        }
        public static T FromBinary<T>(this byte[] data)
        {
            return (MyAPIUtilities.Static as IMyUtilities).SerializeFromBinary<T>(data);
        }
        public static byte[] ToBinary<T>(this T obj)
        {
            return (MyAPIUtilities.Static as IMyUtilities).SerializeToBinary(obj);
        }
        #endregion
        #region Strings
        public static string GetLastChars(this string data, int count)
        {
            return data.Substring(Math.Max(0, data.Length - count));
        }
        public static bool IsMaskMatch(this string input, string mask)
        {
            return Regex.IsMatch(input, $"^{Regex.Escape(mask).Replace("\\*", ".*").Replace("\\?", ".")}$");
        }
        #endregion
        #region Queue
        public static IEnumerable<T> DequeueAll<T>(this ConcurrentQueue<T> queue)
        {
            T res;
            while (queue.TryDequeue(out res))
            {
                yield return res;
            }
        }
        #endregion
        #region Draw
        public static void Draw(this BoundingBoxD aabb, Color color, MySimpleObjectRasterizer raster = MySimpleObjectRasterizer.Solid, float thickness = 0.5f, MyStringId? material = null)
        {
            var box = new BoundingBoxD(-aabb.HalfExtents, aabb.HalfExtents);
            var wm = MatrixD.CreateWorld(aabb.Center);
            MySimpleObjectDraw.DrawTransparentBox(ref wm, ref box, ref color, raster, 1, thickness, material ?? Square, material ?? Square);
        }
        public static void Draw(this BoundingFrustumD frustum, Vector4 color, float thickness, MyStringId? material = null)
        {
            Draw(frustum.GetLines(), color, thickness, material);
        }
        public static void Draw(this IEnumerable<LineD> lines, Vector4 color, float thickness, MyStringId? material = null)
        {
            foreach (var line in lines)
                MyTransparentGeometry.AddLineBillboard(material ?? Square, color, line.From, line.Direction, (float)line.Length, thickness);
        }
        public static void Draw(this MyOrientedBoundingBoxD obb, Color color, MySimpleObjectRasterizer raster = MySimpleObjectRasterizer.Solid, float thickness = 0.5f, MyStringId? material = null)
        {
            var box = new BoundingBoxD(-obb.HalfExtent, obb.HalfExtent);
            var wm = MatrixD.CreateFromTransformScale(obb.Orientation, obb.Center, Vector3D.One);
            MySimpleObjectDraw.DrawTransparentBox(ref wm, ref box, ref color, raster, 1, thickness, material ?? Square, material ?? Square);
        }
        static VRage.Utils.MyStringId Square = VRage.Utils.MyStringId.GetOrCompute("Square");
        public static void Draw(this BoundingSphereD sphere, Color color, MySimpleObjectRasterizer rasterizer = MySimpleObjectRasterizer.Solid, int wire = 20, MyStringId? material = null)
        {
            var matrix = MatrixD.CreateWorld(sphere.Center);
            MySimpleObjectDraw.DrawTransparentSphere(ref matrix, (float)sphere.Radius, ref color, rasterizer, wire, material ?? Square, material ?? Square);
        }
        public static void Draw(this LineD line, Vector4 color, float thickness, MyStringId? material = null)
        {
            MyTransparentGeometry.AddLineBillboard(material ?? Square, color, line.From, line.Direction, (float)line.Length, thickness);
        }
        public static MatrixD DrawAsLine(this MatrixD matrix, double length, Vector4 color, float thickness, MyStringId? material = null)
        {
            MySimpleObjectDraw.DrawLine(matrix.Translation, matrix.Translation + (Vector3D.Normalize(matrix.Forward) * length), material ?? Square, ref color, thickness);
            return matrix;
        }
        public static MatrixD DrawAsSphere(this MatrixD matrix, float radius, Color color, MySimpleObjectRasterizer rasterizer = MySimpleObjectRasterizer.Solid, int wire = 20, MyStringId? material = null)
        {
            MySimpleObjectDraw.DrawTransparentSphere(ref matrix, (float)radius, ref color, rasterizer, wire, material ?? Square, material ?? Square);
            return matrix;
        }
        public static Vector3D DrawAsSphere(this Vector3D vector, float radius, Color color, MySimpleObjectRasterizer rasterizer = MySimpleObjectRasterizer.Solid, int wire = 20, MyStringId? material = null)
        {
            var matrix = MatrixD.CreateWorld(vector);
            MySimpleObjectDraw.DrawTransparentSphere(ref matrix, (float)radius, ref color, rasterizer, wire, material ?? Square, material ?? Square);
            return vector;
        }
        #endregion
        #region Raycast
        public static HitInfo<IMyEntity> Raycast(this IMyPhysics phy, ref LineD line)
        {
            IHitInfo hit;
            if (phy.CastRay(line.From, line.To, out hit))
                return new HitInfo<IMyEntity>(hit.HitEntity, hit.Position);
            return null;
        }
        static List<IHitInfo> tmpHits = new List<IHitInfo>();
        public static void RaycastAll(this IMyPhysics phy, ref LineD line, List<HitInfo<IMyEntity>> result)
        {
            phy.CastRay(line.From, line.To, tmpHits);
            result.Capacity = tmpHits.Count;
            result.AddRange(tmpHits.Select(h => new HitInfo<IMyEntity>(h.HitEntity, h.Position)));
            tmpHits.Clear();
        }
        #endregion
        #region IMyDestroyableObject
        public static bool ApplyDamage(this IMyDestroyableObject obj, float damage, MyStringHash damageType, Vector3D position, long attackerId = 0)
        {
            return obj.DoDamage(damage, damageType, NetworkHandlerSystem.IsServer, new MyHitInfo() { Position = position }, attackerId);
        }
        #endregion
        #region Notification and log
        public static T ShowNotification<T>(this T data, int time = 3000 / 60)
        {
            MyAPIGateway.Utilities.ShowNotification(data?.ToString() ?? "<null>", time);
            return data;
        }
        public static T Log<T>(this T data)
        {
            MyLog.Default.WriteLineAndConsole(data?.ToString() ?? "<null>");
            return data;
        }
        public static T Log<T>(this T data, bool flush)
        {
            MyLog.Default.WriteLineAndConsole(data?.ToString() ?? "<null>");
            if (flush)
                MyLog.Default.Flush();
            return data;
        }
        #endregion
        #region Iterators
        public static IEnumerable<Vector3I> IterateTo(this Vector3I start, Vector3I end)
        {
            Vector3I pos = new Vector3I();
            for (var it = new Vector3I_RangeIterator(ref start, ref end); it.IsValid(); it.GetNext(out pos))
            {
                yield return pos;
            }
        }
        #endregion
        #region Entity
        public static Vector3D GetInheritedVelocity(this IMyEntity entity, Vector3D position)
        {
            entity = entity.GetTopMostParent();
            if (entity.Physics != null)
            {
                return entity.Physics.GetVelocityAtPoint(position);
            }
            return Vector3D.Zero;
        }
        public static T EnsureComponent<T>(this IMyEntity entity) where T : MyEntityComponentBase, new()
        {
            return EnsureComponent(entity, () => new T());
        }
        public static T EnsureComponent<T>(this IMyEntity entity, Func<T> factory) where T : MyEntityComponentBase
        {
            T res;
            if (entity.Components.TryGet(out res))
                return res;
            res = factory();
            if (res is MyGameLogicComponent)
            {
                if (entity.GameLogic?.GetAs<T>() == null)
                {
                    entity.AddGameLogic(res as MyGameLogicComponent);
                    (res as MyGameLogicComponent).Init((MyObjectBuilder_EntityBase)null);
                }
            }
            else
            {
                entity.Components.Add(res);
                res.Init(null);
            }
            return res;
        }
        public static void AddGameLogic(this IMyEntity entity, MyGameLogicComponent logic)
        {
            var comp = entity.GameLogic as MyCompositeGameLogicComponent;
            if (comp != null)
            {
                entity.GameLogic = MyCompositeGameLogicComponent.Create(new List<MyGameLogicComponent>(2) { comp, logic }, entity as MyEntity);
            }
            else if (entity.GameLogic != null)
            {
                entity.GameLogic = MyCompositeGameLogicComponent.Create(new List<MyGameLogicComponent>(2) { entity.GameLogic as MyGameLogicComponent, logic }, entity as MyEntity);
            }
            else
            {
                entity.GameLogic = logic;
            }
        }
        #endregion
        #region Directions
        public static MatrixD GetRotated(this MatrixD matrix, Base6Directions.Direction direction)
        {
            switch (direction)
            {
                case Base6Directions.Direction.Backward:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Backward, matrix.Up);
                case Base6Directions.Direction.Left:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Left, matrix.Up);
                case Base6Directions.Direction.Right:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Right, matrix.Up);
                case Base6Directions.Direction.Up:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Up, matrix.Backward);
                case Base6Directions.Direction.Down:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Down, matrix.Forward);
                default:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Forward, matrix.Up);
            }
        }
        public static MatrixD GetRotated(this MatrixD matrix, Base27Directions.Direction direction)
        {
            switch (direction)
            {
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Left):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Forward + matrix.Left),
                        Vector3D.Normalize(matrix.Up));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Right):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Forward + matrix.Right),
                        Vector3D.Normalize(matrix.Up));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Forward + matrix.Up),
                        Vector3D.Normalize(matrix.Left));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Forward + matrix.Down),
                        Vector3D.Normalize(matrix.Left));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Left | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Forward + matrix.Left + matrix.Up),
                        Vector3D.Normalize(matrix.Backward + matrix.Right + matrix.Up));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Left | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Forward + matrix.Left + matrix.Down),
                        Vector3D.Normalize(matrix.Forward + matrix.Left + matrix.Up));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Right | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Forward + matrix.Right + matrix.Up),
                        Vector3D.Normalize(matrix.Backward + matrix.Left + matrix.Up));
                case (Base27Directions.Direction.Forward | Base27Directions.Direction.Right | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Forward + matrix.Right + matrix.Down),
                        Vector3D.Normalize(matrix.Forward + matrix.Right + matrix.Up));
                case (Base27Directions.Direction.Backward):
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Backward, matrix.Up);
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Left):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Backward + matrix.Left),
                        Vector3D.Normalize(matrix.Up));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Right):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Backward + matrix.Right),
                        Vector3D.Normalize(matrix.Up));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Backward + matrix.Up),
                        Vector3D.Normalize(matrix.Right));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Backward + matrix.Down),
                        Vector3D.Normalize(matrix.Right));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Left | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Backward + matrix.Left + matrix.Up),
                        Vector3D.Normalize(matrix.Forward + matrix.Right + matrix.Up));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Left | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Backward + matrix.Left + matrix.Down),
                        Vector3D.Normalize(matrix.Backward + matrix.Left + matrix.Up));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Right | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Backward + matrix.Right + matrix.Up),
                        Vector3D.Normalize(matrix.Forward + matrix.Left + matrix.Up));
                case (Base27Directions.Direction.Backward | Base27Directions.Direction.Right | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Backward + matrix.Right + matrix.Down),
                        Vector3D.Normalize(matrix.Backward + matrix.Right + matrix.Up));
                case (Base27Directions.Direction.Left):
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Left, matrix.Up);
                case (Base27Directions.Direction.Left | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                        Vector3D.Normalize(matrix.Up + matrix.Left),
                        Vector3D.Normalize(matrix.Forward));
                case (Base27Directions.Direction.Left | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Down + matrix.Left),
                        Vector3D.Normalize(matrix.Forward));
                case (Base27Directions.Direction.Right):
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Right, matrix.Up);
                case (Base27Directions.Direction.Right | Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Up + matrix.Right),
                        Vector3D.Normalize(matrix.Backward));
                case (Base27Directions.Direction.Right | Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation,
                    Vector3D.Normalize(matrix.Down + matrix.Right),
                        Vector3D.Normalize(matrix.Backward));
                case (Base27Directions.Direction.Up):
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Up, matrix.Backward);
                case (Base27Directions.Direction.Down):
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Down, matrix.Forward);
                default:
                    return MatrixD.CreateWorld(matrix.Translation, matrix.Forward, matrix.Up);
            }
        }
        public static MatrixD GetRotated(this MatrixD matrix, Vector3 direction)
        {
            return MatrixD.CreateWorld(matrix.Translation, Vector3.Normalize((direction.X * matrix.Right) + (direction.Y * matrix.Up) + (direction.Z * matrix.Forward)), Vector3.Up);
        }
        #endregion
        #region Subparts/Dummies
        const string subpartDelimiter = ".";
        public static SubpartWrapper FindSubpart(this IMyEntity entity, string query)
        {
            return entity.GetAllSubparts().FirstOrDefault(s => Regex.IsMatch(s.SearchExpression, $"^{query}$"));
        }
        public static IEnumerable<SubpartWrapper> FindSubparts(this IMyEntity entity, string query)
        {
            return entity.GetAllSubparts().Where(s => Regex.IsMatch(s.SearchExpression, $"^{query}$"));
        }
        public static IEnumerable<DummyWrapper> GetAllDummies(this IMyEntity entity)
        {
            foreach (var sub in entity.GetAllSubparts())
            {
                foreach (var dum in sub.Dummies)
                {
                    yield return dum.Value;
                }
            }
        }
        public static IEnumerable<SubpartWrapper> GetAllSubparts(this IMyEntity entity)
        {
            return GetAllSubparts(entity as MyEntity);
        }
        static IEnumerable<SubpartWrapper> GetAllSubparts(this MyEntity entity)
        {
            yield return new SubpartWrapper() { Subpart = entity, Name = "root", SearchExpression = "root", Origin = (entity as IMyEntity).LocalMatrix };
            foreach (var sub in entity.Subparts)
            {
                foreach (var wrap in GetAllSubparts(sub.Value, entity, sub.Key, "root"))
                    yield return wrap;
            }
        }
        static IEnumerable<SubpartWrapper> GetAllSubparts(MyEntity entity, MyEntity parent, string name, string expression)
        {
            if (expression != null)
                expression = expression + subpartDelimiter + name;
            else
                expression = name;
            yield return new SubpartWrapper() { Parent = parent, Subpart = entity, SearchExpression = expression, Name = name, Origin = (entity as IMyEntity).LocalMatrix };
            foreach (var sub in entity.Subparts)
            {
                foreach (var wrap in GetAllSubparts(sub.Value, entity, sub.Key, expression))
                    yield return wrap;
            }
        }

        #endregion
        #region Lerp
        public static Color LerpTo(this Color start, Color end, double slider)
        {
            slider = Math.Min(1, Math.Max(0, slider));
            return Color.Lerp(start, end, (float)slider);
        }
        #endregion
        #region Grid Work
        public static HashSet<IMyEntity> CalculateAntennaRecievers(this IMyRadioAntenna antenna, bool allowEnemy)
        {
            var tmp = new HashSet<IMyEntity>();
            var result = new HashSet<IMyEntity>();
            antenna.CalculateAntennaRecievers(antenna, tmp, result, allowEnemy);
            return result;
        }
        static void CalculateAntennaRecievers(this IMyRadioAntenna antenna, IMyRadioAntenna source, HashSet<IMyEntity> alreadyChecked, HashSet<IMyEntity> result, bool allowEnemy)
        {

            if (!antenna.IsWorking || !antenna.IsBroadcasting)
                return;
            var sp = new BoundingSphereD(antenna.GetPosition(), antenna.Radius);
            var entities = MyAPIGateway.Entities.GetEntitiesInSphere(ref sp);
            var lst = new List<IMySlimBlock>();
            foreach (var ent in entities)
            {
                if (!alreadyChecked.Add(ent))
                    continue; ;
                if (ent is IMyCharacter)
                {
                    if (!allowEnemy)
                    {
                        var pl = MyAPIGateway.Players.GetPlayerControllingEntity(ent);
                        if (pl != null && source.GetUserRelationToOwner(pl.IdentityId) != MyRelationsBetweenPlayerAndBlock.Enemies)
                            result.Add(ent);
                    }
                    else
                        result.Add(ent);
                }
                else
                {
                    var grid = ent as IMyCubeGrid;
                    if (grid != null)
                    {
                        lst.Clear();
                        grid.GetBlocks(lst, b => b.FatBlock is IMyRadioAntenna);
                        foreach (var ant in lst.Select(c => c.FatBlock as IMyRadioAntenna))
                        {
                            ant.CalculateAntennaRecievers(source, alreadyChecked, result, allowEnemy);
                        }
                    }
                }
            }
        }
        public static Dictionary<MyDefinitionId, int> CalculateBlockCost(this IMyCubeGrid grid)
        {
            var res = new Dictionary<MyDefinitionId, int>(MyDefinitionId.Comparer);
            grid.GetBlocks(new List<IMySlimBlock>(), b =>
            {
                foreach (var comp in (b.BlockDefinition as MyCubeBlockDefinition).Components)
                {
                    var id = comp.Definition.Id;
                    int count = 0;
                    if (res.TryGetValue(id, out count))
                        res[id] = count + comp.Count;
                    else
                        res[id] = comp.Count;
                }
                return false;
            });
            return res;
        }
        public static Dictionary<MyDefinitionId, int> CalculateCost(this IMyCubeGrid grid)
        {
            var res = new Dictionary<MyDefinitionId, int>(MyDefinitionId.Comparer);
            grid.GetBlocks(new List<IMySlimBlock>(), b =>
            {
                foreach (var comp in (b.BlockDefinition as MyCubeBlockDefinition).Components.Select(s => s.Definition.Id).Distinct(MyDefinitionId.Comparer))
                {
                    int cnt = b.GetConstructionStockpileItemAmount(comp);
                    int count = 0;
                    if (res.TryGetValue(comp, out count))
                        res[comp] = count + cnt;
                    else
                        res[comp] = cnt;
                }
                return false;
            });
            return res;
        }
        public static Dictionary<MyDefinitionId, int> CalculateRepairCost(this IMyCubeGrid grid)
        {
            var res = new Dictionary<MyDefinitionId, int>(MyDefinitionId.Comparer);
            var miss = new Dictionary<string, int>();
            var cmpOB = new MyObjectBuilderType(typeof(MyComponentDefinition));
            grid.GetBlocks(new List<IMySlimBlock>(), b =>
            {
                miss.Clear();
                b.GetMissingComponents(miss);
                foreach (var comp in miss)
                {
                    var id = new MyDefinitionId(cmpOB, comp.Key);
                    int count = 0;
                    if (res.TryGetValue(id, out count))
                        res[id] = count + comp.Value;
                    else
                        res[id] = comp.Value;
                }
                return false;
            });
            return res;
        }
        #endregion

    }
}

