using System.Windows;

namespace Task_2_5
{
    public partial class UserPageWindow
    {
        public UserPageWindow()
        {
            InitializeComponent();
            
            using (ApplicationContext db = new ApplicationContext())
            {
                List<User> users = db.Users.ToList();
                ListOfUsers.ItemsSource = users;
            }
            
            LogoutButton.Click += LogoutButton_Click;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}