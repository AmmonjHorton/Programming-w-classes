using System;
using System.Runtime.CompilerServices;
//Take scripture as variable or input and convert it into a list of words using a for loop


// create 2 variables that hold scriptures as strings to be converted into lists of words
public class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string word)
    {
        _word = word;

    }
    public string GetWord()
    {
        if (_isHidden)
        {
            return new string('_', _word.Length);
        }
        else
        {
            return _word;
        }
    }
    public void HideWord()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
}