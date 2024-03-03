using Mysln.Domain.Entities;

namespace Mysln.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}