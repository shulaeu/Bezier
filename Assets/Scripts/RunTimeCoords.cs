using UnityEngine;


    public class RunTimeCoords : IBezierCoords
    {
    
            public Vector3 StartValue { get; }
            public Vector3 EndValue { get; }
            public Vector3 TopValue { get; }
            public Vector3 DownValue { get; }

            public RunTimeCoords(Vector3 startValue, Vector3 endValue, Vector3 topValue, Vector3 downValue)
            {
                StartValue = startValue;
                EndValue = endValue;
                TopValue = topValue;
                DownValue = downValue;
            }          
    }

