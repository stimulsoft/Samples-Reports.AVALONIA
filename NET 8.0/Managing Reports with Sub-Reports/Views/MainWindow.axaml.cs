using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Stimulsoft.Report;
using Stimulsoft.Report.Viewer.Avalonia;
using Stimulsoft.Report.Viewer.Avalonia.Theme;
using Stimulsoft.Report.Viewer.Avalonia.Viewer;
using System;
using System.Data;
using System.Globalization;

namespace Managing_Reports_with_Sub_Reports.Views;

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
    }

    #region Handlers
    private async void ButtonReport1Show_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();

        var stream = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/SimpleList.mrt"));
        report.Load(stream);

        report.CalculationMode = StiCalculationMode.Interpretation;
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Assets/avalonia-logo.ico"));

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

    private async void ButtonReport2Show_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();

        var stream = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/SimpleGroup.mrt"));
        report.Load(stream);

        report.CalculationMode = StiCalculationMode.Interpretation;
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Assets/avalonia-logo.ico"));

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

    private async void ButtonReport3Show_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();

        var stream = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/MasterDetail.mrt"));
        report.Load(stream);

        report.CalculationMode = StiCalculationMode.Interpretation;
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Assets/avalonia-logo.ico"));

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

    private async void ButtonShow_Click(object sender, RoutedEventArgs e)
    {
        var report1 = new StiReport();
        report1.Load(AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/SimpleList.mrt")));
        report1.CalculationMode = StiCalculationMode.Interpretation;

        var report2 = new StiReport();
        report2.Load(AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/SimpleGroup.mrt")));
        report2.CalculationMode = StiCalculationMode.Interpretation;

        var report3 = new StiReport();
        report3.Load(AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Reports/MasterDetail.mrt")));
        report3.CalculationMode = StiCalculationMode.Interpretation;

        var report = new StiReport();
        report.SubReports.Add(report1);
        report.SubReports.Add(report2, checkBoxResetPageNumber.IsChecked.GetValueOrDefault(), checkBoxPrintOnPreviousPage.IsChecked.GetValueOrDefault());
        report.SubReports.Add(report3, checkBoxResetPageNumber.IsChecked.GetValueOrDefault(), checkBoxPrintOnPreviousPage.IsChecked.GetValueOrDefault());
        report.CalculationMode = StiCalculationMode.Interpretation;
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Managing Reports with Sub-Reports/Assets/avalonia-logo.ico"));

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
    #endregion
}
