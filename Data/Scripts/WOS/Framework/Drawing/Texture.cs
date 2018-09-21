#line 2
using Sandbox.ModAPI;
using System;
using VRage.Game;
using VRage.Utils;
using VRageMath;
using VRage.ModAPI;

namespace Phoera.Framework.Drawing
{
    public abstract class Texture
    {
        public abstract void DrawFullRect(ref Vector4 color, ref Vector3D position, ref MatrixD matrix, float width, float height);
        public abstract void DrawPie(ref Vector3D position, ref MatrixD matrix, float width, float height, double start, double end);

        protected const double localEps = 1e-3;
        protected const double Pi2 = Math.PI * 2;
        protected const double Pi_4 = Math.PI / 4;
        protected const double Pi_2 = Math.PI / 2;
        protected readonly Vector2 centerUv = new Vector2(0.5f);
    }
}
