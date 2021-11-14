using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElementView : IObjectPoolElement
    {
        public Transform Transform { get; }
        public void UpdateView(IObjectPoolElementModel elementModel);
    }
}