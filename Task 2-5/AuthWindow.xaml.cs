using System.Windows;

namespace Task_2_5
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            // Получение введенных данных
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();

            // Проверка на пустые поля
            if (login.Length < 1 || pass.Length < 1)
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль!");
                return;
            }

            // Поиск пользователя в БД
            User authUser = null;
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    // Поиск пользователя по логину и паролю
                    authUser = db.Users
                        .Where(user => user.Login == login && user.Pass == pass)
                        .FirstOrDefault();
                }

                // Проверка результата поиска
                if (authUser != null)
                {
                    // Если пользователь найден - переход в личный кабинет
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    this.Hide();
                }
                else
                {
                    // Если пользователь не найден - уведомление об ошибке
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
            // Переход к окну регистрации
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}