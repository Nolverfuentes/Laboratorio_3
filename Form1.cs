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
namespace Laboratorio_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonIr_Click(object sender, EventArgs e)
        {

            String uri = "";
            if (comboBox1.SelectedItem != null)
                uri=comboBox1.SelectedItem.ToString();
            if (comboBox1.Text != null)
                uri = comboBox1.Text;
            if (!uri.Contains("."))
                uri = "https://www.google.com/search?q=" + uri;
            if (!uri.Contains("https://"))
                uri = "https://" + uri;
            webBrowser1.Navigate(new Uri(uri));

            int yaEsta = 0;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (uri == comboBox1.Items[i].ToString())
                    yaEsta++;
            }
            if (yaEsta == 0)
            {
                comboBox1.Items.Add(uri);
                Guardar("Historial.txt", uri);
            }
        }
        private void Guardar (string FileName,string texto)
        {
            FileStream stream = new FileStream(FileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(texto);
            writer.Close();

        }
        private void Leer(string fileName)
        {
            
      
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            
            while (reader.Peek() > -1)
            
            {
                // richTextBox1.AppendText(reader.ReadLine());
                comboBox1.Items.Add (reader.ReadLine());

            }
          
            reader.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0;
            //webBrowser1.GoHome();
            Leer("Historial.txt");


        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void haciaAtràsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
