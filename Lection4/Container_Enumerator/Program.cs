
using System.Collections;

MyCollection<int> myCollection = new MyCollection<int>();

myCollection[0] = 1;
myCollection[1] = 2;
myCollection[2] = 3;
myCollection[3] = 4;
myCollection[4] = 5;
myCollection[5] = 6;

// hier kann man nur mit Enumerator eine foreach Schleife benutzen 
// Es braucht eine Methode GetEnumerator()
foreach (int ival in myCollection)
{
    Console.WriteLine("Array contains: " + ival);
}

foreach (int ival in myCollection.Flipped())
{
    Console.WriteLine("Array contains: " + ival);
}

foreach (int ival in myCollection.Flipping)
{
    Console.WriteLine("Array contains: " + ival);
}
/* Translate to:
for (IEnumerator<int> enumerator = myCollection.GetEnumerator(); enumerator.MoveNext();)
{
    Console.WriteLine("Array contains: " + enumerator.Current);
}
*/

// Enumorator

class MyCollection<T> : IEnumerable<T>
{
    private T[] _theValues;
    private int _n;

    public MyCollection()
    {
        _theValues = new T[5];
        _n = 0;
    }


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


    // Enumerator Funktionen 
    // Routinen sind Methoden
    // Co-Routinen:
    // => Methoden die sich an einer bestimmten Stelle unterbrechen lassen und dann beim nächsten Aufruf ihre Arbeit dort fortsetzen, wo sie unterbrochen wurden.
    // mit yield bzw. yield return 
    public IEnumerator<T> GetEnumerator()
    {
        for (int inx = 0; inx < _n; inx++)
        {
            // hier kann man nicht return benutzen
            // sie springt sofort aus der Funktion raus und der Typ IEnumorator<T> passt nicht zu _theValues[inx] überein
            // Hier benutzt man yield 
            // Hier wird beim ersten Schleifendurchlauf rausgesprungen, aber wenn die Funktion nochmal benutzt wird fängt er an wo er aufgehört hat 
            yield return _theValues[inx];
        }
    }

    public IEnumerable<T> Flipped()
    {
        for (int inx = _n - 1; inx >= 0; inx--)
        {
            yield return _theValues[inx];
        }
    }

    public IEnumerable<T> Flipping
    {
        get
        {
            for (int inx = _n - 1; inx >= 0; inx--)
            {
                yield return _theValues[inx];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count
    {
        get { return _n; }
    }
}

