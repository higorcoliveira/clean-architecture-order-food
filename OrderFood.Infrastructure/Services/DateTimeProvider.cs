using OrderFood.Application.Common.Interfaces.Services;

namespace OrderFood.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
