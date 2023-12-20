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

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Update()
    {
        // Si pulsamos escape abrir menu.
    }

    // Finaliza el juego.
    public void FinishGame()
    {
        SceneManager.LoadScene(2);
    }

}
