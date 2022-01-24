using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    private CutscenesHub _csHub;

    private void Awake()
    {
        _csHub = GetComponentInParent<CutscenesHub>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _csHub.PlayDialogFirstLvlStart();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
