﻿using Level.Config;
using UnityEngine;

namespace Level.Other
{
    public interface IObjectPoolElementModel : IObjectPoolElement
    {
        bool IsActive { get; set; }
        float Speed { get; set; }
        Transform Transform { get; set; }
        void CallUpdateMethod();
        ObjectPoolElementConfig Config { get; }
    }
}