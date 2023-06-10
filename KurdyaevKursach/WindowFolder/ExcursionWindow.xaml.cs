using KurdyaevKursach.ClassFolder;
using KurdyaevKursach.PageFolder.AdminFolder;
using KurdyaevKursach.PageFolder.ExcursionFolder;
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
using System.Windows.Shapes;

namespace KurdyaevKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для ExcursionWindow.xaml
    /// </summary>
    public partial class ExcursionWindow : Window
    {
        public ExcursionWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListExcursionPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListExcursionPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddExcursionPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
