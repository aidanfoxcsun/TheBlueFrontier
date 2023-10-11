using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioManager audioManager;
    DebugManager debugManager;

    public GameObject map;
    public GameObject uiText;
    public GameObject crosses;
    public GameObject gameOver;
    public GameObject loading;
    public GameObject mainMenu;
    public GameObject victory;
    public GameObject failure;


    public bool paused = true;
    public bool checkFailed = false;

    public List<GameObject> islandLocations;
    public List<IslandType> islandTypes;
    public List<GameObject> mapSlots;
    public List<IslandType> slotTypes;

    public bool mapEnabled;


    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DebugManager.instance.enableRuntimeUI = false;

    }

    private void Start()
    {
        map.SetActive(true);
        audioManager = AudioManager.instance;
        for (int i = 0; i < 8; i++)
        {
            islandLocations.Add(GameObject.Find("SpawnPoint" + i));
            mapSlots.Add(GameObject.Find("MapSlot" + i));
        }
        for (int i = 0; i < mapSlots.Count; i++)
        {
            slotTypes.Add(IslandType.Null);
        }
        ResumeGame();
        loading.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            mainMenu.SetActive(false);
        }
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape))
            {
                audioManager.PlayPaperSound();
                mapEnabled = !mapEnabled;
            }
            map.SetActive(mapEnabled);
            uiText.SetActive(!mapEnabled);
            if (islandTypes.Count <= 0)
            {
                FillTypes();
            }
        }
    }

    private void FillTypes()
    {
        for (int i = 0; i < islandLocations.Count; i++)
        {
            if (islandLocations[i].transform.childCount > 0)
            {
                islandTypes.Add(islandLocations[i].GetComponentInChildren<Island>().type);
            }
            else
            {
                islandTypes.Add(IslandType.Null);
            }
        }

    }

    public void FillSlotTypes()
    {
        slotTypes.Clear();
        for (int i = 0; i < mapSlots.Count; i++)
        {
            if (mapSlots[i].transform.childCount > 0)
            {
                slotTypes.Add(mapSlots[i].GetComponentInChildren<Island>().type);
            }
            else
            {
                slotTypes.Add(IslandType.Null);
            }
        }
    }

    public void CheckWinCondition()
    {
        for(int i = 0; i < slotTypes.Count; i++)
        {
            if (slotTypes[i] == islandTypes[i])
            {
                Debug.Log("Check " + i + " passed");
            }
            else
            {
                crosses.GetComponent<UICrosses>().crosses[i].SetActive(true);
                Debug.Log("Check " + i + " failed!");
                checkFailed = true;

            }
                
        }
        if (!checkFailed)
        {
            audioManager.Victory();
            victory.SetActive(true);
        }
        else
        {
            audioManager.Failure();
            failure.SetActive(true);
        }
    }

    public void GameOver()
    {
        audioManager.Failure();
        PauseGame();
        gameOver.SetActive(true);
    }

    public void PauseGame()
    {
        paused = true;
    }

    public void ResumeGame()
    {
        paused = false;
        gameOver.SetActive(false);
    }

    public void Reload()
    {
        audioManager.PlayPaperSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        loading.SetActive(true);
        ResumeGame();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

}
