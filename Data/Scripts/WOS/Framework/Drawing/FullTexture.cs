#line 2
using Sandbox.ModAPI;
using System;
using VRage.Game;
using VRage.Utils;
using VRageMath;
using VRage.ModAPI;

namespace Phoera.Framework.Drawing
{
    public class FullTexture : Texture
    {
        public MyStringId Material { get; }

        public FullTexture(MyStringId material)
        {
            Material = material;
        }

        public override void DrawFullRect(ref Vector4 color, ref Vector3D position, ref MatrixD matrix, float width, float height)
        {
            MyTransparentGeometry.AddBillboardOriented(Material, color, position, matrix.Left, matrix.Up, width, height);
        }
        //Thanks to Equinox
        public override void DrawPie(ref Vector3D position, ref MatrixD matrix, float width, float height, double start, double end)
        {
            if (start < 0 || end > Pi2 || Math.Abs(start - end) < double.Epsilon)
                return;
            if (start > end)
            {
                DrawPie(ref position, ref matrix, width, height, start, Pi2);
                DrawPie(ref position, ref matrix, width, height, 0, end);
            }


            var pTheta = start;
            var pPosL = new Vector2((float)Math.Sin(pTheta), (float)-Math.Cos(pTheta));
            pPosL /= Math.Max(Math.Abs(pPosL.X), Math.Abs(pPosL.Y));
            var pPosLd = new Vector2(pPosL.X / 2 + 0.5f, pPosL.Y / 2 + 0.5f);
            var cPosL = new Vector2(0, 0);
            var cPosLd = new Vector2(0.5f, 0.5f);
            Vector3 normal = matrix.Backward;
            float hw = width / 2;
            float hh = height / 2;
            Vector3D right = matrix.Right * hw;
            Vector3D up = matrix.Up * hh;
            while (pTheta + localEps < end)
            {
                var nextCorner = Math.Ceiling((pTheta - Pi_4) / Pi_2 + localEps);
                var arcNext = Pi_4 + (Pi_2 * nextCorner);
                var nTheta = Math.Min(arcNext, end);
                var nPosL = new Vector2((float)Math.Sin(nTheta), (float)-Math.Cos(nTheta));
                nPosL /= Math.Max(Math.Abs(nPosL.X), Math.Abs(nPosL.Y));
                var nPosLd = new Vector2(nPosL.X / 2 + 0.5f, nPosL.Y / 2 + 0.5f);
                Vector3D p1 = position + right * cPosL.X + up * cPosL.Y;
                Vector3D p2 = position + right * pPosL.X + up * pPosL.Y;
                Vector3D p3 = position + right * nPosL.X + up * nPosL.Y;
                MyTransparentGeometry.AddTriangleBillboard(p1, p2, p3, normal, normal, normal, cPosLd, pPosLd, nPosLd, Material, 0, position, transparent);
                pTheta = nTheta;
                pPosL = nPosL;
                pPosLd = nPosLd;
            }
        }
        static readonly Vector4 transparent = new Vector4(0, 0, 0, 0);
    }
}
