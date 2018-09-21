#line 2


namespace Phoera.Framework.Interfaces
{
    public interface ITemporal
    {
        ulong LifeTime { get; }
        void Expired();
    }
}
