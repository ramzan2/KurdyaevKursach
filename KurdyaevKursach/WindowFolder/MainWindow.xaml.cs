﻿using KurdyaevKursach.ClassFolder;
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
using System.Windows.Shapes;

namespace KurdyaevKursach.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListUserPage());
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
            MainFrame.Navigate(new ListUserPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddUserPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
