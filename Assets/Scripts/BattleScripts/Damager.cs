using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageble>(out IDamageble damagetaker))
        {
            damagetaker.TakeDamage(_damage);
        }
    }
}
