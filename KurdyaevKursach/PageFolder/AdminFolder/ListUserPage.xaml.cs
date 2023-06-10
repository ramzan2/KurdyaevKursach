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

namespace KurdyaevKursach.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = kurdyaevEntities2.GetContext().User
                .ToList().OrderBy(u => u.UserName);
        }
      

        private void SearchTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                .User.Where(u => u.UserName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.UserName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт пользователей");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            User user = DgUser.SelectedItem as User;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{user.UserName}?"))
                {
                    kurdyaevEntities2.GetContext().User
                        .Remove(DgUser.SelectedItem as User);
                    kurdyaevEntities2.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь удален");
                    DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                        .User.ToList().OrderBy(u => u.UserName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditUserPage(DgUser.SelectedItem as User));
            }
        }
    }
}
