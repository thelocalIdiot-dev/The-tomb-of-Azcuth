using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class mainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject settings;
    public GameObject levelSelectMenu;

    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0;i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    void Start()
    {
        main.SetActive(true);
        settings.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void returnToMain()
    {
        main.SetActive(true);
        settings.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void goToSettings()
    {
        main.SetActive(false);
        settings.SetActive(true);
        levelSelectMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void selectLevel(int level)
    {
        SceneLoader.instance.loadScene(level);
    }

    public void openLevelSelectScreen()
    {
        main.SetActive(false);
        settings.SetActive(false);
        levelSelectMenu.SetActive(true);
    }


    [ContextMenu("clear saves")]
    public void clearSaves()
    {
        PlayerPrefs.GetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        SceneLoader.instance.loadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
