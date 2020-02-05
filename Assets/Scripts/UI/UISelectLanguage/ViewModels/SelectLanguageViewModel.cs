using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLanguageViewModel : ViewModelBase
{
    private InteractionRequest closePopupRequest;
    private SimpleCommand closePopupCommand;

    public SelectLanguageViewModel()
    {
        this.closePopupRequest = new InteractionRequest(this);

        this.closePopupCommand = new SimpleCommand(() =>
        {
            this.closePopupCommand.Enabled = false;
            this.closePopupRequest.Raise();
        });
    }

    public IInteractionRequest ClosePopupRequest { get { return this.closePopupRequest; } }
    public ICommand ClosePopupCommand { get { return this.closePopupCommand; } }
}
