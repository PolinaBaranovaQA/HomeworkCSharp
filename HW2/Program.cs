using System;

public class MainClass
{
    public static void Main()
    {
        try
        {
            var array = ReadArray();
            var secondMaxElement = FindSecondMaxElement(array);

            //Выводим значение secondMaxElement
            Console.WriteLine(secondMaxElement);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static int[] ReadArray()
    {
        //Создание массива
        int n = ReadInt();
        int[] array = new int[n];

        //Заполнение массива с консоли
        for (int i = 0; i < n; i++)
        {
            array[i] = ReadInt();
        }

        return array;
    }

    public static int FindSecondMaxElement(int[] array)
    {
        if (array.Length < 2)
        {
            throw new Exception("Длинна массива должна быть больше 1");
        }

        //Создание переменных, куда вкладываются значения
        int maxElement = int.MinValue;
        int secondMaxElement = int.MinValue;

        //Пробегаемся по массиву и сравниваем элементы
        foreach (var element in array)
        {
            if (element > maxElement)
            {
                secondMaxElement = maxElement;
                maxElement = element;
            }
            else if (element > secondMaxElement && element != maxElement)
            {
                secondMaxElement = element;
            }
        }

        if (secondMaxElement == int.MinValue)
        {
            throw new Exception("Не найдено второго максимума");
        }

        return secondMaxElement;
    }

    public static int ReadInt()
    {
        var text = Console.ReadLine();
        if (text == null)
        {
            throw new Exception("Не удалось считать значение");
        }

        try
        {
            return Int32.Parse(text);
        }
        catch (Exception ex)
        {
            throw new Exception("Неверный формат числа", ex);
        }

    }
}
