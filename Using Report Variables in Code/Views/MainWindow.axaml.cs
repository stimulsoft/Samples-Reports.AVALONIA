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
using System.Linq;

namespace Using_Report_Variables_in_Code.Views;

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
    private async void ButtonShow_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        report.Load(AssetLoader.Open(new Uri($@"avares://Using Report Variables in Code/Reports/Variables.mrt")));
        report.CalculationMode = StiCalculationMode.Interpretation;

        report["Name"] = tbName.Text;
        report["Surname"] = tbSurname.Text;
        report["Email"] = tbEmail.Text;
        report["Address"] = tbAddress.Text;
        report["Sex"] = rbMale.IsChecked.GetValueOrDefault();
        report["BirthDay"] = dtBirthDay.SelectedDate.GetValueOrDefault().DateTime;

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
