using System;

namespace Task_2_5
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public User() { }

        public User(string login, string pass)
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