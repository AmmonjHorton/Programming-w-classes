using System;
public class Reference
{
     private string _book;
     private int _chapter;
     private int _verseStart;
     private int _verseEnd;

    public Reference(string _book, int _chapter, int _verseStart, int _verseEnd)
    {
        string book = _book;
        int chapter = _chapter;
        int verseStart = _verseStart;
        int verseEnd = _verseEnd;
    }
    public string GetReferenceString()
    {
        if (_verseEnd > 0)
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verseStart}";
        }
    }

}