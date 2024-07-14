using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo;

public sealed class MainWindowViewModel
{
    #region class StiFolderInfo
    internal class StiFolderInfo
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public List<string> Reports { get; set; }
    }
    #endregion

    public MainWindowViewModel()
    {

        reportsCache = new List<StiFolderInfo>
        {
            new StiFolderInfo(){
                Key = "01_GetStartedWithReports",
                Name = "Get Started with Reports",
                Reports = new List<string>
                {
                    "Blue Order.mrt",
                    "Invoice Green.mrt",
                    "Invoice Quotation.mrt",
                    "Invoice Software.mrt",
                    "Purchase Order.mrt",
                    "Revenue - Expenses.mrt",
                    "Switzerland Invoice.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "02_BasicReports",
                Name = "Basic Reports",
                Reports = new List<string>
                {
                    "Simple List.mrt",
                    "Two Simple Lists.mrt",
                    "Highlight Condition.mrt",
                    "Shapes.mrt",
                    "Images.mrt",
                    "Watermark.mrt",
                    "Bar-Codes.mrt",
                    "Invoice.mrt",
                    "Indicators.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "03_ReportsWithColumns",
                Name = "Reports with Columns",
                Reports = new List<string>
                {
                    "Multi-Column List.mrt",
                    "Multi-Column Bands - Across then Down.mrt",
                    "Multi-Column Bands - Down then Across.mrt",
                    "Labels.mrt",
                    "GDP Growth 2000-2021.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "04_MasterDetailReports",
                Name = "Master-Detail Reports",
                Reports = new List<string>
                {
                    "Master-Detail.mrt",
                    "Master-Detail-Subdetail.mrt",
                    "Master-Detail with Columns.mrt",
                    "Two Masters on One Detail.mrt",
                    "Master-Detail with Zero Height.mrt",
                    "Master-Detail on DataBand.mrt",
                }
            },
             new StiFolderInfo(){
                Key ="05_ReportsWithGroups",
                Name ="Reports with Groups",
                Reports = new List<string>
                {
                    "Simple Group.mrt",
                    "Nested Groups.mrt",
                    "Top Sales.mrt",
                    "Master-Detail with Groups.mrt",
                    "Multi-Column Group.mrt",
                    "Groups with Ranges.mrt",
                    "Simple Group with Columns.mrt",
                    "All Group Footers at End.mrt",
                    "Invoice with Groups.mrt",
                    "Sales Invoice.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "06_HierarchicalReports",
                Name = "Hierarchical Reports",
                Reports = new List<string>
                {
                    "Tree.mrt",
                    "Tree with Headers and Footers.mrt",
                    "Tree with Totals.mrt",
                    "Tree with Totals - All Levels.mrt",
                    "Tree with Locked Components.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "07_ParametersInReports",
                Name = "Parameters in Reports",
                Reports = new List<string>
                {
                    "Detailed Categories.mrt",
                    "Detailed Orders.mrt",
                    "Highlight Condition.mrt",
                    "Selecting Country.mrt",
                    "Invoice.mrt",
                    "Dependent Parameter.mrt",
                    "Two Dependent Parameters.mrt",
                    "Product Units by Category.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "08_InteractiveReports",
                Name = "Interactive Reports",
                Reports = new List<string>
                {
                    "List of Products.mrt",
                    "Cross-Tab with Detailing.mrt",
                    "Sorting.mrt",
                    "Table with Sorting.mrt",
                    "Group with Collapsing.mrt",
                    "Group with Collapsing without Footer.mrt",
                    "Cross-Tab with Collapsing.mrt",
                    "Tree with Collapsing.mrt",
                    "Master-Detail with Collapsing.mrt",
                    "Editable.mrt",
                    "Bookmarks and Hyperlinks.mrt",
                    "Anchors.mrt",
                    "Interactive Charts.mrt",
                }
            },
             new StiFolderInfo(){
                Key = "09_ReportsWithTable",
                Name = "Reports with Table",
                Reports = new List<string>
                {
                    "Simple Table.mrt",
                    "Master-Detail-Subdetail.mrt",
                    "Simple Group.mrt",
                    "Invoice with Groups.mrt",
                    "Images.mrt",
                    "Fixed Width of Columns.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "10_ReportsWithCharts",
                Name = "Reports with Charts",
                Reports = new List<string>
                {
                    "Simple Chart.mrt",
                    "Multiple Series.mrt",
                    "Chart on Databand.mrt",
                    "Charts with Negatives.mrt",
                    "Global Growth.mrt",
                    "Tasks by Date.mrt",
                    "Stepped Chart.mrt",
                    "Migration by Decade in USA.mrt",
                    "Natural Gas Production.mrt",
                    "Top Auto Sales.mrt",
                    "Combined Charts.mrt",
                    "Clustered Column.mrt",
                    "Line.mrt",
                    "Pie.mrt",
                    "Doughnut.mrt",
                    "Clustered Bar.mrt",
                    "Gantt.mrt",
                    "Area.mrt",
                    "Range.mrt",
                    "Scatter.mrt",
                    "Bubble.mrt",
                    "Funnel.mrt",
                    "Financial.mrt",
                    "Radar.mrt",
                    "Treemap.mrt",
                    "Sunburst.mrt",
                    "Histogram.mrt",
                    "Pareto.mrt",
                    "Waterfall.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "11_ReportsWithGauges",
                Name = "Reports with Gauges",
                Reports = new List<string>
                {
                    "Linear.mrt",
                    "Radial.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "12_ReportsWithCrossTab",
                Name = "Reports with Cross-Tab",
                Reports = new List<string>
                {
                    "Standard Cross-Tab.mrt",
                    "Cross-Tab without Columns.mrt",
                    "Cross-Tab without Rows.mrt",
                    "Cross-Tab with Highlight Condition 1.mrt",
                    "Cross-Tab with Highlight Condition 2.mrt",
                    "Cross-Tab with Two Summaries.mrt",
                    "Two Cross-Tabs.mrt",
                    "Wrapped Cross-Tabs.mrt",
                    "Large Cross-Tab.mrt",
                    "Cross-Tab on DataBand.mrt",
                    "Cross-Tab and Cross-Bands.mrt",
                    "Cross-Tab on Page.mrt",
                    "Cross-Tab with Images.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "13_EmptyRowsInReports",
                Name = "Empty Rows in Reports",
                Reports = new List<string>
                {
                    "Simple List.mrt",
                    "Master-Detail.mrt",
                    "Invoice.mrt"
                }
            },
            new StiFolderInfo(){
                Key = "14_UsingPanelsInReports",
                Name = "Using Panels in Reports",
                Reports = new List<string>
                {
                    "Side-by-Side Lists.mrt",
                    "Side-by-Side Groups.mrt",
                    "Multi-Column List.mrt",
                    "Multi-Panels.mrt",
                    "Master-Detail Cards.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "15_ReportsWithSubReports",
                Name = "Reports with Sub-Report",
                Reports = new List<string>
                {
                    "Side-by-Side Lists.mrt",
                    "Side-by-Side Lists on DataBand.mrt",
                    "Side-by-Side Groups.mrt",
                    "Master-Detail.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "16_ReportsWithMap",
                Name = "Reports with Map",
                Reports = new List<string>
                {
                    "Individual Map.mrt",
                    "Map with Group.mrt",
                    "Heatmap.mrt",
                    "Heatmap with Group.mrt",
                }
            },
            new StiFolderInfo(){
                Key = "17_3dChartsInReports",
                Name = "3D Charts in Reports",
                Reports = new List<string>
                {
                    "3D Pie Chart.mrt",
                    "Hulu Revenue Statistics.mrt",
                    "Income from Hobby Trading.mrt",
                    "Internet browser market share in Europe.mrt",
                    "Lab Test Turnaround.mrt",
                    "Microsoft's revenue worldwide.mrt",
                    "Statistic Disney.mrt",
                    "The chemical composition of the Earth.mrt",
                    "Wallet.mrt",
                }
            },
        };

        foreach (var info in reportsCache)
        {
            var folderNode = new Node(info.Name)
            {
                Nodes = new()
            };

            foreach (var report in info.Reports)
            {
                var nodeReport = new Node(info.Key, report);
                folderNode.Nodes.Add(nodeReport);
            }

            ReportItems.Add(folderNode);
        }
    }

    #region Fields
    //private Dictionary<string, List<string>> reportsCache = new Dictionary<string, List<string>>();
    private List<StiFolderInfo> reportsCache = new List<StiFolderInfo>();
    #endregion

    #region Properties
    public ObservableCollection<Node> ReportItems { get; } = new();
    #endregion

    #region class Node
    public sealed class Node
    {
        #region Properties
        public ObservableCollection<Node> Nodes { get; set; }

        public string Folder { get; }

        public string Text { get; }
        #endregion

        public Node(string text)
        {
            Text = text;
        }

        public Node(string folder, string text)
        {
            Folder = folder;
            Text = text;
        }
    }
    #endregion
}