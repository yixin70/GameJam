using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Startgame(){
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene(){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
}
