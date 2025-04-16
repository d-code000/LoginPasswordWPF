using System.Windows;

namespace Task_2_5
{
    public partial class AuthWindow
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();

            if (login.Length < 1 || pass.Length < 1)
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль!");
                return;
            }

            try
            {
                User? authUser;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users
                        .FirstOrDefault(user => user.Login == login);
                }

                if (authUser != null && authUser.VerifyPassword(pass))
                {
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message);
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}