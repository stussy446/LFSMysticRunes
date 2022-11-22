using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocaleButton : MonoBehaviour
{
    [SerializeField] private Locale locale;

    public void OnClick()
    {
        Localization.ChangeLocale(locale);
    }
    
}
