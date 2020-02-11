using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLanguageViewModel : ViewModelBase
{
    private List<SystemLanguage> systemLanguages = new List<SystemLanguage>();

    private InteractionRequest closePopupRequest;
    private SimpleCommand closePopupCommand;

    public SelectLanguageViewModel()
    {
        this.closePopupRequest = new InteractionRequest(this);

        this.closePopupCommand = new SimpleCommand(() =>
        {
            this.closePopupCommand.Enabled = true;
            this.closePopupRequest.Raise();
        });

        InitSystemLanguage();
    }

    public void InitSystemLanguage()
    {
        systemLanguages.Add(SystemLanguage.English);
        systemLanguages.Add(SystemLanguage.Vietnamese);
    }

    public List<SystemLanguage> GetSystemLanguages()
    {
        return systemLanguages;
    }

    public IInteractionRequest ClosePopupRequest { get { return this.closePopupRequest; } }
    public ICommand ClosePopupCommand { get { return this.closePopupCommand; } }
}
