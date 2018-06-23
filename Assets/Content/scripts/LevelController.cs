using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController current;

    int gold;

    void Awake()
    {
        current = this;
        Debug.Log("start");
        gold = 0;
    }

    public void onRabitDeath(HeroRabbit rabbit)
    {
        ObjectsInLevel.current.decrementLifes();
        rabbit.onRabbitDeath();
    }

    public void addCoins(int n)
    {
        Debug.Log("add coin");
        gold += n;
        Debug.Log(gold);
    }

    public int amountOfGold()
    {
        Debug.Log(gold);
        return gold;
    }

}