namespace DomainModel;

public static class BaseRegex
{
    public const string ValidPersianLetters = @"[\u0600-\u06FF\u0698\u067E\u0686\u06AF]+$";

    public const string EnglishLetters = @".*?[a-zA-Z].*?";
}