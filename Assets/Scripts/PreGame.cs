using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGame : MonoBehaviour
{
    [SerializeField] float waitTime = 5.0f;

    // event
    public delegate void TimeOut();
    public static event TimeOut OnTimeOut;

    // Start is called before the first frame update
    void Start()
    {
        GameObjectManager.Instance.ShuffleInitialPos();
        GameObjectManager.Instance.SetGrabablesPos(GameObjectManager.Instance.initPos);
        StartCoroutine("CountDown");
    }

    // Count down routine
    IEnumerator CountDown()
    {
        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            GameObjectManager.Instance.SetTxtOnHUD("Rápido, memoriza las posiciones iniciales!",
                "Tiempo: " + waitTime.ToString("F0") + " segundos");
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        OnTimeOut(); // event
    }
}
