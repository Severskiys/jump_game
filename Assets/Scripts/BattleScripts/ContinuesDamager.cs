using System.Collections;
using UnityEngine;

public class ContinuesDamager : MonoBehaviour
{
    [SerializeField] private int _damage;
    private bool _isDamageDeleyPass = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageble damagetaker))
        {
            if (_isDamageDeleyPass)
            {
                StartCoroutine(ApplayContinuesDamage(damagetaker));
            }
        }
    }

    private IEnumerator ApplayContinuesDamage(IDamageble damagetaker)
    {
        _isDamageDeleyPass = false;
        yield return new WaitForSeconds(0.8f);
        damagetaker.TakeDamage(_damage);
        _isDamageDeleyPass = true;
    }
}
