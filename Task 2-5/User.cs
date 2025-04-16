namespace Task_2_5
{
    public class User
    {
        public int Id { get; init; }
        public string? Login { get; init; }
        public string? Pass { get; init; }

        public User() { }

        public User(string? login, string? pass)
        {
            Login = login;
            Pass = pass;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Логин: {Login}, Пароль: {Pass}";
        }
    }
}