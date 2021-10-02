using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationToGame : MonoBehaviour
{
    public StateController StateController;

    public void Click()
    {
        StateController.SetStateToGame();
    }
}
