using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamageble
{
    private int _hp = 15;

    public event UnityAction DeathHappen;
    public event UnityAction<int> DamageTaken;

    public void TakeDamage(int dmg)
    {
        if (_hp > 0)
        {
            _hp -= dmg;
            DamageTaken?.Invoke(_hp);
        }
        if (_hp <= 0)
        {
            _hp = 0;
            DeathHappen?.Invoke();
        }
    }

}
