using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rftim3WinFormsCL;
using Rftim3WinFormsUCL.RftAD;
using Rftim3WinFormsUCL.RftAuthentication;
using Rftim3WinFormsUCL.RftAuthorization;
using Rftim3WinFormsUCL.RftBackgroundWorker;
using Rftim3WinFormsUCL.RftBarChart;
using Rftim3WinFormsUCL.RftBindingSource;
using Rftim3WinFormsUCL.RftButton;
using Rftim3WinFormsUCL.RftCheckBox;
using Rftim3WinFormsUCL.RftCheckedListBox;
using Rftim3WinFormsUCL.RftColorDialog;
using Rftim3WinFormsUCL.RftColumnChart;
using Rftim3WinFormsUCL.RftComboBox;
using Rftim3WinFormsUCL.RftConsole;
using Rftim3WinFormsUCL.RftContextMenuStrip;
using Rftim3WinFormsUCL.RftCSV;
using Rftim3WinFormsUCL.RftDataGridView;
using Rftim3WinFormsUCL.RftDateTimePicker;
using Rftim3WinFormsUCL.RftDomainUpDown;
using Rftim3WinFormsUCL.RftDoughnutChart;
using Rftim3WinFormsUCL.RftErrorProvider;
using Rftim3WinFormsUCL.RftFactory;
using Rftim3WinFormsUCL.RftFileSystemWatcher;
using Rftim3WinFormsUCL.RftFlowLayoutPanel;
using Rftim3WinFormsUCL.RftFolderBrowserDialog;
using Rftim3WinFormsUCL.RftFontDialog;
using Rftim3WinFormsUCL.RftGroupBox;
using Rftim3WinFormsUCL.RftHelpProvider;
using Rftim3WinFormsUCL.RftHomepage;
using Rftim3WinFormsUCL.RftHScrollBar;
using Rftim3WinFormsUCL.RftImageList;
using Rftim3WinFormsUCL.RftKeyboard;
using Rftim3WinFormsUCL.RftLabel;
using Rftim3WinFormsUCL.RftLDAP;
using Rftim3WinFormsUCL.RftLineChart;
using Rftim3WinFormsUCL.RftLinkLabel;
using Rftim3WinFormsUCL.RftListBox;
using Rftim3WinFormsUCL.RftListView;
using Rftim3WinFormsUCL.RftMaskedTextBox;
using Rftim3WinFormsUCL.RftMenuStrip;
using Rftim3WinFormsUCL.RftMonthCalendar;
using Rftim3WinFormsUCL.RftNotifyIcon;
using Rftim3WinFormsUCL.RftNumericUpDown;
using Rftim3WinFormsUCL.RftOpenFileDialog;
using Rftim3WinFormsUCL.RftPageSetupDialog;
using Rftim3WinFormsUCL.RftPanel;
using Rftim3WinFormsUCL.RftPictureBox;
using Rftim3WinFormsUCL.RftPieChart;
using Rftim3WinFormsUCL.RftPrintDialog;
using Rftim3WinFormsUCL.RftPrintDocument;
using Rftim3WinFormsUCL.RftPrintPreviewControl;
using Rftim3WinFormsUCL.RftPrintPreviewDialog;
using Rftim3WinFormsUCL.RftProcess;
using Rftim3WinFormsUCL.RftProgressBarHorizontal;
using Rftim3WinFormsUCL.RftProgressBarVertical;
using Rftim3WinFormsUCL.RftPropertyGrid;
using Rftim3WinFormsUCL.RftRadioButton;
using Rftim3WinFormsUCL.RftRangeBarChart;
using Rftim3WinFormsUCL.RftRichTextBox;
using Rftim3WinFormsUCL.RftSaveFileDialog;
using Rftim3WinFormsUCL.RftSerialPort;
using Rftim3WinFormsUCL.RftServiceController;
using Rftim3WinFormsUCL.RftSockets;
using Rftim3WinFormsUCL.RftSplineChart;
using Rftim3WinFormsUCL.RftSplitContainer;
using Rftim3WinFormsUCL.RftSplitter;
using Rftim3WinFormsUCL.RftSQL;
using Rftim3WinFormsUCL.RftStackedBarChart;
using Rftim3WinFormsUCL.RftStackedBarChart100;
using Rftim3WinFormsUCL.RftStackedColumn100;
using Rftim3WinFormsUCL.RftStackedColumnChart;
using Rftim3WinFormsUCL.RftStatusStrip;
using Rftim3WinFormsUCL.RftSystemInformation;
using Rftim3WinFormsUCL.RftTabControl;
using Rftim3WinFormsUCL.RftTableLayoutPanel;
using Rftim3WinFormsUCL.RftTextBox;
using Rftim3WinFormsUCL.RftTimer;
using Rftim3WinFormsUCL.RftToolStrip;
using Rftim3WinFormsUCL.RftToolStripContainer;
using Rftim3WinFormsUCL.RftToolTip;
using Rftim3WinFormsUCL.RftTrackBar;
using Rftim3WinFormsUCL.RftTreeView;
using Rftim3WinFormsUCL.RftUserControl;
using Rftim3WinFormsUCL.RftVScrollBar;
using RftWinForms;

