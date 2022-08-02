using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenHandler : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    public void ShowWinScreen() 
    {
        _winScreen.SetActive(true);
    }
    public void ShowLoseScreen() 
    {
        _loseScreen.SetActive(true);
    }
}
