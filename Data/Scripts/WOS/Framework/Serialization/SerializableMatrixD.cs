#line 2
using ProtoBuf;
using VRageMath;

namespace Phoera.Framework.Serialization
{
    [ProtoContract]
    public struct SerializableMatrixD
    {
        [ProtoMember(1)]
        public double M11;
        [ProtoMember(2)]
        public double M12;
        [ProtoMember(3)]
        public double M13;
        [ProtoMember(4)]
        public double M14;
        [ProtoMember(5)]
        public double M21;
        [ProtoMember(6)]
        public double M22;
        [ProtoMember(7)]
        public double M23;
        [ProtoMember(8)]
        public double M24;
        [ProtoMember(9)]
        public double M31;
        [ProtoMember(10)]
        public double M32;
        [ProtoMember(11)]
        public double M33;
        [ProtoMember(12)]
        public double M34;
        [ProtoMember(13)]
        public double M41;
        [ProtoMember(14)]
        public double M42;
        [ProtoMember(15)]
        public double M43;
        [ProtoMember(16)]
        public double M44;

        public SerializableMatrixD(ref MatrixD matrix)
        {
            M11 = matrix.M11;
            M12 = matrix.M12;
            M13 = matrix.M13;
            M14 = matrix.M14;
            M21 = matrix.M21;
            M22 = matrix.M22;
            M23 = matrix.M23;
            M24 = matrix.M24;
            M31 = matrix.M31;
            M32 = matrix.M32;
            M33 = matrix.M33;
            M34 = matrix.M34;
            M41 = matrix.M41;
            M42 = matrix.M42;
            M43 = matrix.M43;
            M44 = matrix.M44;
        }
        public SerializableMatrixD(MatrixD matrix) : this(ref matrix)
        {

        }
        public MatrixD GetMatrix()
        {
            return new MatrixD(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }
        public void GetMatrix(out MatrixD result)
        {
            result = new MatrixD(M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }
    }
}
