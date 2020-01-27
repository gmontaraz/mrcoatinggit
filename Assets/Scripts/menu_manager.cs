using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_manager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause_menu.SetActive(true);
            Game_hud.SetActive(false);
            Time.timeScale = 0;
        }

    }
    public void Continue()
    {
        Debug.Log("Continue");
        Time.timeScale = 1;
        
        Pause_menu.SetActive(false);
        Game_hud.SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Time.timeScale = 1;

        Pause_menu.SetActive(false);
        Game_hud.SetActive(false);
        Destroy(FindObjectOfType<singleton>().gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public GameObject Pause_menu;
    public GameObject Game_hud;
}
