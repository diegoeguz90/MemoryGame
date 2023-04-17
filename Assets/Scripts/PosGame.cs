using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosGame : MonoBehaviour
{
    void CalculateScore()
    {

    }

    #region EventSuscription
    private void OnEnable()
    {
        Game.OnTimeOut += CalculateScore;
    }
    private void OnDisable()
    {
        Game.OnTimeOut -= CalculateScore;
    }
    #endregion
}
