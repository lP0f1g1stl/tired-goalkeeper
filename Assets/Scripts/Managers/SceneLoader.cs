using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button[] _restartButtons;

    private void OnEnable()
    {
        for(int i = 0; i < _restartButtons.Length; i++) 
        {
            _restartButtons[i].onClick.AddListener(ReloadScene);
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _restartButtons.Length; i++)
        {
            _restartButtons[i].onClick.RemoveListener(ReloadScene);
        }
    }
    private void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
