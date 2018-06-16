using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInLevel : MonoBehaviour {

    public static ObjectsInLevel current;
    int coins;
    int crystals;
    int fruit;
    int mushr;

    void Awake()
    {
        current = this;
    }

    public void addCoins(int n)
    {
        coins += n;
    }
    public void addCrystals(int n)
    {
        crystals += n;
    }
    public void addMushr(int n)
    {
        mushr += n;
    }
    public void addFruit(int n)
    {
        fruit += n;
    }


}
