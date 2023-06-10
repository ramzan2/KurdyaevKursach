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

namespace KurdyaevKursach.PageFolder.ExcursionFolder
{
    /// <summary>
    /// Логика взаимодействия для EditExcursionPage.xaml
    /// </summary>
    public partial class EditExcursionPage : Page
    {
        Excursion excursion = new Excursion();
        public EditExcursionPage(Excursion excursion)
        {
            InitializeComponent();
            DataContext = excursion;

            this.excursion.ExcursionId = excursion.ExcursionId;

            ExcursionBuroCb.ItemsSource = kurdyaevEntities2.GetContext()
                .ExcurionBuro.ToList();
            EmployeeTb.ItemsSource = kurdyaevEntities2.GetContext().Employee.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index1 = ExcursionBuroCb.SelectedIndex + 1;
                int index2 = EmployeeTb.SelectedIndex + 1;
                excursion = kurdyaevEntities2.GetContext().Excursion
                    .FirstOrDefault(u => u.ExcursionId == excursion.ExcursionId);
                excursion.ExcursionName = NameTb.Text;
                excursion.ExcursionPrice = int.Parse(PriceTb.Text);
                excursion.ExcursionPlace = PlaceTb.Text;
                excursion.ExcursionBuroId = index1;
                excursion.EmployeeId = index2;
                excursion.ExcursionDate = DateTime.Parse(DateTb.Text);
                kurdyaevEntities2.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ListExcursionPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListExcursionPage());
        }
    }
}
