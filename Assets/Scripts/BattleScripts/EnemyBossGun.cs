using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossGun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _enemyGunPoint;

    private bool _noCooldown = true;
    private float _bulletSpeed = 3f;
    private float _cooldown = 1f;

    private void Update()
    {
        if (_noCooldown)
        {
            StartCoroutine(EnemyFire());
        }
    }
    private IEnumerator EnemyFire()
    {
        _noCooldown = false;
        yield return new WaitForSeconds(_cooldown);
        GameObject currentBullet = Instantiate(_bullet, _enemyGunPoint.position, Quaternion.identity);
        Rigidbody2D currentBulletRB = currentBullet.GetComponent<Rigidbody2D>();
        currentBulletRB.velocity = new Vector2(_playerTransform.position.normalized.x * _bulletSpeed/2, (_playerTransform.position.normalized.y+0.1f) * _bulletSpeed / 2);
        _noCooldown = true;
    }
}
