using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinDoor : MonoBehaviour {

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private Image[] crystals;

    [SerializeField]
    private Text fruits;

    [SerializeField]
    private Text coins;

    void startWaiting()
    {
        StartCoroutine(open());
    }


    IEnumerator open()
    {
        yield return new WaitForSeconds(0.5f);
        winPanel.SetActive(true);
        Image[] im = changeLevelStatistic.current.getCrystals();
        for(int i = 0; i < 3; i++)
        {
            crystals[i].GetComponent<Image>().sprite = im[i].GetComponent<Image>().sprite;
        }
        coins.text = changeLevelStatistic.current.getCoinsText().text;
        fruits.text = changeLevelStatistic.current.getFruitsText().text;
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
