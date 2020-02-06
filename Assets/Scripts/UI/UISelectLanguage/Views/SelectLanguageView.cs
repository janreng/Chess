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

    protected override void OnCreate(IBundle bundle)
    {
        BindingSet<SelectLanguageView, SelectLanguageViewModel> bindingSet = this.CreateBindingSet<SelectLanguageView, SelectLanguageViewModel>();

        // binding interaction request
        bindingSet.Bind().For(v => v.OnClosePopup).To(vm => vm.ClosePopupRequest);

        // binding command
        bindingSet.Bind(this.variables.Get<Button>("btn_close")).For(v => v.onClick).To(vm => vm.ClosePopupCommand);
        bindingSet.Build();
    }

    public void OnClosePopup(object sender, InteractionEventArgs args)
    {
        this.Dismiss();
    }
}
