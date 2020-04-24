using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ShowTime : MonoBehaviour
{
    public UnityEvent ScaleTime;

    [SerializeField] private TMP_Text text;

    private Animation animation;
    private EmptyPlace _emptyPlace;
    
    private int _second = 0;
    private int _minute = 0;
    private  float _stepTime =0f;

    private void Awake()
    {
        animation = GetComponent<Animation>();
        _emptyPlace = FindObjectOfType<EmptyPlace>();
    }
    private void Update()
    {
        _stepTime+= Time.deltaTime;
        if (_stepTime >= 1f) 
        {
            TimeFormat();
            _stepTime = 0f;
        }
    }

    private void TimeFormat()
    {
        _second++;
        if (_second > 59)
        { 
            _second = 0;
            _minute++;
        }
        text.text = $"Время - {_minute} : {_second}";
    }

    private void OnEnable()
    {
        _emptyPlace.EptyPositionChange += OnEptyPositionChange;
    }

    private void OnDisable()
    {
        _emptyPlace.EptyPositionChange += OnEptyPositionChange;
    }

    private void OnEptyPositionChange()
    {
        animation.Play();
    }

    public void SetTimeInZero()
    {
        _minute = 0;
        _second = 0;
    }
}
