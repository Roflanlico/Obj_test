public class Subscription
{
    public int Id { get; set; }
    public string ApartmentUrl { get; set; }
    public string Email { get; set; }
    public decimal LastPrice { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}