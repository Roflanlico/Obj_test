public class ApartmentPrice
{
    public int Id { get; set; } // Идентификатор
    public string ApartmentUrl { get; set; } // URL квартиры
    public decimal Price { get; set; } // Текущая цена
    public DateTime DateChecked { get; set; } // Дата последней проверки цены
}
