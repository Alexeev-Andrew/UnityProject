using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsInLevel : MonoBehaviour {

    public static ObjectsInLevel current;
    int coins;
    int crystals;
    int fruit;
    int mushr;
    int lives;

    void Awake()
    {
        current = this;
        lives = 3;
        coins = LevelController.current.amountOfGold();
        fruit = 0;
        crystals = 0;
        mushr = 0;
    }

    public void addCoins(int n)
    {
        coins += n;
        LevelController.current.addCoins(n);
        changeLevelStatistic.current.setCoins(coins);
    }
    public void addCrystal(Sprite s)
    {
        crystals += 1;
        changeLevelStatistic.current.addCrystal(s, crystals);
    }
    public void addMushr(int n)
    {
        mushr += n;
    }
    public void addFruit(int n)
    {
        fruit += n;
        changeLevelStatistic.current.setFruit(fruit);
    }

    public void decrementLifes()
    {
        --lives;
        if(lives>0)
            changeLevelStatistic.current.setLifes(lives);
        else
            SceneManager.LoadScene("chooseLevelScene");
    }

}
