using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationButton : MonoBehaviour
{
    public TextButton TextButton;
    [HideInInspector]
    public ConversationController Controller;
    [HideInInspector]
    public int ID;

    private void Reset()
    {
        TextButton = GetComponent<TextButton>();
    }

    public void Click()
    {
        Controller.Select(ID);
    }
}
