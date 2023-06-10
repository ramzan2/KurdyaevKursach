﻿using KurdyaevKursach.ClassFolder;
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
    /// Логика взаимодействия для ListEmployeePage.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public ListEmployeePage()
        {
            InitializeComponent();
            DgUser.ItemsSource = kurdyaevEntities2.GetContext().Employee
                .ToList().OrderBy(u => u.EmployeeName);
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            ExportClass.ToExcelFile(DgUser, "Экспорт работников");
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = DgUser.SelectedItem as Employee;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите работника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"работника с именем " +
                    $"{employee.EmployeeName}?"))
                {
                    kurdyaevEntities2.GetContext().Employee
                        .Remove(DgUser.SelectedItem as Employee);
                    kurdyaevEntities2.GetContext().SaveChanges();

                    MBClass.InfoMB("работник удален");
                    DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                        .Employee.ToList().OrderBy(u => u.EmployeeName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "работника для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditEmployeePage(DgUser.SelectedItem as Employee));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = kurdyaevEntities2.GetContext()
                .Employee.Where(u => u.EmployeeName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.EmployeeName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
