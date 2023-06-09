using UnityEngine;
using System;
public class Points
{
    private readonly GameObject tempStart;
    private readonly GameObject tempEnd;
    private readonly GameObject tempTop;
    private readonly GameObject tempDown;

    public Points(GameObject tempStart, GameObject tempEnd, GameObject tempTop, GameObject tempDown)
    {
        this.tempStart = tempStart;
        this.tempEnd = tempEnd;
        this.tempTop = tempTop;
        this.tempDown = tempDown;
    }

    public Vector3 GetPosition(CoordType type)
    {
        switch (type)
        {
            case CoordType.Start:
                return tempStart.transform.localPosition;
            case CoordType.End:
                return tempEnd.transform.localPosition;
            case CoordType.Top:
                return tempTop.transform.localPosition;
            case CoordType.Down:
                return tempDown.transform.localPosition;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
