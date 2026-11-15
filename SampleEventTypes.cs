using Godot;
namespace EventBusDeluxe{

    public struct SpawnBulletImpactParticlesEvent
    {
        /// <summary> Position in world space to spawn the particles at</summary>
        public Vector3 impactPoint;
        /// <summary> Essentially the "ricochet" direction of the impact point. </summary>
        public Vector3 impactNormal;
        /// <summary> The particles to spawn in </summary>
        public PackedScene bulletImpactParticlesScene;
    }

    /// <summary> Fires when the player changes their grab mode. </summary>
    public struct PlayerChangedGrabModeEvent
    {
        /// <summary> Boolean to represent if the active grab mode is "toggle" (true) or is "hold" (false) </summary>
        public bool isToggleGrabModeOn;
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

    }

    public struct PlayerHasDiedEvent() {
        public RigidBody3D deadPlayerNode;
        public Node nodeThatCausedPlayerDeath;
    }

}
