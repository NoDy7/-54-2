
public class AdvancedPasswordGenerator : PasswordGenerator
{
    public string GeneratePronounceablePassword(int syllableCount = 4)
    {
        var vowels = "aeiou";
        var consonants = "bcdfghjklmnpqrstvwxyz";
        var password = new StringBuilder();
        
        var random = new Random();
        
        for (int i = 0; i < syllableCount; i++)
        {
            password.Append(consonants[random.Next(consonants.Length)]);
            password.Append(vowels[random.Next(vowels.Length)]);

            if (random.Next(3) == 0) 
            {
                password.Append(consonants[random.Next(consonants.Length)]);
            }
        }
        
        password.Append(RandomNumberGenerator.GetInt32(10));
        
        return password.ToString();
    }
    
    public string GeneratePassphrase(int wordCount = 4, string separator = "-")
    {
        string[] words = {
            "apple", "river", "mountain", "sun", "star", "forest", "ocean", 
            "book", "music", "light", "dream", "cloud", "flower", "wind"
        };
        
        var passphrase = new StringBuilder();
        for (int i = 0; i < wordCount; i++)
        {
            if (i > 0) passphrase.Append(separator);
            var word = words[RandomNumberGenerator.GetInt32(words.Length)];

            if (RandomNumberGenerator.GetInt32(2) == 0)
            {
                word = char.ToUpper(word[0]) + word.Substring(1);
            }
            
            passphrase.Append(word);
        }

        passphrase.Append(RandomNumberGenerator.GetInt32(10));
        
        return passphrase.ToString();
    }
}