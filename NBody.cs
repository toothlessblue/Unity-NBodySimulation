using UnityEngine;

namespace Unity_NBodySimulation
{
    /// <summary>
    /// Calculates and applies gravitational attraction to all other bodies
    /// </summary>
    public class NBody : Body
    {
        protected override Vector3 _getGravitationalAcceleration() {
            return this.getGravitationalAcceleration(this.getPosition());
        }

        public override Vector3 getGravitationalAcceleration(Vector3 position) {
            Vector3 acceleration = Vector3.zero;
            
            foreach (Body body in Body.bodies) {
                if (this == body) continue;
                if (!body.includeInOtherBodyCalculations) continue;
                
                acceleration += this.calculateAttractionTo(body, position);
            }

            return acceleration;
        }
    }
}