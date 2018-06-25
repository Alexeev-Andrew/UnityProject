using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldRenderer : MonoBehaviour {

    public Text coinsLabel;

    void Awake () {
		setCoins(PlayerPrefs.GetInt("coins", 0));
	}

    public void setCoins(int n)
    {
        coinsLabel.text = "" + (n > 9 ? "" : "0") + (n > 99 ? "" : "0") + (n > 999 ? "" : "0") + n;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
