using LemonInc.Gameplay.Controller.Core;
using UnityEngine;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    [CreateAssetMenu(menuName = "Controllers/Iso Controller Config")]
    public class IsoControllerConfig : ControllerConfig
    {
        [Header("Movement")]
        public float MoveSpeed = 40f;
        public float GroundDrag = 5f;
        public float AirDrag = 0f;
        [Range(0, 1)] public float AirControl = 0.5f;

        [Header("Jump")]
        public float JumpForce = 20f;
        public float JumpCooldown = .1f;
        public float CoyoteTime = 0.15f;
        public float JumpBufferTime = 0.15f;

        [Header("Ground Check")]
        public Vector3 GroundCheckOffset;
        public float GroundCheckRadius = 0.1f;
        public LayerMask GroundLayer;
    }
}