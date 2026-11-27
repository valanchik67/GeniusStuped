using System.Xml.Linq;
using System.IO;

namespace ConsoleApp2GS1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше фио:");
            Console.WriteLine();
            string name = Console.ReadLine();
            Console.WriteLine();
            string[] questions = { "Сколько будет 2 + 2 * 2?", "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, две потухли. Сколько свечей осталось?" };
            int[] answers = { 6, 9, 25, 60, 2 };
            string repeat = "да";
            while (repeat == "да")
            {
                int correctAnswersCount = PlayQuiz(questions, answers);
                Console.WriteLine();
                int procent = correctAnswersCount * 100 / questions.Length;
                string diagnosis = UserDiagnosis(procent);
                Console.WriteLine(name + " набрал: " + correctAnswersCount + " правильных ответов");
                Console.WriteLine("Процент правильных ответов: " + procent + "%");
                Console.WriteLine(name + ", ваш диагноз: " + diagnosis);
                Console.WriteLine();
                File.AppendAllText("results.txt", name + ";" + correctAnswersCount + ";" + diagnosis + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine("Результат сохранен");
                Console.WriteLine();
                ShowResults();
                repeat = UserAnswer();
            }
            Console.WriteLine("Спасибо за прохождение нашего теста!)");

        }
        static int PlayQuiz(string[] questions, int[] answers)
        {
            int correctAnswersCount = 0;
            int[] num = new int[questions.Length];
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = i;
            }
            Random random = new Random();
            for (int i = 0; i < num.Length; i++)
            {
                int k = random.Next(i, num.Length);
                int mixing = num[i];
                num[i] = num[k];
                num[k] = mixing;
            }
            for (int i = 0; i < questions.Length; i++)
            {
                int index = num[i];
                Console.WriteLine(questions[index]);
                int userAnswer;
                while (!int.TryParse(Console.ReadLine(), out userAnswer))
                {
                    Console.WriteLine("Пожалуйста, введите число");
                }
                if (userAnswer == answers[index])
                {
                    Console.WriteLine();
                    Console.WriteLine("Правильно!!!");
                    Console.WriteLine();
                    correctAnswersCount++;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Неправильно((");
                    Console.WriteLine();
                }
            }
            return correctAnswersCount;
        }
        static string UserDiagnosis(int procent)
        {
            if (procent == 100)
            {
                return "ГЕНИЙ";
            }
            else if (procent >= 80)
            {
                return "ТАЛАНТ";
            }
            else if (procent >= 60)
            {
                return "НОРМАЛЬНЫЙ";
            }
            else if (procent >= 40)
            {
                return "ДУРАК";
            }
            else if (procent >= 20)
            {
                return "КРЕТИН";
            }
            else
            {
                return "ИДИОТ";
            }
        }
        static void ShowResults()
        {
            Console.WriteLine();
            Console.WriteLine("Все результаты");
            Console.WriteLine("ФИО".PadRight(20) + "Правильных ответов".PadRight(25) + "Диагноз");
            Console.WriteLine("-----------------------------------------------------");
            string[] res = File.ReadAllLines("results.txt");
            foreach (string result in res)
            {
                string[] parts = result.Split(';');
                Console.WriteLine(parts[0].PadRight(20) + parts[1].PadRight(25) + parts[2]);
            }
        }
        static string UserAnswer()
        {
            Console.WriteLine();
            Console.WriteLine("Хочешь пройти тест еще раз?)))");
            Console.WriteLine();
            Console.WriteLine("Введите да или нет");
            Console.WriteLine();
            string repeat = Console.ReadLine();
            while (repeat != "да" && repeat != "нет")
            {
                Console.WriteLine("Пожалуйста, введите да или нет");
                repeat = Console.ReadLine();
            }
            return repeat;
        }
    }
}

