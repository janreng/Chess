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
    private IUIViewLocator viewLocator;


    protected override void OnCreate(IBundle bundle)
    {
        viewLocator = Context.GetApplicationContext().GetService<IUIViewLocator>();
        this.viewModel = new SelectLanguageViewModel();

        BindingSet<SelectLanguageView, SelectLanguageViewModel> bindingSet = this.CreateBindingSet(viewModel);

        // binding interaction request
        bindingSet.Bind().For(v => v.OnClosePopup).To(vm => vm.ClosePopupRequest);

        // binding command
        bindingSet.Bind(this.variables.Get<Button>("btn_close")).For(v => v.onClick).To(vm => vm.ClosePopupCommand);
        bindingSet.Build();

        LoadSystemLanguage();
    }

    public void OnClosePopup(object sender, InteractionEventArgs args)
    {
        this.Dismiss();
    }

    public void LoadSystemLanguage()
    {
        var languageGroup = this.variables.Get<RectTransform>("language_group");
        List<SystemLanguage> languageList = this.viewModel.GetSystemLanguages();

        for (int i = 0; i < languageList.Count; i++)
        {
            LanguageElementView languageElementView = viewLocator.LoadView<LanguageElementView>("UI/language_element");
            LanguageElementViewModel viewModel = new LanguageElementViewModel()
            {
                Language = languageList[i],
                Label = languageList[i].ToString(),
            };
            languageElementView.SetDataContext(viewModel);
            languageElementView.Visibility = true;
            languageElementView.transform.SetParent(languageGroup);
        }
    }
}
