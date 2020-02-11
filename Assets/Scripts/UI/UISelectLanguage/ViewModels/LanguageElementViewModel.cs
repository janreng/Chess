using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageElementViewModel : ViewModelBase
{
    private string label;
    private SystemLanguage language;

    private SimpleCommand changeLanguageCommand;

    public string Label
    {
        get { return this.label; }
        set { this.Set<string>(ref this.label, value, "Label"); }
    }

    public SystemLanguage Language
    {
        get { return this.language; }
        set { this.Set<SystemLanguage>(ref this.language, value, "Language"); }
    }

    public LanguageElementViewModel()
    {
        this.changeLanguageCommand = new SimpleCommand(() =>
        {
            GameManager.instance.LocalizationChess.CultureInfo = Locale.GetCultureInfoByLanguage(language);
            PlayerPrefs.SetString("language", language.ToString());
            this.changeLanguageCommand.Enabled = true;
        });

    }

    public ICommand ChangeLanguageCommand { get { return this.changeLanguageCommand; } }
}
