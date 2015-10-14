using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using EbayModule.view;
using Ninject;

namespace ApplicationTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IKernel kernel = new StandardKernel(new Bindings());
            //kernel.Load(Assembly.GetExecutingAssembly());
            Application.Run(kernel.Get<Form1>());
        }
    }
}
