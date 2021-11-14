using System;
using System.Collections.Generic;

namespace Level.Other
{
    public interface IObjectPoolModel : IObjectPool<IObjectPoolElementModel>
    {
        void SetElementActive(string id, bool isActive);
        List<IObjectPoolElementModel> Elements { get; }
        event Action OnUpdate;
    }
}