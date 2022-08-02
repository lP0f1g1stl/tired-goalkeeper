using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ChangeTimerText(int minutes, int seconds) 
    {
        string text = string.Format("{0:00}:{1:00}", minutes, seconds);
        _text.text = text;
    }
}
