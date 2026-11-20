namespace fool
{
    internal class Programm
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Введите ваше имя:");
            string name = Console.ReadLine();
            string[] questions = { "Сколько будет 2 + 2 * 2?", "Бревно нужно распилить на 10 частей. Сколько надо сделать распилов?", "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", "Укол делают каждые полчаса. Сколько нужно минут для трех уколов?", "5 свечей горело, две потухли. Сколько свечей осталось?" };
            int[] answers = { 6, 9, 25, 60, 2 };
            string repeat = "да";
            while (repeat == "да")
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
                        Console.WriteLine("Правильно!!!");
                        correctAnswersCount++;
                    }
                    else
                    {
                        Console.WriteLine("Неправильно((");
                    }
                }
                int procent = correctAnswersCount * 100 / questions.Length;
                Console.WriteLine(name + " НАБРАЛ:" + correctAnswersCount);
                Console.WriteLine("Процент правильных ответов: " + procent + "%");
                if (procent == 100)
                {
                    Console.WriteLine(name + " ТЫ ГЕНИЙ!!!");
                }
                else if (procent >= 80)
                {
                    Console.WriteLine(name + " ТЫ ТАЛАНТ!!!");
                }
                else if (procent >= 60)
                {
                    Console.WriteLine(name + " ТЫ НОРМАЛЬНЫЙ!!!");
                }
                else if (procent >= 40)
                {
                    Console.WriteLine(name + " ТЫ ДУРАК!!!");
                }
                else if (procent >= 20)
                {
                    Console.WriteLine(name + " ТЫ КРЕТИН!!!");
                }
                else
                {
                    Console.WriteLine(name + " ТЫ ИДИОТ!!!");
                }
                Console.WriteLine(name + " хочешь пройти тест еще раз?)))");
                Console.WriteLine("Введите да или нет");
                repeat = Console.ReadLine();
                while (repeat != "да" && repeat != "нет")
                {
                    Console.WriteLine("Пожалуйста, введите да или нет");
                    repeat = Console.ReadLine();
                }
            }
            Console.WriteLine("Спасибо за прохождение нашего теста!)");
        }
    }
}