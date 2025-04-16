using System.Windows;

namespace Task_2_5
{
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из текстовых полей
            string login = LoginTextBox.Text.Trim();
            string pass = PassBox.Password.Trim();

            // Проверка корректности введенных данных
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

            // Проверка отсутствия символа "*" в пароле (требование из задания)
            if (pass.Contains("*"))
            {
                MessageBox.Show("Пароль не должен содержать символ '*'!");
                return;
            }

            try
            {
                // Создание нового пользователя
                User user = new User(login, pass);

                // Добавление в базу данных
                db.Users.Add(user);
                db.SaveChanges();

                MessageBox.Show("Пользователь успешно зарегистрирован!");

                // Переход к окну авторизации
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра окна авторизации
            AuthWindow authWindow = new AuthWindow();
            // Отображение окна авторизации
            authWindow.Show();
            // Скрытие текущего окна
            this.Hide();
        }
    }
}