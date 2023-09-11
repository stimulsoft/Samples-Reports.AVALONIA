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
using System.IO;

namespace Exporting_a_Report_from_Code.Views;

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

    #region Methods
    public Stream GetReportStream()
    {
        var item = listBoxReports.SelectedItem as ListBoxItem;
        return AssetLoader.Open(new Uri($@"avares://Exporting a Report from Code/Reports/{item.Content}.mrt"));
    }
    #endregion

    #region Handlers
    private async void ButtonPreview_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        report.Load(GetReportStream());
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

    private async void ButtonExport_Click(object sender, RoutedEventArgs e)
    {
        var report = new StiReport();
        report.Load(GetReportStream());
        report.CalculationMode = StiCalculationMode.Interpretation;
        report.RenderWithWpf(false);

        if (radioButtonPdf.IsChecked == true)
        {
            await StiViewerControl.ExportPdfAsync(report);
        }
        else if (radioButtonHtml.IsChecked == true)
        {
            await StiViewerControl.ExportHtmlAsync(report);
        }
        else if (radioButtonExcel.IsChecked == true)
        {
            await StiViewerControl.ExportExcelAsync(report);
        }
        else if (radioButtonText.IsChecked == true)
        {
            await StiViewerControl.ExportTxtAsync(report);
        }
        else if (radioButtonRtf.IsChecked == true)
        {
            await StiViewerControl.ExportRtfAsync(report);
        }
    }
    #endregion
}
