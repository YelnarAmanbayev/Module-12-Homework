using System;
using System.Collections.Generic;

namespace HiringProcess
{
    // Класс кандидата
    public class Candidate
    {
        public string Name { get; set; }
        public bool HasGoodExperience { get; set; }
        public bool PassedHRInterview { get; set; }
        public bool PassedTechInterview { get; set; }
        public bool AcceptedOffer { get; set; }

        public Candidate(string name, bool experience)
        {
            Name = name;
            HasGoodExperience = experience;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Запуск системы управления наймом ---");

            // 1. Подготовительный этап
            Console.WriteLine("[Руководитель]: Создание заявки на вакансию 'Fullstack Developer'...");
            bool isRequestValid = true; // Имитация проверки HR-отделом

            if (!isRequestValid)
            {
                Console.WriteLine("[HR]: Заявка отклонена. Требуется доработка.");
                return;
            }
            Console.WriteLine("[HR]: Заявка утверждена. Вакансия опубликована.");

            // 2. Этап отбора
            List<Candidate> applicants = new List<Candidate>
            {
                new Candidate("Алексей", true),
                new Candidate("Иван", false)
            };

            foreach (var candidate in applicants)
            {
                Console.WriteLine($"\n--- Обработка кандидата: {candidate.Name} ---");

                // Проверка анкеты
                if (!candidate.HasGoodExperience)
                {
                    Console.WriteLine("[HR]: Анкета отклонена (недостаточно опыта).");
                    continue;
                }

                // 3. Этап собеседований
                Console.WriteLine("[HR]: Первичное интервью пройдено успешно.");
                candidate.PassedHRInterview = true;

                Console.WriteLine("[Руководитель]: Проведение технического собеседования...");
                candidate.PassedTechInterview = true; // Имитация успеха

                if (candidate.PassedHRInterview && candidate.PassedTechInterview)
                {
                    // 4. Заключительный этап
                    Console.WriteLine("[Система]: Кандидату предложен оффер.");
                    candidate.AcceptedOffer = true;

                    if (candidate.AcceptedOffer)
                    {
                        Console.WriteLine($"[Система]: {candidate.Name} добавлен в базу данных сотрудников.");
                        Console.WriteLine("[IT-отдел]: Получено уведомление. Рабочее место настраивается.");
                    }
                }
                else
                {
                    Console.WriteLine("[HR]: Кандидату отправлен отказ по результатам интервью.");
                }
            }

            Console.WriteLine("\n--- Процесс завершен ---");
        }
    }
}