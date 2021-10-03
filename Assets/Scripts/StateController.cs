using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private static string state;
    private static StateController current;
    private static Vector3 checkpointPos = Vector3.zero;
    private static Vector3 checkpointRot = Vector3.zero;

    public string LevelName;
    public AnimalController Player;
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
        else
        {
            CrossfadeMusicPlayer.Instance.Play(LevelName + "Convo");
        }
    }

    public void SetStateToGame()
    {
        state = LevelName;
        ConversationObjects.ForEach(a => a.SetActive(false));
        GameObjects.ForEach(a => a.SetActive(true));
        CrossfadeMusicPlayer.Instance.Play(LevelName + "Game");
        Debug.Log(checkpointPos);
        if (checkpointPos != Vector3.zero)
        {
            Player.transform.position = new Vector3(checkpointPos.x, Player.transform.position.y, checkpointPos.z);
            Player.Rotation = checkpointRot;
        }
    }

    public static void Lose()
    {
        current.GameOver.SetActive(true);
    }

    public static void RegisterCheckpoint(Vector3 pos, Vector3 rotation)
    {
        checkpointPos = pos;
        checkpointPos.y = 1;
        checkpointRot = rotation;
        Debug.Log(checkpointPos);
    }
}
