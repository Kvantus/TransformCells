using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace TransformCells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Articles> MyArticles { get; set; }
        public string FileName { get; set; }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            if (OpenBadFile.ShowDialog() == DialogResult.OK)
            {
                LabelState.Text = "Сбор данных из файла...";
                LabelState.Refresh();

                MyArticles = new List<Articles>();
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(OpenBadFile.FileName, Encoding.Default);
                    FileName = Path.GetFileNameWithoutExtension(OpenBadFile.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Файл должен быть закрыт\n" + ex.Message);
                    return;
                }

                while (!reader.EndOfStream)
                {
                    string currentRow = reader.ReadLine();
                    foreach (var row in GetArticlesAndCounts(currentRow))
                    {
                        MyArticles.Add(row);
                    }
                }

                reader.Close();

                LabelState.Text = "Сбор данных завершен. Ожидание";
                LabelState.Refresh();
            }
        }


        private List<Articles> GetArticlesAndCounts(string row)
        {
            string article = "Артикул: ";
            string count = "Кол-во: ";
            int artLength = article.Length;
            int countLenght = count.Length;

            int articleIndex = row.IndexOf(article);
            int countIndex = row.IndexOf(count);

            if (articleIndex < 0 || countIndex < 0)
            {
                return new List<Articles>();
            }
            List<Articles> rowsInLine = new List<Articles>();

            while (articleIndex > -1 && countIndex > -1)
            {
                int separatorIndex = row.IndexOf(';', articleIndex);
                if (separatorIndex < 0)
                {
                    break;
                }
                int articleLine = separatorIndex - articleIndex - artLength;
                string currentArticle = row.Substring(articleIndex + artLength, articleLine);


                separatorIndex = row.IndexOf(';', countIndex);
                if (separatorIndex < 0)
                {
                    break;
                }
                int countLine = separatorIndex - countIndex - countLenght;
                string currentCount = row.Substring(countIndex + countLenght, countLine);

                rowsInLine.Add(new Articles { Number = currentArticle, Count = currentCount });

                row = row.Remove(articleIndex, artLength);
                row = row.Remove(countIndex - artLength, countLenght);
                articleIndex = row.IndexOf(article);
                countIndex = row.IndexOf(count);
            }

            return rowsInLine;
        }

        private void BTransform_Click(object sender, EventArgs e)
        {
            if (MyArticles == null)
            {
                MessageBox.Show("Не выбран файл!");
                return;
            }

            ExcelPackage eP = new ExcelPackage();
            ExcelWorkbook book = eP.Workbook;
            ExcelWorksheet sheet = book.Worksheets.Add("Лист1");

            sheet.Cells[1, 1].Value = "Артикул";
            sheet.Cells[1, 2].Value = "Кол-во";

            for (int i = 0; i < MyArticles.Count; i++)
            {
                sheet.Cells[i + 1, 1].Value = MyArticles[i].Number;
                sheet.Cells[i + 1, 2].Value = MyArticles[i].Count;
            }
            string timeNow = DateTime.Now.ToString().Replace(":", "-").Replace(".", "_");
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"{folder}\\{FileName} {timeNow}.xlsx";
            eP.SaveAs(new FileInfo( $"{folder}\\{FileName} {timeNow}.xlsx"));


            Excel.Application excel = null;
            try
            {
                excel = System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application")
                        as Excel.Application;
            }
            catch (Exception)
            {
                excel = new Excel.Application();
                excel.Visible = true;
            }

            excel.Visible = true;

            excel.Workbooks.Open(fileName);
        }
    }
}
