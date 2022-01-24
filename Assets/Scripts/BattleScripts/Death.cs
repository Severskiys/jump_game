using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;

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
            _deathPanel.SetActive(true);
        }
        gameObject.SetActive(false);//убираем из кадра персонажа
    }
}
