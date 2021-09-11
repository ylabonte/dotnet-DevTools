using Microsoft.Win32;
using SetUserEnvVars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvLoaderWindows
{
    public partial class MainWindow : Form
    {
        private string _filePath = string.Empty;
        private Dictionary<string, object> _envVars = new Dictionary<string, object>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell())
            {
                HeaderText = ProgramResources.VariableName,
                Name = "Variable",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });
            dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell())
            {
                HeaderText = ProgramResources.VariableValue,
                Name = "Value",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        string jsonString = reader.ReadToEnd();
                        _envVars = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();

                        dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell())
                        {
                            HeaderText = ProgramResources.VariableName,
                            Name = "Variable",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        });
                        dataGridView.Columns.Add(new DataGridViewColumn(new DataGridViewTextBoxCell())
                        {
                            HeaderText = ProgramResources.VariableValue,
                            Name = "Value",
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        });

                        var viewData = from row in _envVars select new string[] { row.Key, row.Value.ToString() };
                        foreach (var row in viewData)
                            dataGridView.Rows.Add(row);
                    }
                }
            }
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                if (!string.IsNullOrWhiteSpace((string)row.Cells[0].Value))
                {
                    RegistryHelper.SetRegistryValue(
                        Registry.CurrentUser,
                        "Environment",
                        row.Cells[0].Value.ToString(),
                        row.Cells[1].Value
                    );
                }
        }

        private void unsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                if (!string.IsNullOrWhiteSpace((string)row.Cells[0].Value))
                {
                    RegistryHelper.UnsetRegistryValue(
                        Registry.CurrentUser,
                        "Environment",
                        row.Cells[0].Value.ToString()
                    );
                }
        }
    }
}