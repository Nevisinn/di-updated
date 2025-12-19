namespace TagsCloud.Infrastructure.Services;

public static class EnumMapper
{
    public static TEnum Map<TEnum>(string value) where TEnum : struct, Enum
    {
        if (!Enum.TryParse<TEnum>(value, true, out var result))
            throw new ArgumentException($"Не найден: {value}");

        return result;
    }
}