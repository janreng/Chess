using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Binding.Contexts;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.ViewModels;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//public class LoadingGameViewModel : ViewModelBase
//{
//    public void OnSelectLanguage()
//    {
//        EventDispatcher.Instance.PostEvent(EventID.OpenPopupLanguage);
//    }

//    public void OnStartGame()
//    {
//        Debug.Log("Start Game");
//    }
//}

public class UIPopupLoadingGame : UIView
{
    public VariableArray variables;

    LoadingGameViewModel viewModel;

    protected override void Start()
    {
        viewModel = new LoadingGameViewModel();

        IBindingContext bindingContext = this.BindingContext();
        bindingContext.DataContext = viewModel;

        /* databinding */
        //BindingSet<UIPopupLoadingGame, LoadingGameViewModel> bindingSet = this.CreateBindingSet<UIPopupLoadingGame, LoadingGameViewModel>();
        //bindingSet.Bind(this.variables.Get<Button>("select_language")).For(v => v.onClick).To(vm => vm.OnSelectLanguage).OneWay();
        //bindingSet.Bind(this.variables.Get<Button>("tap_to_start")).For(v => v.onClick).To(vm => vm.OnStartGame);
        //bindingSet.Build();
    }
}
