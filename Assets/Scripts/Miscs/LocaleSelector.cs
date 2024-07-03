using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LocaleSelector : MonoBehaviour
{
    public class OptionData : TMP_Dropdown.OptionData
    {
        public int value;

        public OptionData(string label, int value) : base(label)
        {
            this.value = value;
        }
    }

    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private LocalizedString localizedStringEngLang;
    [SerializeField] private LocalizedString localizedStringVieLang;

    private bool isActive;
    private string labelEngLang;
    private string labelVieLang;
    private int currentLocaleId;

    private const int engLocaleId = 0;
    private const int vieLocaleId = 1;
    public const string PLAYER_PREF_LANG = "LangId";

    private void Awake()
    {
        currentLocaleId = PlayerPrefs.GetInt(PLAYER_PREF_LANG, engLocaleId);
    }

    private void OnEnable()
    {
        localizedStringEngLang.StringChanged += UpdateEngLang;
        localizedStringVieLang.StringChanged += UpdateVietLang;

        UpdateDropdownLang();
    }

    private void Start()
    {
        dropdown.onValueChanged.AddListener(ChanageLocale);
    }

    private void OnDisable()
    {
        localizedStringEngLang.StringChanged -= UpdateEngLang;
        localizedStringVieLang.StringChanged -= UpdateVietLang;
    }

    private void UpdateVietLang(string value)
    {
        labelVieLang = value;
        UpdateDropdownLang();
    }

    private void UpdateEngLang(string value)
    {
        labelEngLang = value;
        UpdateDropdownLang();
    }

    private void UpdateDropdownLang()
    {
        dropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new()
        {
            new OptionData(labelEngLang, engLocaleId),
            new OptionData(labelVieLang, vieLocaleId),
        };

        dropdown.AddOptions(options);
        dropdown.captionText.text = options[currentLocaleId].text;
        dropdown.value = currentLocaleId;
    }


    private void ChanageLocale(int index)
    {
        if (isActive) return;

        currentLocaleId = ((OptionData)dropdown.options[index]).value;
        StartCoroutine(SetLocaleRoutine(currentLocaleId));

        PlayerPrefs.SetInt(PLAYER_PREF_LANG, currentLocaleId);
        PlayerPrefs.Save();
    }

    private IEnumerator SetLocaleRoutine(int localeId)
    {
        isActive = true;
        yield return LocalizationSettings.InitializationOperation;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        isActive = false;
    }
}
