using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLevelStatistic : MonoBehaviour {

    public static changeLevelStatistic current;

    public Text coinsLabel;
    public Text fruitLabel;
    public Image[] lifesImages;
    public Sprite redLife;
    public Sprite emptyLife;

    public Image[] crystals;

    public void Awake()
    {
        current = this;
        setCoins(LevelController.current.amountOfGold());
    }
    	
	public void setCoins(int n)
    {
        coinsLabel.text = ""+ (n > 9 ? "" : "0") + (n > 99 ? "" : "0") + (n > 999 ? "" : "0")+n;
    }

    public void setFruit(int n)
    {
        fruitLabel.text = n + "/11";
    }

    public void setLifes(int n)
    {
        for(int i=0;i<n;i++)
            lifesImages[i].GetComponent<Image>().sprite = redLife;
        for(int i=n;i<3;i++)
            lifesImages[i].GetComponent<Image>().sprite = emptyLife;
    }

    public void addCrystal(Sprite sprite,int position)
    {
        crystals[--position].GetComponent<Image>().sprite = sprite;
    }

    public Image[] getCrystals()
    {
        return crystals;
    }

    public Text getCoinsText()
    {
        return coinsLabel;
    }
    public Text getFruitsText()
    {
        return fruitLabel;
    }
}
