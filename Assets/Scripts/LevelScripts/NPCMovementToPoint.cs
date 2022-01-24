using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NPCMovementToPoint : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;

    private SpriteRenderer _renderer;
    private int _pointIndex = 0;
    private int _earlierPointIndex;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MoveFromPointToPoint();
    }

    private void MoveFromPointToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _movePoints[_pointIndex].position, 0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CrabMovePoint>(out CrabMovePoint _cMP))
        {
            if (_cMP.transform.position == _movePoints[_pointIndex].position)
            {
                _earlierPointIndex = _pointIndex;

                if (_pointIndex < _movePoints.Length - 1)
                    _pointIndex++;
                else
                    _pointIndex = 0;

                ChangeRendererFlipX();
            }
        }
    }

    private void ChangeRendererFlipX()
    {
        if (_movePoints[_pointIndex].position.x > _movePoints[_earlierPointIndex].position.x)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }
    }
}
