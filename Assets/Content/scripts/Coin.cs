using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public AudioClip audio;
    protected override void OnRabitHit(HeroRabbit rabit)
    {
        AudioSource.PlayClipAtPoint(audio,transform.position);
        ObjectsInLevel.current.addCoins(1);
        this.CollectedHide();
    }
}
