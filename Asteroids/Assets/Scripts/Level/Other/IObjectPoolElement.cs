using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElement
    {
        string Id { get; set; }
        ObjectPoolElementType Type { get; }
    }
}