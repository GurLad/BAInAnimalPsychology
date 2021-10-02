using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextButton : MonoBehaviour
{
    public RectTransform RectTransform;
    public Button Button;
    public Text Text;

    private void Reset()
    {
        RectTransform = GetComponent<RectTransform>();
        Button = GetComponent<Button>();
        Text = GetComponentInChildren<Text>();
    }
}
