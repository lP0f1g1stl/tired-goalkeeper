using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    public void ChangeText(string text) 
    {
        _text.text = text;
    }
}
