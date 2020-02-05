using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectLanguageView : Window
{
    public VariableArray variables;

    private SelectLanguageViewModel viewModel;

    protected override void OnCreate(IBundle bundle)
    {
        //this.viewModel = new SelectLanguageViewModel();

        //BindingSet<SelectLanguageView, SelectLanguageViewModel> bindingSet = this.CreateBindingSet(viewModel);

        //// binding interaction request
        //bindingSet.Bind().For(v => v.OnClosePopup).To(vm => vm.ClosePopupRequest);

        //// binding command
        //bindingSet.Bind(this.variables.Get<Button>("button_close")).For(v => v.onClick).To(vm => vm.ClosePopupCommand);
        //bindingSet.Build();
    }

    public void OnClosePopup(object sender, InteractionEventArgs args)
    {
        this.Dismiss();
    }
}
