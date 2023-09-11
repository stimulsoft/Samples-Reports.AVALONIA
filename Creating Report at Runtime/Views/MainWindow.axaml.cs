using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Stimulsoft.Base.Drawing;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Viewer.Avalonia;
using Stimulsoft.Report.Viewer.Avalonia.Theme;
using Stimulsoft.Report.Viewer.Avalonia.Viewer;
using System;
using System.Data;
using System.Drawing;

namespace Creating_Report_at_Runtime.Views;

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
    private async void ButtonCreateSimpleReport_Click(object sender, RoutedEventArgs e)
    {
        var dataXml = AssetLoader.Open(new Uri($@"avares://Creating Report at Runtime/Data/Demo.xml"));
        var dataXsd = AssetLoader.Open(new Uri($@"avares://Creating Report at Runtime/Data/Demo.xsd"));

        var dataSet1 = new DataSet();
        dataSet1.ReadXmlSchema(dataXsd);
        dataSet1.ReadXml(dataXml);
        dataSet1.DataSetName = "Demo";

        var report = new StiReport();

        //Add data to datastore
        report.RegData(dataSet1);

        //Fill dictionary
        report.Dictionary.Synchronize();

        var page = report.Pages[0];

        //Create HeaderBand
        var headerBand = new StiHeaderBand();
        headerBand.Height = 0.5;
        headerBand.Name = "HeaderBand";
        page.Components.Add(headerBand);

        //Create text on header
        var headerText = new StiText(new RectangleD(0, 0, 5, 0.5));
        headerText.Text = "CompanyName";
        headerText.HorAlignment = StiTextHorAlignment.Center;
        headerText.Name = "HeaderText";
        headerText.Brush = new StiSolidBrush(Color.LightGreen);
        headerBand.Components.Add(headerText);

        //Create Databand
        var dataBand = new StiDataBand();
        dataBand.DataSourceName = "Customers";
        dataBand.Height = 0.5;
        dataBand.Name = "DataBand";
        page.Components.Add(dataBand);

        //Create text
        var dataText = new StiText(new RectangleD(0, 0, 5, 0.5));
        dataText.Text = "{Line}.{Customers.CompanyName}";
        dataText.Name = "DataText";
        dataBand.Components.Add(dataText);

        //Create FooterBand
        var footerBand = new StiFooterBand();
        footerBand.Height = 0.5;
        footerBand.Name = "FooterBand";
        page.Components.Add(footerBand);

        //Create text on footer
        var footerText = new StiText(new RectangleD(0, 0, 5, 0.5));
        footerText.Text = "Count - {Count()}";
        footerText.HorAlignment = StiTextHorAlignment.Right;
        footerText.Name = "FooterText";
        footerText.Brush = new StiSolidBrush(Color.LightGreen);
        footerBand.Components.Add(footerText);

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

    private async void ButtonCreateCrossTab_Click(object sender, RoutedEventArgs e)
    {
        var dataXml = AssetLoader.Open(new Uri($@"avares://Creating Report at Runtime/Data/Demo.xml"));
        var dataXsd = AssetLoader.Open(new Uri($@"avares://Creating Report at Runtime/Data/Demo.xsd"));

        var dataSet1 = new DataSet();
        dataSet1.ReadXmlSchema(dataXsd);
        dataSet1.ReadXml(dataXml);
        dataSet1.DataSetName = "Demo";

        var report = new StiReport();
        report.RegData(dataSet1);
        report.Dictionary.Synchronize();

        Stimulsoft.Report.CrossTab.StiCrossTab crossTab1 = new Stimulsoft.Report.CrossTab.StiCrossTab();
        crossTab1.ClientRectangle = new RectangleD(1.8, 4.6, 14.6, 13);
        crossTab1.DataSourceName = "Categories";
        crossTab1.Name = "CrossTab1";

        Stimulsoft.Report.CrossTab.StiCrossRowTotal crossTab1_RowTotal1 = new Stimulsoft.Report.CrossTab.StiCrossRowTotal();
        crossTab1_RowTotal1.Guid = "416a93a6cbff4f24929c07006f5f4c21";
        crossTab1_RowTotal1.Name = "CrossTab1_RowTotal1";
        crossTab1_RowTotal1.Text.Value = "Total";

        Stimulsoft.Report.CrossTab.StiCrossTitle crossTab1_Row1_Title = new Stimulsoft.Report.CrossTab.StiCrossTitle();
        crossTab1_Row1_Title.Name = "CrossTab1_Row1_Title";
        crossTab1_Row1_Title.TypeOfComponent = "Row:CrossTab1_Row1";
        crossTab1_Row1_Title.Text.Value = "CategoryID";

        Stimulsoft.Report.CrossTab.StiCrossColumnTotal crossTab1_ColTotal1 = new Stimulsoft.Report.CrossTab.StiCrossColumnTotal();
        crossTab1_ColTotal1.Guid = "9e5a67edfe87448e96ebcf75e4ef19c4";
        crossTab1_ColTotal1.Name = "CrossTab1_ColTotal1";
        crossTab1_ColTotal1.Text.Value = "Total";

        Stimulsoft.Report.CrossTab.StiCrossTitle crossTab1_LeftTitle = new Stimulsoft.Report.CrossTab.StiCrossTitle();
        crossTab1_LeftTitle.Guid = "a4a019be008042c9a4c4b604e041ceba";
        crossTab1_LeftTitle.Name = "CrossTab1_LeftTitle";
        crossTab1_LeftTitle.TypeOfComponent = "LeftTitle";
        crossTab1_LeftTitle.Text.Value = "Categories";

        Stimulsoft.Report.CrossTab.StiCrossRow crossTab1_Row1 = new Stimulsoft.Report.CrossTab.StiCrossRow();
        crossTab1_Row1.Alias = "CategoryID";
        crossTab1_Row1.Guid = "7f0d8b9785504d009e6afe47f70a74d3";
        crossTab1_Row1.Name = "CrossTab1_Row1";
        crossTab1_Row1.TotalGuid = "416a93a6cbff4f24929c07006f5f4c21";
        crossTab1_Row1.DisplayValue.Value = "{Categories.CategoryID}";
        crossTab1_Row1.Value.Value = "{Categories.CategoryID}";

        Stimulsoft.Report.CrossTab.StiCrossColumn crossTab1_Column1 = new Stimulsoft.Report.CrossTab.StiCrossColumn();
        crossTab1_Column1.Alias = "CategoryName";
        crossTab1_Column1.Guid = "fc86b73eb9694091b62b55fce6041715";
        crossTab1_Column1.Name = "CrossTab1_Column1";
        crossTab1_Column1.TotalGuid = "9e5a67edfe87448e96ebcf75e4ef19c4";
        crossTab1_Column1.DisplayValue.Value = "{Categories.CategoryName}";
        crossTab1_Column1.Value.Value = "{Categories.CategoryName}";

        Stimulsoft.Report.CrossTab.StiCrossSummary crossTab1_Sum1 = new Stimulsoft.Report.CrossTab.StiCrossSummary();
        crossTab1_Sum1.Alias = "Description";
        crossTab1_Sum1.Guid = "ec4c270655bf49a58766bf36a2b21c5c";
        crossTab1_Sum1.Name = "CrossTab1_Sum1";
        crossTab1_Sum1.Summary = Stimulsoft.Report.CrossTab.Core.StiSummaryType.None;
        crossTab1_Sum1.Value.Value = "{Categories.Description}";

        Stimulsoft.Report.CrossTab.StiCrossTitle crossTab1_RightTitle = new Stimulsoft.Report.CrossTab.StiCrossTitle();
        crossTab1_RightTitle.Guid = "43929f3151c248b6b4e07b0a8ea44f93";
        crossTab1_RightTitle.Name = "CrossTab1_RightTitle";
        crossTab1_RightTitle.TypeOfComponent = "RightTitle";
        crossTab1_RightTitle.Text.Value = "CategoryName";

        report.Pages[0].Components.Add(crossTab1);
        crossTab1.Components.AddRange(new Stimulsoft.Report.Components.StiComponent[] {
                        crossTab1_RowTotal1,
                        crossTab1_Row1_Title,
                        crossTab1_ColTotal1,
                        crossTab1_LeftTitle,
                        crossTab1_Row1,
                        crossTab1_Column1,
                        crossTab1_Sum1,
                        crossTab1_RightTitle});

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
