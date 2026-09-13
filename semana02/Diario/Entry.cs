using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Data: {_date} - Pergunta: {_promptText}");
        Console.WriteLine($"Resposta: {_entryText}\n");
    }

    public string GetAsFormattedString()
    {
        return $"{_date}|~|{_promptText}|~|{_entryText}";
    }
}