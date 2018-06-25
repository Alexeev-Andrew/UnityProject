using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {
    public AudioClip audio;
    protected override void OnRabitHit(HeroRabbit rabit)
    {
        AudioSource.PlayClipAtPoint(audio, transform.position);
        ObjectsInLevel.current.addFruit(1);
        this.CollectedHide();
    }
}
