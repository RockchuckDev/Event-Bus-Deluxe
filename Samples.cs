using Godot;

// Note, these are examples that examples taken from Godot projects, but this system should work with any C# project
namespace EventBusDeluxe
{

    public struct SpawnBulletImpactParticlesEvent
    {
        /// <summary> Position in world space to spawn the particles at</summary>
        public Vector3 impactPoint;
        /// <summary> Essentially the "ricochet" direction of the impact point. </summary>
        public Vector3 impactNormal;
        /// <summary> The particles to spawn in </summary>
        public PackedScene bulletImpactParticlesScene;
    }

    public struct TriggerExplosionEvent
    {
        public SceneTree activeSceneTree;
        public Vector3 position;
        public float magnitude;
        public float radius;
    }

    public struct StopNonUIPlayerInputEvent
    {
        // While events typically contain relevant info, this is not strictly necessary
    }

    public struct PlayerHasDiedEvent
    {
        public RigidBody3D deadPlayerNode;
        public Node nodeThatCausedPlayerDeath;
    }

}
