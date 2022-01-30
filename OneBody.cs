using UnityEngine;

namespace Unity_NBodySimulation
{
    public class OneBody : Body
    {
        public Body otherBody;

        protected override void doGravity() {
            if (!this.otherBody) return;

            this.addVelocity(this.calculateAttractionTo(this.otherBody));
        }
    }
}