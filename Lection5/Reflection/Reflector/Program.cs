using System.Reflection;


string assemblyPath = args[0];
Console.WriteLine("Reflecting " + assemblyPath);

// Hier kann mein ein Assembly laden und auf einer Variable speichern
Assembly toReflect = Assembly.LoadFile(assemblyPath);

// hier wird das ausgeführte Assembly benutzt
//Assembly toReflect = Assembly.GetExecutingAssembly();
Type[] typelist = toReflect.GetTypes();

foreach (Type type in typelist)
{
    string category = type.IsClass ? "class" : "type";
    Console.WriteLine("Found " + category + ": " + type.Name);
    MethodInfo[] methods = type.GetMethods();
    foreach (MethodInfo mi in methods)
    {
        Console.WriteLine("  Method: " + mi.Name + "and is from class: " + mi.DeclaringType.Name);
        Attribute[] attribs = mi.GetCustomAttributes().ToArray();
        foreach (Attribute at in attribs)
        {
            Console.WriteLine("    is " + at);
        }
    }
}



