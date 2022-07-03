
// dies kann man wie ein Collection ansehen indem man Werte in ein Collection speichert und diese spezifisch aufpicken kann
// bei Array muss man angeben wie groß die Collection sein muss 
object[] objArray = new object[5];

objArray[0] = 42;
objArray[1] = 4711;
objArray[2] = 32;
objArray[3] = 96;
objArray[4] = 20;

foreach (int i in objArray)
{
    Console.WriteLine("Array contains: " + i);
}



MyCollection myCollection = new MyCollection();

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



// wir legen uns eine Collection an
// hier kann man Werte mit unterschiedlichen Datentypen speichern 
// ist aber nicht so praktisch ist, da sie unterschiedlich sein können 
// wenn man die Werte des Array aufaddieren will aber es gibt int und String dann ist sowas nicht möglich 
// => Typensicherheit & Laufzeit wird vergeudet wegen boxing und unboxing 
class MyCollection
{
    private object[] _theValues;
    private int _n;

    // bei Konstruktion werden fünf speicherplätze reserviert
    // und eine Variable die sagt wv schon besetzt wurden 
    public MyCollection()
    {
        _theValues = new object[5];
        _n = 0;
    }
    // hinzufügen eines Wertes und _n wird um eins erhöht
    public void Add(object v)
    {
        // falls nötig vergrößer den Array
        if (_n == _theValues.Length)
        {
            // wir vegrößern _theValues und kopieren die alten Werten in den neuen vergrößerten _theValues
            object[] oldarray = _theValues;
            _theValues = new object[2 * oldarray.Length];
            Array.Copy(oldarray, _theValues, _n);
        }


        _theValues[_n] = v;
        _n++;
    }

    // zeigt den Wert
    public object GetAt(int i)
    {
        return _theValues[i];
    }

    // geter braucht keine ()
    public int Count
    {
        get { return _n; }
    }
}
