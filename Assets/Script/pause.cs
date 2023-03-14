using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class pause : MonoBehaviour
{
    public GameObject pausemenu; // the pause menu
    public string sceneName; //the name of the main menu
    public bool toggle; // determines whether game is paused or not
    public FirstPersonController playerScript; // the player's script

    void Update() // when they press escape, toggle will equal to the opposite of what toggle is and depending on true/false, the pause menu will show up or disappear
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if (toggle == false)
            {
                pausemenu.SetActive(false);
                AudioListener.pause = false;
                Time.timeScale = 1;
                playerScript.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (toggle == true)
            {
                pausemenu.SetActive(true);
                AudioListener.pause = true;
                Time.timeScale = 0;
                playerScript.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void resumeGame() // when u press resume button, the game will unpause and the pause menu will disappear
    {
        toggle = false;
        pausemenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
        playerScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void quitToMenu() // when the quit to menu button is pressed, the game will quit to the main menu scene
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneName);
    }
    public void quitToDesktop() // if you press to desktop button, the game will quit to your desktop
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Debug.Log("the game will quit");
        Application.Quit();
    }
}
