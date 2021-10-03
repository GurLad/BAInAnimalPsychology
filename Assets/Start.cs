using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public string Level1;
    public GameObject Menu;
    public GameObject LevelSelect;

    public void Click()
    {
        if (SavedData.Load("LevelNumber", 0) > 0)
        {
            LevelSelect.SetActive(true);
            Menu.SetActive(false);
        }
        else
        {
            SceneLoader.LoadScene(Level1);
        }
    }
}
