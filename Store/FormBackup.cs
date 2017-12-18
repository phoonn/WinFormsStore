using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repositories;
using System.IO;
using ErrorAndValidation;

namespace Store
{
    public partial class FormBackup : Form
    {
        string path;
        public FormBackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            path = folderBrowserDialog1.SelectedPath;
            textBox1.Text = path;
        }

        private void button_backup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(path))
            {
                return;
            }
            try
            {
                using (StoreDbContext context = new StoreDbContext())
                {
                    context.CreateBackup(path);
                    try
                    {
                        context.CheckIntegrity(path);
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.Log(ex);
                        MessageBox.Show("Backup integrity violated, check log file", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Backup Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex);
                MessageBox.Show("Backup Couldn't be created, check log file", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
