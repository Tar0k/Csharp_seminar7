using static Csharp_seminar7.Functions;

var tasks = new Dictionary<int, Action>
{
    { 47, Task47 },
    { 50, Task50 },
    { 52, Task52 },
};
var numbersOfTasks = tasks.Keys.ToArray();
tasks[GetTaskFromUser(numbersOfTasks)].Invoke();

void Task47()
{
    // Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами. m = 3, n = 4.
    // 0,5 7 -2 -0,2
    // 1 -3,3 8 -9,9
    // 8 7,8 -7,1 9
    Console.WriteLine("Задача 47");
    var array = Generate2DDoubleArray(
        rows: GetUserInt("количество строк"),
        columns: GetUserInt("количество столбцов"),
        decimalPlaces: 1,
        minElement: 1,
        maxElement: 10);
    Print2DArray(array);
}

void Task50()
{
    // Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // 17 -> такого числа в массиве нет
    Console.WriteLine("Задача 50");
    var array = Generate2DIntArray(rows: 4, columns: 4, minElement: 1, maxElement: 10);
    Print2DArray(array);
    // Выбирал, считая от столбцы и ряды начиная с 1-го
    var elementRow = GetUserInt("номер ряда элемента") - 1;
    var elementColumn = GetUserInt("номер столбца элемента") - 1;
    if (elementRow >= array.GetLength(0) || elementRow < 0 || 
        elementColumn >= array.GetLength(1) || elementColumn < 0)
    {
        Console.WriteLine("Такого числа в массиве нет");
    }
    else
    {
        Console.WriteLine($"Найден элемент в позиции [{elementRow + 1}, {elementColumn + 1}]: {array[elementRow, elementColumn]}");
    }
}

void Task52()
{
    // Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
    Console.WriteLine("Задача 52");
    var array = Generate2DIntArray(rows: 4, columns: 4, minElement: 1, maxElement: 10);
    Print2DArray(array);
    var columnsSum = new int[array.GetLength(1)];
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
        {
            columnsSum[j] += array[i, j];
        }
    }
    var columnsMean = columnsSum.Select(sum => Math.Round((double)sum / array.GetLength(1), 3));
    Console.WriteLine($"Среднее арифметическое каждого столбца: {string.Join("; ", columnsMean)}");
}

int GetTaskFromUser(int[] availableTasks)
{
    var taskNumber = GetUserInt("номер задания");
    while (!availableTasks.Contains(taskNumber))
    {
        Console.WriteLine("!!!Данной задачи не заложено!!!");
        taskNumber = GetUserInt();
    }
    return taskNumber;
}

