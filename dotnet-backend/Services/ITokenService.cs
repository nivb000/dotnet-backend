namespace dotnet_backend.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(string userId);
    }
}