using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GameController: Singleton<GameController>
{
    public GameObject activeCheckpoint;

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

}
