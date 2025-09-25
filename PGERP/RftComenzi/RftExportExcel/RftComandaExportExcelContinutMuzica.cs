using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace PGERP.RftComenzi.RftExportExcel
{
    internal class RftComandaExportExcelContinutMuzica : RftComandaBaza
    {
        private readonly RftVedereModelContinutMuzica rftVedereModelContinutMuzica;

        public RftComandaExportExcelContinutMuzica(RftVedereModelContinutMuzica rftVedereModelContinutMuzica)
        {
            this.rftVedereModelContinutMuzica = rftVedereModelContinutMuzica;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog rftSalvareDocument = new()
            {
                Filter = "Excel|*.xlsx",
                Title = "Salvare Fisier Excel"
            };
            rftSalvareDocument.ShowDialog();

            if (rftSalvareDocument.FileName != "")
            {
                List<RftModelDivertismentMuzica>? rftDateDeExport = rftVedereModelContinutMuzica.RftModelDivertismentMuzicaLista.ToList();
                DataTable rftTabelaDeDate = new(typeof(RftModelDivertismentMuzica).Name);
                PropertyInfo[] rftModelProprietati = typeof(RftModelDivertismentMuzica).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo item in rftModelProprietati)
                {
                    rftTabelaDeDate.Columns.Add(item.Name);
                }

                foreach (RftModelDivertismentMuzica? item in rftDateDeExport)
                {
                    object[]? rftObiect = new object[rftModelProprietati.Length];
                    for (int i = 0; i < rftModelProprietati.Length; i++)
                    {
                        rftObiect[i] = rftModelProprietati[i].GetValue(item, null);
                    }
                    rftTabelaDeDate.Rows.Add(rftObiect);
                }

                Application? excelApp = null;
                Workbooks? workbooks = null;
                Workbook? excelWorkbook = null;
                Sheets? sheets = null;
                Worksheet? excelWorksheet = null;
                Microsoft.Office.Interop.Excel.Range? range = null;

                try
                {
                    excelApp = new Application();
                    workbooks = excelApp.Workbooks;
                    excelWorkbook = workbooks.Add();
                    sheets = excelWorkbook.Sheets;
                    excelWorksheet = (Worksheet?)sheets.Add();

                    excelWorksheet = (Worksheet?)excelWorkbook.Sheets["Sheet1"];
                    excelWorksheet = (Worksheet?)excelWorkbook.ActiveSheet;
                    excelWorksheet.Cells.NumberFormat = "@";

                    excelWorksheet.Cells[1, 1] = rftVedereModelContinutMuzica.RftGraficTitlu;
                    for (int i = 1; i < rftTabelaDeDate.Columns.Count; i++)
                    {
                        excelWorksheet.Cells[2, i] = rftTabelaDeDate.Columns[i - 1].ColumnName;
                    }

                    for (int i = 0; i < rftTabelaDeDate.Rows.Count; i++)
                    {
                        for (int j = 0; j < rftTabelaDeDate.Columns.Count - 1; j++)
                        {
                            excelWorksheet.Cells[i + 3, j + 1] = rftTabelaDeDate.Rows[i].ItemArray[j].ToString();
                        }
                    }
                    excelWorksheet.Columns.AutoFit();
                    excelWorksheet.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    excelWorkbook.SaveAs(rftSalvareDocument.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    excelWorkbook.Close();
                    excelApp.Quit();

                }
                catch (Exception f)
                {
                    f.ToString();
                }
                finally
                {
                    if (range != null) Marshal.ReleaseComObject(range);
                    if (excelWorksheet != null) Marshal.ReleaseComObject(excelWorksheet);
                    if (sheets != null) Marshal.ReleaseComObject(sheets);
                    if (excelWorkbook != null) Marshal.ReleaseComObject(excelWorkbook);
                    if (workbooks != null) Marshal.ReleaseComObject(workbooks);
                    if (excelApp != null) Marshal.ReleaseComObject(excelApp);
                }
            }
        }
    }
}
