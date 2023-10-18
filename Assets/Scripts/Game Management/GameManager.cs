using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Item> GameItems;
    public bool isGameOver;

    public static GameManager Instance;

    public bool isGravityOverriden;
    public float gravityMultiplier;

    public bool isHarnessOn = false;
    public bool isXRGrabOverriden;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Start()
    {
        if (isGravityOverriden)
        {
            Physics.gravity = new Vector3(0,-9.81f * gravityMultiplier, 0);
        }
        Debug.Log($"{gameObject.name}: Gravity={Physics.gravity}");
    }

    public bool ItemExists(string id)
    {
        try
        {
            return GameItems.Find(x => x.id == id);
        }
        catch
        {
            return false;
        }
        
    }

    public void GameOver(GameOverCause cause)
    {
        switch (cause)
        {
            case GameOverCause.TimeOver:
                FindObjectOfType<SceneTransition>().ChangeScene(2, "GameOverScene");
                break;

            case GameOverCause.AmberCollected:
                FindObjectOfType<SceneTransition>().ChangeScene(4, "GameOverSceneWin");
                break;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"{scene.name}");

        if(scene.name == "GameOverScene" || scene.name== "GameOverSceneWin")
        {
            isGameOver = true;
        }

        if (isGravityOverriden)
        {
            Physics.gravity = new Vector3(0, -9.81f * gravityMultiplier, 0);
        }
    }
}

public enum GameOverCause
{
    TimeOver,
    AmberCollected
}
[System.Serializable]
public struct GameOverStruct
{
    public GameObject timeOverCanvas;
    public GameObject amberCollectedCanvas;
}
