using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public void StartRemoveTimer() 
    {
        StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
