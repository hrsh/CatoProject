namespace Cato.JwtService
{
    public interface IJwtService
    {
        string Token();

        string Token(string issuer);
    }
}