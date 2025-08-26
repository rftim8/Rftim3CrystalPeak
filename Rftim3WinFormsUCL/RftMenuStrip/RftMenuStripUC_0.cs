using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
using Rftim3WinFormsUCL.RftMonthCalendar;
using Rftim3WinFormsUCL.RftNotifyIcon;
using Rftim3WinFormsUCL.RftNumericUpDown;
using Rftim3WinFormsUCL.RftOpenFileDialog;
using Rftim3WinFormsUCL.RftPageSetupDialog;
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

namespace Rftim3WinFormsUCL.RftMenuStrip
{
    public partial class RftMenuStripUC_0 : UserControl
    {
        private readonly RftHomepageUC_0 rftHomepageUC_0;
        private readonly RftButtonUC_0 rftButtonUC_0;
        private readonly RftCheckBoxUC_0 rftCheckBoxUC_0;
        private readonly RftConsoleUC_0 rftConsoleUC_0;
        private readonly RftADUC_0 rftADUC_0;
        private readonly RftAuthenticationUC_0 rftAuthenticationUC_0;
        private readonly RftAuthorizationUC_0 rftAuthorizationUC_0;
        private readonly RftBackgroundWorkerUC_0 rftBackgroundWorkerUC_0;
        private readonly RftBarChartUC_0 rftBarChartUC_0;
        private readonly RftBarChartUC_1 rftBarChartUC_1;
        private readonly RftBindingSourceUC_0 rftBindingSourceUC_0;
        private readonly RftCheckedListBoxUC_0 rftCheckedListBoxUC_0;
        private readonly RftColorDialogUC_0 rftColorDialogUC_0;
        private readonly RftColumnChartUC_0 rftColumnChartUC_0;
        private readonly RftComboBoxUC_0 rftComboBoxUC_0;
        private readonly RftContextMenuStripUC_0 rftContextMenuStripUC_0;
        private readonly RftCSVUC_0 rftCSVUC_0;
        private readonly RftDataGridViewUC_0 rftDataGridViewUC_0;
        private readonly RftDateTimePickerUC_0 rftDateTimePickerUC_0;
        private readonly RftDomainUpDownUC_0 rftDomainUpDownUC_0;
        private readonly RftDoughnutChartUC_0 rftDoughnutChartUC_0;
        private readonly RftErrorProviderUC_0 rftErrorProviderUC_0;
        private readonly RftFileSystemWatcherUC_0 rftFileSystemWatcherUC_0;
        private readonly RftFlowLayoutPanelUC_0 rftFlowLayoutPanelUC_0;
        private readonly RftFolderBrowserDialogUC_0 rftFolderBrowserDialogUC_0;
        private readonly RftFontDialogUC_0 rftFontDialogUC_0;
        private readonly RftGroupBoxUC_0 rftGroupBoxUC_0;
        private readonly RftHelpProviderUC_0 rftHelpProviderUC_0;
        private readonly RftHScrollBarUC_0 rftHScrollBarUC_0;
        private readonly RftImageListUC_0 rftImageListUC_0;
        private readonly RftKeyboardUC_0 rftKeyboardUC_0;
        private readonly RftLabelUC_0 rftLabelUC_0;
        private readonly RftLDAPUC_0 rftLDAPUC_0;
        private readonly RftLineChartUC_0 rftLineChartUC_0;
        private readonly RftLinkLabelUC_0 rftLinkLabelUC_0;
        private readonly RftListBoxUC_0 rftListBoxUC_0;
        private readonly RftListViewUC_0 rftListViewUC_0;
        private readonly RftMaskedTextBoxUC_0 rftMaskedTextBoxUC_0;
        private readonly RftMenuStripUC_1 rftMenuStripUC_1;
        private readonly RftMonthCalendarUC_0 rftMonthCalendarUC_0;
        private readonly RftNotifyIconUC_0 rftNotifyIconUC_0;
        private readonly RftNumericUpDownUC_0 rftNumericUpDownUC_0;
        private readonly RftOpenFileDialogUC_0 rftOpenFileDialogUC_0;
        private readonly RftPageSetupDialogUC_0 rftPageSetupDialogUC_0;
        private readonly RftPictureBoxUC_0 rftPictureBoxUC_0;
        private readonly RftPieChartUC_0 rftPieChartUC_0;
        private readonly RftPrintDialogUC_0 rftPrintDialogUC_0;
        private readonly RftPrintDocumentUC_0 rftPrintDocumentUC_0;
        private readonly RftPrintPreviewControlUC_0 rftPrintPreviewControlUC_0;
        private readonly RftPrintPreviewDialogUC_0 rftPrintPreviewDialogUC_0;
        private readonly RftProcessUC_0 rftProcessUC_0;
        private readonly RftHProgressBarUC_0 rftHProgressBarUC_0;
        private readonly RftVProgressBarUC_0 rftVProgressBarUC_0;
        private readonly RftPropertyGridUC_0 rftPropertyGridUC_0;
        private readonly RftRadioButtonUC_0 rftRadioButtonUC_0;
        private readonly RftRangeBarChartUC_0 rftRangeBarChartUC_0;
        private readonly RftRichTextBoxUC_0 rftRichTextBoxUC_0;
        private readonly RftSaveFileDialogUC_0 rftSaveFileDialogUC_0;
        private readonly RftSerialPortUC_0 rftSerialPortUC_0;
        private readonly RftServiceControllerUC_0 rftServiceControllerUC_0;
        private readonly RftTCPIPUC_0 rftTCPIPUC_0;
        private readonly RftSplineChartUC_0 rftSplineChartUC_0;
        private readonly RftSplitContainerUC_0 rftSplitContainerUC_0;
        private readonly RftSplitterUC_0 rftSplitterUC_0;
        private readonly RftMSSQLUC_0 rftMSSQLUC_0;
        private readonly RftStackedBarChartUC_0 rftStackedBarChartUC_0;
        private readonly RftStackedBarChart100UC_0 rftStackedBarChart100UC_0;
        private readonly RftStackedColumnChartUC_0 rftStackedColumnChartUC_0;
        private readonly RftStackedColumnChart100UC_0 rftStackedColumnChart100UC_0;
        private readonly RftStatusStripUC_0 rftStatusStripUC_0;
        private readonly RftSystemInformationUC_0 rftSystemInformationUC_0;
        private readonly RftTabControlUC_0 rftTabControlUC_0;
        private readonly RftTableLayoutPanelUC_1 rftTableLayoutPanelUC_1;
        private readonly RftTextBoxUC_0 rftTextBoxUC_0;
        private readonly RftTimerUC_0 rftTimerUC_0;
        private readonly RftToolStripUC_0 rftToolStripUC_0;
        private readonly RftToolStripContainerUC_0 rftToolStripContainerUC_0;
        private readonly RftToolTipUC_0 rftToolTipUC_0;
        private readonly RftTrackBarUC_0 rftTrackBarUC_0;
        private readonly RftTreeViewUC_0 rftTreeViewUC_0;
        private readonly RftUserControlUC_0 rftUserControlUC_0;
        private readonly RftVScrollBarUC_0 rftVScrollBarUC_0;
        private readonly RftFactoryUC_0 rftFactoryUC_0;
        private readonly RftRepairUC_0 rftRepairUC_0;

