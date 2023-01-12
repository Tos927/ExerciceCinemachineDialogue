using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Text txtNameLeft;
    public Image imgSpriteLeft;

    public Text txtNameRight;
    public Image imgSpriteRight;

    public Text txtSentence;

    private DialogConfig dialogConfig;
    private int idCurrentSentence;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDialogue(DialogConfig dialog)
    {
        Time.timeScale = 0;

        gameObject.SetActive(true);

        txtNameLeft.text = dialog.nameLeft;
        imgSpriteLeft.sprite = dialog.spriteLeft;

        txtNameRight.text = dialog.nameRight;
        imgSpriteRight.sprite = dialog.spriteRight;

        dialogConfig = dialog;

        RefreshBox();
    }

    private void RefreshBox()
    {
        DialogConfig.SentenceConfig sentence = dialogConfig.sentenceList[idCurrentSentence];

        DialogConfig.SpeakerConfig speaker = dialogConfig.speakers[0];

        switch (speaker.position)
        {
            case DialogConfig.SpeakerConfig.POSITION.LEFT:
                txtNameLeft.color = Color.black;
                txtNameRight.color = Color.clear;

                imgSpriteLeft.color = Color.white;
                imgSpriteRight.color = Color.gray;
                break;
            case DialogConfig.SpeakerConfig.POSITION.RIGHT:
                txtNameRight.color = Color.black;
                txtNameLeft.color = Color.clear;

                imgSpriteRight.color = Color.white;
                imgSpriteLeft.color = Color.gray;
                break;

            default:
                break;
        }

        txtSentence.text = sentence.sentence;

        audioSource.Stop();

        audioSource.clip = sentence.audioClip;
        audioSource.Play();
    }

    public void NextSentence()
    {
        idCurrentSentence++;

        if (idCurrentSentence < dialogConfig.sentenceList.Count)
            RefreshBox();
        else
            CloseDialog();
    }

    public void CloseDialog()
    {
        Time.timeScale = 1;
        idCurrentSentence = 0;
        dialogConfig = null;

        gameObject.SetActive(false);
    }
}
