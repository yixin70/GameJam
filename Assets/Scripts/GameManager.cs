using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject activeCheckpoint;
    public GameObject player;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player.transform.position = activeCheckpoint.transform.position;
    }

    public void Update()
    {
        // Si pulsamos escape abrir menu.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }
    }
    // Activa un checkpoint y desactiva el anterior.
    public void ActivateCheckpoint(GameObject newCheckpoint)
    {
        // Si había un checkpoint antiguo lo desactivamos.
        if (activeCheckpoint)
        {
            activeCheckpoint.GetComponent<Checkpoint>().Deactivate(); 
        }
        // Marcamos el checkpoint como activo.
        activeCheckpoint = newCheckpoint;
        activeCheckpoint.GetComponent<Checkpoint>().Activate();
    }

    // Finaliza el juego.
    public void FinishGame()
    {
       // TODO: Implementar
    }

}
