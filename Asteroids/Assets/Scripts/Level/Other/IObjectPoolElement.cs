using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElement
    {
        string Id { get; set; }
        EntityType Type { get; }
    }
}