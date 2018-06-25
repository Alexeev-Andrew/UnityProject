using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour {

    [SerializeField]
    private GameObject settingsPanel;

    public void settings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
