using UnityEngine;
using UnityEngine.Events;

public class ChipMove : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;
    
    public UnityEvent MovementChip;

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

                emptyPlace.PositionChange(temp);
                isChengePosition = true;
            }
        }
        _boxCollider.enabled = true;
        return isChengePosition;
    }
}

