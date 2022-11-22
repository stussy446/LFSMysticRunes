using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Announcer : MonoBehaviour, ILocalizable
{
    [SerializeField]
    private float bounceAmplitude = 0.01f;
    [SerializeField]
    private float bounceFrequency = 5f;
    [SerializeField]
    private string previewTextID = "AnnouncerListen";
    [SerializeField]
    private string sequenceInputTextID = "AnnouncerPlayerTurn";
    [SerializeField]
    private TMP_Text announcerText;
    [SerializeField]
    private string wrongRuneTextID = "AnnouncerFailedChoice";
    [SerializeField] private string timeoutTextID = "AnnouncerTimeout";
    [SerializeField] private string highScoreTextID = "AnnouncerHighScore";
    [SerializeField] private string failedByTimeoutTextID = "AnnouncerFailedByTimeout";
    [SerializeField] private string failedByRuneChoiceID = "AnnouncerFailedByRuneChoice";
    [SerializeField] private string bloodSacrificeID = "AnnouncerBloodSacrific";

    private string currentTextID;
    private bool mustFormat;
    private string formatParam;

    private string highScoreText = "New high score: {0} ";

    void Update()
    {
        transform.localScale = Vector3.one + Vector3.one * (Mathf.Sin(Time.time
            * bounceFrequency) * bounceAmplitude);
    }

    public void ShowPreviewText()
    {
        currentTextID = previewTextID;
        mustFormat = false;
        UpdateText();
    }

    public void ShowSequenceText()
    {
        currentTextID = sequenceInputTextID;
        mustFormat = false;
        UpdateText();
    }

    public void Clear()
    {
        announcerText.text = String.Empty;
    }

    public void ShowWrongRuneText()
    {
        currentTextID = wrongRuneTextID;
        mustFormat = false;
        UpdateText();
    }

    public void ShowHighScoreText(int highScore)
    {
        currentTextID = highScoreTextID;
        mustFormat = true;
        formatParam = highScore.ToString();
        UpdateText();
    }

    public void ShowTimeoutText()
    {
        currentTextID = timeoutTextID;
        mustFormat = false;
        UpdateText();
    }

    public void ShowFailedByRuneChoiceText()
    {
        currentTextID = failedByRuneChoiceID;
        mustFormat = false;
        UpdateText();
    }

    public void ShowFailedByTimeoutText()
    {
        currentTextID = failedByTimeoutTextID;
        mustFormat = false;
        UpdateText();
    }

    public void ShowBloodSacrificeText()
    {
        currentTextID = bloodSacrificeID;
        mustFormat = false;
        UpdateText();
    }

    public void UpdateText()
    {
        if (currentTextID == String.Empty)
        {
            announcerText.text = String.Empty;
        }
        else if (mustFormat)
        {
            announcerText.text = String.Format(Localization.GetLocalizedText(
                highScoreTextID), formatParam);
        }
        else
        {
            announcerText.text = Localization.GetLocalizedText(currentTextID);
        }
    }

    public void ShowCorrectRuneText()
    {
        announcerText.text = "Correct choice!";
    }

    public void ShowLostGameText()
    {
        announcerText.text = "NOOO YOU LOSE!";
    }

    public void LocaleChanged()
    {
        UpdateText();
    }

    private void Awake()
    {
        Localization.RegisterWatcher(this);
    }

    private void OnDestroy()
    {
        Localization.DeregisterWatcher(this);
    }
}
