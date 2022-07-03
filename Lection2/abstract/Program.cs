
Object2D[] obj2darray = new Object2D[]{
    new react {Height = 2, Width = 6},
    new Circle {Radius = 5},
    new react { Height = 3, Width = 5 },
    new Circle {Radius = 8},
    new react { Height = 4, Width = 4 },
    new Circle {Radius = 9},
};

foreach (Object2D ob2d in obj2darray)
{
    double area = ob2d.CalcArea();
    Console.WriteLine("Area of Object: " + area);
}

// implentierloser Elterntyp
abstract class Object2D
{
    // Rumpflose Methodedeklaration indem man mit abstract dekodiert
    // Die Deklaration einer Abstrakten Methode garantiert dem Anwender der Klasse, 
    // dass er eine Instanz eines Typs hat, der diese Methode implementiert - daher kann sie aufgerufen werden.
    public abstract double CalcArea();
}

class Circle : Object2D
{
    public double Radius;

    public override double CalcArea()
    {
        return Radius * Radius * 3.141592;
    }
}

class react : Object2D
{
    public double Width;
    public double Height;

    public override double CalcArea()
    {
        return Width * Height;
    }
}