using UnityEngine.UI;
using UnityEngine;

public class EnemyHPCounter : MonoBehaviour
{
    [SerializeField] private Image _hpCounter;
    [SerializeField] private Enemy _bossEnemy;
    private float _enemyHpAmount;

    private void Start()
    {
        _enemyHpAmount = _bossEnemy.GetHpAmount();
        _hpCounter.fillAmount = 1;
    }
    private void OnEnable()
    {
        _bossEnemy.DamageTaken += OnDamageTaken;
    }

    private void OnDisable()
    {
        _bossEnemy.DamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken(float dmg)
    {
        _hpCounter.fillAmount -= dmg/ _enemyHpAmount;
    }
}
