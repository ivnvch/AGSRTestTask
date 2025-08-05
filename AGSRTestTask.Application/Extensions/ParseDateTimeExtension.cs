namespace AGSRTestTask.Application.Extensions;

public static class ParseDateTimeExtension
{
    public static DateTime ParseDateTime(string datePart)
    {
        if (!DateTime.TryParse(datePart, out var parsed))
            throw new ArgumentException($"Invalid date format: '{datePart}'");

        return DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
    }
}