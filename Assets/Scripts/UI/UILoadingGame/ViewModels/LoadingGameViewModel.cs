using Loxodon.Framework.Commands;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.ViewModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGameViewModel : ViewModelBase
{
    private InteractionRequest<SelectLanguageViewModel> selectLanguageRequest;
    private InteractionRequest tapToStartRequest;

    private SimpleCommand selectLanguageCommand;
    private SimpleCommand tapToStartCommand;

    public LoadingGameViewModel()
    {
        this.selectLanguageRequest = new InteractionRequest<SelectLanguageViewModel>(this);
        this.tapToStartRequest = new InteractionRequest(this);

        SelectLanguageViewModel selectLanguageViewModel = new SelectLanguageViewModel();
        this.selectLanguageCommand = new SimpleCommand(() =>
        {
            Debug.Log("select Language");
            this.selectLanguageCommand.Enabled = false;
            this.selectLanguageRequest.Raise(selectLanguageViewModel, vm => 
            {
                this.selectLanguageCommand.Enabled = true;
            });
        });

        this.tapToStartCommand = new SimpleCommand(() =>
        {

        });
    }


    public IInteractionRequest SelectLanguageRequest { get { return this.selectLanguageRequest; } }
    public IInteractionRequest TapToStartRequest { get { return this.tapToStartRequest; } }

    public ICommand SelectLanguageCommand { get { return this.selectLanguageCommand; } }
    public ICommand TapToStartCommand { get { return this.tapToStartCommand; } }
}
