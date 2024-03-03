using Mysln.Domain.Entities;

namespace Mysln.Application.Services.Authentication;

public record AuthenticationResult
(
    User User,
    string Token
);