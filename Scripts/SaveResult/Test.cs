using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    private List<Vector3> _сhildPosition = new List<Vector3>();
    private GameObject _gameFild;

    private void Awake()
    {
        _gameFild =GameObject.Find("GameFild");

        for (int i = 0; i < _gameFild.transform.childCount; i++)
        {
            _сhildPosition.Add(_gameFild.transform.GetChild(i).position);
        }
    }

    public void RePlacingChips()
    {
        int i = 0;
        foreach (Transform child in _gameFild.transform)
            child.position = _сhildPosition[i++];
    }
}