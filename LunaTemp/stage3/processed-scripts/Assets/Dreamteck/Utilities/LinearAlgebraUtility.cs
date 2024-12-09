using UnityEngine;
using System.Collections;
using System.IO;

namespace Dreamteck
{
    public static class LinearAlgebraUtility
    {
        public enum Axis
        {
            X = 0,
            Y = 1,
            Z = 2
        }

        public static Vector3 ProjectOnLine([Bridge.Ref] Vector3 fromPoint, [Bridge.Ref] Vector3 toPoint, [Bridge.Ref] Vector3 project)
        {
            Vector3 projectedPoint = Vector3.Project((project - fromPoint), (toPoint - fromPoint)) + fromPoint;
            Vector3 dir = toPoint - fromPoint;
            Vector3 projectedDir = projectedPoint - fromPoint;
            float dot = Vector3.Dot(projectedDir, dir);
            if(dot > 0f)
            {
                if(projectedDir.sqrMagnitude <= dir.sqrMagnitude) return projectedPoint;
                else return toPoint;
            } else return fromPoint;
        }

        public static float InverseLerp([Bridge.Ref] Vector3 a, [Bridge.Ref] Vector3 b, [Bridge.Ref] Vector3 value)
        {
            Vector3 ab = b - a;
            Vector3 av = value - a;
            return Vector3.Dot(av, ab) / Vector3.Dot(ab, ab);
        }

        public static float DistanceOnSphere([Bridge.Ref] Vector3 from, [Bridge.Ref] Vector3 to, float radius)
        {
            float distance = 0;
            
            if (from == to)
            {
                distance = 0;
            }
            else if (from == -to)
            {
                distance = Mathf.PI * radius;
            }
            else
            {
                distance = Mathf.Sqrt(2) * radius * Mathf.Sqrt(1.0f - Vector3.Dot(from, to));
            }

            return distance;
        }

        public static Vector3 FlattenVector(Vector3 input, Axis axis, float flatValue = 0f)
        {
            switch (axis)
            {
                case Axis.X: input.x = flatValue; break;
                case Axis.Y: input.y = flatValue; break;
                case Axis.Z: input.z = flatValue; break;
            }
            return input;
        }
    }
}