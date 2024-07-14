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

namespace Drilling_Down_Report_in_Live.Views;

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

        var dataXml = AssetLoader.Open(new Uri($@"avares://Drilling Down Report in Live/Data/Demo.xml"));
        var dataXsd = AssetLoader.Open(new Uri($@"avares://Drilling Down Report in Live/Data/Demo.xsd"));

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
        var report = new StiReport();
        var stream = AssetLoader.Open(new Uri($@"avares://Drilling Down Report in Live/Reports/LiveReports.mrt"));
        report.Load(stream);

        //Add data to datastore
        report.RegData(dataSet1);

        report.CalculationMode = StiCalculationMode.Interpretation;
        report.Click += new EventHandler(click);
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Drilling Down Report in Live/Assets/avalonia-logo.ico"));

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop && desktop.MainWindow != null)
        {
            var window = new Window
            {
                WindowState = WindowState.Maximized,
                Width = 450,
                Height = 450,
                Icon = new WindowIcon(streamIcon),
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

    private async void click(object sender, EventArgs e)
    {
        var comp = sender as StiComponent;
        var customerID = (string)comp.BookmarkValue;

        if (customerID != null)
        {
            var report = new StiReport();
            report.RegData(dataSet1);

            var stream = AssetLoader.Open(new Uri($@"avares://Drilling Down Report in Live/Reports/Details.mrt"));
            report.Load(stream);
            report.CalculationMode = StiCalculationMode.Interpretation;

            var dataBand = (StiDataBand)report.Pages["Page1"].Components["DataBand1"];
            var filter = new StiFilter("{Orders.CustomerID==\"" + customerID + "\"}");
            dataBand.Filters.Add(filter);

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
    }

    #endregion
}
