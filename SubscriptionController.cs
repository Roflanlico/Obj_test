using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly SubscriptionService _subscriptionService;

    public SubscriptionController(SubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPost("subscribe")]
    public ActionResult<Subscription> Subscribe([FromBody] Subscription subscription)
    {
        _subscriptionService.AddSubscription(subscription);
        return CreatedAtAction(nameof(GetSubscriptions), new { id = subscription.Id }, subscription);
    }

    [HttpGet("subscriptions")]
    public ActionResult<List<Subscription>> GetSubscriptions()
    {
        var subscriptions = _subscriptionService.GetAllSubscriptions();
        return Ok(subscriptions);
    }
}