namespace Rftim3WinForms
{
    internal static class Program
    {
        [STAThread]
        private static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            IHost host = Host
                .CreateDefaultBuilder()
                .ConfigureAppConfiguration((config) =>
                {
                    config.AddUserSecrets<RftTreeViewUC_0>();
                })
                .ConfigureServices((context, services) =>
                {
                    string? northwindConnection = context.Configuration["Northwind"];
                    string? leetCodeConnection = context.Configuration["LeetCode"];
                    string? sqliteConnection = context.Configuration["SQLite"];
                    string? repairConnection = context.Configuration["Repair"];

                    services.AddSingleton(new RftDatabaseConnections(
                        northwindConnection,
                        leetCodeConnection,
                        sqliteConnection,
                        repairConnection
                        ));

                    services.AddSingleton<RftHomepageUC_0>();
                    services.AddSingleton<RftFactoryUC_0>();

                    services.AddSingleton<IRftButtonCL, RftButtonCL>();
                    services.AddSingleton<RftButtonUC_0>();

                    services.AddSingleton<IRftCheckBoxCL, RftCheckBoxCL>();
                    services.AddSingleton<RftCheckBoxUC_0>();

                    services.AddSingleton<IRftFormCL, RftFormCL>();
                    services.AddSingleton<RftMainForm>();

                    services.AddSingleton<IRftMenuStripCL, RftMenuStripCL>();
                    services.AddSingleton<RftMenuStripUC_0>();

                    services.AddSingleton<IRftConsoleCL, RftConsoleCL>();
                    services.AddSingleton<RftConsoleUC_0>();

                    services.AddSingleton<IRftADCL, RftADCL>();
                    services.AddSingleton<RftADUC_0>();

                    services.AddSingleton<IRftAuthenticationCL, RftAuthenticationCL>();
                    services.AddSingleton<RftAuthenticationUC_0>();

                    services.AddSingleton<IRftAuthorizationCL, RftAuthorizationCL>();
                    services.AddSingleton<RftAuthorizationUC_0>();

                    services.AddSingleton<IRftBackgroundWorkerCL, RftBackgroundWorkerCL>();
                    services.AddSingleton<RftBackgroundWorkerUC_0>();

                    services.AddSingleton<IRftBarChartCL, RftBarChartCL>();
                    services.AddSingleton<RftBarChartUC_0>();
                    services.AddSingleton<RftBarChartUC_1>();

                    services.AddSingleton<IRftBindingSourceCL, RftBindingSourceCL>();
                    services.AddSingleton<RftBindingSourceUC_0>();

                    services.AddSingleton<IRftCheckedListBoxCL, RftCheckedListBoxCL>();
                    services.AddSingleton<RftCheckedListBoxUC_0>();

                    services.AddSingleton<IRftColorDialogCL, RftColorDialogCL>();
                    services.AddSingleton<RftColorDialogUC_0>();

                    services.AddSingleton<IRftColumnChartCL, RftColumnChartCL>();
                    services.AddSingleton<RftColumnChartUC_0>();

                    services.AddSingleton<IRftComboBoxCL, RftComboBoxCL>();
                    services.AddSingleton<RftComboBoxUC_0>();

                    services.AddSingleton<IRftContextMenuStripCL, RftContextMenuStripCL>();
                    services.AddSingleton<RftContextMenuStripUC_0>();

                    services.AddSingleton<IRftCSVCL, RftCSVCL>();
                    services.AddSingleton<RftCSVUC_0>();

                    services.AddSingleton<IRftDataGridViewCL, RftDataGridViewCL>();
                    services.AddSingleton<RftDataGridViewUC_0>();

                    services.AddSingleton<IRftDateTimePickerCL, RftDateTimePickerCL>();
                    services.AddSingleton<RftDateTimePickerUC_0>();

                    services.AddSingleton<IRftDomainUpDownCL, RftDomainUpDownCL>();
                    services.AddSingleton<RftDomainUpDownUC_0>();

                    services.AddSingleton<IRftDoughnutChartCL, RftDoughnutChartCL>();
                    services.AddSingleton<RftDoughnutChartUC_0>();

                    services.AddSingleton<IRftErrorProviderCL, RftErrorProviderCL>();
                    services.AddSingleton<RftErrorProviderUC_0>();

                    services.AddSingleton<IRftFileSystemWatcherCL, RftFileSystemWatcherCL>();
                    services.AddSingleton<RftFileSystemWatcherUC_0>();

                    services.AddSingleton<IRftFlowLayoutPanelCL, RftFlowLayoutPanelCL>();
                    services.AddSingleton<RftFlowLayoutPanelUC_0>();

                    services.AddSingleton<IRftFolderBrowserDialogCL, RftFolderBrowserDialogCL>();
                    services.AddSingleton<RftFolderBrowserDialogUC_0>();

                    services.AddSingleton<IRftFontDialogCL, RftFontDialogCL>();
                    services.AddSingleton<RftFontDialogUC_0>();

                    services.AddSingleton<IRftGroupBoxCL, RftGroupBoxCL>();
                    services.AddSingleton<RftGroupBoxUC_0>();

                    services.AddSingleton<IRftHelpProviderCL, RftHelpProviderCL>();
                    services.AddSingleton<RftHelpProviderUC_0>();

                    services.AddSingleton<IRftHScrollBarCL, RftHScrollBarCL>();
                    services.AddSingleton<RftHScrollBarUC_0>();

                    services.AddSingleton<IRftImageListCL, RftImageListCL>();
                    services.AddSingleton<RftImageListUC_0>();

                    services.AddSingleton<IRftKeyboardCL, RftKeyboardCL>();
                    services.AddSingleton<RftKeyboardUC_0>();

                    services.AddSingleton<IRftLabelCL, RftLabelCL>();
                    services.AddSingleton<RftLabelUC_0>();

                    services.AddSingleton<IRftLDAPCL, RftLDAPCL>();
                    services.AddSingleton<RftLDAPUC_0>();

                    services.AddSingleton<IRftLineChartCL, RftLineChartCL>();
                    services.AddSingleton<RftLineChartUC_0>();

                    services.AddSingleton<IRftLinkLabelCL, RftLinkLabelCL>();
                    services.AddSingleton<RftLinkLabelUC_0>();

                    services.AddSingleton<IRftListBoxCL, RftListBoxCL>();
                    services.AddSingleton<RftListBoxUC_0>();

                    services.AddSingleton<IRftListViewCL, RftListViewCL>();
                    services.AddSingleton<RftListViewUC_0>();

                    services.AddSingleton<IRftMaskedTextBoxCL, RftMaskedTextBoxCL>();
                    services.AddSingleton<RftMaskedTextBoxUC_0>();

                    services.AddSingleton<RftMenuStripUC_1>();

                    services.AddSingleton<IRftMonthCalendarCL, RftMonthCalendarCL>();
                    services.AddSingleton<RftMonthCalendarUC_0>();

                    services.AddSingleton<IRftNotifyIconCL, RftNotifyIconCL>();
                    services.AddSingleton<RftNotifyIconUC_0>();

                    services.AddSingleton<IRftNumericUpDownCL, RftNumericUpDownCL>();
                    services.AddSingleton<RftNumericUpDownUC_0>();

                    services.AddSingleton<IRftOpenFileDialogCL, RftOpenFileDialogCL>();
                    services.AddSingleton<RftOpenFileDialogUC_0>();

                    services.AddSingleton<IRftPageSetupDialogCL, RftPageSetupDialogCL>();
                    services.AddSingleton<RftPageSetupDialogUC_0>();

                    services.AddSingleton<IRftPanelCL, RftPanelCL>();
                    services.AddSingleton<RftPanelUC_0>();

                    services.AddSingleton<IRftPictureBoxCL, RftPictureBoxCL>();
                    services.AddSingleton<RftPictureBoxUC_0>();

                    services.AddSingleton<IRftPieChartCL, RftPieChartCL>();
                    services.AddSingleton<RftPieChartUC_0>();

                    services.AddSingleton<IRftPrintDialogCL, RftPrintDialogCL>();
                    services.AddSingleton<RftPrintDialogUC_0>();

                    services.AddSingleton<IRftPrintDocumentCL, RftPrintDocumentCL>();
                    services.AddSingleton<RftPrintDocumentUC_0>();

                    services.AddSingleton<IRftPrintPreviewControlCL, RftPrintPreviewControlCL>();
                    services.AddSingleton<RftPrintPreviewControlUC_0>();

                    services.AddSingleton<IRftPrintPreviewDialogCL, RftPrintPreviewDialogCL>();
                    services.AddSingleton<RftPrintPreviewDialogUC_0>();

                    services.AddSingleton<IRftProcessCL, RftProcessCL>();
                    services.AddSingleton<RftProcessUC_0>();

                    services.AddSingleton<IRftHProgressBarCL, RftHProgressBarCL>();
                    services.AddSingleton<RftHProgressBarUC_0>();

                    services.AddSingleton<IRftVProgressBarCL, RftVProgressBarCL>();
                    services.AddSingleton<RftVProgressBarUC_0>();

                    services.AddSingleton<IRftPropertyGridCL, RftPropertyGridCL>();
                    services.AddSingleton<RftPropertyGridUC_0>();

                    services.AddSingleton<IRftRadioButtonCL, RftRadioButtonCL>();
                    services.AddSingleton<RftRadioButtonUC_0>();

                    services.AddSingleton<IRftRangeBarChartCL, RftRangeBarChartCL>();
                    services.AddSingleton<RftRangeBarChartUC_0>();

                    services.AddSingleton<IRftRichTextBoxCL, RftRichTextBoxCL>();
                    services.AddSingleton<RftRichTextBoxUC_0>();

                    services.AddSingleton<IRftSaveFileDialogCL, RftSaveFileDialogCL>();
                    services.AddSingleton<RftSaveFileDialogUC_0>();

                    services.AddSingleton<IRftSerialPortCL, RftSerialPortCL>();
                    services.AddSingleton<RftSerialPortUC_0>();

                    services.AddSingleton<IRftServiceControllerCL, RftServiceControllerCL>();
                    services.AddSingleton<RftServiceControllerUC_0>();

                    services.AddSingleton<IRftTCPIPCL, RftTCPIPCL>();
                    services.AddSingleton<RftTCPIPUC_0>();

                    services.AddSingleton<IRftSplineChartCL, RftSplineChartCL>();
                    services.AddSingleton<RftSplineChartUC_0>();

                    services.AddSingleton<IRftSplitContainerCL, RftSplitContainerCL>();
                    services.AddSingleton<RftSplitContainerUC_0>();

                    services.AddSingleton<IRftSplitterCL, RftSplitterCL>();
                    services.AddSingleton<RftSplitterUC_0>();

                    services.AddSingleton<IRftMSSQLCL, RftMSSQLCL>();
                    services.AddSingleton<RftMSSQLUC_0>();

                    services.AddSingleton<IRftStackedBarChart100CL, RftStackedBarChart100CL>();
                    services.AddSingleton<RftStackedBarChart100UC_0>();

                    services.AddSingleton<IRftStackedBarChartCL, RftStackedBarChartCL>();
                    services.AddSingleton<RftStackedBarChartUC_0>();

                    services.AddSingleton<IRftStackedColumnChartCL, RftStackedColumnChartCL>();
                    services.AddSingleton<RftStackedColumnChartUC_0>();

                    services.AddSingleton<IRftStackedColumnChart100CL, RftStackedColumnChart100CL>();
                    services.AddSingleton<RftStackedColumnChart100UC_0>();

                    services.AddSingleton<IRftStatusStripCL, RftStatusStripCL>();
                    services.AddSingleton<RftStatusStripUC_0>();

                    services.AddSingleton<IRftSystemInformationCL, RftSystemInformationCL>();
                    services.AddSingleton<RftSystemInformationUC_0>();

                    services.AddSingleton<IRftTabControlCL, RftTabControlCL>();
                    services.AddSingleton<RftTabControlUC_0>();

                    services.AddSingleton<IRftTableLayoutPanelCL, RftTableLayoutPanelCL>();
                    services.AddSingleton<RftTableLayoutPanelUC_0>();
                    services.AddSingleton<RftTableLayoutPanelUC_1>();

                    services.AddSingleton<IRftTextBoxCL, RftTextBoxCL>();
                    services.AddSingleton<RftTextBoxUC_0>();

                    services.AddSingleton<IRftTimerCL, RftTimerCL>();
                    services.AddSingleton<RftTimerUC_0>();

                    services.AddSingleton<IRftToolStripCL, RftToolStripCL>();
                    services.AddSingleton<RftToolStripUC_0>();

                    services.AddSingleton<IRftToolStripContainerCL, RftToolStripContainerCL>();
                    services.AddSingleton<RftToolStripContainerUC_0>();

                    services.AddSingleton<IRftToolTipCL, RftToolTipCL>();
                    services.AddSingleton<RftToolTipUC_0>();

                    services.AddSingleton<IRftTrackBarCL, RftTrackBarCL>();
                    services.AddSingleton<RftTrackBarUC_0>();

                    services.AddSingleton<IRftTreeViewCL, RftTreeViewCL>();
                    services.AddSingleton<RftTreeViewUC_0>();

                    services.AddSingleton<IRftUserControlCL, RftUserControlCL>();
                    services.AddSingleton<RftUserControlUC_0>();

                    services.AddSingleton<IRftVScrollBarCL, RftVScrollBarCL>();
                    services.AddSingleton<RftVScrollBarUC_0>();

                    services.AddSingleton<RftRepairUC_0>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();

            await host.StartAsync();

            RftMainForm mainForm = host.Services.GetRequiredService<RftMainForm>();
            Application.Run(mainForm);

            await host.StopAsync();
        }
    }
}