using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfAppv1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        ExcelDataService _objExcelSer;
        ArticleDisplayVM _article = new ArticleDisplayVM();

        public UserControlTest()
        {
            InitializeComponent();
        }

            private void Import_Click(object sender, RoutedEventArgs e)
        {
            _objExcelSer = new ExcelDataService();
            try
            {
                dataGridStudent.ItemsSource = _objExcelSer.ReadFromExcel().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportCat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportCat_Click(object sender, RoutedEventArgs en)
        {
            string excel_path = @"C:\Users\asus\OneDrive\Desktop\DokumentacijaPraksa\ExcelFile.xls";
            string con =
               @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel_path + ";" +
               @"Extended Properties='Excel 8.0;HDR=Yes;';Persist Security Info=True";
            using (OleDbConnection connection = new OleDbConnection(con))
            {

            }
        }

        public static bool ImportArticlesFromExcel(string excel_path = @"C:\Users\asus\OneDrive\Desktop\DokumentacijaPraksa\ExcelFile.xls", string tab_name = "Sheet1$", int barcode_index = 1, int name_index = 1, int price_ind = 1)
        {

            
            return true;
        }
    }
}

