
object[] obj2darray = new object[]{
    new react {Height = 2, Width = 6},
    new Circle {Radius = 5},
    new react { Height = 3, Width = 5 },
    new Circle {Radius = 8},
    new react { Height = 4, Width = 4 },
    new Circle {Radius = 9},
};

foreach (object ob2d in obj2darray)
{
    double area = ob2d switch
    {
        Circle circle => circle.Radius * circle.Radius * 3.141592,
        react React => React.Width * React.Height
    };

    Console.WriteLine("Area of Object: " + area);
}


class Circle
{
    public double Radius;

    public double CalcArea()
    {
        return Radius * Radius * 3.141592;
    }
}

class react
{
    public double Width;
    public double Height;

    public double CalcArea()
    {
        return Width * Height;
    }
}