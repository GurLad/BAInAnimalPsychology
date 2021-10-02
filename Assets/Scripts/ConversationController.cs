using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    public Text AnimalText;
    public TextButton BaseOption;
    public int NumOptions;
    public float SeperatorSize;
    public GameObject GameOverScreen;
    public Text GameOverText;
    public AdvancedAnimation DeathAnimation;
    public AdvancedAnimation IdleAnimation;
    public AdvancedAnimation TalkAnimation;
    [Header("Data")]
    public List<ConversationData> ConversationDatas;
    private List<ConversationButton> conversationButtons = new List<ConversationButton>();
    private int current;

    private void Start()
    {
        for (int i = 0; i < NumOptions; i++)
        {
            TextButton textButton = Instantiate(BaseOption, BaseOption.transform.parent);
            textButton.gameObject.SetActive(true);
            textButton.RectTransform.anchoredPosition = new Vector2(BaseOption.RectTransform.anchoredPosition.x, BaseOption.RectTransform.anchoredPosition.y - i * (BaseOption.RectTransform.sizeDelta.y + SeperatorSize));
            ConversationButton button = textButton.GetComponent<ConversationButton>();
            button.Controller = this;
            button.ID = i;
            conversationButtons.Add(button);
        }
        ShowConversation(0);
    }

    private void ShowConversation(int id)
    {
        current = id;
        AnimalText.text = ConversationDatas[current].AnimalText;
        for (int i = 0; i < NumOptions; i++)
        {
            conversationButtons[i].TextButton.Text.text = ConversationDatas[current].Options[i].Option;
        }
    }

    public void Select(int id)
    {
        if (ConversationDatas[current].Options[id].Correct)
        {
            ShowConversation(current + 1);
        }
        else
        {
            IdleAnimation.Active = false;
            TalkAnimation.Active = false;
            DeathAnimation.Active = true;
            Destroy(gameObject);
            GameOverScreen.SetActive(true);
            GameOverText.text = ConversationDatas[current].Options[id].Fail;
        }
    }
}

[System.Serializable]
public class ConversationData
{
    public string AnimalText;
    public AudioClip VoiceActing;
    public List<OptionData> Options;
    public float TalkLength;
}

[System.Serializable]
public class OptionData
{
    [TextArea]
    public string Option;
    public bool Correct;
    public string Fail;
}