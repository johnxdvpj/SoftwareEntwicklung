// Value-Variablen enthalten direkt den Wert, & Reference-Variablen eine Referenz auf die Speicherstelle enthalten,
// der Wert gespeichert wird 

// Zuweisung (a=b):
// Value: Wert wird kopiert 
// Reference: Referenz wird kopiert, Objekt existiert immer noch einmal 

int i = 3;
int j = i;
i = 4;

Console.WriteLine("i: " + i + " j: " + j);

// Objekterzeugung (a = new T())
// Value: a ist untrennbar mit Objekt verbunden
// Reference: ein neues Objekt wird irgendwo im Speicher erzeugt und a erhält eine Referenz auf dieses Objekt

Pair p = new Pair { one = 47, two = 11 };
Cat c = new Cat { name = "Whiskers", age = 5 };
Pair q = p;
Cat d = c;

Console.WriteLine("p: " + p.one + " & " + p.two + " q: " + q.one + " & " + q.two);
Console.WriteLine("c: " + c.name + " & " + c.age + " d: " + d.name + " & " + d.age);

// Objektzugriff (a.xyz)
// Value: Änderungen von Eigenschaften/Seiteneffekte wirken sich nur auf a aus
// Reference: Änderungen von Eigenschaften/Seiteneffekte wirken sich das durch a referenzierte Objekt aus und auf alle anderen Variablen, die das selbe Objekt referenzieren

p.one = 48;
c.age = 6;

Console.WriteLine("p: " + p.one + " & " + p.two + " q: " + q.one + " & " + q.two);
Console.WriteLine("c: " + c.name + " & " + c.age + " d: " + d.name + " & " + d.age);

Pair[] parray = new Pair[]{
    new Pair {one = 2, two = 22},
    new Pair {one = 4, two = 33},
    new Pair {one = 6, two = 44},
};

for (int e = 0; e < parray.Length; e++)
{
    Console.WriteLine(e + ". Array one: " + parray[e].one + " & two: " + parray[e].two);
}

Cat[] carray = new Cat[]{
    new Cat {name = "Garfield", age = 2},
    new Cat {name = "Mausetod", age = 5},
    new Cat {name = "Fritz", age = 7},
};

for (int e = 0; e < carray.Length; e++)
{
    Console.WriteLine(e + ". Array name: " + carray[e].name + " & age: " + carray[e].age);
}

Cat bsp = carray[0];
bsp.age = 10;

Console.WriteLine("bsp name: " + carray[0].name + " & age: " + carray[0].age);


struct Pair
{
    public int one;
    public int two;
}

class Cat
{
    public string name;
    public int age;
}

