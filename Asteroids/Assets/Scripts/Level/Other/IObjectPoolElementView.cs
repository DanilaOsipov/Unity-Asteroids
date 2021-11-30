using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElementView : IObjectPoolElement, ICollidable
    {
        public Transform Transform { get; }
        public void UpdateView(IObjectPoolElementModel elementModel);
        public void Initialize(IObjectPoolElementModel elementModel);
    }
}