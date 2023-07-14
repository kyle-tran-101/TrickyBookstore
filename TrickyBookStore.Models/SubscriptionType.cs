using System;
namespace TrickyBookStore.Models;

public class SubscriptionType
{
    private const double small = 0.001;
    public const int All = 0; 
    public int Id { get; init; }
    public string Name { get; set; }
    public double Price { get; set; } = 0;
    public double OldBooksDiscount { get; set; } = 0;
    public double NewBooksDiscount { get; set;} = 0;
    public int NewBooksApplied { get; set;} = All;

    public override bool Equals(object obj)
    {
        return obj is SubscriptionType type &&
               Id == type.Id &&
               Name == type.Name &&
               Math.Abs(Price - type.Price) < small &&
               Math.Abs(OldBooksDiscount - type.OldBooksDiscount) < small &&
               Math.Abs(NewBooksDiscount - type.NewBooksDiscount) < small &&
               NewBooksApplied == type.NewBooksApplied;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}