        private readonly IRftFormCL rftFormCL;
        private readonly IRftMenuStripCL rftMenuStripCL;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftMenuStripUC_0(IHost host)
        {
            InitializeComponent();

            rftMenuStripCL = host.Services.GetRequiredService<IRftMenuStripCL>();
            rftMenuStripCL.RftMenuStrip = menuStrip1;

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftTopMenuBarProperties();

            rftFormCL = host.Services.GetRequiredService<IRftFormCL>();

            rftHomepageUC_0 = host.Services.GetRequiredService<RftHomepageUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftHomepageUC_0);

            rftButtonUC_0 = host.Services.GetRequiredService<RftButtonUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftButtonUC_0);

            rftCheckBoxUC_0 = host.Services.GetRequiredService<RftCheckBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftCheckBoxUC_0);

            rftConsoleUC_0 = host.Services.GetRequiredService<RftConsoleUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftConsoleUC_0);

            rftADUC_0 = host.Services.GetRequiredService<RftADUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftADUC_0);

            rftAuthenticationUC_0 = host.Services.GetRequiredService<RftAuthenticationUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftAuthenticationUC_0);

            rftAuthorizationUC_0 = host.Services.GetRequiredService<RftAuthorizationUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftAuthorizationUC_0);

            rftBackgroundWorkerUC_0 = host.Services.GetRequiredService<RftBackgroundWorkerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftBackgroundWorkerUC_0);

            rftBarChartUC_0 = host.Services.GetRequiredService<RftBarChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftBarChartUC_0);

            rftBarChartUC_1 = host.Services.GetRequiredService<RftBarChartUC_1>();
            rftFormCL.RftForm!.Controls.Add(rftBarChartUC_1);

            rftBindingSourceUC_0 = host.Services.GetRequiredService<RftBindingSourceUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftBindingSourceUC_0);

            rftCheckedListBoxUC_0 = host.Services.GetRequiredService<RftCheckedListBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftCheckedListBoxUC_0);

            rftColorDialogUC_0 = host.Services.GetRequiredService<RftColorDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftColorDialogUC_0);

            rftColumnChartUC_0 = host.Services.GetRequiredService<RftColumnChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftColumnChartUC_0);

            rftComboBoxUC_0 = host.Services.GetRequiredService<RftComboBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftComboBoxUC_0);

            rftContextMenuStripUC_0 = host.Services.GetRequiredService<RftContextMenuStripUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftContextMenuStripUC_0);

            rftCSVUC_0 = host.Services.GetRequiredService<RftCSVUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftCSVUC_0);

            rftDataGridViewUC_0 = host.Services.GetRequiredService<RftDataGridViewUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftDataGridViewUC_0);

            rftDateTimePickerUC_0 = host.Services.GetRequiredService<RftDateTimePickerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftDateTimePickerUC_0);

            rftDomainUpDownUC_0 = host.Services.GetRequiredService<RftDomainUpDownUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftDomainUpDownUC_0);

            rftDoughnutChartUC_0 = host.Services.GetRequiredService<RftDoughnutChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftDoughnutChartUC_0);

            rftErrorProviderUC_0 = host.Services.GetRequiredService<RftErrorProviderUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftErrorProviderUC_0);

            rftFileSystemWatcherUC_0 = host.Services.GetRequiredService<RftFileSystemWatcherUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftFileSystemWatcherUC_0);

            rftFlowLayoutPanelUC_0 = host.Services.GetRequiredService<RftFlowLayoutPanelUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftFlowLayoutPanelUC_0);

            rftFolderBrowserDialogUC_0 = host.Services.GetRequiredService<RftFolderBrowserDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftFolderBrowserDialogUC_0);

            rftFontDialogUC_0 = host.Services.GetRequiredService<RftFontDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftFontDialogUC_0);

            rftGroupBoxUC_0 = host.Services.GetRequiredService<RftGroupBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftGroupBoxUC_0);

            rftHelpProviderUC_0 = host.Services.GetRequiredService<RftHelpProviderUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftHelpProviderUC_0);

            rftHScrollBarUC_0 = host.Services.GetRequiredService<RftHScrollBarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftHScrollBarUC_0);

            rftImageListUC_0 = host.Services.GetRequiredService<RftImageListUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftImageListUC_0);

            rftKeyboardUC_0 = host.Services.GetRequiredService<RftKeyboardUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftKeyboardUC_0);

            rftLabelUC_0 = host.Services.GetRequiredService<RftLabelUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftLabelUC_0);

            rftLDAPUC_0 = host.Services.GetRequiredService<RftLDAPUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftLDAPUC_0);

            rftLineChartUC_0 = host.Services.GetRequiredService<RftLineChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftLineChartUC_0);

            rftLinkLabelUC_0 = host.Services.GetRequiredService<RftLinkLabelUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftLinkLabelUC_0);

            rftListBoxUC_0 = host.Services.GetRequiredService<RftListBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftListBoxUC_0);

            rftListViewUC_0 = host.Services.GetRequiredService<RftListViewUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftListViewUC_0);

            rftMaskedTextBoxUC_0 = host.Services.GetRequiredService<RftMaskedTextBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftMaskedTextBoxUC_0);

            rftMenuStripUC_1 = host.Services.GetRequiredService<RftMenuStripUC_1>();
            rftFormCL.RftForm!.Controls.Add(rftMenuStripUC_1);

            rftMonthCalendarUC_0 = host.Services.GetRequiredService<RftMonthCalendarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftMonthCalendarUC_0);

            rftNotifyIconUC_0 = host.Services.GetRequiredService<RftNotifyIconUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftNotifyIconUC_0);

            rftNumericUpDownUC_0 = host.Services.GetRequiredService<RftNumericUpDownUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftNumericUpDownUC_0);

            rftOpenFileDialogUC_0 = host.Services.GetRequiredService<RftOpenFileDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftOpenFileDialogUC_0);

            rftPageSetupDialogUC_0 = host.Services.GetRequiredService<RftPageSetupDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPageSetupDialogUC_0);

            rftPictureBoxUC_0 = host.Services.GetRequiredService<RftPictureBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPictureBoxUC_0);

            rftPieChartUC_0 = host.Services.GetRequiredService<RftPieChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPieChartUC_0);

            rftPrintDialogUC_0 = host.Services.GetRequiredService<RftPrintDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPrintDialogUC_0);

            rftPrintDocumentUC_0 = host.Services.GetRequiredService<RftPrintDocumentUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPrintDocumentUC_0);

            rftPrintPreviewControlUC_0 = host.Services.GetRequiredService<RftPrintPreviewControlUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPrintPreviewControlUC_0);

            rftPrintPreviewDialogUC_0 = host.Services.GetRequiredService<RftPrintPreviewDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPrintPreviewDialogUC_0);

            rftProcessUC_0 = host.Services.GetRequiredService<RftProcessUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftProcessUC_0);

            rftHProgressBarUC_0 = host.Services.GetRequiredService<RftHProgressBarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftHProgressBarUC_0);

            rftVProgressBarUC_0 = host.Services.GetRequiredService<RftVProgressBarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftVProgressBarUC_0);

            rftPropertyGridUC_0 = host.Services.GetRequiredService<RftPropertyGridUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftPropertyGridUC_0);

            rftRadioButtonUC_0 = host.Services.GetRequiredService<RftRadioButtonUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftRadioButtonUC_0);

            rftRangeBarChartUC_0 = host.Services.GetRequiredService<RftRangeBarChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftRangeBarChartUC_0);

            rftRichTextBoxUC_0 = host.Services.GetRequiredService<RftRichTextBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftRichTextBoxUC_0);

            rftSaveFileDialogUC_0 = host.Services.GetRequiredService<RftSaveFileDialogUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSaveFileDialogUC_0);

            rftSerialPortUC_0 = host.Services.GetRequiredService<RftSerialPortUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSerialPortUC_0);

            rftServiceControllerUC_0 = host.Services.GetRequiredService<RftServiceControllerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftServiceControllerUC_0);

            rftTCPIPUC_0 = host.Services.GetRequiredService<RftTCPIPUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTCPIPUC_0);

            rftSplineChartUC_0 = host.Services.GetRequiredService<RftSplineChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSplineChartUC_0);

            rftSplitContainerUC_0 = host.Services.GetRequiredService<RftSplitContainerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSplitContainerUC_0);

            rftSplitterUC_0 = host.Services.GetRequiredService<RftSplitterUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSplitterUC_0);

            rftMSSQLUC_0 = host.Services.GetRequiredService<RftMSSQLUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftMSSQLUC_0);

            rftStackedBarChartUC_0 = host.Services.GetRequiredService<RftStackedBarChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftStackedBarChartUC_0);

            rftStackedBarChart100UC_0 = host.Services.GetRequiredService<RftStackedBarChart100UC_0>();
            rftFormCL.RftForm!.Controls.Add(rftStackedBarChart100UC_0);

            rftStackedColumnChartUC_0 = host.Services.GetRequiredService<RftStackedColumnChartUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftStackedColumnChartUC_0);

            rftStackedColumnChart100UC_0 = host.Services.GetRequiredService<RftStackedColumnChart100UC_0>();
            rftFormCL.RftForm!.Controls.Add(rftStackedColumnChart100UC_0);

            rftStatusStripUC_0 = host.Services.GetRequiredService<RftStatusStripUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftStatusStripUC_0);

            rftSystemInformationUC_0 = host.Services.GetRequiredService<RftSystemInformationUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftSystemInformationUC_0);

            rftTabControlUC_0 = host.Services.GetRequiredService<RftTabControlUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTabControlUC_0);

            rftTableLayoutPanelUC_1 = host.Services.GetRequiredService<RftTableLayoutPanelUC_1>();
            rftFormCL.RftForm!.Controls.Add(rftTableLayoutPanelUC_1);

            rftTextBoxUC_0 = host.Services.GetRequiredService<RftTextBoxUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTextBoxUC_0);

            rftTimerUC_0 = host.Services.GetRequiredService<RftTimerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTimerUC_0);

            rftToolStripUC_0 = host.Services.GetRequiredService<RftToolStripUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftToolStripUC_0);

            rftToolStripContainerUC_0 = host.Services.GetRequiredService<RftToolStripContainerUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftToolStripContainerUC_0);

            rftToolTipUC_0 = host.Services.GetRequiredService<RftToolTipUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftToolTipUC_0);

            rftTrackBarUC_0 = host.Services.GetRequiredService<RftTrackBarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTrackBarUC_0);

            rftTreeViewUC_0 = host.Services.GetRequiredService<RftTreeViewUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftTreeViewUC_0);

            rftUserControlUC_0 = host.Services.GetRequiredService<RftUserControlUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftUserControlUC_0);

            rftVScrollBarUC_0 = host.Services.GetRequiredService<RftVScrollBarUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftVScrollBarUC_0);

            rftFactoryUC_0 = host.Services.GetRequiredService<RftFactoryUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftFactoryUC_0);

            rftRepairUC_0 = host.Services.GetRequiredService<RftRepairUC_0>();
            rftFormCL.RftForm!.Controls.Add(rftRepairUC_0);
        }

        private void HomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftHomepageUC_0.BringToFront();
        }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFormCL.RftMinimize();
        }

        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFormCL.RftNormal();
        }

        private void MaximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFormCL.RftMaximize();
        }

        private void FullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFormCL.RftFullscreen();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFormCL.RftExit();
        }

        private void ConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftConsoleUC_0.BringToFront();
        }

        private void ButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftButtonUC_0.BringToFront();
        }

        private void CheckBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftCheckBoxUC_0.BringToFront();
        }

        private void CheckedListBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftCheckedListBoxUC_0.BringToFront();
        }

        private void ComboBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftComboBoxUC_0.BringToFront();
        }

        private void DateTimePickerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftDateTimePickerUC_0.BringToFront();
        }

        private void LabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftLabelUC_0.BringToFront();
        }

        private void LinkLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftLinkLabelUC_0.BringToFront();
        }

        private void ListBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftListBoxUC_0.BringToFront();
        }

        private void ListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftListViewUC_0.BringToFront();
        }

        private void MaskedTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftMaskedTextBoxUC_0.BringToFront();
        }

        private void MonthCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftMonthCalendarUC_0.BringToFront();
        }

        private void NotifyIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftNotifyIconUC_0.BringToFront();
        }

        private void NumericUpDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftNumericUpDownUC_0.BringToFront();
        }

        private void PictureBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPictureBoxUC_0.BringToFront();
        }

        private void HorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftHProgressBarUC_0.BringToFront();
        }

        private void VerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftVProgressBarUC_0.BringToFront();
        }

        private void RadioButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftRadioButtonUC_0.BringToFront();
        }

        private void RichTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftRichTextBoxUC_0.BringToFront();
        }

        private void TextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTextBoxUC_0.BringToFront();
        }

        private void ToolTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftToolTipUC_0.BringToFront();
        }

        private void TreeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTreeViewUC_0.BringToFront();
        }

        private void BackgroundWorkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftBackgroundWorkerUC_0.BringToFront();
        }

        private void ErrorProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftErrorProviderUC_0.BringToFront();
        }

        private void FileSystemWatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFileSystemWatcherUC_0.BringToFront();
        }

        private void HelpProviderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftHelpProviderUC_0.BringToFront();
        }

        private void ImageListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftImageListUC_0.BringToFront();
        }

        private void ProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftProcessUC_0.BringToFront();
        }

        private void SerialPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSerialPortUC_0.BringToFront();
        }

        private void ServiceControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftServiceControllerUC_0.BringToFront();
        }

        private void TimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTimerUC_0.BringToFront();
        }

        private void FlowLayoutPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFlowLayoutPanelUC_0.BringToFront();
        }

        private void GroupBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftGroupBoxUC_0.BringToFront();
        }

        private void PanelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SplitContainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSplitContainerUC_0.BringToFront();
        }

        private void TabControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTabControlUC_0.BringToFront();
        }

        private void TableLayoutPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTableLayoutPanelUC_1.BringToFront();
        }

        private void BindingSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftBindingSourceUC_0.BringToFront();
        }

        private void BarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftBarChartUC_1.BringToFront();
        }

        private void ColumnChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftColumnChartUC_0.BringToFront();
        }

        private void DoughnutChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftDoughnutChartUC_0.BringToFront();
        }

        private void LineChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftLineChartUC_0.BringToFront();
        }

        private void PieChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPieChartUC_0.BringToFront();
        }

        private void RangeBarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftRangeBarChartUC_0.BringToFront();
        }

        private void SplineChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSplineChartUC_0.BringToFront();
        }

        private void StackedBarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftStackedBarChartUC_0.BringToFront();
        }

        private void StackedBarChart100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftStackedBarChart100UC_0.BringToFront();
        }

        private void StackedColumnChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftStackedColumnChartUC_0.BringToFront();
        }

        private void StackedColumnChart100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftStackedColumnChart100UC_0.BringToFront();
        }

        private void DataGridViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftDataGridViewUC_0.BringToFront();
        }

        private void ColorDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftColorDialogUC_0.BringToFront();
        }

        private void FolderBrowserDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFolderBrowserDialogUC_0.BringToFront();
        }

        private void FontDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftFontDialogUC_0.BringToFront();
        }

        private void OpenFileDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftOpenFileDialogUC_0.BringToFront();
        }

        private void SaveFileDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSaveFileDialogUC_0.BringToFront();
        }

        private void DomainUpDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftDomainUpDownUC_0.BringToFront();
        }

        private void GaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HScrollBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftHScrollBarUC_0.BringToFront();
        }

        private void PropertyGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPropertyGridUC_0.BringToFront();
        }

        private void SplitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSplitterUC_0.BringToFront();
        }

        private void TrackBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTrackBarUC_0.BringToFront();
        }

        private void VScrollBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftVScrollBarUC_0.BringToFront();
        }

        private void PageSetupDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPageSetupDialogUC_0.BringToFront();
        }

        private void PrintDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPrintDialogUC_0.BringToFront();
        }

        private void PrintDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPrintDocumentUC_0.BringToFront();
        }

        private void PrintPreviewControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPrintPreviewControlUC_0.BringToFront();
        }

        private void PrintPreviewDialogfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftPrintPreviewDialogUC_0.BringToFront();
        }

        private void ContextMenuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftContextMenuStripUC_0.BringToFront();
        }

        private void MenuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftMenuStripUC_1.BringToFront();
        }

        private void StatusStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftStatusStripUC_0.BringToFront();
        }

        private void ToolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftToolStripUC_0.BringToFront();
        }

        private void ToolStripContainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftToolStripContainerUC_0.BringToFront();
        }

        private void CertificatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LDAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftLDAPUC_0.BringToFront();
        }

        private void TCPIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftTCPIPUC_0.BringToFront();
        }

        private void AuthenticationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftAuthenticationUC_0.BringToFront();
        }

        private void AuthorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftAuthorizationUC_0.BringToFront();
        }

        private void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LocalGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MSSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftMSSQLUC_0.BringToFront();
        }

        private void PostgreSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SQLiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ReceivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PurchasingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TraceabilityToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void LaserToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void LabelToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PickAndPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OvenToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void DepanelingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ICTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FlashToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AssemblyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void WaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TestingToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void RepairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftRepairUC_0.BringToFront();
        }

        private void PackingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void KeyboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftKeyboardUC_0.BringToFront();
        }

        private void PreferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void InventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ADToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rftADUC_0.BringToFront();
        }

        private void CSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftCSVUC_0.BringToFront();
        }

        private void SystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftSystemInformationUC_0.BringToFront();
        }

        private void UserControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rftUserControlUC_0.BringToFront();
        }

        private void HomepageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rftFactoryUC_0.BringToFront();
        }
    }
}
