using System;

public static class StringExtensions
{
    public static string Shuffle(this string str)
    {
        var characters = str.ToCharArray();
        var random = new Random();
        var numberOfCharacters = characters.Length;
        while(numberOfCharacters > 1)
        {
            var index = random.Next(--numberOfCharacters + 1);
            var temp = characters[index];
            characters[index] = characters[numberOfCharacters];
            characters[numberOfCharacters] = temp;
        }

        if((characters.Length > 1) &&
           (characters[0] == str[0]) &&
           (characters[characters.Length - 1] == str[str.Length - 1]))
        {
            characters[characters.Length - 1] = str[0];
            characters[0] = str[str.Length - 1];
        }

        return new string(characters);
    }
}
