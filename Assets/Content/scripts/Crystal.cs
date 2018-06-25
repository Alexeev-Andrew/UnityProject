using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {

    public AudioClip audio;

    protected override void OnRabitHit(HeroRabbit rabit)
    {
        AudioSource.PlayClipAtPoint(audio, transform.position);
        ObjectsInLevel.current.addCrystal(GetComponent<SpriteRenderer>().sprite);
        this.CollectedHide();
    }
}
