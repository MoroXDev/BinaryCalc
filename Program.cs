string DecimalTo(int num, int dividend)
{
    string result = string.Empty;

    while (num != 0)
    {
        result += (num % dividend).ToString();
        num /= dividend;
    }

    result = new string(result.Reverse().ToArray());
    return result;
}

string DecimalToOctal(int num)
{
    return DecimalTo(num, 8);
}

string DecimalToHex(int num)
{
    return DecimalTo(num, 16);
}

string ToDecimal(int num, int system)
{
    string binary_str = new string(num.ToString().Reverse().ToArray());
    //int summand = 1;
    int sum = 0;

    for (int i = 0; i < binary_str.Length; i++)
    {
        sum += (int)Math.Pow(system, i) * (int)char.GetNumericValue(binary_str[i]);
    }

    return sum.ToString();
}

string BinToDecimal(int num)
{
    return ToDecimal(num, 2);
}

//Console.WriteLine("wpisz liczbe");
//int.TryParse(Console.ReadLine(), out int input);

//Console.WriteLine("result = " + ToDecimal(input, 2));

Console.WriteLine("Wybierz działanie: \n1.Binarka do dziesiętnego\n2.Dziesiętny do szesnastkowego\n3.Dziesiętny do ósemkowego");
int.TryParse(Console.ReadLine(), out int choice);
Console.WriteLine("Wpisz liczbe:");
if (int.TryParse(Console.ReadLine(), out int num))
{
    switch (choice)
    {
        case 1:
            Console.WriteLine(BinToDecimal(num));
            break;
        case 2:
            Console.WriteLine(DecimalToHex(num));
            break;
        case 3:
            Console.WriteLine(DecimalToOctal(num));
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
