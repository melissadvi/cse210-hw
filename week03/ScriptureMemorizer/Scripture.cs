using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] pieces = text.Split(' ');

        foreach (string piece in pieces)
        {
             _words.Add(new Word (piece));
        }
    }
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            displayText = displayText + word.GetDisplayText() + " ";
        }

        return displayText;
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    } 
}