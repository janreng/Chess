using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGameView : Window
{
    public VariableArray variables;

    private LoadingGameViewModel viewModel;
    private IUIViewLocator viewLocator;

    protected override void OnCreate(IBundle bundle)
    {
        viewLocator = Context.GetApplicationContext().GetService<IUIViewLocator>();
        this.viewModel = new LoadingGameViewModel();

        BindingSet<LoadingGameView, LoadingGameViewModel> bindingSet = this.CreateBindingSet(viewModel);

        // binding interaction request
        bindingSet.Bind().For(v => v.OnOpenPopupSelectLanguage).To(vm => vm.SelectLanguageRequest);
        bindingSet.Bind().For(v => v.OnTapToStart).To(vm => vm.TapToStartRequest);

        // binding command
        bindingSet.Bind(this.variables.Get<Button>("select_language")).For(v => v.onClick).To(vm => vm.SelectLanguageCommand);
        bindingSet.Bind(this.variables.Get<Button>("tap_to_start")).For(v => v.onClick).To(vm => vm.TapToStartCommand);
        bindingSet.Build();
    }

    public void OnOpenPopupSelectLanguage(object sender, InteractionEventArgs args)
    {
        Debug.Log("Open Popup select language");
        SelectLanguageView loginWindow = viewLocator.LoadWindow<SelectLanguageView>(this.WindowManager, "UI/popup_language");
        var loginViewModel = args.Context;

        loginWindow.SetDataContext(loginViewModel);
        loginWindow.Create();
        loginWindow.Show();
    }

    public void OnTapToStart(object sender, InteractionEventArgs args)
    {

    }
}
