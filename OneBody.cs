using UnityEngine;

namespace Unity_NBodySimulation
{    
    /// <summary>
    /// Calculates and applies gravitational attraction to only the specified body
    /// </summary>
    public class OneBody : Body
    {
        public Body otherBody;

        protected override void doGravity() {
            if (!this.otherBody) return;

            this.addVelocity(this.calculateAttractionTo(this.otherBody));
        }
    }
}