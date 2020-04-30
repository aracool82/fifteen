using TMPro;
using UnityEngine;

public class SaveAndLoadResult : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestTimeResult;
    [SerializeField] private ShowTime _showTime;

    private int _sevedSecond;

    private void Start()
    {
        if(PlayerPrefs.HasKey("Result"))
            _bestTimeResult.text = "Лучшее время :" + FormatTime(PlayerPrefs.GetInt("Result"));
    }

    public void Load()
    {
        var text = "Лучшее время :";
        if (PlayerPrefs.HasKey("Result"))
        {
            _sevedSecond = PlayerPrefs.GetInt("Result");
            if (_sevedSecond > _showTime.SumSecond)
            {
                text += FormatTime(_showTime.SumSecond);
                PlayerPrefs.SetInt("Result", _showTime.SumSecond);
                PlayerPrefs.Save();
            }
            else
            {
                text += FormatTime(_sevedSecond);
            }
        }
        else //если сохранения нету в реестре
        {
            PlayerPrefs.SetInt("Result", _showTime.SumSecond);
            PlayerPrefs.Save();
            text += FormatTime(_showTime.SumSecond);
        }
        _bestTimeResult.text = text;
    }

    private string FormatTime(int sumSecond)
    {
        var minute = sumSecond / 60;
        var second = sumSecond % 60;
        return $" {minute.ToString()}m : {second.ToString()}c";
    }

    public void DeleteKeyResult()
    {
        PlayerPrefs.DeleteKey("Result");
    }
}


