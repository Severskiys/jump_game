using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    enum PlayerState { Jump, Idle, Run };

    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _wallColliderTransform;

    private float _inputDirection;
    private bool _isIntesectGround = false;
    private bool _isIntesectWall = false;

    private float _runSpeed = 2f;
    private float _jumpShiftSpeedCurrent = 1.1f;
    private float _jumpShiftSpeed = 1.1f;
    private float _jumpForce = 3.3f;
    private float _jumpOverlapRadius = 0.09f;
    private Vector2 _wallOverlapBoxSize = new Vector2(0.18f, 0.5f);

    private PlayerState _playerState = PlayerState.Idle;

    public event UnityAction StartRun,
                             StartJump,
                             StartIdle;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private PlayerInputWrapper _playerInputWrapper;

    private void Awake()
    {
        _playerInputWrapper = GetComponent<PlayerInputWrapper>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _playerInputWrapper.IsJump += OnInputJump;
        _playerInputWrapper.IsMoved += OnInputMove;
    }

    private void OnDisable() 
    {
        _playerInputWrapper.IsJump -= OnInputJump;
        _playerInputWrapper.IsMoved -= OnInputMove;
    }

    private void Update ()
    {
        _isIntesectGround = Physics2D.OverlapCircle(_groundColliderTransform.position, _jumpOverlapRadius, _groundLayer);
        _isIntesectWall = Physics2D.OverlapBox(_wallColliderTransform.position, _wallOverlapBoxSize, 360f, _groundLayer);

        if (_playerState == PlayerState.Jump)
        {
            Move(_inputDirection * _jumpShiftSpeedCurrent);
            if (_isIntesectGround)
                Idle();
        }

        if (_playerState == PlayerState.Run)
        {
            Move(_inputDirection * _runSpeed);
            if (_inputDirection == 0 || !_isIntesectGround)
                Idle();
        }

        if (_playerState == PlayerState.Idle && _inputDirection != 0 && _isIntesectGround)
        {
            _playerState = PlayerState.Run;
            StartRun?.Invoke();
        }
        else if (_isIntesectWall == true && _isIntesectGround == false)
        {
            _jumpShiftSpeedCurrent = 0f;
        }
        else
        {
            _jumpShiftSpeedCurrent = _jumpShiftSpeed;
        }
    }

    private void Move(float inputSpeed)
    {
        _rigidbody.velocity = new Vector2(-inputSpeed, _rigidbody.velocity.y);
    }

    private void Idle()
    {
        _playerState = PlayerState.Idle;
        StartIdle?.Invoke();
    }

    public void OnInputJump()
    {
        if (_isIntesectGround)
        {
            _isIntesectGround = false;
            _rigidbody.velocity = new Vector2(0, _jumpForce);
            _playerState = PlayerState.Jump;
            StartJump?.Invoke();
        }
    }

    public void OnInputMove(float inputDirection)
    {
        _inputDirection = inputDirection;

        if (_inputDirection > 0)
            TurnRight();

        if (_inputDirection < 0)
            TurnLeft();
    }

    private void TurnRight()
    {
        _spriteRenderer.flipX = true;
    }

    private void TurnLeft()
    {
        _spriteRenderer.flipX = false;
    }
}
