using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openLevel : MonoBehaviour {

    public int level=1;

    void startWaiting()
    {
        StartCoroutine(open());
    }


    IEnumerator open()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Scene" + level);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
        if (rabit != null)
        {
            startWaiting();
        }
    }


}
