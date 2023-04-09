using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public bool canMove = false;
    public bool isAlive = false;
    public bool DisabledCollision = false;
    float delayLoading = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameStarter();
    }

    private void Update()
    {
        BtnGameControll();
    }

    void GameStarter ()
    {
        canMove = true;
        isAlive = true;
    }

    public void DelayCall(string status)
    {
        canMove = false;
        isAlive = false;
        switch (status)
        {
            case "Finish":
                Invoke("NextLevel", delayLoading);
                break;
            case "Obstacle":
                Invoke("ReloadLevel", delayLoading);
                break;
        }
    }

    void BtnGameControll()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReloadLevel();
        }else if (Input.GetKeyDown(KeyCode.C))
        {
            DisabledCollision = !DisabledCollision;
        }
    }

    public void NextLevel ()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        int nextLevel;
        nextLevel = level + 1;
        if (nextLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
    }

    public void ReloadLevel()
    {
        int IndexActiveScene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.GetActiveScene().buildIndex to get active scene index 
        SceneManager.LoadScene(IndexActiveScene);
    }

}
