using System.Security.Cryptography;
using System.Text;

namespace Task_2_5;

public class User
{
    public int Id { get; init; }
    public string? Login { get; init; }
    public string? PassHash { get; init; }
    public User() { }
    public User(string? login, string? password)
    {
        Login = login;
        PassHash = HashPassword(password);
    }
    private static string? HashPassword(string? password)
    {
        if (string.IsNullOrEmpty(password))
            return null;

        using SHA256 sha256 = SHA256.Create();
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
        StringBuilder builder = new StringBuilder();
        foreach (var t in hashBytes)
        {
            builder.Append(t.ToString("x2"));
        }
                
        return builder.ToString();
    }
    
    public bool VerifyPassword(string? password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(PassHash))
            return false;

        string? inputPasswordHash = HashPassword(password);
        return inputPasswordHash == PassHash;
    }
    
    public override string ToString()
    {
        return $"ID: {Id}, Логин: {Login}, Хэш пароля: {PassHash}";
    }
}