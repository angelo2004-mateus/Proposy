namespace Domain.Auth;

public interface IRefreshTokenRepository
{
    Task AddAsync (RefreshToken token);
    Task<RefreshToken> FindByTokenAsync (string token);
    Task UpdateAsync (RefreshToken token);
}