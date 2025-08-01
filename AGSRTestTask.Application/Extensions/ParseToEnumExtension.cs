namespace AGSRTestTask.Application.Extensions;

public static class ParseToEnumExtension
{
    public static T ToEnum<T>(this string enumString) where T : Enum
    {
        if (Enum.TryParse(typeof(T), enumString, true,  out object parsedEnum))
        {
            return (T)parsedEnum;
        }

        throw new ArgumentException("Invalid enum string");
    }
}