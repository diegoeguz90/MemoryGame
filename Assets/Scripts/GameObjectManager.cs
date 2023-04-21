using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameObjectManager : MonoBehaviour
{
    // singleton instance
    public static GameObjectManager Instance { get; private set; }
    // cache variables
    [SerializeField] TMP_Text timetxt, msjTxt;
    [SerializeField] GameObject Menu, HUD;
    // variables
    public GameObject[] grabables;
    public Vector3[] initPos, finalPos, userPos;
    private int n;

    private void Awake()
    {
        // this if for singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;

        Menu.SetActive(false);

        grabables = GameObject.FindGameObjectsWithTag("Grabable");
        n = grabables.Length;
        initPos = new Vector3[n];
        finalPos = new Vector3[n];
        userPos = new Vector3[n];
        SetInitialPos();
    }
    private void SetInitialPos()
    {
        for(int i=0; i<n; i++)
        {
            this.initPos[i] = this.grabables[i].transform.position;
            this.finalPos[i] = this.initPos[i];
        }
    }
    public void SetGrabablesPos(Vector3[] pos)
    {
        for (int i = 0; i < n; i++)
        {
            this.grabables[i].transform.position = pos[i];
        }
    }
    public void GetUserPos()
    {
        for (int i = 0; i < n; i++)
        {
            this.userPos[i] = this.grabables[i].transform.position;
        }
    }
    public void ShuffleInitialPos()
    {
        System.Random _random = new System.Random();
        for(int i = n - 1; i > 0; i--)
        {
            int randIndex = _random.Next(0, i);
            Vector3 vectorTemp = this.initPos[randIndex];
            this.initPos[randIndex] = this.initPos[i];
            this.initPos[i] = vectorTemp;
        }
    }
    public void ShuffleFinalPos()
    {
        System.Random _random = new System.Random();
        for (int i = n - 1; i > 0; i--)
        {
            int randIndex = _random.Next(0, i);
            Vector3 vectorTemp = this.finalPos[randIndex];
            this.finalPos[randIndex] = this.finalPos[i];
            this.finalPos[i] = vectorTemp;
        }
    }
    public int CalculateScore()
    {
        int score = 0;
        for(int i=0; i<n; i++)
        {
            if (this.userPos[i] == this.initPos[i])
                score++;
        }
        Menu.SetActive(true);
        return score;
    }
    public void SetTxtOnHUD(string message, string time)
    {
        this.timetxt.text = time;
        this.msjTxt.text = message;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("DesktopGame");
    }
}
