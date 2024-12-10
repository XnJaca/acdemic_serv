namespace acdemic_serv.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string value)
    {
        // naïve camel case
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }
        if (value.Length == 1)
        {
            return value.ToLowerInvariant();
        }

        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }
}