using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class WinGame : MonoBehaviour
{
    private List<Vector3> _сhildPosition = new List<Vector3>();
    private List<Vector3> _thisWin = new List<Vector3>();
    private EmptyPlace _emptyPlace;

    public UnityEvent GameWinHandler;

    private void Awake()
    {
        _emptyPlace = FindObjectOfType<EmptyPlace>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            _thisWin.Add(transform.GetChild(i).position);
            _сhildPosition.Add(transform.GetChild(i).position);
        }
    }

    private void Start()
    {
        RemixByShuffle();
    }

    private void OnEnable()
    {
        _emptyPlace.EptyPositionChange += onEptyPositionChange;
    }

    private void OnDisable()
    {
        _emptyPlace.EptyPositionChange -= onEptyPositionChange;
    }

    public void onEptyPositionChange()
    {
        bool isWin = false;
        int i = 0;
        foreach (Transform item in transform)
        {
            if (item.position == _thisWin[i++])
                isWin = true;
            else
            { 
                isWin = false;
                break;
            }
        }

        if (isWin)
        { 
            Debug.Log($"<color=green> Победа!!!  </color>");
            GameWinHandler?.Invoke();
            Invoke("StopGame", 0.4f);
        }
        else
            Debug.Log($"<color=red> У тебя все получится...  </color>");
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    public void RemixByShuffle()
    {
        Time.timeScale = 1f;
        Vector3 temp;
        int count = _сhildPosition.Count-1;
        for (int i = count; i > 0  ; i--)
        {
            int n = Random.Range(0, count);
            temp = _сhildPosition[i];
            _сhildPosition[i] = _сhildPosition[n];
            _сhildPosition[n] = temp;
            count--;
        }
        RePlacingChips(_сhildPosition);
    }

    private void RePlacingChips(List<Vector3> сhildPosition)
    {
        int i = 0;
        foreach (Transform child in transform)
            child.position = сhildPosition[i++];
    }
}