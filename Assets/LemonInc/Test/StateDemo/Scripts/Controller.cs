using LemonInc.Core.StateMachine;
using LemonInc.Core.Utilities;
using LemonInc.Test.StateDemo.Scripts.Inputs;
using LemonInc.Test.StateDemo.Scripts.States;
using TMPro;
using UnityEngine;

namespace LemonInc.Test.StateDemo.Scripts
{
    public class Controller : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _groundDrag = 5f;
        [SerializeField] private float _airDrag = 0f;
        [SerializeField, Range(0, 1)] private float _airControl = 0.5f;
        
        [Header("Ground Check")]
        [SerializeField] private Vector3 _groundCheckOffset;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayer;

        [SerializeField] private Timer _jumpTimer;
        
        private IInputProvider _inputs;
        private Rigidbody _rb;
        private TextMeshPro _textMesh;
        private bool _isGrounded;
        
        private readonly StateMachine _stateMachine = new();

        public bool CanJump => _inputs.Jump.Pressed && _isGrounded && _jumpTimer.IsOver();
        public bool IsMoving => _inputs.Movement.Value.magnitude > 0;
        
        private void Awake()
        {
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _rb = GetComponent<Rigidbody>();
            _inputs = GetComponent<IInputProvider>();

            // Demo: setup states and transition within the root script
            var grounded = _stateMachine.RegisterSubStateMachine(new Grounded(this))
                .RegisterState(new Idle(transform))
                .RegisterState(new Run(transform));

            // Demo: setup states and transitions locally
            _stateMachine.RegisterSubStateMachine(new Airborne(transform));

            grounded.AddEntryLink<Idle>(() => !IsMoving);
            grounded.AddEntryLink<Run>(() => IsMoving);
            grounded.AddMutualLink<Idle, Run>(() => IsMoving);
            
            _stateMachine.AddMutualLink<Grounded, Airborne>(() => !_isGrounded);
            _stateMachine.SetActiveState<Grounded>();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
        
        private void Update()
        {
            _textMesh.text = _stateMachine.ToString();
            _stateMachine.Update();
            GroundCheck();
            _rb.linearDamping = _isGrounded ? _groundDrag : _airDrag;
        }

        private void GroundCheck()
        {
            var check = transform.position + _groundCheckOffset;
            _isGrounded = Physics.CheckSphere(check, _groundCheckRadius, _groundLayer);
        }

        public void HandleMovements()
        {
            var moveDir = _inputs.Movement.Value;
            var speed = _isGrounded ? _moveSpeed : _moveSpeed * _airControl;
            
            _rb.AddForce(moveDir * (speed * Time.fixedDeltaTime), ForceMode.Impulse);
        }

        public void HandleJump()
        {
            if (!CanJump)
                return;
            
            _jumpTimer.Restart();
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + _groundCheckOffset, _groundCheckRadius);
        }
    }
}