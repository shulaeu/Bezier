using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;

namespace DefaultNamespace.ScriptableObjects
{
    [Serializable]
    public class CustomCoord
    {
        [SerializeField] private CoordType name;
        [SerializeField] private Vector2 value;

        public Vector2 Value => value;
    }

}