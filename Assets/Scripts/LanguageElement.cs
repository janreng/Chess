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

public class LanguageElementViewModel : ViewModelBase
{
    private string label;
    private SystemLanguage language;

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

    public void OnChangeLanguage(bool isOn)
    {
        GameManager.instance.LocalizationChess.CultureInfo = Locale.GetCultureInfoByLanguage(language);
    }
}

public class LanguageElement : UIView
{
    public VariableArray variables;
    [HideInInspector]
    public SystemLanguage language;
    [HideInInspector]
    public LanguageElementViewModel viewModel;

    protected override void Start()
    {
        viewModel = new LanguageElementViewModel();

        IBindingContext bindingContext = this.BindingContext();
        bindingContext.DataContext = viewModel;
        viewModel.Language = language;
        viewModel.Label = language.ToString();

        /* databinding */
        BindingSet<LanguageElement, LanguageElementViewModel> bindingSet = this.CreateBindingSet<LanguageElement, LanguageElementViewModel>();
        bindingSet.Bind(this.variables.Get<Text>("label")).For(v => v.text).To(vm => vm.Label).OneWay();
        bindingSet.Bind(this.variables.Get<Toggle>("toggle")).For(v => v.onValueChanged).To(vm => vm.OnChangeLanguage(true));
        bindingSet.Build();
    }
}
