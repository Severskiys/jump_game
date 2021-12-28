using UnityEngine;
using UnityEngine.Events;

public class StoryPoints : MonoBehaviour
{
    public event UnityAction StoryPointCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StoryPointCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
