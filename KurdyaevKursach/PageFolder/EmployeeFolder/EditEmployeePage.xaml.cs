using KurdyaevKursach.ClassFolder;
using KurdyaevKursach.DataFolder;
using KurdyaevKursach.PageFolder.AdminFolder;
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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        Employee employee = new Employee();
        public EditEmployeePage(Employee employee)
        {
            InitializeComponent();
            DataContext = employee;

            this.employee.EmployeeId = employee.EmployeeId;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee = kurdyaevEntities2.GetContext().Employee
                    .FirstOrDefault(u => u.EmployeeId == employee.EmployeeId);
                employee.EmployeeName = NameTb.Text;
                employee.EmployeeSecondName = SecondNameTb.Text;
                employee.EmployeeLastName = LastNameTb.Text;
                employee.EmployeeLanguage= LanguageTb.Text;
                employee.EmployeeCountry = CountryTb.Text;
                kurdyaevEntities2.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListEmployeePage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListEmployeePage());
        }
    }
}
