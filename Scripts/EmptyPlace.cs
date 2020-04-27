using UnityEngine;
using UnityEngine.Events;

public class EmptyPlace : MonoBehaviour
{
    public event UnityAction EptyPositionChange;

    public void PositionChange(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        EptyPositionChange?.Invoke();
    }
}
