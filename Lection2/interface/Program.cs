
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

// Interface
interface Object2D
{
    // in jedem Interface dürfen nur abstrakte Bestandteile haben
    // Eine Klasse kann mehrere Interfaces implementieren, aber nur von einer anderen Klasse erben
    // Auch structs können Interfaces implementieren

    double CalcArea();
}

// hier braucht man bei der Methode CalcArea() kein override 
// Bestandteile (Methoden) eines Interfaces sind automatisch virtual

class Circle : Object2D
{
    public double Radius;

    public double CalcArea()
    {
        return Radius * Radius * 3.141592;
    }
}

class react : Object2D
{
    public double Width;
    public double Height;

    public double CalcArea()
    {
        return Width * Height;
    }
}