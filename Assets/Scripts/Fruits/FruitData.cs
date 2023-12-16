using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableFruit", menuName = "ScriptableObjects/ScriptableFruits")]
public class FruitData :ScriptableObject 
{
    public FruitType type;
    public int count;
    public float power;
    public float score;

    public override string ToString()
    {
        return "Fruit: "+ type + " Count: " + count +" Power: "+ power +" Score: "+score;
    }
}
public enum FruitType
{
    Apple,Banana,Strawberry
}

