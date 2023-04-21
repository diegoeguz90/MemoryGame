using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucheable : MonoBehaviour
{
    private bool isToucheable = true;
    private void OnMouseDown()
    {
        if (isToucheable)
        {
            Debug.Log("touched!");
            isToucheable = false;
            InteractionManager.Instance.SetSelectorPos(this.gameObject);
            StartCoroutine("FreezeTime");
        }
    }
    IEnumerator FreezeTime()
    {
        yield return new WaitForSeconds(0.5f);
        isToucheable = true;
    }
}