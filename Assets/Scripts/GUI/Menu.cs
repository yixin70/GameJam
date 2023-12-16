using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public GameObject menuList;

    [SerializeField]
    private bool menukeys = false;


    // Update is called once per frame
    void Update()
    {
        if(menukeys){
            if(Input.GetKeyDown(KeyCode.Escape)){
                menuList.SetActive(true);
                menukeys = false;
                Time.timeScale = 0;
            }
        }else if(Input.GetKeyDown(KeyCode.Escape)){
            menuList.SetActive(false);
            menukeys = true;
            Time.timeScale = 1;
        }
    }

    public void Return(){
        menuList.SetActive(false);
        menukeys = true;
        Time.timeScale = 1;
    }

    public void Restart(){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void Exit(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void quit(){
        Application.Quit();
    }

}
