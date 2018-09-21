#line 2
using Sandbox.ModAPI;
using System.Collections.Generic;
using VRageMath;

namespace Phoera.Framework.Utils
{
    public class AABBTree<T> where T : class
    {
        MyDynamicAABBTreeD tree = new MyDynamicAABBTreeD(Vector3D.Zero);
        Dictionary<T, int> indexes = new Dictionary<T, int>();
        public class AABBKeeper
        {
            public BoundingBoxD Box;
        }
        Dictionary<int, AABBKeeper> boxes = new Dictionary<int, AABBKeeper>();

        public int Count
        {
            get
            {
                return indexes.Count;
            }
        }

        public void Add(BoundingBoxD box, T obj, uint flags = 0)
        {
            Add(ref box, obj, flags);
        }
        public void Add(ref BoundingBoxD box, T obj, uint flags = 0)
        {
            boxes[indexes[obj] = tree.AddProxy(ref box, obj, flags)] = new AABBKeeper() { Box = box };
        }
        public void UpdatePosition(BoundingBoxD box, T obj)
        {
            UpdatePosition(ref box, obj);
        }
        public void UpdatePosition(ref BoundingBoxD box, T obj)
        {
            int index;
            if (indexes.TryGetValue(obj, out index))
            {
                tree.MoveProxy(index, ref box, Vector3D.Zero);
                boxes[index].Box = box;
            }
        }
        public void Remove(T obj)
        {
            int index;
            if (indexes.TryGetValue(obj, out index))
            {
                tree.RemoveProxy(index);
                indexes.Remove(obj);
                boxes.Remove(index);
            }
        }
        public bool IsVisible(T obj)
        {
            int index;
            if (indexes.TryGetValue(obj, out index))
            {
                return MyAPIGateway.Session.Camera.IsInFrustum(ref boxes[index].Box);
            }
            return false;
        }
        public void GetAllInSphere(List<T> result, ref BoundingSphereD sphere, uint flags = 0)
        {
            var box = BoundingBoxD.CreateFromSphere(sphere);
            GetAllInBox(result, ref box, flags);
        }
        public void GetAllInBox(List<T> result, ref BoundingBoxD box, uint flags = 0)
        {
            tree.OverlapAllBoundingBox(ref box, result, flags, false);
        }
        public void GetAllInFrustum(List<T> result, ref BoundingFrustumD frustum, uint flags = 0)
        {
            tree.OverlapAllFrustum(ref frustum, result, flags, false);
        }
        public void GetAllAlongLine(List<MyLineSegmentOverlapResult<T>> result, ref LineD line, uint flags = 0)
        {
            tree.OverlapAllLineSegment(ref line, result, flags, false);
        }
    }
}
