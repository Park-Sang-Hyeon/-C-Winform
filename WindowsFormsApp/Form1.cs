﻿using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private readonly ILogger<Form1> _logger;

        public Form1(ILogger<Form1> logger)
        {
            this._logger = logger;

            InitializeComponent();

            ErrorTest();
        }

        private void ErrorTest()
        {
            this._logger.LogError("WindowsFormsApp Error ??");
        }
    }
}
