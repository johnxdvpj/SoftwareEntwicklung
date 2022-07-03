using System.Reflection;


string assemblyPath = args[0];
Console.WriteLine("Reflecting " + assemblyPath);

SomeClass someClassOb = new SomeClass();
object o = someClassOb;

Type type = o.GetType();

string category = type.IsClass ? "class" : "type";
Console.WriteLine("Found " + category + ": " + type.Name);
MethodInfo[] methods = type.GetMethods();
foreach (MethodInfo mi in methods)
{
    Console.WriteLine("Method: " + mi.Name + "and is from class: " + mi.DeclaringType.Name);
}


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
