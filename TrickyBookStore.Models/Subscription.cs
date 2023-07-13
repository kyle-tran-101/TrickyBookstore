using System.Collections.Generic;

namespace TrickyBookStore.Models;

public class Subscription
{
    public int Id { get; set; }
    public SubscriptionType SubscriptionType { get; set; }
    public int? BookCategoryId { get; set; }
    public Dictionary<string, double> PriceDetails { get; set; }
}