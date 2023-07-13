using System;
namespace TrickyBookStore.Models;

public class SubscriptionType
{
    private const int All = 0; 
    public int Id { get; set; }
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
               Price == type.Price &&
               OldBooksDiscount == type.OldBooksDiscount &&
               NewBooksDiscount == type.NewBooksDiscount &&
               NewBooksApplied == type.NewBooksApplied;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}