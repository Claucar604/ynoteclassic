﻿using System;
using System.Windows.Forms;

namespace SS.Ynote.Classic.Extensibility.Packages
{
    public partial class PackageInstaller : Form
    {
        private readonly string _package;
        private readonly Timer _time;

        public PackageInstaller(string package)
        {
            InitializeComponent();
            _time = new Timer {Interval = 10};
            _time.Tick += _time_Tick;
            _package = package;
            _time.Start();
            // installer.ProgressChanged += installer_ProgressChanged;
            // installer.RunWorkerCompleted += installer_RunWorkerCompleted;
        }

        // protected override void OnShown(EventArgs e)
        // {
        //     installer.RunWorkerAsync(_package);
        //     base.OnShown(e);
        // }
        // void installer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        // {
        //     var val = (bool) (e.Result);
        //     if (val)
        //     {
        //         var result = MessageBox.Show("Plugin Installed Successfully ? Restart now to make changes ?",
        //             "Plugin Installer",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //         if (result == DialogResult.Yes)
        //             Application.Restart();
        //     }
        //     else
        //         MessageBox.Show("There was an Error Installing the Plugin");
        //     Close();
        // }

        // void installer_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        // {
        //     progressBar1.Value = e.ProgressPercentage;
        //     label1.Text = string.Format("Installing Package.. {0} % Completed", e.ProgressPercentage);
        // }

        private void _time_Tick(object sender, EventArgs e)
        {
            _time.Stop();
            if (YnotePackageManager.InstallPackage(_package))
            {
                progressBar1.Value = 100;
                var result = MessageBox.Show("Package Installed Successfully ? Restart now to make changes ?",
                    "Package Installer",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Application.Restart();
            }
            else
                MessageBox.Show("There was an Error Installing the Package");
            Close();
        }

        //private void installer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        //{
        //    YnotePackageInstaller.InstallPackage(e.Argument.ToString());
        //}
    }
}