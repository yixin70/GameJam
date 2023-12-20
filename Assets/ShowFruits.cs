using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowFruits : MonoBehaviour
{
    public List<FruitData> fruits;
    public List<Text> texts;
   
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fruits.Count; i++)
        {
            texts[i].text = fruits[i].count.ToString();
        }
       
        
        
    }
}
