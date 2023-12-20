using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHearth : MonoBehaviour
{
    private PlayerController controller;
    private Text text;

    private void Start()
    {
        text=GetComponent<Text>();
        controller = MapManager.Instance.player.GetComponent<PlayerController>();
    }
    void Update()
    {
       text.text=controller.health.ToString();
    }
}
