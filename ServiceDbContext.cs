using Microsoft.EntityFrameworkCore;

public class ServiceDbContext : DbContext
{
    public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
        : base(options)
    {
    }

    // Таблица для хранения цен на квартиры
    public DbSet<ApartmentPrice> ApartmentPrices { get; set; }

    // Таблица для хранения подписок
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация для таблицы ApartmentPrice
        modelBuilder.Entity<ApartmentPrice>()
            .ToTable("ApartmentPrices")
            .HasKey(ap => ap.Id); // Указание первичного ключа

        modelBuilder.Entity<ApartmentPrice>()
            .Property(ap => ap.ApartmentUrl)
            .IsRequired(); // Указание, что URL квартиры обязателен

        modelBuilder.Entity<ApartmentPrice>()
            .Property(ap => ap.Price)
            .IsRequired(); // Указание, что цена обязательна

        modelBuilder.Entity<ApartmentPrice>()
            .Property(ap => ap.DateChecked)
            .IsRequired(); // Указание, что дата проверки обязательна

        // Конфигурация для таблицы Subscription
        modelBuilder.Entity<Subscription>()
            .ToTable("Subscriptions")
            .HasKey(s => s.Id); // Указание первичного ключа

        modelBuilder.Entity<Subscription>()
            .Property(s => s.UserEmail)
            .IsRequired(); // Указание, что email пользователя обязателен

        modelBuilder.Entity<Subscription>()
            .Property(s => s.ApartmentUrl)
            .IsRequired(); // Указание, что URL квартиры обязателен

        // Вы можете добавить дополнительные настройки для других свойств
    }
}
