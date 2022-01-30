using System.Collections.Generic;
using Unity_Utils;
using UnityEngine;

namespace Unity_NBodySimulation
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Body : MonoBehaviour
    {
        protected static readonly List<Body> bodies = new List<Body>();
        
        [Tooltip("Whether or not this body is included when calculating NBody gravity")]
        public bool includeInOtherBodyCalculations = true;
        
        [Tooltip("The velocity this body will start with")]
        public Vector3 initialVelocity;

        public float mass => this.rigidbody.mass;
        
        private Rigidbody rigidbody;

        public Vector3 getVelocity() => this.rigidbody.velocity;
        public Vector3 getPosition() => this.rigidbody.position;

        private void Start() {
            this.rigidbody = this.GetComponent<Rigidbody>();
            this.rigidbody.velocity = initialVelocity;
            Body.bodies.Add(this);
        }

        private void FixedUpdate() {
            this.addVelocity(this.getGravitationalAcceleration() * Time.fixedDeltaTime);
        }

        /// <summary>
        /// Returns a Vector3 of the velocity change that would be caused by gravitational pull toward Body other
        /// </summary>
        /// <param name="other">The body the attraction force is coming from</param>
        /// <returns>Vector3 change in velocity</returns>
        protected Vector3 calculateAttractionTo(Body other) {
            return this.calculateAttractionTo(other, this.transform.position);
        }
        
        /// <summary>
        /// Returns a Vector3 of the velocity change that would be caused by gravitational pull toward Body other
        /// </summary>
        /// <param name="other">The body the attraction force is coming from</param>
        /// <param name="fromPosition">The position to calculate from</param>
        /// <returns>Vector3 change in velocity</returns>
        protected Vector3 calculateAttractionTo(Body other, Vector3 fromPosition) {
            return NBodyUtils.calculateGravity(fromPosition, other.transform.position, other.mass);
        }

        /// <summary>
        /// Adds velocity directly to the Rigidbody
        /// </summary>
        /// <param name="velocity">To add</param>
        public void addVelocity(Vector3 velocity) {
            this.rigidbody.velocity += velocity;
        }

        /// <summary>
        /// Calculates the gravitational acceleration on the body this frame
        /// </summary>
        /// <returns>The gravitational acceleration this frame</returns>
        protected abstract Vector3 _getGravitationalAcceleration();
        
        /// <summary>
        /// Calculates the gravitational acceleration on the body this frame at the given position
        /// </summary>
        /// <param name="position">The position to calculate from</param>
        /// <returns>The gravitational acceleration this frame</returns>
        public abstract Vector3 getGravitationalAcceleration(Vector3 position);

        
        private readonly ValueFrameCache<Vector3> gravitationalAccelerationThisFrame = new ValueFrameCache<Vector3>();
        /// <summary>
        /// Calculates the gravitational acceleration on the body this frame.
        /// This method is frame cached; it won't be recalculated multiple times per frame.
        /// </summary>
        /// <returns>The gravitational acceleration this frame</returns>
        public Vector3 getGravitationalAcceleration() {
            if (this.gravitationalAccelerationThisFrame.isValid()) return this.gravitationalAccelerationThisFrame.getValue();
            
            this.gravitationalAccelerationThisFrame.setValue(this._getGravitationalAcceleration());
            return this.gravitationalAccelerationThisFrame.getValue();
        }
    }
}