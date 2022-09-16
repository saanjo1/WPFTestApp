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
using WpfAppv1.ViewModels;

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

            private void Prikaz_Click(object sender, RoutedEventArgs e)
        {
            _objExcelSer = new ExcelDataService();
            try
            {
                dataGridArticle.ItemsSource = _objExcelSer.ReadFromExcel().Result;
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
          
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

