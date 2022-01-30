using UnityEngine;

namespace NBodySimulation
{
    public class OneBody : Body
    {
        public Body otherBody;

        protected override void doGravity() {
            if (!this.otherBody) return;

            this.calculateAttractionTo(this.otherBody);
        }
    }
}