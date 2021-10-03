using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    [Header("Data")]
    public List<ConversationData> ConversationDatas;
    [TextArea]
    public string WinText;
    public float WinTime;
    public AudioClip WinAudio;
    [Header("Animations")]
    public AdvancedAnimation DeathAnimation;
    public AdvancedAnimation IdleAnimation;
    public AdvancedAnimation TalkAnimation;
    public AdvancedAnimation EndTalkAnimation;
    [Header("Objects")]
    public Text AnimalText;
    public TextButton BaseOption;
    public int NumOptions;
    public float SeperatorSize;
    public Text GameOverText;
    public GameObject WinButton;
    private List<ConversationButton> conversationButtons = new List<ConversationButton>();
    private int current;
    private AudioSource audioSource;
    private float count;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void Update()
    {
        if (count > 0)
        {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                TalkAnimation.Active = false;
                EndTalkAnimation.Activate(true);
            }
        }
    }

    private void ShowConversation(int id)
    {
        current = id;
        if (current < ConversationDatas.Count)
        {
            AnimalText.text = ConversationDatas[current].AnimalText;
            audioSource.Stop();
            audioSource.PlayOneShot(ConversationDatas[current].VoiceActing);
            if ((count = ConversationDatas[current].TalkLength) > 0)
            {
                TalkAnimation.Active = true;
                EndTalkAnimation.Active = false;
            }
            for (int i = 0; i < NumOptions; i++)
            {
                conversationButtons[i].TextButton.Text.text = ConversationDatas[current].Options[i].Option;
            }
        }
        else
        {
            AnimalText.text = WinText;
            audioSource.Stop();
            audioSource.PlayOneShot(WinAudio);
            if ((count = WinTime) > 0)
            {
                TalkAnimation.Active = true;
                EndTalkAnimation.Active = false;
            }
            for (int i = 0; i < NumOptions; i++)
            {
                conversationButtons[i].gameObject.SetActive(false);
            }
            //Destroy(this);
            WinButton.SetActive(true);
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
            EndTalkAnimation.Active = false;
            DeathAnimation.Activate(true);
            Destroy(gameObject);
            StateController.Lose();
            GameOverText.text = ConversationDatas[current].Options[id].Fail;
        }
    }
}

[System.Serializable]
public class ConversationData
{
    [TextArea]
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