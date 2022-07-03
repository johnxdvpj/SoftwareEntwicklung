
A anA = new A();
B someB = new B();

anA.SayHello();
someB.SayHello();

// wir haben eine Variable von Typ A die auf ein Objekt von Typ A referenziert
// Hier ist es möglich auch ein B zuzuweisen da B von A erbt
A referenceofA;
referenceofA = someB;

// dennoch wird es als ein Typ A dargestellt da diese als A deklariert wurde 
referenceofA.SayHello();

// in Class A wurde keine virtual Methode eingesetzt
// -> es wurde zu der Compile Zeit festgelegt welche SayHello() Methode genommen wird 
// -> Es hängt davon ab welchen Typ die Variable hat 


C aC = new C();
D someD = new D();

// in Class C gibt es eine virtual Methode 
// -> es wurde während der Laufzeit festgelegt welche SayHello() Methode genommen wird 
// -> Es hängt vom Typ des Objektes ab

C referenceofC;
referenceofC = someD;

referenceofC.SayHello();

referenceofC = aC;
referenceofC.SayHello();

class A
{
    public void SayHello()
    {
        Console.WriteLine("Hello, I'm of type A");
    }
}

// B erbt von A
class B : A
{
    // Hier wird die Methode von A überschrieben
    public void SayHello()
    {
        Console.WriteLine("Hi, it's me, a B");
    }
}

class C
{
    public virtual void SayHello()
    {
        Console.WriteLine("Hello, I'm of type C");
    }
}

// B erbt von A
class D : C
{
    // Hier wird die Methode von C mit override überschrieben, dies implemtiert Polymorphie
    public override void SayHello()
    {
        Console.WriteLine("Hi, it's me, a D");
    }
}