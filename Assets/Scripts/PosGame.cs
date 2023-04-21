using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGame : MonoBehaviour
{
    void CalculateScore()
    {
        GameObjectManager.Instance.GetUserPos();
        int score = GameObjectManager.Instance.CalculateScore();
        GameObjectManager.Instance.SetTxtOnHUD("el puntaje final fue: " + score,
            "Tiempo: 00 segundos");
    }

    #region EventSuscription
    private void OnEnable()
    {
        Gameplay.OnTimeOut += CalculateScore;
    }
    private void OnDisable()
    {
        Gameplay.OnTimeOut -= CalculateScore;
    }
    #endregion
}
