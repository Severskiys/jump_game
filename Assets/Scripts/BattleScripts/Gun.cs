using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _rightFireDirection;
    [SerializeField] private Transform _leftFireDirection;

    private float _bulletSpeed = 5f;
    private float _shotDirection = 1f;
    private Transform _currentFireDirection;
    private PlayerInputWrapper _playerInputActions;

    public event UnityAction StartShoot;

    private void Awake()
    {
        _playerInputActions = GetComponentInParent<PlayerInputWrapper>();
        _currentFireDirection = _rightFireDirection;
    }

    private void OnEnable()
    {
        _playerInputActions.IsMoved += OnInputMove;
        _playerInputActions.IsFire += OnInputFire;
    }

    private void OnDisable()
    {
        _playerInputActions.IsMoved -= OnInputMove;
        _playerInputActions.IsFire -= OnInputFire;
    }

    private void OnInputMove(float inputDirection)
    {
        if (inputDirection != 0)
        {
            _shotDirection = -inputDirection;

            if (_shotDirection > 0)
                _currentFireDirection = _rightFireDirection;
            else
                _currentFireDirection = _leftFireDirection;
        }
    }

    private void OnInputFire()
    {
        StartShoot?.Invoke();
        GameObject currentBullet = Instantiate(_bullet, _currentFireDirection.position, Quaternion.identity);
        Rigidbody2D currentBulletRB = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletRB.velocity = new Vector2(_shotDirection * _bulletSpeed, 0);
    }
}
