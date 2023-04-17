using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] float waitTime = 30.0f;

    // event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;

    // Start is called before the first frame update
    void GameBegin()
    {
        StartCoroutine("CountDown");
    }

    // Count down routine
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        OnTimeOut(); // event
    }

    #region EventSuscription
    private void OnEnable()
    {
        PreGame.OnTimeOut += GameBegin;
    }
    private void OnDisable()
    {
        PreGame.OnTimeOut -= GameBegin;
    }
    #endregion
}
