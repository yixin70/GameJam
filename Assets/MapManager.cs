using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public GameObject activeCheckpoint;
    public GameObject player;

    public override void Awake()
    {
        base.Awake();
        GameManager.Instance.mapManager = this; 
        player=Instantiate(GameManager.Instance.player);
        player.transform.position = activeCheckpoint.transform.position;
       
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
}
