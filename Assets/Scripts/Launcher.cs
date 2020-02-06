using UnityEngine;
using System.Globalization;
using System.Collections;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Views;
using Loxodon.Log;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Services;

public class Launcher : MonoBehaviour
{
    private ApplicationContext context;

    public GameObject[] listPopup;

    private void Awake()
    {
        GlobalWindowManager windowManager = FindObjectOfType<GlobalWindowManager>();
        if (windowManager == null)
            throw new NotFoundException("Not found the GlobalWindowManager.");

        context = Context.GetApplicationContext();

        IServiceContainer container = context.GetContainer();

        /* Initialize the data binding service */
        //BindingServiceBundle bundle = new BindingServiceBundle(context.GetContainer());
        //bundle.Start();

        container.Register<IUIViewLocator>(new DefaultUIViewLocator());

        // Initialize the localization service 
        //CultureInfo cultureInfo = Locale.GetCultureInfo();
        //var localization = Localization.Current;
        //localization.CultureInfo = cultureInfo;
        //localization.AddDataProvider(new ResourcesDataProvider("LocalizationExamples", new XmlDocumentParser()));
        //container.Register<Localization>(localization);
    }

    private void Start()
    {
        /* Create a window container */
        WindowContainer winContainer = WindowContainer.Create("MAIN");

        IUIViewLocator locator = context.GetService<IUIViewLocator>();
        LoadingGameView window = locator.LoadWindow<LoadingGameView>(winContainer, "UI/popup_loading");
        window.Create();
        window.Show();

        for (int i = 0; i < listPopup.Length; i++)
        {
            SmartPool.Instance.Preload(listPopup[i], 1);
        }
    }
}
