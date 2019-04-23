using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        var casino = new Casino();
        var deck = casino.CreateDeck();
        deck = casino.ShuffleDeck(deck);
        casino.DisplayDeck(deck);

    }
}


public class Card
{
    public string value { get; set; }
}

public class Casino
{
    public List<Card> CreateDeck()
    {
        List<Card> deck = new List<Card>();
        List<string> royalCardFaces = new List<string> { "Jack", "Queen", "King" };
        List<string> suits = new List<string> { "Club", "Heart", "Spade", "Diamond" };


        foreach (string suit in suits)
        {
            for (int i = 1; i < 11; i++)
            {
                deck.Add(new Card() { value = suit + " - " + i });
            }

            foreach (string face in royalCardFaces)
            {
                deck.Add(new Card() { value = suit + " - " + face });
            }
        }

        return deck;

    }

    public List<Card> ShuffleDeck(List<Card> deck)
    {
        return deck.OrderBy(a => Guid.NewGuid()).ToList();
    }

    public void DisplayDeck(List<Card> deck)
    {
        foreach (Card card in deck)
        {
            Console.WriteLine(">> " + card.value);
        }
    }

}


