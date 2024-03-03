using Mysln.Domain.Entities;

namespace Mysln.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}