using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstAppCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAOclass dao = new DAOclass();
            List<Mats> mats = dao.getAllMats();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("NRC", 50);
            listView1.Columns.Add("ASIGNATURA", 250);
            listView1.Columns.Add("CREDITOS", 30);
            listView1.Columns.Add("MODALIDAD", 30);
            listView1.Columns.Add("PERIODO", 30);

            ListViewItem itm;

            foreach (Mats mat in mats) {                
                string[] arr = new string[5];
                arr[0] = mat.Nrc.ToString();
                arr[1] = mat.Asignatura;
                arr[2] = mat.Creditos.ToString();
                arr[3] = mat.Modalidad;
                arr[4] = mat.Periodo.ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
