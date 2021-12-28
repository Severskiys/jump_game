using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageble
{
    private int _hp = 3;
    
    public event UnityAction DeathHappen;

    public void TakeDamage(int dmg)
    {
        if (_hp > 0)
        {
            _hp -= dmg;
        }

        if (_hp <= 0)
        {
            _hp = 0;
            DeathHappen?.Invoke();
        }
    }
}
