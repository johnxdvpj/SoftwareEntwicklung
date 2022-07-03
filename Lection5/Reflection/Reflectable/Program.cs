// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Attribute einschränken
//[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Parameter)]

// Attribut wurde hier deklariert
class SpecialAttribute : Attribute
{

}

// Reflection
// Informationen über einer Assembly enthaltenen Datentypen oder über den Datentyp enthaltenen Bestandteile
// diese Informationen kann man per Laufzeit abfragen und auswerten 


// Attribut
[Special]
// Wir haben ein Struct mit Variablen und Methoden
struct MyStruct
{
    [Special]
    public int MyIntField;
    private float NoOnecanSeeThis;

    [Special]
    public void DoSomething([Special] int i)
    {
        Console.WriteLine("Called DoSomething with " + i + "as a parameter");
    }
}

[Special]
// Wir haben eine Klasse mit Variablen und Methoden
public class SomeClass
{
    private int _intProp;
    public int IntProperty
    {
        get { return _intProp; }
        set { _intProp = value; }
    }

    public int CalcPorpTimesTwo()
    {
        return _intProp * 2;
    }
}