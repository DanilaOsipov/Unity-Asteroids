namespace Level.Other
{
    public interface IObjectPool
    {
        ObjectPoolElementType ElementType { get; }
        void Add(IObjectPoolElement element);
    }
}