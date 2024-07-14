using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using Avalonia.Styling;
using Stimulsoft.Report;
using Stimulsoft.Report.Viewer.Avalonia;
using Stimulsoft.Report.Viewer.Avalonia.Theme;
using System;

namespace Customizing_the_Viewer.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // How to Activate
        //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
        //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
        //Stimulsoft.Base.StiLicense.LoadFromStream(stream);

        StiOptions.Configuration.IsAvalonia = true;

        Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        StiAvaloniaTheme.ApplyNewTheme(StiAvaloniaAppThemeAppearance.Light);

        #region Init
        var report = new StiReport();
        var stream = AssetLoader.Open(new Uri($@"avares://Customizing the Viewer/Reports/Blue Order.mrt"));
        report.Load(stream);
        report.CalculationMode = StiCalculationMode.Interpretation;

        viewerControl.Report = report;

        checkBoxShowReportOpen.IsChecked = viewerControl.ShowReportOpen;
        checkBoxShowReportSave.IsChecked = viewerControl.ShowReportSave;
        checkBoxShowReportSaveDocument.IsChecked = viewerControl.ShowReportSaveDocument;

        checkBoxShowPageNew.IsChecked = viewerControl.ShowPageNew;
        checkBoxShowPageDelete.IsChecked = viewerControl.ShowPageDelete;

        checkBoxShowBookmarks.IsChecked = viewerControl.ShowBookmarks;
        checkBoxShowParameters.IsChecked = viewerControl.ShowParameters;

        checkBoxShowToolEditor.IsChecked = viewerControl.ShowToolEditor;
        checkBoxShowToolFind.IsChecked = viewerControl.ShowToolFind;
        checkBoxShowSignature.IsChecked = viewerControl.ShowSignature;

        checkBoxShowClose.IsChecked = viewerControl.ShowClose;

        checkBoxShowStatusBar.IsChecked = viewerControl.ShowStatusBar;
        checkBoxShowHorScrollBar.IsChecked = viewerControl.ShowHorScrollBar;
        checkBoxShowVertScrollBar.IsChecked = viewerControl.ShowVertScrollBar;

        checkBoxShowPageFirst.IsChecked = viewerControl.ShowPageFirst;
        checkBoxShowPagePrevious.IsChecked = viewerControl.ShowPagePrevious;
        checkBoxShowPageGoTo.IsChecked = viewerControl.ShowPageGoTo;
        checkBoxShowPageNext.IsChecked = viewerControl.ShowPageNext;
        checkBoxShowPageLast.IsChecked = viewerControl.ShowPageLast;
        #endregion
    }

    #region Handlers
    private void CheckBoxShowReportOpen_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowReportOpen = checkBoxShowReportOpen.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowReportSave_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowReportSave = checkBoxShowReportSave.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowReportSaveDocument_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowReportSaveDocument = checkBoxShowReportSaveDocument.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageNew_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageNew = checkBoxShowPageNew.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageDelete_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageDelete = checkBoxShowPageDelete.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageFirst_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageFirst = checkBoxShowPageFirst.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPagePrevious_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPagePrevious = checkBoxShowPagePrevious.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageGoTo_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageGoTo = checkBoxShowPageGoTo.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageNext_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageNext = checkBoxShowPageNext.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowPageLast_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowPageLast = checkBoxShowPageLast.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowBookmarks_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowBookmarks = checkBoxShowBookmarks.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowParameters_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowParameters = checkBoxShowParameters.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowToolEditor_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowToolEditor = checkBoxShowToolEditor.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowToolFind_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowToolFind = checkBoxShowToolFind.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowSignature_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowSignature = checkBoxShowSignature.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowClose_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowClose = checkBoxShowClose.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowStatusBar_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowStatusBar = checkBoxShowStatusBar.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowHorScrollBar_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowHorScrollBar = checkBoxShowHorScrollBar.IsChecked.GetValueOrDefault();
    }

    private void CheckBoxShowVertScrollBar_Click(object sender, RoutedEventArgs e)
    {
        viewerControl.ShowVertScrollBar = checkBoxShowVertScrollBar.IsChecked.GetValueOrDefault();
    }
    #endregion
}
