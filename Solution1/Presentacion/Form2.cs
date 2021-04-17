using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace Presentacion
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            TextReader sr = new StreamReader("PalabrasConfirmadas.txt");
            PalabrasConfirmadas PC = new PalabrasConfirmadas();
            PC.palabrasConfirmadas = new Hashtable();
            string Keys = "", Values = "";
            Keys = sr.ReadLine();
            Values = sr.ReadLine();
            while (Keys != null)
            {
                PC.palabrasConfirmadas.Add(int.Parse(Keys), Values);
                Keys = sr.ReadLine();
                Values = sr.ReadLine();
            }
            sr.Close();
            string mensaje = "";
            textBox1.Text = "";

            for (int i = 1; i <= PC.palabrasConfirmadas.Count; i++)
            {
                mensaje += PC.palabrasConfirmadas[i].ToString() + Environment.NewLine;
            }
            textBox1.Text = mensaje;
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            TextReader sr = new StreamReader("PalabrasConfirmadas.txt");
             PalabrasConfirmadas PC = new PalabrasConfirmadas();
             PC.palabrasConfirmadas = new Hashtable();
             string Keys = "", Values = "";
             Keys = sr.ReadLine();
             Values = sr.ReadLine();
             while (Keys != null)
             {
                 PC.palabrasConfirmadas.Add(int.Parse(Keys), Values);
                 Keys = sr.ReadLine();
                 Values = sr.ReadLine();
             }
             sr.Close();
             string mensaje = "";
             textBox1.Text = "";

             for (int i=1;i<=PC.palabrasConfirmadas.Count;i++)
             {
                 mensaje +=PC.palabrasConfirmadas[i].ToString() +Environment.NewLine;
             }
             textBox1.Text = mensaje;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path =  @"R:\Login C#\Nueva carpeta\Solution1\Presentacion\bin\Debug";
        }
    }
}
