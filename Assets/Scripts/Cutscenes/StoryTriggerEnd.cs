using UnityEngine;
using TMPro;
public class StoryTriggerEnd : MonoBehaviour
{
    [SerializeField] private GameObject _endGameCanvas;
    [SerializeField] private TMP_Text _endPoints;
    private PlayerInputWrapper _playerInpWrap;
    private PointsCount _pointsCount;

    private CutscenesHub _csHub;

    private void Awake()
    {
        _csHub = GetComponentInParent<CutscenesHub>();
        _playerInpWrap = FindObjectOfType<PlayerInputWrapper>();
        _pointsCount = FindObjectOfType<PointsCount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _csHub.PlayDialogFirstLvlEnd();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _endPoints.text = _pointsCount.GetPointsAmount().ToString();
            _endGameCanvas.SetActive(true);
            _playerInpWrap.DisableInput();
        }
    }
}
