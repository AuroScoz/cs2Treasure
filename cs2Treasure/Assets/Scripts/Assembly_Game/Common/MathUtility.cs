using Scoz.Func;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MathUtility
{
    public static float angle(float3 from, float3 to) {
        return math.degrees(math.acos(math.dot(math.normalize(from), math.normalize(to))));
    }

    public static float anglesinged(float3 from, float3 to, float3 axis) {
        float angle = math.degrees(math.acos(math.dot(math.normalize(from), math.normalize(to))));
        float sign = math.sign(math.dot(axis, math.cross(from, to)));
        return math.degrees(angle * sign);
    }
}
