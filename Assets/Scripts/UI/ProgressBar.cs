using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    public void ChangeProgressBar(int current, int max)
    {
        _progressBar.fillAmount = (float)current / max;
    }
}
