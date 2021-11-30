using System.Collections.Generic;

namespace Level.Other
{
    public interface IObjectPoolView : IObjectPool<IObjectPoolElementView>, ICollidable
    {
        void Initialize(IObjectPoolModel objectPoolModel);
        void UpdateView(IObjectPoolModel objectPoolModel);
        List<IObjectPoolElementView> Elements { get; }
    }
}