using UnityEngine;
using UnityEngine.Events;

public class EmptyPlace : MonoBehaviour
{
    public event UnityAction EptyPositionChange;
    private ChipMove[] _chipMove;

    private void Awake()
    {
        _chipMove = FindObjectsOfType<ChipMove>();
    }

    private void OnEnable()
    {
        foreach (var chip in _chipMove)
            chip.PositionChange += OnPositionChange; 
    }
    private void OnDisable()
    {
        foreach (var chip in _chipMove)
            chip.PositionChange -= OnPositionChange;
    }

    private void OnPositionChange(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        EptyPositionChange?.Invoke();
    }
}
