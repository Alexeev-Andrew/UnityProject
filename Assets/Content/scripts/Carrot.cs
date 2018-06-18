using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable {

    public float speed = 1;
	// Use this for initialization
	void Start () {
        StartCoroutine(destroyLater());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnRabitHit(HeroRabbit rabit)
    {
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


    public void launch(float direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction*speed, 0);
        if (direction < 0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
    

}
