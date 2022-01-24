using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageble
{
    [SerializeField] private int _hp = 3;
    
    public event UnityAction DeathHappen;
    public event UnityAction<float> DamageTaken;


    public void TakeDamage(int dmg)
    {
        if (_hp > 0)
        {
            _hp -= dmg;
            DamageTaken?.Invoke(dmg);
        }

        if (_hp <= 0)
        {
            _hp = 0;
            DeathHappen?.Invoke();
        }
    }

    public float GetHpAmount()
    {
        return _hp;
    }
}
