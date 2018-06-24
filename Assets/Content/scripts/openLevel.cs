using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openLevel : MonoBehaviour {

    public int level=1;

    [SerializeField]
    private GameObject crystals;

    [SerializeField]
    private GameObject fruits;

    [SerializeField]
    private GameObject isBlock;

    public Sprite crystal;
    public Sprite fruit;
    public Sprite locked;

    bool isLocked;

    public void Awake()
    {
        string str = PlayerPrefs.GetString("stats" + level.ToString(), null);
        LevelStat Stats = JsonUtility.FromJson<LevelStat>(str);
        if (Stats == null)
        {
            Stats = new LevelStat();
        }
        if (Stats.hasCrystals) crystals.GetComponent<SpriteRenderer>().sprite = crystal;
        if (Stats.hasAllFruits) fruits.GetComponent<SpriteRenderer>().sprite = fruit;    
    }

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
