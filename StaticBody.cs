using UnityEngine;

namespace Unity_NBodySimulation
{
    public class StaticBody : Body
    {
        protected override Vector3 _getGravitationalAcceleration() {
            return Vector3.zero;
        }

        public override Vector3 getGravitationalAcceleration(Vector3 position) {
            return Vector3.zero;
        }
    }
}