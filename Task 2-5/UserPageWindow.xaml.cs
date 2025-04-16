using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Task_2_5
{
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            // Загрузка пользователей из базы данных
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = db.Users.ToList();
                ListOfUsers.ItemsSource = users;
            }

            // Обработчик кнопки выхода
            LogoutButton.Click += LogoutButton_Click;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}