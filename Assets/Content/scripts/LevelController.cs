using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    Vector3 startPosition;//= new Vector3(0, 0);

    void Awake()
    {
        current = this;
    }

    public void onRabitDeath(HeroRabbit rabbit)
    {
        rabbit.transform.position = this.startPosition;
    }

    public void setStartPosition(Vector3 position)
    {
        this.startPosition = position;
    }
}