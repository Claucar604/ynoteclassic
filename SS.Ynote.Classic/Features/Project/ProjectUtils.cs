﻿using System;
using System.Windows.Forms;

namespace SS.Ynote.Classic.Features.Project
{
    public partial class ProjectUtils : Form
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public ProjectUtils()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     FileName
        /// </summary>
        public string FileName
        {
            get { return textBox1.Text; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}