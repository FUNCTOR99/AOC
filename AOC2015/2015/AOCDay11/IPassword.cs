namespace AOC2015
{
    public interface IPassword
    {
        string PasswordValue { get; set; }

        void UpdatePassword(string newPassword);

        bool IsValid();
    }
}