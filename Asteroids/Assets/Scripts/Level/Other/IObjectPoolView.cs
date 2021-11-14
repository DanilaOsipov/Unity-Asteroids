using System.Collections.Generic;

namespace Level.Other
{
    public interface IObjectPoolView : IObjectPool<IObjectPoolElementView>
    {
        void UpdateView(IObjectPoolModel objectPoolModel);
        List<IObjectPoolElementView> Elements { get; }
    }
}