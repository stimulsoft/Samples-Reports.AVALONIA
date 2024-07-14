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

namespace Change_Theme_in_Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        StiOptions.Configuration.IsAvalonia = true;

        // How to Activate
        //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
        //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
        //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

        if (StiAvaloniaTheme.Appearance == StiAvaloniaAppThemeAppearance.Light)
        {
            this.comboBoxTheme.SelectedIndex = 0;
            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        }
        else
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
            this.comboBoxTheme.SelectedIndex = 1;
        }
    }

    #region Handlers
    private void ComboBoxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (this.comboBoxTheme.SelectedIndex)
        {
            case 0:
                Application.Current.RequestedThemeVariant = ThemeVariant.Light;
                StiAvaloniaTheme.ApplyNewTheme(StiAvaloniaAppThemeAppearance.Light);
                break;

            case 1:
                Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
                StiAvaloniaTheme.ApplyNewTheme(StiAvaloniaAppThemeAppearance.Dark);
                break;
        }
    }

    private async void ButtonShowViewer_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        var stream = AssetLoader.Open(new Uri($@"avares://Change Theme in Avalonia/Reports/Blue Order.mrt"));
        report.Load(stream);
        report.CalculationMode = StiCalculationMode.Interpretation;
        var streamIcon = AssetLoader.Open(new Uri($@"avares://Change Theme in Avalonia/Assets/avalonia-logo.ico"));

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
