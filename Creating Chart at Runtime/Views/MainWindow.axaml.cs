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
using System.IO;

namespace Creating_Chart_at_Runtime.Views;

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
    public class DataDataSource : Stimulsoft.Report.Dictionary.StiDataTableSource
    {
        public DataDataSource() :
                base("Data.Data", "Data", "Data", "6974e28fa8754b298fa767db9df3a4d5")
        {
        }

        public virtual double Units
        {
            get
            {
                return ((double)(StiReport.ChangeType(this["Units"], typeof(double), true)));
            }
        }

        public virtual double Units_in_Stock
        {
            get
            {
                return ((double)(StiReport.ChangeType(this["Units in Stock"], typeof(double), true)));
            }
        }

        public virtual double Units_Ordered
        {
            get
            {
                return ((double)(StiReport.ChangeType(this["Units Ordered"], typeof(double), true)));
            }
        }

        public virtual string Year
        {
            get
            {
                return ((string)(StiReport.ChangeType(this["Year"], typeof(string), true)));
            }
        }
    }

    public void Item5__GetTitle(object sender, Stimulsoft.Report.Events.StiGetTitleEventArgs e)
    {
        e.Value = "Series 1";
    }
    #endregion

    #region Handlers
    private async void ButtonCreateChart_Click(object sender, RoutedEventArgs e)
    {
        byte[] dataBuffer = null;
        using (var data = AssetLoader.Open(new Uri($@"avares://Creating Chart at Runtime/Data/Data.xlsx")))
        using (var memoryStream = new MemoryStream())
        {
            data.CopyTo(memoryStream);
            dataBuffer = memoryStream.ToArray();
        }

        var report = new StiReport();

        Stimulsoft.Report.Components.StiPage page;
        Stimulsoft.Report.Chart.StiChart chart;
        Stimulsoft.Report.Chart.StiGanttArea chartArea;
        Stimulsoft.Report.Chart.StiGanttSeries ganttSeries;
        Stimulsoft.Report.Chart.StiCenterAxisLabels centerAxisLabels;
        DataDataSource Data;

        Data = new DataDataSource();
        page = new Stimulsoft.Report.Components.StiPage
        {
            PageWidth = 8.27,
            PageHeight = 11.69,
            Alias = "Gantt",
            Guid = "3a7d7edd89b2440f84fee03628209a97",
            Name = "Gantt",
            PaperSize = System.Drawing.Printing.PaperKind.A4,
            Border = new Stimulsoft.Base.Drawing.StiBorder(Stimulsoft.Base.Drawing.StiBorderSides.None, System.Drawing.Color.Black, 2, Stimulsoft.Base.Drawing.StiPenStyle.Solid, false, 4, new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.Black), false),
            Brush = new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.Transparent),
            Margins = new Stimulsoft.Report.Components.StiMargins(0, 0, 0, 0),
            Report = report
        };
        report.Pages.Clear();
        report.Pages.AddRange(new StiPage[] { page });


        chart = new Stimulsoft.Report.Chart.StiChart
        {
            ClientRectangle = new Stimulsoft.Base.Drawing.RectangleD(0.1, 0.1, 7.3, 6.3),
            CustomStyleName = "Chart",
            EditorType = Stimulsoft.Report.Chart.StiChartEditorType.Simple,
            Name = "Chart1",
            Border = new Stimulsoft.Base.Drawing.StiBorder(Stimulsoft.Base.Drawing.StiBorderSides.All, System.Drawing.Color.Transparent, 1, Stimulsoft.Base.Drawing.StiPenStyle.Solid, false, 4, new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 0)), false),
            Brush = new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.FromArgb(255, 255, 255, 255)),
            Interaction = null,
            Page = page,
            Parent = page,
            Style = new Stimulsoft.Report.Chart.StiCustomStyle()
        };

        chartArea = new Stimulsoft.Report.Chart.StiGanttArea
        {
            BorderColor = System.Drawing.Color.FromArgb(255, 95, 72, 29),
            BorderThickness = 1F,
            ColorEach = true,
            Brush = new Stimulsoft.Base.Drawing.StiGradientBrush(System.Drawing.Color.FromArgb(255, 255, 255, 255), System.Drawing.Color.FromArgb(255, 255, 255, 219), 90),
            GridLinesHorRight = new Stimulsoft.Report.Chart.StiGridLinesHor(System.Drawing.Color.Silver, Stimulsoft.Base.Drawing.StiPenStyle.Dot, false, System.Drawing.Color.Gainsboro, Stimulsoft.Base.Drawing.StiPenStyle.Dot, false, 0, true),
            YAxis = new Stimulsoft.Report.Chart.StiYLeftAxis(new Stimulsoft.Report.Chart.StiAxisLabels("", "", "", 0F, new System.Drawing.Font("Tahoma", 8F), true, Stimulsoft.Report.Chart.StiLabelsPlacement.OneLine, System.Drawing.Color.FromArgb(255, 95, 72, 29), 0F, Stimulsoft.Base.Drawing.StiHorAlignment.Right, 0F, true, false), new Stimulsoft.Report.Chart.StiAxisRange(true, 0, 0), new Stimulsoft.Report.Chart.StiAxisTitle(new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold), "", System.Drawing.Color.FromArgb(255, 95, 72, 29), true, System.Drawing.StringAlignment.Center, Stimulsoft.Report.Chart.StiDirection.BottomToTop, true, Stimulsoft.Report.Chart.StiTitlePosition.Outside), new Stimulsoft.Report.Chart.StiAxisTicks(true, 5F, false, 2F, 4, 0, 5F), new Stimulsoft.Report.Chart.StiAxisInteraction(false, true), Stimulsoft.Report.Chart.StiArrowStyle.None, Stimulsoft.Base.Drawing.StiPenStyle.Solid, System.Drawing.Color.FromArgb(255, 95, 72, 29), 1F, true, true, Stimulsoft.Report.Chart.StiShowYAxis.Both, true, false),
            YRightAxis = new Stimulsoft.Report.Chart.StiYRightAxis(new Stimulsoft.Report.Chart.StiAxisLabels("", "", "", 0F, new System.Drawing.Font("Tahoma", 8F), true, Stimulsoft.Report.Chart.StiLabelsPlacement.OneLine, System.Drawing.Color.FromArgb(255, 95, 72, 29), 0F, Stimulsoft.Base.Drawing.StiHorAlignment.Left, 0F, true, false), new Stimulsoft.Report.Chart.StiAxisRange(true, 0, 0), new Stimulsoft.Report.Chart.StiAxisTitle(new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold), "", System.Drawing.Color.FromArgb(255, 95, 72, 29), true, System.Drawing.StringAlignment.Center, Stimulsoft.Report.Chart.StiDirection.TopToBottom, true, Stimulsoft.Report.Chart.StiTitlePosition.Outside), new Stimulsoft.Report.Chart.StiAxisTicks(true, 5F, false, 2F, 4, 0, 5F), new Stimulsoft.Report.Chart.StiAxisInteraction(false, true), Stimulsoft.Report.Chart.StiArrowStyle.None, Stimulsoft.Base.Drawing.StiPenStyle.Solid, System.Drawing.Color.FromArgb(255, 95, 72, 29), 1F, false, true, true, false),
            Chart = chart
        };

        ganttSeries = new Stimulsoft.Report.Chart.StiGanttSeries
        {
            ArgumentDataColumn = "Data.Year",
            BorderColor = System.Drawing.Color.FromArgb(255, 94, 17, 0),
            ShowShadow = false,
            ValueDataColumn = "Data.Units_in_Stock",
            ValueDataColumnEnd = "Data.Units_Ordered",
            Brush = new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.FromArgb(255, 194, 117, 53)),
            BrushNegative = new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.Firebrick),
            Chart = chart
        };
        ganttSeries.GetTitle += new Stimulsoft.Report.Events.StiGetTitleEventHandler(this.Item5__GetTitle);

        centerAxisLabels = new Stimulsoft.Report.Chart.StiCenterAxisLabels
        {
            BorderColor = System.Drawing.Color.FromArgb(255, 95, 72, 29),
            LabelColor = System.Drawing.Color.FromArgb(255, 95, 72, 29),
            MarkerSize = new System.Drawing.Size(8, 6),
            ValueTypeSeparator = "-",
            Width = 0,
            Brush = new Stimulsoft.Base.Drawing.StiSolidBrush(System.Drawing.Color.Wheat),
            Font = new System.Drawing.Font("Arial", 7F),
            Chart = chart
        };

        chart.Area = chartArea;
        chart.SeriesLabels = centerAxisLabels;
        ganttSeries.SeriesLabels = centerAxisLabels;

        chart.Series.Clear();
        chart.Series.AddRange(new Stimulsoft.Report.Chart.IStiSeries[] { ganttSeries });

        page.Components.Clear();
        page.Components.AddRange(new StiComponent[] { chart });

        Data.Columns.AddRange(new Stimulsoft.Report.Dictionary.StiDataColumn[] {
                        new Stimulsoft.Report.Dictionary.StiDataColumn("Units", "Units", "Units", typeof(double), null),
                        new Stimulsoft.Report.Dictionary.StiDataColumn("Units in Stock", "Units in Stock", "Units in Stock", typeof(double), null),
                        new Stimulsoft.Report.Dictionary.StiDataColumn("Units Ordered", "Units Ordered", "Units Ordered", typeof(double), null),
                        new Stimulsoft.Report.Dictionary.StiDataColumn("Year", "Year", "Year", typeof(string), null)});
        report.Dictionary.Resources.Add("Data", Stimulsoft.Report.Dictionary.StiResourceType.Excel, dataBuffer);
        report.DataSources.Add(Data);
        report.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiExcelDatabase("Data", "resource://Data", "935c893d445c42d7b4113a6b5cc797e2", true));
        report.Dictionary.Synchronize();

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
