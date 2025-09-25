using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftExportPDF
{
    internal class RftComandaExportPDFContinutJocuri : RftComandaBaza
    {
        private readonly RftVedereModelContinutJocuri rftVedereModelContinutJocuri;

        public RftComandaExportPDFContinutJocuri(RftVedereModelContinutJocuri rftVedereModelContinutJocuri)
        {
            this.rftVedereModelContinutJocuri = rftVedereModelContinutJocuri;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog rftSalvareDocument = new()
            {
                Filter = "PDF|*.pdf",
                Title = "Salvare Fisier PDF"
            };
            rftSalvareDocument.ShowDialog();

            if (rftSalvareDocument.FileName != "")
            {
                FileStream fs = (FileStream)rftSalvareDocument.OpenFile();

                List<RftModelDivertismentJocuri>? rftDateDeExport = rftVedereModelContinutJocuri.RftModelDivertismentJocuriLista.ToList();
                DataTable rftTabelaDeDate = new(typeof(RftModelDivertismentJocuri).Name);
                PropertyInfo[] rftModelProprietati = typeof(RftModelDivertismentJocuri).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo item in rftModelProprietati)
                {
                    rftTabelaDeDate.Columns.Add(item.Name);
                }

                foreach (RftModelDivertismentJocuri? item in rftDateDeExport)
                {
                    object[]? rftObiect = new object[rftModelProprietati.Length];
                    for (int i = 0; i < rftModelProprietati.Length; i++)
                    {
                        rftObiect[i] = rftModelProprietati[i].GetValue(item, null);
                    }
                    rftTabelaDeDate.Rows.Add(rftObiect);
                }

                Document rftDocument = new();
                _ = PdfWriter.GetInstance(rftDocument, fs);
                rftDocument.Open();

                PdfPTable rftTabelaTotal = new(1);
                rftTabelaTotal.AddCell(new Phrase(rftVedereModelContinutJocuri.RftGraficTitlu));

                PdfPTable rftTabela = new(rftTabelaDeDate.Columns.Count);
                Array floatArray = Array.CreateInstance(typeof(float), rftTabelaDeDate.Columns.Count);

                for (int i = 0; i < rftTabelaDeDate.Columns.Count - 1; i++)
                {
                    floatArray.SetValue(4f, i);
                }

                rftTabela.SetWidths((float[])floatArray);
                rftTabela.WidthPercentage = 100;
                Font rftFontDocument = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                foreach (DataColumn item in rftTabelaDeDate.Columns)
                {
                    rftTabela.AddCell(new Phrase(item.ColumnName, rftFontDocument));
                }

                foreach (DataRow r in rftTabelaDeDate.Rows)
                {
                    if (rftTabelaDeDate.Rows.Count > 0)
                    {
                        for (int i = 0; i < rftTabelaDeDate.Columns.Count; i++)
                        {
                            rftTabela.AddCell(new Phrase(r[i].ToString(), rftFontDocument));
                        }
                    }
                }

                rftDocument.Add(rftTabelaTotal);
                rftDocument.Add(rftTabela);
                rftDocument.Close();
                fs.Close();
            }
        }
    }
}
