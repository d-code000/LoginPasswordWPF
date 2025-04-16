using System.Windows;

namespace Task_2_5
{
    public partial class MainWindow
    {
        private readonly ApplicationContext _db;

        public MainWindow()
        {
            InitializeComponent();
            _db = new ApplicationContext();
            _db.EnsureDbCreated();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();
            
            if (login.Length < 3)
            {
                MessageBox.Show("Логин должен содержать не менее 3 символов!");
                return;
            }

            if (pass.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов!");
                return;
            }
            
            if (pass.Contains("*"))
            {
                MessageBox.Show("Пароль не должен содержать символ '*'!");
                return;
            }

            try
            {
                User user = new User(login, pass);
                
                _db.Users.Add(user);
                _db.SaveChanges();

                MessageBox.Show("Пользователь успешно зарегистрирован!");
                
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}