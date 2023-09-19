using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Stimulsoft.Report;
using Stimulsoft.Report.Viewer.Avalonia;
using Stimulsoft.Report.Viewer.Avalonia.Theme;
using Stimulsoft.Report.Viewer.Avalonia.Viewer;
using System;
using System.Diagnostics;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            //var streamLang = assets?.Open(new Uri($@"avares://TestAvalonia/Localization/ru.xml"));
            //if (streamLang != null)
            //{
            //    StiLocalization.Load(streamLang);
            //}

            InitializeComponent(true, true);

            StiOptions.Configuration.IsAvalonia = true;

            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
            StiAvaloniaTheme.ApplyNewTheme(StiAvaloniaAppThemeAppearance.Light);

            this.Opened += This_Opened;
        }

        #region Handlers.This
        private void This_Opened(object? sender, EventArgs e)
        {
            var node = treeViewReports.Items;
            if (this.DataContext is MainWindowViewModel nodel)
            {
                treeViewReports.SelectedItem = nodel.ReportItems[0].Nodes[0];
                if (treeViewReports.ItemContainerGenerator.ContainerFromIndex(0) is TreeViewItem firstItem)
                    firstItem.IsExpanded = true;
            }
        }
        #endregion

        #region Handlers
        private void TreeViewReports_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (treeViewReports.SelectedItems is AvaloniaList<object> items && items.Count > 0)
            {
                if (items[0] is MainWindowViewModel.Node node && node.Folder != null)
                {
                    var folderName = node.Folder;
                    var reportName = node.Text;

                    if (viewerPresenter.Content is StiViewerControl currentVeiwer)
                    {
                        currentVeiwer.Report = null;
                        viewerPresenter.Content = null;
                    }

                    var viewer = new StiViewerControl();

                    var sw = new Stopwatch();
                    sw.Start();

                    #region Load report
                    var report = new StiReport();
                    if (reportName.EndsWith(".mrt"))
                    {
                        var stream = AssetLoader.Open(new Uri($@"avares://Demo/Reports/{folderName}/{reportName}"));
                        report.Load(stream);
                    }
                    else
                    {
                        var stream = AssetLoader.Open(new Uri($@"avares://Demo/Reports/{folderName}/{reportName}.mdc"));
                        report.LoadDocument(stream);
                    }
                    #endregion

                    report.Info.Zoom = 1d;
                    report.CalculationMode = StiCalculationMode.Interpretation;

                    sw.Stop();

                    viewerPresenter.Content = viewer;
                    viewer.Report = report;
                }
            }
        }

        private void ButtonRefresh_Click(object? sender, RoutedEventArgs e)
        {
            TreeViewReports_OnSelectionChanged(null, null);
        }
        #endregion
    }
}