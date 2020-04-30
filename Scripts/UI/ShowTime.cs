using UnityEngine;
using TMPro;

[RequireComponent (typeof(Animation))]

public class ShowTime : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    private Animation _animationText;
    private EmptyPlace _emptyPlace;
    
    private int _second = 0;
    private int _minute = 0;
    private int _sumSecond=0;
    private  float _stepTime =0f;
    public int SumSecond => _sumSecond;

    private void Awake()
    {
        _animationText = GetComponent<Animation>();
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
        _sumSecond++;
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
        _animationText.Play();
    }

    public void SetTimeInZero()
    {
        _minute = 0;
        _second = 0;
        _sumSecond = 0;
    }
}
