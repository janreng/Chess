using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Binding.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageElementView : WindowView
{
    public VariableArray variables;

    private SystemLanguage language;

    protected override void Start()
    {
        /* databinding */
        BindingSet<LanguageElementView, LanguageElementViewModel> bindingSet = this.CreateBindingSet<LanguageElementView, LanguageElementViewModel>();
        bindingSet.Bind(this.variables.Get<Text>("label")).For(v => v.text).To(vm => vm.Label).TwoWay();

        // binding command
        Toggle toggle = this.variables.Get<Toggle>("toggle");
        toggle.group = this.transform.GetComponentInParent<ToggleGroup>();
        bindingSet.Bind(toggle).For(v => v.onValueChanged).To(vm => vm.ChangeLanguageCommand);
        bindingSet.Build();

        OnSelected();
    }

    public void OnSelected()
    {
        var label = this.variables.Get<Text>("label");
        if (label.text.Equals(PlayerPrefs.GetString("language", "English")))
        {
            Toggle toggle = this.variables.Get<Toggle>("toggle");
            toggle.isOn = true;
        }
    }
}
