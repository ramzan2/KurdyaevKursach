using KurdyaevKursach.ClassFolder;
using KurdyaevKursach.DataFolder;
using System;
using System.Collections.Generic;
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

namespace KurdyaevKursach.PageFolder.ExcursionFolder
{
    /// <summary>
    /// Логика взаимодействия для AddExcursionBuroPage.xaml
    /// </summary>
    public partial class AddExcursionBuroPage : Page
    {
        public AddExcursionBuroPage()
        {
            InitializeComponent();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                kurdyaevEntities2.GetContext().ExcurionBuro.Add(new ExcurionBuro()
                {
                    ExcurionBuroName = NameTb.Text,
                    ExcurionBuroCountry= CountryTb.Text,
                    ExcurionBuroExcursions = ExcursionsTb.Text
                });
                kurdyaevEntities2.GetContext().SaveChanges();
                MBClass.InfoMB("Бюро успешно добавлено");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}
