#line 2
using Sandbox.ModAPI;
using System;
using VRage.Game;
using VRage.Utils;
using VRageMath;
using VRage.ModAPI;

namespace Phoera.Framework.Drawing
{

    public class ScreenDrawer
    {
        private Vector3D _leftTop;
        private Vector3D _leftBottom;
        private Vector3D _rightTop;
        private Vector3D _leftToRight;
        private Vector3D _topToBottom;
        private Vector3D _origin;
        private IMyCamera _camera;
        private MatrixD _matrix;
        private MatrixD ViewProjectionMatrix;

        public void Prepare()
        {
            var vs = MyAPIGateway.Session.Camera.ViewportSize;
            _leftTop = MyAPIGateway.Session.Camera.WorldLineFromScreen(Vector2.Zero).GetPoint(0.01);
            _leftBottom = MyAPIGateway.Session.Camera.WorldLineFromScreen(new Vector2(0, vs.Y - 1)).GetPoint(0.01);
            _rightTop = MyAPIGateway.Session.Camera.WorldLineFromScreen(new Vector2(vs.X - 1, 0)).GetPoint(0.01);
            _leftToRight = _rightTop - _leftTop;
            _topToBottom = _leftBottom - _leftTop;
            _origin = MyAPIGateway.Session.Camera.Position;
            _camera = MyAPIGateway.Session.Camera;
            _matrix = _camera.WorldMatrix;
            ViewProjectionMatrix = _camera.ViewMatrix * _camera.ProjectionMatrix;
        }
        void CalculateWorldPoint(ref Vector2D point, out Vector3D result)
        {
            result = _leftTop + (_leftToRight * point.X) + (_topToBottom * point.Y);
        }
        //Thanks to Equinox
        void CalculateScreenPoint(ref Vector3D worldPos, out Vector2D result)
        {
            var clip = Vector4D.Transform(new Vector4D(worldPos, 1), ViewProjectionMatrix);
            var ndc = clip / clip.W;
            result = new Vector2D(ndc.X + 1, 1 - ndc.Y) / 2.0;
        }
        void CalculateNormal(ref Vector3D point, out Vector3D normal)
        {
            var pnt = point - _origin;
            Vector3D.Normalize(ref pnt, out normal);
        }
        public void DrawScreenRect(Vector2D leftTop, Vector2D rightTop, Texture texture, Vector4 color)
        {

        }
        public void DrawWorldRect(Vector3D position, double size, Texture material, Vector4 color, double min = 0, double max = double.MaxValue)
        {
            Vector2D center;
            CalculateScreenPoint(ref position, out center);
            var left = (Vector3D.Normalize(_matrix.Left) * size) + position;
            Vector2D leftS;
            CalculateScreenPoint(ref left, out leftS);
            leftS.Y = center.Y;
            leftS.X = center.X - Math.Max(min / 2, Math.Min(Math.Abs(leftS.X - center.X), max / 2)) ;
            CalculateWorldPoint(ref center, out position);
            CalculateWorldPoint(ref leftS, out left);
            Vector3D.Distance(ref position, ref left, out size);
            float ss = (float)size;
            material.DrawFullRect(ref color, ref position, ref _matrix, ss, ss);
        }
        public void DrawScreenRectW(Vector3D position, double size, Texture material, Vector4 color)
        {
            Vector2D center;
            CalculateScreenPoint(ref position, out center);
            var left = (Vector3D.Normalize(_matrix.Left) * size) + position;
            Vector2D leftS;
            leftS.Y = center.Y;
            leftS.X = center.X - (size / 2);
            CalculateWorldPoint(ref center, out position);
            CalculateWorldPoint(ref leftS, out left);
            Vector3D.Distance(ref position, ref left, out size);
            float ss = (float)size;
            material.DrawFullRect(ref color, ref position, ref _matrix, ss, ss);
        }
        public void DrawScreenRectPieW(Vector3D position, double size, Texture material, double start, double end)
        {
            Vector2D center;
            CalculateScreenPoint(ref position, out center);
            var left = (Vector3D.Normalize(_matrix.Left) * size) + position;
            Vector2D leftS;
            leftS.Y = center.Y;
            leftS.X = center.X - (size / 2);
            CalculateWorldPoint(ref center, out position);
            CalculateWorldPoint(ref leftS, out left);
            Vector3D.Distance(ref position, ref left, out size);
            float ss = (float)size;
            material.DrawPie(ref position, ref _matrix, ss, ss, start, end);
        }
        public void DrawScreenRectH(Vector3D position, double size, Texture material, Vector4 color)
        {
            Vector2D center;
            CalculateScreenPoint(ref position, out center);
            var left = (Vector3D.Normalize(_matrix.Left) * size) + position;
            Vector2D leftS;
            leftS.Y = center.Y - (size / 2);
            leftS.X = center.X;
            CalculateWorldPoint(ref center, out position);
            CalculateWorldPoint(ref leftS, out left);
            Vector3D.Distance(ref position, ref left, out size);
            float ss = (float)size;
            material.DrawFullRect(ref color, ref position, ref _matrix, ss, ss);
        }
    }
}
