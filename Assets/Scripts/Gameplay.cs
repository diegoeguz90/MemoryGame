using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] float waitTime = 30.0f;

    // event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;

    // Start is called before the first frame update
    void GameBegin()
    {
        GameObjectManager.Instance.ShuffleFinalPos();
        GameObjectManager.Instance.SetGrabablesPos(GameObjectManager.Instance.finalPos);
        StartCoroutine("CountDown");
    }

    // Count down routine
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameObjectManager.Instance.SetTxtOnHUD("Vuelve a poner todo en su lugar!",
                "Tiempo: " + waitTime.ToString("F0") + " segundos");
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
