using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationToGame : MonoBehaviour
{
    public List<GameObject> ConversationObjects;
    public List<GameObject> GameObjects;

    public void Click()
    {
        ConversationObjects.ForEach(a => a.SetActive(false));
        GameObjects.ForEach(a => a.SetActive(true));
    }
}
