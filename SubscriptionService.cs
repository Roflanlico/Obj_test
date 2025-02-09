using System.Collections.Generic;
using System.Linq;

public class SubscriptionService
{
    private readonly ServiceDbContext _context;

    public SubscriptionService(ServiceDbContext context)
    {
        _context = context;
    }

    public void AddSubscription(Subscription subscription)
    {
        _context.Subscriptions.Add(subscription);
        _context.SaveChanges();
    }

    public List<Subscription> GetAllSubscriptions()
    {
        return _context.Subscriptions.ToList();
    }
}
