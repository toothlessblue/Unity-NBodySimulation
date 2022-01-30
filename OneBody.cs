using Unity_LoggerHelper;
using UnityEngine;

namespace Unity_NBodySimulation
{    
    /// <summary>
    /// Calculates and applies gravitational attraction to only the specified body
    /// </summary>
    public class OneBody : Body
    {
        public Body otherBody;

        protected override Vector3 _getGravitationalAcceleration() {
            if (this.otherBody == this) {
                LoggerHelper.WarnOnce("OneBody is calculating attraction to itself.");
                return Vector3.zero;
            }
            
            if (!this.otherBody) return Vector3.zero;
            if (!otherBody.includeInOtherBodyCalculations) return Vector3.zero;
            
            return this.calculateAttractionTo(this.otherBody);
        }

        public override Vector3 getGravitationalAcceleration(Vector3 position) {
            if (this.otherBody == this) {
                LoggerHelper.WarnOnce("OneBody is calculating attraction to itself.");
                return Vector3.zero;
            }
            
            if (!this.otherBody) return Vector3.zero;
            if (!otherBody.includeInOtherBodyCalculations) return Vector3.zero;
            
            return this.calculateAttractionTo(this.otherBody, position);
        }
    }
}