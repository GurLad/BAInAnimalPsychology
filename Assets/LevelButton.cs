using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int ID;

    private void Start()
    {
        if (SavedData.Load("LevelNumber", 0) < ID)
        {
            Destroy(gameObject);
        }
    }
}
