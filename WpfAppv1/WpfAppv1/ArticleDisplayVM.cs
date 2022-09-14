using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppv1
{
    public class ArticleDisplayVM
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string Prijevodi { get; set; }
        public string ColorDescription { get; set; }
        public string ItemSize { get; set; }
        public string Gender { get; set; }
        public string BarCode { get; set; }
        public string So_Price { get; set; }
    }

    public class ExcelDataService
    {
        OleDbConnection conn;
        OleDbCommand Command;

        public ExcelDataService()
        {
            string excelfile = @"C:\Users\asus\OneDrive\Desktop\DokumentacijaPraksa\ExcelFile.xls";
            string con =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfile + ";" +
                  @"Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=True";
            conn = new OleDbConnection(con);
        }


        public async Task<ObservableCollection<ArticleDisplayVM>> ReadFromExcel()
        {
            ObservableCollection<ArticleDisplayVM> Articles = new ObservableCollection<ArticleDisplayVM>();

            await conn.OpenAsync();
            Command = new OleDbCommand();
            Command.Connection = conn;
            Command.CommandText = "select * from [DETAILS$]";

            var Reader = await Command.ExecuteReaderAsync();

            while (Reader.Read())
            {
                Articles.Add(new ArticleDisplayVM()
                {
                    ID = Reader["ITEM"].ToString(),
                    BarCode = Reader["BARCODE"].ToString(),
                    ItemName = Reader["BARCODE"].ToString() + " " + Reader["ITEM"].ToString() + " "
                    + Reader["prijevodi HRVATSKI"].ToString() + " " + Reader["COLOR_DESCRIPTION"].ToString() + " " + Reader["ITEM_SIZE"].ToString(),
                    ColorDescription = Reader["COLOR_DESCRIPTION"].ToString(),
                    Gender = Reader["GENDER"].ToString(),
                    So_Price = Reader["SO_PRICE"].ToString(),
                    Prijevodi = Reader["prijevodi HRVATSKI"].ToString(),
                    ItemSize = Reader["ITEM_SIZE"].ToString()
                });
            }

            Reader.Close();
            conn.Close();
            return Articles;
        }
    }
}
