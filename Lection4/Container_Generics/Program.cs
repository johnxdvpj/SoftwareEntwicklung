
// bei Generics muss ers bei der Verwendung der Datentyp festgelegt werden
MyCollection<int> myCollection = new MyCollection<int>();

/*
myCollection.Add(42);
myCollection.Add(4711);
myCollection.Add(32);
myCollection.Add(96);
myCollection.Add(20);
myCollection.Add(40);


for (int i = 0; i < myCollection.Count; i++)
{
    Console.WriteLine("Array contains: " + myCollection.GetAt(i));
}
*/

// manchmal ist es aber bequemer es wie bei Arrays zu schreiben dafür braucht man ein Indexer
myCollection[0] = 1;
myCollection[1] = 2;
myCollection[2] = 3;
myCollection[3] = 4;
myCollection[4] = 5;
myCollection[5] = 6;

int sum = 0;
for (int i = 0; i < myCollection.Count; i++)
{
    sum += myCollection[i];
    Console.WriteLine("Array contain: " + myCollection[i]);
}


// Generics 
// Klasse wird generisch deklariert 
// object wird druch generische Parameter <T> ersetzt
class MyCollection<T>
{
    private T[] _theValues;
    private int _n;

    public MyCollection()
    {
        _theValues = new T[5];
        _n = 0;
    }



    // Indexer 
    // man kann entscheiden was als Indexer akzeptiert wird bsp.: [int i]
    public T this[int i]
    {
        get { return GetAt(i); }
        set { AddAt(i, value); }
    }

    public void AddAt(int i, T v)
    {
        if (i > _theValues.Length - 1)
        {
            T[] oldarray = _theValues;
            _theValues = new T[i + 1];
            Array.Copy(oldarray, _theValues, oldarray.Length);
        }
        _theValues[i] = v;
        _n++;
    }

    public void Add(T v)
    {
        if (_n == _theValues.Length)
        {
            T[] oldarray = _theValues;
            _theValues = new T[2 * oldarray.Length];
            Array.Copy(oldarray, _theValues, _n);
        }


        _theValues[_n] = v;
        _n++;
    }

    public T GetAt(int i)
    {
        return _theValues[i];
    }

    public int Count
    {
        get { return _n; }
    }
}
