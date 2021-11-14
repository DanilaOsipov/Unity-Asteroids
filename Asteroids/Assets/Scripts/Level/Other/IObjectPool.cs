namespace Level.Other
{
    public interface IObjectPool<TElement> where TElement : IObjectPoolElement 
    {
        ObjectPoolElementType ElementType { get; }
        void Add(TElement element);
    }
}