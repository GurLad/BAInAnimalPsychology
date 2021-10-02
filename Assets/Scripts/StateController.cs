using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private static string state;
    private static StateController current;

    public string LevelName;
    [Header("Objects")]
    public List<GameObject> ConversationObjects;
    public List<GameObject> GameObjects;
    public GameObject GameOver;

    private void Start()
    {
        current = this;
        if (state == LevelName)
        {
            SetStateToGame();
        }
    }

    public void SetStateToGame()
    {
        state = LevelName;
        ConversationObjects.ForEach(a => a.SetActive(false));
        GameObjects.ForEach(a => a.SetActive(true));
    }

    public static void Lose()
    {
        current.GameOver.SetActive(true);
    }
}
