using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour {

    [SerializeField]
    private GameObject winPanel;

    void startWaiting()
    {
        StartCoroutine(open());
    }


    IEnumerator open()
    {
        yield return new WaitForSeconds(0.5f);
        winPanel.SetActive(true);
    }

    void disableRabbit(HeroRabbit rabit)
    {
        StartCoroutine(dsbl(rabit));
       
    }

    IEnumerator dsbl(HeroRabbit rabit)
    {
        yield return new WaitForSeconds(0.2f);
        rabit.GetComponent<HeroRabbit>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        HeroRabbit rabit = collider.GetComponent<HeroRabbit>();
        if (rabit != null)
        {
            disableRabbit(rabit);
            startWaiting();
        }
    }
}
