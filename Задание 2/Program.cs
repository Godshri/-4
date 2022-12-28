using Задание_2;

int[] coll = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
DynamicArray<int> arr1 = (DynamicArray<int>)coll;

PrintArray(arr1);

DynamicArray<int> arr2 = new DynamicArray<int>(new int[] { 1, 3, 5, 7, 9 });
PrintArray(arr2);

arr1.ResizeCapacity += func;

arr1.Add(1);
arr1.Add(12);
arr1.Add(132);

arr1.Insert(18, 10);
arr1.Insert(109, 10);
arr1.Add(91);
arr1.Insert(18, 11);
arr1.Add(90);
arr1.Insert(18, 14);


arr1.AddRange(new int[] { 1, 3, 4, 1, 2, 1, 1 });
PrintArray(arr1);

arr1.Remove(1, delegateFunc);
PrintArray(arr1);

DynamicArray<int> arr3 = new DynamicArray<int>(new int[] { 1, 2, 3 });
DynamicArray<int> arr4 = new DynamicArray<int>(new int[] { 1, 2, 3 });

if (arr4.Equals(arr4))
{
    Console.WriteLine("Массивы одинаковые");
}

if (!arr1.Equals(arr3))
{
    Console.WriteLine("Массивы разные");
}


bool delegateFunc(int first, int second)
{
    return first == second;
}

void PrintArray(DynamicArray<int> arr)
{
    foreach (int item in arr)
    {
        Console.Write($"{item} ");
    }
    Console.WriteLine($"\nLength: {arr.Length}\n");
}

void func(Object obj, DynamicArrayEventArgs e)
{
    Console.WriteLine($"Old capacity: {e.OldCapacity}");
    Console.WriteLine($"New capacity: {e.NewCapacity}\n\n");
}

//arr1.Dispose();
Console.ReadKey();