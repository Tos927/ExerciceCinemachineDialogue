using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text txtNameLeft;
    public Image imgSpriteLeft;

    public Text txtNameRight;
    public Image imgSpriteRight;

    public Text txtSentence;

    private DialogConfig2 _dialog2;
    private int _idCurrentSentence = 0;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
        }
    }
    public void PlayDialog(DialogConfig2 dialog)
    {
        gameObject.SetActive(true);

        txtNameLeft.text = dialog.nameLeft;
        imgSpriteLeft.sprite = dialog.spriteLeft;

        txtNameRight.text = dialog.nameRight;
        imgSpriteRight.sprite = dialog.spriteRight;
        
        _dialog2 = dialog;

        RefreshBox();
    }

    private void RefreshBox()
    {
        DialogConfig2.SentenceConfig sentence = _dialog2.sentenceConfig[_idCurrentSentence];

        switch (sentence.postion)
        {
            case DialogConfig2.SentenceConfig.POSTION.LEFT:
                txtNameLeft.color = Color.black;
                txtNameRight.color = Color.clear;
                
                imgSpriteLeft.color = Color.white;
                imgSpriteRight.color = Color.gray;
                break;

            case DialogConfig2.SentenceConfig.POSTION.RIGHT:
                txtNameLeft.color = Color.clear;
                txtNameRight.color = Color.black;

                imgSpriteLeft.color = Color.gray;
                imgSpriteRight.color = Color.white;
                break;
        }

        txtSentence.text = sentence.sentence;

        _audioSource.Stop();
        
        _audioSource.clip = sentence.audioClip;
        _audioSource.Play();
    }

    public void NextSentence()
    {
        _idCurrentSentence++;

        if (_idCurrentSentence < _dialog2.sentenceConfig.Count) 
            RefreshBox();
        else
            CloseDialog();
    }

    public void CloseDialog()
    {
        _idCurrentSentence = 0;
        _dialog2 = null;

        gameObject.SetActive(false);
    }
}
