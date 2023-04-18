using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucheable : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameplayManager.Instance.SetSelectorPos(this.gameObject);
    }
}