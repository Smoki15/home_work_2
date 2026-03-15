
class Container<T>
{
    private T[] items;
    private int count;

    public int Length
    {
        get { return count; }
    }

    public Container(int size)
    {
        items = new T[size];
        count = 0;
    }

    public void Add(T value)
    {
        if (count < items.Length)
        {
            items[count] = value;
            count++;
        }
        else
        {
            Console.WriteLine("Container full");
        }
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < count)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            count--;
        }
    }
    public T Get(int index)
    {
        if (index >= 0 && index < count)
        {
            return items[index];
        }
        else
        {
            Console.WriteLine("Invalid Index");
            return default(T);
        }
    }

    public void Render()
    {
        Console.WriteLine("Container elements: ");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(items[i]);
        }
    }
}


class Program
{
    static void Main()
    {
        Container<int> numbers = new Container<int>(10);

        numbers.Add(5);
        numbers.Add(10);
        numbers.Add(15);

        numbers.Render();

        Console.WriteLine("Elements index 1: " + numbers.Get(1));

        numbers.Remove(1);

        numbers.Render();

        Console.WriteLine("Length: " + numbers.Length);
    }
}