using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    public List<FruitData> fruitList; 

    // Use this for initialization
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            FruitController fruitController = collision.gameObject.GetComponent<FruitController>();
            Debug.Log(fruitController.fruitType);
            this.CollectFruit(fruitController);
        } 

    }
    private void CollectFruit(FruitController fruitController)
    {
        foreach (FruitData fruit in fruitList)
        {
            if (fruit.type == fruitController.fruitType)
            {
                fruit.count++;
                fruitController.CollectFruit();
                Debug.Log(fruit.ToString());
            }
        }
    }

}
