namespace WebApplication5.Services
{
    public interface ILameService
    {
        bool Authenticate(string secret);
    }
}