using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Gun _playerGun;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        _playerGun = GetComponentInChildren<Gun>();
    }

    private void OnEnable()
    {
        _playerMovement.StartRun += OnRun;
        _playerMovement.StartJump += OnJump;
        _playerMovement.StartIdle += OnIdle;

        _playerGun.StartShoot += OnShoot;
    }

    private void OnDisable()
    {
        _playerMovement.StartRun -= OnRun;
        _playerMovement.StartJump -= OnJump;
        _playerMovement.StartIdle -= OnIdle;

        _playerGun.StartShoot -= OnShoot;
    }

    private void OnRun()
    {
        _animator.Play("PlayerRun");
    }

    private void OnJump()
    {
        _animator.Play("PlayerJump");
    }

    private void OnIdle()
    {
        _animator.Play("PlayerIdle");
    }

    private void OnShoot()
    {
        var currAnimInfo = _animator.GetCurrentAnimatorClipInfo(0);

        if (!(currAnimInfo[0].clip.name == "PlayerRun"))
        {
            _animator.Play("PlayerShoot");
        }
    }
}
