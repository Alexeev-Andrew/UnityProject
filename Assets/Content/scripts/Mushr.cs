using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushr : Collectable {

    protected override void OnRabitHit(HeroRabbit rabit)
    {
        ObjectsInLevel.current.addMushr(1);
        if (!rabit.isBigg())
        {
            rabit.setBig(true);
            Vector3 currSize = rabit.transform.localScale;
            rabit.transform.localScale = new Vector3(currSize.x * 1.5f, currSize.y * 1.5f, 0);
        }

        this.CollectedHide();
    }
}
