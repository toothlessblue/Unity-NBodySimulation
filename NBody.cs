namespace Unity_NBodySimulation
{
    public class NBody : Body
    {
        protected override void doGravity() {
            foreach (Body body in Body.bodies) {
                this.addVelocity(this.calculateAttractionTo(body));
            }
        }
    }
}