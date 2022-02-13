﻿using System.Text.RegularExpressions;

namespace DomainModel;

public static class ExtensionsHelper
{
    public static bool IsValidNationalCode(this string nationalCode)
    {
        if (string.IsNullOrEmpty(nationalCode))
            return false;


        if (nationalCode.Length != 10)
            return false;

        var regex = new Regex(@"\d{10}");
        if (!regex.IsMatch(nationalCode))
            return false;

        var allDigitEqual = new[]
        {
            "0000000000", "1111111111",
            "2222222222", "3333333333", "4444444444", "5555555555",
            "6666666666", "7777777777", "8888888888", "9999999999"
        };
        if (allDigitEqual.Contains(nationalCode)) return false;


        var chArray = nationalCode.ToCharArray();
        var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
        var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
        var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
        var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
        var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
        var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
        var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
        var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
        var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
        var a = Convert.ToInt32(chArray[9].ToString());

        var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
        var c = b % 11;

        return c < 2 && a == c || c >= 2 && 11 - c == a;
    }

    public static bool IsNotValidPersianName(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return true;

        var persianAlphabets = new Regex(BaseRegex.ValidPersianLetters);
        return !persianAlphabets.IsMatch(value);
    }

    public static bool IsNotValidMobileNumber(this string phoneNumber)
    {
        var regex = new Regex(@"(\0)?9\d{9}");
        return !regex.IsMatch(phoneNumber);
    }
}