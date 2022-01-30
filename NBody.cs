namespace Unity_NBodySimulation
{
    /// <summary>
    /// Calculates and applies gravitational attraction to all other bodies
    /// </summary>
    public class NBody : Body
    {
        protected override void doGravity() {
            foreach (Body body in Body.bodies) {
                if (this == body) continue;
                
                this.addVelocity(this.calculateAttractionTo(body));
            }
        }
    }
}