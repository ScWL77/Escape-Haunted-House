using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    //loading screen - the loading screen
    //sceneName - string of the first level's name

    public GameObject loadingscreen,controlObj,menuObj;
    public string sceneName,sceneName2;
    public Button continueButton;

    void Start() // when player is back to main menu, their cursor will be visible and can be moved
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update() //if the playerprefs level int equals 0, the continue button will be disabled
    {
        if (PlayerPrefs.GetInt("level") == 0)
        {
            continueButton.interactable = false;
        }
    }

    public void playGame() //when u click on the play button, the loading screen will show up and the first level will load
    {
        loadingscreen.SetActive(true);
        PlayerPrefs.SetInt("level", 1); //set the playerprefs level int to 1 when starting a new game
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }

    public void controlMenu()
    {
        menuObj.SetActive(false);
        controlObj.SetActive(true);
    }

    public void continueGame() // when continue button is pressed, the last level you played will be loaded depending on what the playerpref level int equals to 
    {
        loadingscreen.SetActive(true);
        if (PlayerPrefs.GetInt("level", 2) == 2)
        {
            SceneManager.LoadScene(sceneName2);
        }
        if (PlayerPrefs.GetInt("level", 1) == 1)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void quitGame() //when u click on the quit button, the game will quit
    {
        Debug.Log("This will quit the game.");
        Application.Quit();
    }

    public void backToMenu()
    {
        controlObj.SetActive(false);
        menuObj.SetActive(true);
    }
}
