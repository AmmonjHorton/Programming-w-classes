using System;
using System.Security.Cryptography.X509Certificates;
// random number generator for blanking out words

//blanking function that increments to reach the value of the random number
// if already blank += 1


// _words list of words
// GetReference _reference string of scripture reference (e.g. {John} {3}:{16-17})

// For loop to display each word in _words
public class Scripture
{
    private readonly Reference _reference;
    private List<Word> _words = new List<Word>();

    private int _scriptureId = new Random().Next(3);


    private List<Word> _convertScriptureToWords(string scripture)
    {
        List<Word> wordsList = new List<Word>();
        string[] wordsArray = scripture.Split(' ');
        foreach (string wordText in wordsArray)
        {
            Word word = new Word(wordText);
            wordsList.Add(word);
        }
        return wordsList;
    }
public void HideRandomWord()
{
    if (_words.Count == 0)
    {
        Console.WriteLine("No words available to hide.");
        return;
    }

    Random random = new Random();
    int totalWords = _words.Count;

    // Pick a random starting point
    int randomIndex = random.Next(0, totalWords);

    // Try to find a word that isn't hidden yet
    int attempts = 0;
    while (_words[randomIndex].IsHidden() && attempts < totalWords)
    {
        randomIndex = (randomIndex + 1) % totalWords; // loop back to start if needed
        attempts++;
    }

    if (attempts >= totalWords)
    {
        Console.WriteLine("All words are already hidden!");
    }
    else
    {
        _words[randomIndex].HideWord();
    }
}

    public Scripture()
    {
        if (_scriptureId == 1)
        {
            _reference = new Reference("John", 3, 16, 17);
            _words = _convertScriptureToWords("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        }
        else if (_scriptureId == 2)
        {
            _reference = new Reference("Proverbs", 3, 5, 6);
            _words = _convertScriptureToWords("Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        }
        else
        {
            _reference = new Reference("Philippians", 4, 13, 13);
            _words = _convertScriptureToWords("I can do all this through him who gives me strength.");
        }


    }
    private int getRandomWordIndex()
    {
        int totalWords = _words.Count;
        Random randomWord = new Random();
        int randomIndex = randomWord.Next(0, totalWords);
        return randomIndex;
    }
    public void DisplayScripture()
    {

        Console.WriteLine(_reference.GetReferenceString());

        Console.WriteLine();
         foreach (Word word in _words)
        {
            Console.Write(word.GetWord() + " ");
        }
        Console.WriteLine("\n");
    }


}
