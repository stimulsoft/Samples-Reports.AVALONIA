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

namespace Using_Business_Objects_in_the_Report.Views;

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
    private async void ButtonIEnumerableShow_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        report.RegData("EmployeeIEnumerable", CreateBusinessObjectsIEnumerable.GetEmployees());
        report.Load(AssetLoader.Open(new Uri($@"avares://Using Business Objects in the Report/Reports/BusinessObjects_IEnumerable.mrt")));
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

    private async void ButtonITypedListShow_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        report.RegData("EmployeeITypedList", CreateBusinessObjectsITypedList.GetEmployees());
        report.Load(AssetLoader.Open(new Uri($@"avares://Using Business Objects in the Report/Reports/BusinessObjects_ITypedList.mrt")));
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
