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

        string[] splitText = text.Split(' ');
        foreach (string wordText in splitText)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        
        // This smart selection picks only from words that are not already hidden
        List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

        int wordsToSelect = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < wordsToSelect; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string textResult = "";
        foreach (Word word in _words)
        {
            textResult += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {textResult.Trim()}";
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