using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo;

public sealed class MainWindowViewModel
{
    public MainWindowViewModel()
    {
        
        reportsCache = new Dictionary<string, List<string>>
        {
            {
                "01_GetStartedWithReports",
                new List<string>
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
            {
                "03_BasicReports",
                new List<string>
                {
                    "01. Simple List.mrt",
                    "02. Two Simple Lists.mrt",
                    "03. Highlight Condition.mrt",
                    "04. Shapes.mrt",
                    "05. Images.mrt",
                    "06. RichText.mrt",
                    "07. Watermark.mrt",
                    "08. Bar-Codes.mrt",
                    "09. Invoice.mrt",
                    "10. Indicators.mrt",
                }
            },
            {
                "04_ReportsWithColumns",
                new List<string>
                {
                    "1. Multi-Column List.mrt",
                    "2. Multi-Column Bands - Across then Down.mrt",
                    "3. Multi-Column Bands - Down then Across.mrt",
                    "4. Labels.mrt",
                    "5. GDP Growth 2000-2021.mrt",
                }
            },
            {
                "05_MasterDetailReports",
                new List<string>
                {
                    "1. Master-Detail.mrt",
                    "2. Master-Detail-Subdetail.mrt",
                    "3. Master-Detail with Columns.mrt",
                    "4. Two Masters on One Detail.mrt",
                    "5. Master-Detail with Zero Height.mrt",
                    "6. Master-Detail on DataBand.mrt",
                }
            },
            {
                "06_ReportsWithGroups",
                new List<string>
                {
                    "01. Simple Group.mrt",
                    "02. Nested Groups.mrt",
                    "03. Top Sales.mrt",
                    "04. Master-Detail with Groups.mrt",
                    "05. Multi-Column Group.mrt",
                    "06. Groups with Ranges.mrt",
                    "07. Simple Group with Columns.mrt",
                    "08. All Group Footers at End.mrt",
                    "09. Invoice with Groups.mrt",
                    "10. Sales Invoice.mrt",
                }
            },
            {
                "11_HierarchicalReports",
                new List<string>
                {
                    "1. Tree.mrt",
                    "2. Tree with Headers and Footers.mrt",
                    "3. Tree with Totals.mrt",
                    "4. Tree with Totals - All Levels.mrt",
                    "5. Tree with Locked Components.mrt",
                }
            },
            {
                "12_ParametersInReports",
                new List<string>
                {
                    "1. Detailed Categories.mrt",
                    "2. Detailed Orders.mrt",
                    "3. Highlight Condition.mrt",
                    "4. Selecting Country.mrt",
                    "5. Invoice.mrt",
                    "6. Dependent Parameter.mrt",
                    "7. Two Dependent Parameters.mrt",
                    "8. Product Units by Category.mrt",
                }
            },
            {
                "13_InteractiveReports",
                new List<string>
                {
                    "01. List of Products.mrt",
                    "02. Cross-Tab with Detailing.mrt",
                    "03. Sorting.mrt",
                    "04. Table with Sorting.mrt",
                    "05. Group with Collapsing.mrt",
                    "06. Group with Collapsing without Footer.mrt",
                    "07. Cross-Tab with Collapsing.mrt",
                    "08. Selection.mrt",
                    "09. Multi-Selection.mrt",
                    "10. Tree with Collapsing.mrt",
                    "11. Master-Detail with Collapsing.mrt",
                    "12. Editable.mrt",
                    "13. Bookmarks and Hyperlinks.mrt",
                    "14. Anchors.mrt",
                    "15. Interactive Charts.mrt",
                }
            },
            {
                "14_ReportsWithTable",
                new List<string>
                {
                    "1. Simple Table.mrt",
                    "2. Master-Detail-Subdetail.mrt",
                    "3. Simple Group.mrt",
                    "4. Invoice with Groups.mrt",
                    "5. Images.mrt",
                    "6. Fixed Width of Columns.mrt",
                }
            },
            {
                "15_ReportsWithCharts",
                new List<string>
                {
                    "01. Simple Chart.mrt",
                    "02. Multiple Series.mrt",
                    "03. Chart on Databand.mrt",
                    "04. Charts with Negatives.mrt",
                    "05. Global Growth.mrt",
                    "06. Tasks by Date.mrt",
                    "07. Stepped Chart.mrt",
                    "08. Migration by Decade in USA.mrt",
                    "09. Natural Gas Production.mrt",
                    "10. Top Auto Sales.mrt",
                    "11. Combined Charts.mrt",
                    "12. Clustered Column.mrt",
                    "13. Line.mrt",
                    "14. Pie.mrt",
                    "15. Doughnut.mrt",
                    "16. Clustered Bar.mrt",
                    "17. Gantt.mrt",
                    "18. Area.mrt",
                    "19. Range.mrt",
                    "20. Scatter.mrt",
                    "21. Bubble.mrt",
                    "22. Funnel.mrt",
                    "23. Financial.mrt",
                    "24. Radar.mrt",
                    "25. Treemap.mrt",
                    "26. Sunburst.mrt",
                    "27. Histogram.mrt",
                    "28. Pareto.mrt",
                    "29. Waterfall.mrt",
                    "30. Pictorial.mrt",
                }
            },
            {
                "16_ReportsWithGauges",
                new List<string>
                {
                    "1. Linear.mrt",
                    "2. Radial.mrt",
                }
            },
            {
                "17_CrossTab",
                new List<string>
                {
                    "01. Standard Cross-Tab.mrt",
                    "02. Cross-Tab without Columns.mrt",
                    "03. Cross-Tab without Rows.mrt",
                    "04. Cross-Tab with Highlight Condition 1.mrt",
                    "05. Cross-Tab with Highlight Condition 2.mrt",
                    "06. Cross-Tab with Two Summaries.mrt",
                    "07. Two Cross-Tabs.mrt",
                    "08. Wrapped Cross-Tabs.mrt",
                    "09. Large Cross-Tab.mrt",
                    "10. Cross-Tab on DataBand.mrt",
                    "11. Cross-Tab and Cross-Bands.mrt",
                    "12. Cross-Tab on Page.mrt",
                    "13. Cross-Tab with Images.mrt",
                }
            },
            {
                "18_EmptyRowsInReports",
                new List<string>
                {
                    "1. Simple List.mrt",
                    "2. Master-Detail.mrt",
                    "3. Invoice.mrt"
                }
            },
            {
                "19_UsingPanelsInReports",
                new List<string>
                {
                    "1. Side-by-Side Lists.mrt",
                    "2. Side-by-Side Groups.mrt",
                    "3. Multi-Column List.mrt",
                    "4. Multi-Panels.mrt",
                    "5. Master-Detail Cards.mrt",
                }
            },
            {
                "20_SubReports",
                new List<string>
                {
                    "1. Side-by-Side Lists.mrt",
                    "2. Side-by-Side Lists on DataBand.mrt",
                    "3. Side-by-Side Groups.mrt",
                    "4. Master-Detail.mrt",
                }
            },
            {
                "21_Maps",
                new List<string>
                {
                    "01. map.mrt",
                    "Maps 1.mrt",
                }
            },
            {
                "22_3dCharts",
                new List<string>
                {
                    "01. 3D Pie Chart.mrt",
                    "02. Hulu Revenue Statistics.mrt",
                    "03. Income from Hobby Trading.mrt",
                    "04. Internet browser market share in Europe.mrt",
                    "05. Lab Test Turnaround.mrt",
                    "06. Microsoft's revenue worldwide.mrt",
                    "07. Statistic Disney.mrt",
                    "08. The chemical composition of the Earth.mrt",
                    "09. Wallet.mrt",
                }
            },
            {
                "Test",
                new List<string>
                {
                    "01_MasterDetailReportWithTOC.mrt",
                }
            },
        };
        
        foreach (var key in reportsCache.Keys)
        {
            var folderNode = new Node(key)
            {
                Nodes = new ()
            };

            var values = reportsCache[key];
            foreach (var value in values)
            {
                var nodeReport = new Node(key, value);
                folderNode.Nodes.Add(nodeReport);
            }
            
            ReportItems.Add(folderNode);
        }
    }
    
    #region Fields
    private Dictionary<string, List<string>> reportsCache = new Dictionary<string, List<string>>();
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