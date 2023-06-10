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
    /// Логика взаимодействия для AddExcursionPage.xaml
    /// </summary>
    public partial class AddExcursionPage : Page
    {
        public AddExcursionPage()
        {
            InitializeComponent();
            ExcursionBuroCb.ItemsSource = kurdyaevEntities2.GetContext()
                .ExcurionBuro.ToList();
            EmployeeTb.ItemsSource = kurdyaevEntities2.GetContext().Employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExcursionBuroPage());
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index1 = ExcursionBuroCb.SelectedIndex + 1;
                int index2 = EmployeeTb.SelectedIndex + 1;
                kurdyaevEntities2.GetContext().Excursion.Add(new Excursion()
                {
                    ExcursionName = NameTb.Text,
                    ExcursionPrice = decimal.Parse(PriceTb.Text),
                    ExcursionPlace = PlaceTb.Text,
                    ExcursionBuroId = index1,
                    EmployeeId = index2,
                    ExcursionDate = DateTime.Parse(DateTb.Text)

                });
                kurdyaevEntities2.GetContext().SaveChanges();
                MBClass.InfoMB("Экскурсия успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListExcursionPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
