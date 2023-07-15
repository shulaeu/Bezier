using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveJsonData
{
   public List<RunTimeCoords> _runTimeCoordsList = new List<RunTimeCoords>();

    [SerializeField]
    public SaveJsonData(List<RunTimeCoords> _runTimeCoordsList)
    {
        this._runTimeCoordsList = _runTimeCoordsList;
    }
}
