using Domain.Entities;

namespace Presentation.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}