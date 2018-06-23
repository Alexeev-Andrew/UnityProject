using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour {

	public void start()
    {
        SceneManager.LoadScene("chooseLevelScene");
    }
}
