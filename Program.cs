using System;

string DecimalTo(int num, int dividend)
{
    string result = string.Empty;

    while (num > 0)
    {
        int remainder = num % dividend;
        if (remainder > 9)
        {
            result += ((char)(remainder + 55)).ToString();
        }
        else
        {
            result += remainder.ToString();
        }
        num /= dividend;
    }
    result = new string(result.Reverse().ToArray());
    return result;
}
string ToDecimal(int num, int system)
{
    string num_str = new string(num.ToString().Reverse().ToArray());
    //int summand = 1;
    int sum = 0;

    for (int i = 0; i < num_str.Length; i++)
    {
        sum += (int)Math.Pow(system, i) * (int)char.GetNumericValue(num_str[i]);
    }

    return sum.ToString();
}

string DecimalToOctal(int num)
{
    return DecimalTo(num, 8);
}

string OctalToDecimal(int num)
{
    return ToDecimal(num, 8);
}

string DecimalToHex(int num)
{
    return DecimalTo(num, 16);
}

string HexToDecimal(string hex)
{
    string hex_reversed = new string(hex.Reverse().ToArray());
    //int summand = 1;
    int sum = 0;

    for (int i = 0; i < hex_reversed.Length; i++)
    {
        int hex_num = 0;
        if (hex_reversed[i] >= 65 && hex_reversed[i] <= 90)
        {
            hex_num = hex_reversed[i] - 55;
        }
        else if (hex_reversed[i] >= 48 && hex_reversed[i] <= 57)
        {
            hex_num = (int)char.GetNumericValue(hex_reversed[i]);
        }
            sum += (int)Math.Pow(16, i) * hex_num;
    }

    return sum.ToString();
}

string BinToDecimal(int num)
{
    return ToDecimal(num, 2);
}

string DecimalToBin(int num)
{
    return DecimalTo(num, 2);
}

Console.WriteLine("Wybierz działanie: \n1.Binarny - Dziesiętny\n2.Dziesietny - Binarny\n3.Dziesiętny - Szesnastkowy\n4.Szesnastkowy - Dziesietny\n5.Dziesiętny - Ósemkowy\n6.Ósemkowy - Dziesiętny");
if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 7)
{
    Console.WriteLine("Wpisz liczbe:");
    string? input = Console.ReadLine();
    if (choice == 4)
    {
        Console.WriteLine(HexToDecimal(input!));
    }
    else if (int.TryParse(input, out int num))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine(BinToDecimal(num));
                break;
            case 2:
                Console.WriteLine(DecimalToBin(num));
                break;
            case 3:
                Console.WriteLine(DecimalToHex(num));
                break;
            case 4:
                Console.WriteLine(HexToDecimal(input));
                break;
            case 5:
                Console.WriteLine(DecimalToOctal(num));
                break;
            case 6:
                Console.WriteLine(OctalToDecimal(num));
                break;
            default:
                Console.WriteLine("Wpisałeś złą opcję");
                break;
        }
    }
    else
    {
        Console.WriteLine("Nie wpisałeś liczby");

    }
}
else
{
    Console.WriteLine("Nie wpisałeś liczby");
}
