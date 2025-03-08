using LemonInc.Test.StateMachine.Scripts.Inputs;
using UnityEngine;

namespace LemonInc.Test.StateMachine.Scripts
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
        
        private IInputProvider _inputs;
        private Rigidbody _rb;
        private bool _isGrounded;
        
        private Core.StateMachine.StateMachine _stateMachine;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _inputs = GetComponent<IInputProvider>();
        }

        private void OnEnable()
        {
            _inputs.Jump.OnPressed += Jump;
        }

        private void OnDisable()
        {
            _inputs.Jump.OnPressed -= Jump;
        }

        private void FixedUpdate()
        {
            HandleMovements();
        }
        
        private void Update()
        {
            GroundCheck();
            _rb.drag = _isGrounded ? _groundDrag : _airDrag;
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

        public void Jump()
        {
            if (!_isGrounded)
                return;
            
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + _groundCheckOffset, _groundCheckRadius);
        }
    }
}