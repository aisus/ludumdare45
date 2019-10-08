using UnityEngine;

namespace Utility
{
    public static class GizmosExtensions
    {
        public static void DrawCircleGizmo(
            Color color,
            float radius,
            Vector3 position,
            int segmentsCount)
        {
            Gizmos.color = color;
            var initialPoint = Vector3.up * radius;
            var angleStep = 360f / segmentsCount;

            for (var i = 0; i < segmentsCount; i++)
            {
                var newPoint = Quaternion.Euler(0, 0, angleStep) * initialPoint;
                Gizmos.DrawLine(position + initialPoint, position + newPoint);
                initialPoint = newPoint;
            }
        }

        public static void DrawArrowGizmo(
            Color color,
            float width,
            float length,
            float distance,
            Vector3 forward,
            Vector3 center)
        {
            Gizmos.color = color;
            var right = Vector3.Cross(forward, Vector3.forward).normalized;

            var points = new Vector3[3];
            points[0] = forward * distance - right * width / 2;
            points[1] = points[0] + right * width;
            points[2] = forward * distance + forward * length;

            for (var i = 1; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i - 1] + center, points[i] + center);
            }
            Gizmos.DrawLine(points[points.Length - 1] + center, points[0] + center);
        }
    }
}
