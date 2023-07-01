using UnityEngine;


    public interface IBezierCoords
    {
        public Vector3 StartValue { get; }
        public Vector3 EndValue { get; }
        public Vector3 TopValue { get; }
        public Vector3 DownValue { get; }
    }
