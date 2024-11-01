using Microsoft.Extensions.Logging;

namespace WinFormsAppCore
{
    public partial class Form1 : Form
    {
        private readonly ILogger _logger;

        public Form1(ILogger<Form1> logger)
        {
            this._logger = logger;

            InitializeComponent();

            ErrorTest();
        }

        private void ErrorTest()
        {
            _logger.LogInformation("¾Ë¸²");
            _logger.LogError("Error Test");
        }
    }
}
