using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public MapManager mapManager;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        audioSource.Play();
    }
    public void StartGame()
    {
        audioSource.Stop();
        audioSource.Play();
        SceneManager.LoadScene(1);
    }

    public void Update()
    {
        // Si pulsamos escape abrir menu.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }
   

    // Finaliza el juego.
    public void FinishGame()
    {
        SceneManager.LoadScene(2);
    }

}
