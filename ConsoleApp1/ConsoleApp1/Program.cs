//21, 48, 54
//1 Создать одномерный массив заданного размера, состоящий из случайных целых чисел в заданном диапазоне.
//int size = int.Parse(Console.ReadLine());
//int min = int.Parse(Console.ReadLine());
//int max = int.Parse(Console.ReadLine());
//int[] array = new int[size];
//Random rand = new Random();
//for (int i = 0; i < size; i++)
//{
//    array[i] = rand.Next(min, max + 1);
//}
//Console.WriteLine(string.Join(" ", array));

//2 Создать двумерный массив (матрицу) заданного размера (NxM),
//состоящий из случайных целых чисел в заданном диапазоне

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
int min = int.Parse(Console.ReadLine());
int max = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, m];
Random rand = new Random();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = rand.Next(min, max + 1);
    }
}
for (int i = 0; i<= n; i++)
{
    for (int j = 0;j < m; j++)
    {
        Console.WriteLine(matrix[i, j]);
    }
    Console.WriteLine();
}
