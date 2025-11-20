namespace Domain.Auth;

public class RefreshToken
{
    public virtual Guid Id { get; set; }
    public virtual Guid UserId { get; set; }
    public virtual string Token { get; set; }
    public virtual DateTime CreationTime { get; set; }
    public virtual DateTime ExpirationTime { get; set; }
    public virtual string CreatedByIp { get; set; }
    public virtual bool IsRevoked { get; set; }
    public virtual string? ReplacedByToken { get; set; }
}