namespace Level.Other
{
    public interface IHittable
    {
        IHitListener HitListener { get; }
    }
}