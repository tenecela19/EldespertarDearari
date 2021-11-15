using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    #region Singleton
    private static ShowUI _instance;
  
    public static ShowUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ShowUI>();
            }

            return _instance;
        }
    }
    #endregion
    public GameObject ShowUi;
    public string AudioName;
    public Dialogue dialogue;
    public GameObject DialogoPersonaje;
    public bool CanSayDialogue;
    public bool CanShowUI = true;
    public GameObject AnimalTalking;
    public bool CanAnimalTalk;
    public void OnClick()
    {
        PlayAudio();
        if (CanSayDialogue)
        {
            DialogoPersonaje.SetActive(true);
            TriggerDialogue();
        }
        if(AnimalTalking != null)
        {
            if (CanAnimalTalk)
            {
                AnimalTalking.SetActive(true);
            }
            else
            {
                AnimalTalking.SetActive(false);

            }
        }

        if (CanShowUI == false)
        {
            ShowUi.SetActive(false);
            FirstPersonController.Instance.ReturnButton.SetActive(false);
        }
        else
        {
            ShowUi.SetActive(true);
            FirstPersonController.Instance.ReturnButton.SetActive(true);
        }

    }
    public void Update()
    {
    }
    public void CloseUI()
    {
        ShowUi.SetActive(false);

    }
    public void PlayAudio()
    {
            FindObjectOfType<AudioManager>().Play(AudioName);
    }
    public void StopAudio()
    {
        FindObjectOfType<AudioManager>().Stop(AudioName);

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void NoShowUi()
    {
        CanSayDialogue = false;
    }
}
