using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtility : MonoBehaviour
{
    public static Vector3 ProjectPointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
    {
        Vector3 relativePoint = point - lineStart;
        Vector3 lineDirection = lineEnd - lineStart;
        float length = lineDirection.magnitude;
        Vector3 normalizedLineDirection = lineDirection;
        if (length > .000001f)
            normalizedLineDirection /= length;

        float dot = Vector3.Dot(normalizedLineDirection, relativePoint);
        dot = Mathf.Clamp(dot, 0.0F, length);

        return lineStart + normalizedLineDirection * dot;
    }

    // Calculate distance between a point and a line.
    public static float DistancePointLine(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
    {
        return Vector3.Magnitude(ProjectPointLine(point, lineStart, lineEnd) - point);
    }

    public static string IndexToLevelType(int i) {
        if (i == 0)
        {
            return "A1";
        }
        else if (i == 1)
        {
            return "A2";
        }
        else if (i == 2)
        {
            return "B1";
        }
        else if (i == 3)
        {
            return "B2";
        }
        else if (i == 4)
        {
            return "C1";
        }
        else {
            return null;
        }
    }

    public static int LevelTypeToIndex(string str) {
        if (str == "A1")
        {
            return 0;
        }
        else if (str == "A2")
        {
            return 1;
        }
        else if (str == "B1")
        {
            return 2;
        }
        else if (str == "B2")
        {
            return 3;
        }
        else if (str == "C1")
        {
            return 4;
        }
        else {
            return 100;
        }
    }
}
