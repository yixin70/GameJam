using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Consume : MonoBehaviour
{
    private InputActions consumeAction;
    private PlayerController playerController;
    private PlayerCollision playerCollision;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerCollision = GetComponent<PlayerCollision>();
        consumeAction = playerController.inputActions;
        consumeAction.Consume.Consume1.started += Consume1;
        consumeAction.Consume.Consume2.started += Consume2;
        consumeAction.Consume.Consume3.started += Consume3;
    }
    

    private void Consume3(InputAction.CallbackContext context) // Strawberry Become Normal
    {
        ConsumeFruit(FruitType.Strawberry);
    }

    private void Consume2(InputAction.CallbackContext context) // Banana Become small
    {
        ConsumeFruit(FruitType.Banana);
    }

    private void Consume1(InputAction.CallbackContext context) //Apple Become Big
    {
        ConsumeFruit(FruitType.Apple);
    }
    private void ConsumeFruit(FruitType type)
    {
        foreach (FruitData fruit in playerCollision.fruitList) {
            if (fruit.type==type&&fruit.count>0)
            {
                fruit.count--;
                Debug.Log("Consume: " + fruit.type);
                playerController.ChangScale(fruit.power);
            }
        }
    }
}

