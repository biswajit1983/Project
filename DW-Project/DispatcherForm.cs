﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Microsoft.SqlServer.Dts.Runtime;

namespace DW_Project
{
    public partial class DispatcherForm : Form
    {
        public DispatcherForm()
        {
            InitializeComponent();
        }

        private void DispatcherForm_Load(object sender, EventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open CSV File";
            //should fliter for files with the name or extention csv
            fDialog.Filter = "CSV Foles|*.csv";
            //sets initial directory to start browser at
            fDialog.InitialDirectory = @"C:\";
            fDialog.CheckFileExists = true;
            fDialog.CheckPathExists = true;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                //needs testing
                //InsetFile name into DTS file
                MessageBox.Show(fDialog.FileName.ToString());
                String file = File.ReadAllText("../sql/Building out the Datawarehouse/02S01 load_dispatcher_report.dtsx");
                file = file.Replace("REPLACESTRINGHERE", fDialog.FileName.ToString());
                File.WriteAllText("../sql/Building out the Datawarehouse/02S01 load_dispatcher_report.dtsx", file);
                //TODO: Run DTS file

                //Clean DTS file
                file = File.ReadAllText("../sql/Building out the Datawarehouse/02S01 load_dispatcher_report.dtsx");
                file = file.Replace(fDialog.FileName.ToString(),"REPLACESTRINGHERE");
                File.WriteAllText("../sql/Building out the Datawarehouse/02S01 load_dispatcher_report.dtsx", file);
                //TODO: prompt user success or fail
            }

        }

        private void backBut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new StartScreenForm().ShowDialog();
            this.Close();
        }

    }
}
