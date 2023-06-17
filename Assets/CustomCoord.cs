using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DefaultNamespace.ScriptableObjects
{
    [Serializable]
    public class CustomCoord
    {
        [SerializeField] private CoordType name;
        [SerializeField] private Vector3 value;

        public Vector3 Value => value;
    }

}