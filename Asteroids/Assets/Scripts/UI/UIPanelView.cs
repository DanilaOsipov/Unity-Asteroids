﻿using UnityEngine;

namespace UI
{
    public abstract class UIPanelData
    {
    }

    public abstract class UIPanelView<TData> : UIPanelView
        where TData : UIPanelData
    {
        public override void UpdateView(UIPanelData data)
        {
            UpdateView(data as TData);
        }

        protected abstract void UpdateView(TData data);
    }
    
    public abstract class UIPanelView : MonoBehaviour
    {
        public abstract UIPanelType Type { get; }

        public Transform Transform => transform;
        
        public abstract void UpdateView(UIPanelData data);

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}