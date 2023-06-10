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

namespace KurdyaevKursach.PageFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListEmployeePage());
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                kurdyaevEntities2.GetContext().Employee.Add(new Employee()
                {
                    EmployeeName = NameTb.Text,
                    EmployeeSecondName= SecondNameTb.Text,
                    EmployeeLastName=LastNameTb.Text,
                    EmployeeLanguage=LanguageTb.Text,
                    EmployeeCountry=CountryTb.Text
                });
                kurdyaevEntities2.GetContext().SaveChanges();
                MBClass.InfoMB("Работник успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }            
        }
    }
}
