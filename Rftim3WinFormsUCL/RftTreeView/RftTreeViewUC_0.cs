using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;
using System.Data.SQLite;

namespace Rftim3WinFormsUCL.RftTreeView
{
    public partial class RftTreeViewUC_0 : UserControl
    {
        private readonly SQLiteConnection sqlConnection;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftTreeViewUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqlConn = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConnection = new SQLiteConnection(sqlConn.SqliteConnection);

            RefreshTreeView(treeView1);
        }

        private void RefreshTreeView(TreeView treeView)
        {
            try
            {
                SQLiteDataAdapter sqlda_main = new("select * from SEGMENT_MAIN;", sqlConnection);
                SQLiteDataAdapter sqlda_primary = new("select * from SEGMENTS_PRIMARY;", sqlConnection);
                SQLiteDataAdapter sqlda_secondary = new("select * from SEGMENTS_SECONDARY;", sqlConnection);
                SQLiteDataAdapter sqlda_nodes = new("select * from SEGMENTS_NODES;", sqlConnection);
                DataTable dataTable_main = new();
                DataTable dataTable_primary = new();
                DataTable dataTable_secondary = new();
                DataTable dataTable_nodes = new();
                sqlda_main.Fill(dataTable_main);
                sqlda_primary.Fill(dataTable_primary);
                sqlda_secondary.Fill(dataTable_secondary);
                sqlda_nodes.Fill(dataTable_nodes);
                treeView.Nodes.Clear();
                treeView.BeginUpdate();

                for (int i = 0; i < dataTable_main.Rows.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            treeView.Nodes.Add(new TreeNode(dataTable_main.Rows[i][0].ToString() + ". " + dataTable_main.Rows[i][1].ToString(), 0, 1));
                            break;
                        case 1:
                            treeView.Nodes.Add(new TreeNode(dataTable_main.Rows[i][0].ToString() + ". " + dataTable_main.Rows[i][1].ToString(), 4, 4));
                            break;
                        case 2:
                            treeView.Nodes.Add(new TreeNode(dataTable_main.Rows[i][0].ToString() + ". " + dataTable_main.Rows[i][1].ToString(), 5, 5));
                            break;
                        default:
                            break;
                    }
                }

                for (int j = 0; j < treeView.Nodes.Count; j++)
                {
                    for (int i = 0; i < dataTable_primary.Rows.Count; i++)
                    {
                        if (treeView.Nodes[j].Text.Split('.')[0] == dataTable_primary.Rows[i][1].ToString())
                        {
                            treeView.Nodes[j].Nodes.Add(new TreeNode(dataTable_primary.Rows[i][0].ToString() + ". " + dataTable_primary.Rows[i][2].ToString(), 0, 1));
                        }
                    }
                }

                for (int k = 0; k < treeView.Nodes.Count; k++)
                {
                    for (int j = 0; j < treeView.Nodes[k].Nodes.Count; j++)
                    {
                        for (int i = 0; i < dataTable_secondary.Rows.Count; i++)
                        {
                            if (treeView.Nodes[k].Nodes[j].Text.Split('.')[0] == dataTable_secondary.Rows[i][1].ToString())
                            {
                                treeView.Nodes[k].Nodes[j].Nodes.Add(new TreeNode(dataTable_secondary.Rows[i][0].ToString() + ". " + dataTable_secondary.Rows[i][2].ToString(), 0, 1));
                            }
                        }
                    }
                }

                for (int l = 0; l < treeView.Nodes.Count; l++)
                {
                    for (int k = 0; k < treeView.Nodes[l].Nodes.Count; k++)
                    {
                        for (int j = 0; j < treeView.Nodes[l].Nodes[k].Nodes.Count; j++)
                        {
                            for (int i = 0; i < dataTable_nodes.Rows.Count; i++)
                            {
                                if (treeView.Nodes[l].Nodes[k].Nodes[j].Text.Split('.')[0] == dataTable_nodes.Rows[i][1].ToString())
                                {
                                    treeView.Nodes[l].Nodes[k].Nodes[j].Nodes.Add(new TreeNode(dataTable_nodes.Rows[i][0].ToString() + ". " + dataTable_nodes.Rows[i][2].ToString(), 2, 3));
                                }
                            }
                        }
                    }
                }

                treeView.EndUpdate();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        #region TreeView NodeOps
        private void Insert_Level0_Node(string node_name)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("INSERT INTO SEGMENT_MAIN([Segment_Main]) VALUES (@node_name);", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@node_name", node_name);
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Insert_Level1_Node(string parent_id, string node_name)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("INSERT INTO SEGMENTS_PRIMARY([ID_Main],[Segment_Primary]) VALUES (@parent_id,@node_name);", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@parent_id", Convert.ToInt32(parent_id));
                sQLiteCommand.Parameters.AddWithValue("@node_name", node_name);
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Insert_Level2_Node(string parent_id, string node_name)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("INSERT INTO SEGMENTS_SECONDARY([ID_Primary],[Segment_Secondary]) VALUES (@parent_id,@node_name);", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@parent_id", Convert.ToInt32(parent_id));
                sQLiteCommand.Parameters.AddWithValue("@node_name", node_name);
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Insert_Level3_Node(string parent_id, string node_name)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("INSERT INTO SEGMENTS_NODES([ID_Secondary],[Node]) VALUES (@parent_id,@node_name);", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@parent_id", Convert.ToInt32(parent_id));
                sQLiteCommand.Parameters.AddWithValue("@node_name", node_name);
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //static public void Update_Node(string node_id, string node_name)
        //{

        //}

        private void Delete_Level0_Node(string node_id)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("DELETE FROM SEGMENT_MAIN WHERE ID = @node_id;", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@node_id", Convert.ToInt32(node_id));
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Delete_Level1_Node(string node_id)
        {
            {
                try
                {
                    sqlConnection.Open();
                    SQLiteCommand sQLiteCommand = new("DELETE FROM SEGMENTS_PRIMARY WHERE ID = @node_id;", sqlConnection);
                    sQLiteCommand.Parameters.AddWithValue("@node_id", Convert.ToInt32(node_id));
                    sQLiteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void Delete_Level2_Node(string node_id)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("DELETE FROM SEGMENTS_SECONDARY WHERE ID = @node_id;", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@node_id", Convert.ToInt32(node_id));
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Delete_Level3_Node(string node_id)
        {
            try
            {
                sqlConnection.Open();
                SQLiteCommand sQLiteCommand = new("DELETE FROM SEGMENTS_NODES WHERE ID = @node_id;", sqlConnection);
                sQLiteCommand.Parameters.AddWithValue("@node_id", Convert.ToInt32(node_id));
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        #endregion


    }
}
