using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfAppv1.Models;

namespace WpfAppv1.ViewModels
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
       private static ObservableCollection<ArticleDisplayVM> Articles = new ObservableCollection<ArticleDisplayVM>();
        possectorContext appContext = new possectorContext();



        public ExcelDataService()
        {
            string excelfile = @"C:\Users\asus\OneDrive\Documents\ExcelFiles\Test.xls";
            string con =
                  @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfile + ";" +
                  @"Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=True";
            conn = new OleDbConnection(con);
        }


        public async Task<ObservableCollection<ArticleDisplayVM>> ReadFromExcel()
        {

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
                    Gender = Reader["GENDER"].ToString(),
                    So_Price = Reader["SO_PRICE"].ToString(),
                    ItemSize = Reader["ITEM_SIZE"].ToString()
                });
            }

            Reader.Close();
            conn.Close();
            return Articles;
        }


        public async void ImportToDatabase()
        {
            var culture = new CultureInfo("en-US");

            for (int i = 0; i < Articles.Count(); i++)
            {
                
                var temp = appContext.Articles.Where(x => x.BarCode == Articles[i].BarCode).FirstOrDefault();

                if(temp == null)
                {
                    appContext.Articles.Add(new Article
                    {
                        Name = Articles[i].ItemName,
                        Price = Helpers.Extensions.GetDecimal(Articles[i].So_Price),
                        BarCode = Articles[i].BarCode,
                        ArticleNumber = 123,
                        SubCategoryId = Helpers.Extensions.ManageSubcategory(Articles[i].Gender),
                        Deleted = false,
                        ReturnFee = 1,
                        Id = Guid.NewGuid(),
                        Order = 1
                    }) ;
                }
                
            }
            appContext.SaveChanges();

        }

       
        


        }
    }
