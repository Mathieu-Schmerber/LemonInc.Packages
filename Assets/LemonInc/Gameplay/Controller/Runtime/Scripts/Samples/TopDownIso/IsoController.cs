using LemonInc.Core.StateMachine.Interfaces;
using LemonInc.Gameplay.Controller.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace LemonInc.Gameplay.Controller.Samples.TopDownIso
{
    public class IsoController : BaseController<IsoControllerConfig>
    {
        public Rigidbody Rb { get; private set; }
        public IInputProvider Inputs { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsMoving => Inputs.Movement.Value.magnitude > 0;

        public IsoControllerConfig Settings => Config;
        [ShowInInspector, ReadOnly, InlineProperty] public IStateMachine StateMachineState => StateMachine;

        protected override void Awake()
        {
            Rb = GetComponent<Rigidbody>();
            Inputs = GetComponent<IInputProvider>();
            base.Awake();
        }

        protected override void SetupStates()
        {
            RegisterSubStateMachine<Grounded>();
            RegisterSubStateMachine<Airborne>();
            StateMachine.AddMutualLink<Grounded, Airborne>(() => !IsGrounded);
        }

        protected override void SetupActions()
        {
            RegisterAction<JumpAction>();
        }

        protected override void OnInitialize()
        {
            StateMachine.SwitchToState<Grounded>();
        }

        protected override void Update()
        {
            GroundCheck();
            Rb.linearDamping = IsGrounded ? Config.GroundDrag : Config.AirDrag;
            base.Update();
        }

        public void HandleMovement(bool grounded)
        {
            var moveDir = Inputs.Movement.Value;
            var speed = grounded ? Config.MoveSpeed : Config.MoveSpeed * Config.AirControl;
            Rb.AddForce(moveDir * (speed * Time.fixedDeltaTime), ForceMode.Impulse);
        }

        private void GroundCheck()
        {
            var check = transform.position + Config.GroundCheckOffset;
            IsGrounded = Physics.CheckSphere(check, Config.GroundCheckRadius, Config.GroundLayer);
        }

        private void OnDrawGizmos()
        {
            if (Config == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + Config.GroundCheckOffset, Config.GroundCheckRadius);
        }
    }
}