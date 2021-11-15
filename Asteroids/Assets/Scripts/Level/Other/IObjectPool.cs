namespace Level.Other
{
    public interface IObjectPool<TElement> where TElement : IObjectPoolElement 
    {
        EntityType ElementType { get; }
        void Add(TElement element);
    }
}