using System;
using UnityEngine;

namespace Unity_NBodySimulation
{
    [RequireComponent(typeof(LineRenderer))]
    public class BodyOrbitPredictor : MonoBehaviour
    {
        [Range(0.001f, 10f)] public float resolution = 1;
        private int predictionRange => this.lineRenderer.positionCount;

        private LineRenderer lineRenderer;
        public Body body;

        private void Start() {
            this.lineRenderer = this.GetComponent<LineRenderer>();
        }

        private void FixedUpdate() {
            Vector3[] predictions = new Vector3[this.predictionRange];

            predictions[0] = this.body.getPosition();
            Vector3 predictionVelocity = this.body.getVelocity();

            for (int i = 1; i < this.predictionRange; i++) {
                predictionVelocity += this.body.getGravitationalAcceleration(predictions[i - 1]) * Time.fixedDeltaTime / this.resolution;
                predictions[i] = predictions[i - 1] + (predictionVelocity * Time.fixedDeltaTime / this.resolution);
            }

            this.lineRenderer.SetPositions(predictions);
        }
    }
}