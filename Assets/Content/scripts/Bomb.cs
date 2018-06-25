using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

    public AudioClip audio;

    protected override void OnRabitHit(HeroRabbit rabit)
    {
        AudioSource.PlayClipAtPoint(audio, transform.position);
        if (rabit.isBigg())
        {
            rabit.setBig(false);
            Vector3 currSize = rabit.transform.localScale;
            rabit.transform.localScale = new Vector3(currSize.x / 1.5f, currSize.y / 1.5f, 0);
        }
        else
        {
            rabit.GetComponent<Animator>().SetBool("isDie", true);
        }
        this.CollectedHide();
    }

}
