using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            SaveFileDialog saveDialog1 = new SaveFileDialog();            
            saveDialog1.InitialDirectory = "c:";
            saveDialog1.Title = "Save Report File";
            saveDialog1.FileName = "";
            saveDialog1.Filter = "Excel Files|*.xlsx";
            if (saveDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                for (int i = 1; i < listView1.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = listView1.Columns[i - 1].Text;
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < listView1.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = listView1.Items[i].SubItems[j].Text;
                    }

                }

                xlWorkBook.SaveCopyAs(saveDialog1.FileName.ToString());
                xlWorkBook.Saved = true;

                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }           
        
        }

    private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


    }
}
