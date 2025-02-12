# Objective test task

# Задание 1
Файлы AppartmentPrice.cs и Subscription.cs содержат описание коллекций для цены на квартиры и подписки соотвественно. На их основе будут создаваться таблицы в бд. Файл PriceParser содержит класс для извлечения цены по странице. SrviceBDContext определяет структуру и настраивает таблицы для цен и подписок. SubscriptionSrvice определяет методы для взаимодействия с подписками. SubscriptionController определяет соотвтствубщие http методы. EmailSrvice реализует отправку писем. 

# API 
Подписка на изменения цены

Метод: POST
URL: /api/subscriptions
Описание: Позволяет пользователю подписаться на уведомления о изменениях цены для конкретной квартиры.
Параметры запроса:
{
  "userEmail": "recipient@example.com",
  "apartmentUrl": "https://example.com/apartment/123"
}
Ответ:
200 OK: Подписка успешно добавлена.
400 Bad Request: Ошибка валидации данных.
Отмена подписки

Метод: DELETE
URL: /api/subscriptions/{id}
Описание: Позволяет пользователю отменить подписку по ID.
Параметры:
Path: id (идентификатор подписки)
Ответ:
204 No Content: Подписка успешно отменена.
404 Not Found: Подписка не найдена.
Проверка цен

Метод: GET
URL: /api/prices/check
Описание: Запускает процесс проверки цен на квартиры для всех подписок.
Ответ:
200 OK: Проверка завершена, уведомления отправлены (если есть изменения).
500 Internal Server Error: Ошибка при выполнении проверки.
Получение всех подписок пользователя

Метод: GET
URL: /api/subscriptions
Описание: Возвращает список всех подписок для текущего пользователя.
Ответ:
[
   {
    "id": 1,
    "userEmail": "recipient@example.com",
    "apartmentUrl": "https://example.com/apartment/123"
  },
  ...
]

Параметры запуска сервиса

При запуске сервиса вам может понадобиться несколько параметров конфигурации. Пример конфигурации, которую можно использовать:

{
  "SmtpSettings": {
    "SmtpServer": "smtp.your-email-provider.com",
    "SmtpPort": 587,
    "Username": "your-email@example.com",
    "Password": "your-email-password"
  },
  "DatabaseSettings": {
    "ConnectionString": "Server=yourserver;Database=yourdb;User  Id=youruser;Password=yourpassword;"
  },
  "CheckInterval": 60000, // Интервал проверки цен в миллисекундах (например, 60000 = 1 минута)
  "AllowedHosts": "*"
}

# Задание 2
Класс "сервер" реализован в файле server.cs
