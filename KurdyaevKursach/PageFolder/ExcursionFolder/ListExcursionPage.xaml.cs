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
    /// Логика взаимодействия для ListExcursionPage.xaml
    /// </summary>
    public partial class ListExcursionPage : Page
    {
        public ListExcursionPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = kurdyaevEntities2.GetContext().Excursion
                .ToList().OrderBy(u => u.ExcursionName);
        }
        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт пользователей");
        }

        private void SearchTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                .Excursion.Where(u => u.ExcursionName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.ExcursionName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Excursion excursion = DgUser.SelectedItem as Excursion;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"экскурсию с именем " +
                    $"{excursion.ExcursionName}?"))
                {
                    kurdyaevEntities2.GetContext().Excursion
                        .Remove(DgUser.SelectedItem as Excursion);
                    kurdyaevEntities2.GetContext().SaveChanges();

                    MBClass.InfoMB("Экскурсия удалена");
                    DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                        .Excursion.ToList().OrderBy(u => u.ExcursionName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "экскурсию для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditExcursionPage(DgUser.SelectedItem as Excursion));
            }
        }
    }
}
