﻿using UnityEngine;

namespace Common
{
    public abstract class View<TData> : MonoBehaviour
    {
        public abstract void UpdateView(TData data);
    }
}