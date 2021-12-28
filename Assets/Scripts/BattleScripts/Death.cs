using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] private Text _deathMessage;

    private IDamageble _unitWhoWillDie;

    private void Awake()
    {
        _unitWhoWillDie = GetComponent<IDamageble>();
    }

    private void OnEnable()
    {
       _unitWhoWillDie.DeathHappen += OnDeathHappen;
    }

    private void OnDisable()
    {
       _unitWhoWillDie.DeathHappen -= OnDeathHappen;
    }

    private void OnDeathHappen()
    {
        if (gameObject.TryGetComponent<Player>(out Player player))
        {
            _deathMessage.gameObject.SetActive(true);
            _deathMessage.text = "YOU DIED";
        }
        gameObject.SetActive(false);
    }
}
