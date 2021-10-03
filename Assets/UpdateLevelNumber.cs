using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLevelNumber : MonoBehaviour
{
    public int Number;

    private void Start()
    {
        if (SavedData.Load("LevelNumber", 0) < Number)
        {
            SavedData.Save("LevelNumber", Number);
            SavedData.SaveAll();
        }
    }
}
