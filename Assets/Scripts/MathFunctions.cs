using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathFunctions
{
    public static float ClampAngle(float angle)
    {
        if (angle > 180f) return angle - 360f;
        else
            return angle;
    }
}
