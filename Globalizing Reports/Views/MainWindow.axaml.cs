using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Viewer.Avalonia;
using Stimulsoft.Report.Viewer.Avalonia.Theme;
using Stimulsoft.Report.Viewer.Avalonia.Viewer;
using System;
using System.Data;
using System.Globalization;

namespace Globalizing_Reports.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        StiOptions.Configuration.IsAvalonia = true;

        Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        StiAvaloniaTheme.ApplyNewTheme(StiAvaloniaAppThemeAppearance.Light);

        // How to Activate
        //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
        //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
        //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

        var dataXml = AssetLoader.Open(new Uri($@"avares://Globalizing Reports/Data/Demo.xml"));
        var dataXsd = AssetLoader.Open(new Uri($@"avares://Globalizing Reports/Data/Demo.xsd"));

        dataSet1 = new DataSet();
        dataSet1.ReadXmlSchema(dataXsd);
        dataSet1.ReadXml(dataXml);
        dataSet1.DataSetName = "Demo";
    }

    #region Fields
    private DataSet dataSet1;
    #endregion

    #region Handlers
    private async void ButtonShow_Click(object sender, RoutedEventArgs e)
    {
        #region Switch Culture
        string cultureName = "";
        switch (cbCountry.SelectedIndex)
        {
            case 0:
                cultureName = "fr-FR";
                break;

            case 1:
                cultureName = "de-DE";
                break;

            case 2:
                cultureName = "it-IT";
                break;

            case 3:
                cultureName = "ru-RU";
                break;

            case 4:
                cultureName = "es-ES";
                break;

            case 5:
                cultureName = "en-GB";
                break;

            case 6:
                cultureName = "en-US";
                break;
        }
        #endregion

        var report = new StiReport();

        var stream = AssetLoader.Open(new Uri($@"avares://Globalizing Reports/Reports/GlobalizedSimpleList.mrt"));
        report.Load(stream);

        //Set globalization
        report.GlobalizationManager = new GlobalizationManager("Globalizing_Reports.MyResources",
            new CultureInfo(cultureName));

        report.RegData(dataSet1);
        report.CalculationMode = StiCalculationMode.Interpretation;

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow != null)
        {
            var window = new Window
            {
                WindowState = WindowState.Maximized,
                Width = 450,
                Height = 450,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Content = new StiViewerControl
                {
                    Report = report
                }
            };

            var result = await window.ShowDialog<bool?>(desktop.MainWindow);
            if (result == null || !result.GetValueOrDefault()) return;
        }
    }
    #endregion
}
