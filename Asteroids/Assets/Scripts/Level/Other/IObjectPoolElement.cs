using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElement
    {
        string Id { get; }
        ObjectPoolElementType Type { get; }
    }
}