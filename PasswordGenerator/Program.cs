var passwordGenerator = new PasswordGenerator(new RandomWrapper());

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(passwordGenerator.Generate(5, 10, false));
}
Console.ReadKey();


public class PasswordGenerator
{
    private readonly IRandom _random;

    public PasswordGenerator(IRandom random)
    {
        _random = random;
    }

    public string Generate(
        int minLength, int maxLength, bool ShallUseSpecialCharacters)
    {
        Validate(minLength, maxLength);

        var passwordLength = GeneratePasswordLength(minLength, maxLength);

        //generate random string
        var charactersToBeIncluded = ShallUseSpecialCharacters ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return GenerateRandomSring(passwordLength, charactersToBeIncluded);
    }

    private void Validate(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {nameof(maxLength)}");
        }
    }

    private int GeneratePasswordLength(int minLength, int maxLength)
    {
        return _random.Next(minLength, maxLength + 1);
    }

    private string GenerateRandomSring(
        int length,
        string charactersToBeIncluded)
    {
        var stringCharacters =
            Enumerable.Repeat(charactersToBeIncluded, length)
            .Select(characters => characters[_random.Next(characters.Length)])
            .ToArray();
        return new string(stringCharacters);
    }
}

public interface IRandom
{
    int Next(int minValue, int maxValue);
    int Next(int maxValue);
}

public class RandomWrapper : IRandom
{
    private readonly Random _random = new Random();

    public int Next(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }

    public int Next(int maxValue)
    {
        return _random.Next(maxValue);
    }
}