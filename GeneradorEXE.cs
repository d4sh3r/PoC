/*
Decripción:Pequeña aplicación que ejemplifica el uso de CodeDOM (Code Document Object Model)
https://msdn.microsoft.com/es-es/library/bb972255.aspx
Autor:d4sh&r
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace GeneradorEXE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
			/*
			txtSource - TextBox multiline
			btnCompile - Button
			*/
            CSharpCodeProvider codeProvider = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            CompilerParameters parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll", "System.dll" }, "output.exe",false);
            parameters.GenerateExecutable = true;
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters,txtSource.Text);

                       if (results.Errors.HasErrors)
            {
                string errores = "";
                results.Errors.Cast<CompilerError>().ToList().ForEach(error => errores += error.ErrorText + "\r\n");
                MessageBox.Show(errores, "Maker-Error");
            }
            else
            {
                MessageBox.Show("¡EXE creado!", "Maker");
            }
             
        }
    }
}
