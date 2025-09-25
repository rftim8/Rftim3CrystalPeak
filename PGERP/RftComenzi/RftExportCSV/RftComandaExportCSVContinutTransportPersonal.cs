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

namespace PGERP.RftComenzi.RftExportCSV
{
    internal class RftComandaExportCSVContinutTransportPersonal : RftComandaBaza
    {
        private readonly RftVedereModelContinutPersonal rftVedereModelContinutPersonal;

        public RftComandaExportCSVContinutTransportPersonal(RftVedereModelContinutPersonal rftVedereModelContinutPersonal)
        {
            this.rftVedereModelContinutPersonal = rftVedereModelContinutPersonal;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog rftSalvareDocument = new()
            {
                Filter = "CSV|*.csv",
                Title = "Salvare Fisier CSV"
            };
            rftSalvareDocument.ShowDialog();

            if (rftSalvareDocument.FileName != "")
            {
                List<RftModelTransportPersonal>? rftDateDeExport = rftVedereModelContinutPersonal.RftModelTransportPersonalLista.ToList();
                DataTable rftTabelaDeDate = new(typeof(RftModelTransportPersonal).Name);
                PropertyInfo[] rftModelProprietati = typeof(RftModelTransportPersonal).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo item in rftModelProprietati)
                {
                    rftTabelaDeDate.Columns.Add(item.Name);
                }

                foreach (RftModelTransportPersonal? item in rftDateDeExport)
                {
                    object[]? rftObiect = new object[rftModelProprietati.Length];
                    for (int i = 0; i < rftModelProprietati.Length; i++)
                    {
                        rftObiect[i] = rftModelProprietati[i].GetValue(item, null);
                    }
                    rftTabelaDeDate.Rows.Add(rftObiect);
                }


                StringBuilder stringBuilder = new();
                stringBuilder.Append(rftVedereModelContinutPersonal.RftGraficTitlu + Environment.NewLine);
                string columnHeaders = "";
                try
                {
                    for (int i = 1; i < rftTabelaDeDate.Columns.Count; i++)
                    {
                        columnHeaders += rftTabelaDeDate.Columns[i - 1].ColumnName + ",\t\t";
                    }
                    stringBuilder.Append(columnHeaders + Environment.NewLine + Environment.NewLine);

                    for (int i = 0; i < rftTabelaDeDate.Rows.Count; i++)
                    {
                        for (int j = 0; j < rftTabelaDeDate.Columns.Count - 1; j++)
                        {
                            stringBuilder.Append(rftTabelaDeDate.Rows[i].ItemArray[j].ToString() + ",\t\t");
                        }
                        stringBuilder.Append(Environment.NewLine);
                    }

                    using StreamWriter sw = new(rftSalvareDocument.FileName, false);
                    sw.WriteLine(stringBuilder.ToString());
                }
                catch (Exception f)
                {
                    f.ToString();
                }
                finally
                {
                }
            }
        }
    }
}
