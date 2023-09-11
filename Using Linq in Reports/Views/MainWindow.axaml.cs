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

namespace Using_Linq_in_Reports.Views;

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

        var items = new Item[] 
        { 
            new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Jim Bob"},
            new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "John Fox"},
            new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Phil Funk"},
            new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Eddie Jones"}
        };

        var query1 = from i in items
                     where i.Price > 9.99
                     orderby i.Price
                     select i;

        report.Load(AssetLoader.Open(new Uri($@"avares://Using Linq in Reports/Reports/Report.mrt")));
        report.RegBusinessObject("MyData", "MyData", query1);
        report.CalculationMode = StiCalculationMode.Interpretation;
    }

    #region Fields
    private StiReport report = new StiReport();
    #endregion

    #region Handlers
    private async void ButtonShow_Click(object sender, RoutedEventArgs e)
    {
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
