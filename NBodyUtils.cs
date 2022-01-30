using UnityEngine;

namespace Unity_NBodySimulation
{
    public static class NBodyUtils
    {
        /// <summary>
        /// Uses the gravity formula to calculate gravitational acceleration this frame.
        /// </summary>
        /// <param name="from">The position being accelerated</param>
        /// <param name="to">The position accelerated to</param>
        /// <param name="toMass">The mass causing the acceleration in KG</param>
        /// <returns>A Vector3 of acceleration</returns>
        public static Vector3 calculateGravity(Vector3 from, Vector3 to, float toMass) {
            // Gravity formula: F = G * (m1 * m2 / r^2)
            // Acceleration equation: a = F / m1
            // Simplified: a = (G * m2 / r^2)

            Vector3 delta = to - from;
            
            Vector3 direction = delta.normalized;
            float squareDistance = delta.sqrMagnitude;
            
            Vector3 deltaV = (UniverseSettings.gravityConstant * toMass * direction) / squareDistance;

            return deltaV;
        }
    }
}