using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // singleton instance
    public static InteractionManager Instance { get; private set; }
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

    public void SetSelectorPos(GameObject touchedGameObject)
    {
        switch (currentState)
        {
            case State.Selection:
                ShowSelector(touchedGameObject);
                break;
            case State.ChangePlaces:
                ChangePlaces(touchedGameObject);
                break;
        }
    }
    public void ShowSelector(GameObject touchedGameObject)
    {
        Vector3 pos = touchedGameObject.transform.position;
        float zPos = 0.005f;
        pos.z = zPos;
        Selector.gameObject.SetActive(true);
        Selector.transform.position = pos;
        selectedGameObject = touchedGameObject;
        currentState = State.ChangePlaces;
    }
    public void ChangePlaces(GameObject touchedGameObject)
    {
        Selector.gameObject.SetActive(false);
        Vector3 pos = touchedGameObject.transform.position;
        Vector3 tempPos = selectedGameObject.transform.position;
        selectedGameObject.transform.position = pos;
        touchedGameObject.transform.position = tempPos;
        currentState = State.Selection;
    }
}
