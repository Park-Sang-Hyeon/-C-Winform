using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // LoggerFactory와 Logger 설정
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();       // Console Logger 설정
            });
            services.AddSingleton(loggerFactory); // LoggerFactory 등록
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>)); // Generic ILogger 등록

            // Register your forms
            services.AddTransient<Form1>();
        }
    }
}
