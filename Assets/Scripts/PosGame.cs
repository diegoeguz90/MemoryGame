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
        Gameplay.OnTimeOut += CalculateScore;
    }
    private void OnDisable()
    {
        Gameplay.OnTimeOut -= CalculateScore;
    }
    #endregion
}
