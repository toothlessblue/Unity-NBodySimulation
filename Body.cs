using System.Collections.Generic;
using UnityEngine;

namespace Unity_NBodySimulation
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Body : MonoBehaviour
    {
        protected static readonly List<Body> bodies = new List<Body>();
        
        public Vector3 initialVelocity;

        private float mass => this.rigidbody.mass;
        private Rigidbody rigidbody;

        private void Start() {
            this.rigidbody = this.GetComponent<Rigidbody>();
            this.rigidbody.velocity = initialVelocity;
            Body.bodies.Add(this);
        }

        private void FixedUpdate() {
            this.doGravity();
        }

        /// <summary>
        /// Returns a Vector3 of the velocity change that would be caused by gravitational pull toward Body other
        /// </summary>
        /// <param name="other">The body the attraction force is coming from</param>
        /// <returns>Vector3 change in velocity</returns>
        protected Vector3 calculateAttractionTo(Body other) {
            // Gravity formula: F = G * (m1 * m2 / r^2)
            // Acceleration equation: a = F / m1
            // Simplified: a = (G * m2 / r^2)

            Vector3 delta = other.transform.position - this.transform.position;
            
            Vector3 direction = delta.normalized;
            float squareDistance = delta.sqrMagnitude;
            
            Vector3 deltaV = (UniverseSettings.gravityConstant * other.mass * direction) / squareDistance;

            return deltaV;
        }

        protected void addVelocity(Vector3 velocity) {
            this.rigidbody.velocity += velocity;
        }
        
        protected abstract void doGravity();
    }
}