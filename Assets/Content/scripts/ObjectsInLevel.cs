using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectsInLevel : MonoBehaviour {

    public int level = 1;

    public static ObjectsInLevel current;
    int coins;
    int crystals;
    int fruit;
    public int allFruit = 11;
    int mushr;
    int lives;

    public LevelStat Stats;

    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private Image[] cr;

    void Awake()
    {
        current = this;

        string str = PlayerPrefs.GetString("stats"+level.ToString(), null);
        this.Stats = JsonUtility.FromJson<LevelStat>(str);
        if (Stats == null)
        {
            this.Stats = new LevelStat();
        }

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
        if (crystals == 3) Stats.hasCrystals = true;
    }
    public int getCrystals()
    {
        return crystals;
    }
    public void addMushr(int n)
    {
        mushr += n;
    }
    public void addFruit(int n)
    {
        fruit += n;
        changeLevelStatistic.current.setFruit(fruit);
        if (fruit == allFruit) Stats.hasAllFruits = true;
    }

    public void decrementLifes()
    {
        --lives;
        if (lives > 0)
            changeLevelStatistic.current.setLifes(lives);
        else
        {  //SceneManager.LoadScene("chooseLevelScene");
            losePanel.SetActive(true);
            Image[] im = changeLevelStatistic.current.getCrystals();
            for (int i = 0; i < 3; i++)
            {
                cr[i].GetComponent<Image>().sprite = im[i].GetComponent<Image>().sprite;
            }
        }
    }


    private void OnDestroy()
    {
        Debug.Log("onDestroy");
        LevelController.current.saveCoins();
        string str = JsonUtility.ToJson(Stats);
        PlayerPrefs.SetString("stats" + level, str);
        PlayerPrefs.Save();
    }

}
