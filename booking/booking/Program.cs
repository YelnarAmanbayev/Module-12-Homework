using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventBookingSystem
{
    public class EventBooking
    {
        public string VenueName { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Система бронирования мероприятий ===");

            string requestedVenue = "Grand Hall";
            DateTime requestedDate = new DateTime(2026, 04 , 25);

            if (!CheckAvailability(requestedVenue, requestedDate))
            {
                Console.WriteLine("[Система]: Площадка занята. Пожалуйста, выберите другую дату.");
                return;
            }

            Console.WriteLine($"[Система]: Площадка {requestedVenue} доступна. Стоимость: 15000 тг.");

            Console.WriteLine("[Клиент]: Подтверждаю бронирование.");

            bool paymentSuccess = await ProcessPayment(15000.00);

            if (!paymentSuccess)
            {
                Console.WriteLine("[Система]: Платеж отклонен. Попробуйте еще раз.");
                return;
            }

            var booking = new EventBooking { VenueName = requestedVenue, Date = requestedDate, IsPaid = true, Status = "Confirmed" };
            Console.WriteLine("[Система]: Бронирование подтверждено. Уведомления отправлены клиенту и админу.");

            Console.WriteLine("\n[Администратор]: Формирование списка задач для подрядчиков...");

            string[] tasks = { "Декорации", "Кейтеринг", "Световое оборудование" };
            await NotifyAndConfirmContractors(tasks);

            Console.WriteLine("[Система]: Все подрядчики подтвердили готовность. Отчет отправлен администратору.");

            Console.WriteLine("\n--- Мероприятие проведено ---");
            Console.WriteLine("[Система]: Запрос отзыва у клиента...");
            CollectFeedback();
        }

        static bool CheckAvailability(string venue, DateTime date)
        {
            return true;
        }

        static async Task<bool> ProcessPayment(double amount)
        {
            Console.WriteLine($"[Платежный шлюз]: Обработка транзакции на {amount} тг...");
            await Task.Delay(1000);
            return true;
        }

        static async Task NotifyAndConfirmContractors(string[] tasks)
        {
            List<Task> notificationTasks = new List<Task>();

            foreach (var task in tasks)
            {
                notificationTasks.Add(Task.Run(() => {
                    Console.WriteLine($"[Подрядчик]: Задача '{task}' получена и подтверждена.");
                }));
            }

            await Task.WhenAll(notificationTasks);
        }

        static void CollectFeedback()
        {
            Console.WriteLine("[Клиент]: Оценка: 5 звезд. Сервис отличный!");
            Console.WriteLine("[Менеджер]: Получен сводный отчет по отзывам.");
        }
    }
}