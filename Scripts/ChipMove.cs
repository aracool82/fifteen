using UnityEngine;
using UnityEngine.Events;

public class ChipMove : MonoBehaviour
{
    public UnityEvent MovementChip;
    public event UnityAction<Vector3> PositionChange;

    [SerializeField] private BoxCollider2D _boxCollider;

    private void OnMouseDown()
    {
        if (TryMove(Vector2.right))
            return;
        if (TryMove(Vector2.left))
            return;
        if (TryMove(Vector2.up))
            return;
        if (TryMove(Vector2.down))
            return;
    }

    private bool TryMove(Vector2 direction)
    {
        RaycastHit2D hit;
        bool isChengePosition = false;
        _boxCollider.enabled = false;
        if (hit=Physics2D.Raycast(transform.position, direction))
        {
            if (hit.collider.TryGetComponent(out EmptyPlace emptyPlace) && Time.timeScale > 0f)
            {
                MovementChip?.Invoke();
                Vector2 temp = transform.position; 
                transform.position = emptyPlace.transform.position;
                PositionChange?.Invoke(temp);
                
                isChengePosition = true;
            }
        }
        _boxCollider.enabled = true;
        return isChengePosition;
    }
}

