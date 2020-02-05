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

public class UIPopupChangeLanguageViewModel : ViewModelBase
{
    private Transform transformLanguageGroup;
    private ToggleGroup languageToggleGroup;
    private GameObject popupLanguage;
    List<SystemLanguage> listLanguage = new List<SystemLanguage>();

    public Transform TransformLanguageGroup
    {
        get { return this.transformLanguageGroup; }
        set { this.Set<Transform>(ref this.transformLanguageGroup, value, "TransformLanguageGroup"); }
    }

    public ToggleGroup LanguageToggleGroup
    {
        get { return this.languageToggleGroup; }
        set { this.Set<ToggleGroup>(ref this.languageToggleGroup, value, "LanguageToggleGroup"); }
    }

    public GameObject PopupLanguage
    {
        get { return this.popupLanguage; }
        set { this.Set<GameObject>(ref this.popupLanguage, value, "PopupLanguage"); }
    }

    public void InitLanguage()
    {
        listLanguage.Add(SystemLanguage.Vietnamese);
        listLanguage.Add(SystemLanguage.English);

        for (int i = 0; i < listLanguage.Count; i++)
        {
            GameObject prefab = GameManager.instance.InitElement(Resources.Load<GameObject>("Prefabs/LanguageElement"), this.transformLanguageGroup);
            LanguageElement languageElement = prefab.GetComponent<LanguageElement>();
            languageElement.language = listLanguage[i];
            languageElement.transform.name = languageElement.language.ToString();
            languageElement.transform.GetComponent<Toggle>().group = this.languageToggleGroup;
        }
    }

    public void OnShowPopupLanguage()
    {
        this.popupLanguage.SetActive(true);
    }

    public void OnClosePopupLanguage()
    {
        this.popupLanguage.SetActive(false);
    }
}

public class UIPopupChangeLanguage : UIView
{
    public VariableArray variables;
    UIPopupChangeLanguageViewModel viewModel;

    protected override void Start()
    {
        viewModel = new UIPopupChangeLanguageViewModel();
        SetVariableViewModel();
        viewModel.InitLanguage();

        IBindingContext bindingContext = this.BindingContext();
        bindingContext.DataContext = viewModel;

        BindingSet<UIPopupChangeLanguage, UIPopupChangeLanguageViewModel> bindingSet = this.CreateBindingSet<UIPopupChangeLanguage, UIPopupChangeLanguageViewModel>();
        bindingSet.Bind(this.variables.Get<Button>("close")).For(v => v.onClick).To(vm => vm.OnClosePopupLanguage);
        bindingSet.Build();

        this.RegisterListener(EventID.OpenPopupLanguage, (param) => viewModel.OnShowPopupLanguage());
    }

    void SetVariableViewModel()
    {
        viewModel.TransformLanguageGroup = this.variables.Get<Transform>("language_group");
        viewModel.LanguageToggleGroup = this.variables.Get<ToggleGroup>("language_toggle_group");
        viewModel.PopupLanguage = this.variables.Get<GameObject>("popup_language");
    }
}
