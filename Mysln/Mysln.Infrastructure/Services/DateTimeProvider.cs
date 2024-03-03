using Mysln.Application.Services;

namespace Mysln.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtwNow => DateTime.UtcNow;
}
