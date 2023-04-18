using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // singleton instance
    public static GameplayManager Instance { get; private set; }
    // cache variables
    [SerializeField] GameObject Selector;
    // states of game
    enum State
    {
        Selection,
        ChangePlaces
    }
    State currentState = State.Selection;
    // variables
    // Vector3 lastPos = new Vector3();
    GameObject selectedGameObject;

    private void Awake()
    {
        // this if for singleton
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetSelectorPos(GameObject selectedObject)
    {
        Vector3 pos = selectedObject.transform.position;

        if (currentState == State.Selection)
        {
            float zPos = 0.005f;
            pos.z = zPos;
            Selector.gameObject.SetActive(true);
            Selector.transform.position = pos;
            selectedGameObject = selectedObject;
            currentState = State.ChangePlaces;
        }
        else if(currentState == State.ChangePlaces)
        {
            Vector3 tempPos = selectedGameObject.transform.position;
            selectedGameObject.transform.position = pos;
            selectedObject.transform.position = tempPos;
            Selector.gameObject.SetActive(false);
            currentState = State.Selection;
        }
    }
}
