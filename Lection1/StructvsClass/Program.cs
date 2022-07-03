using System.Diagnostics;

Stopwatch sw = new Stopwatch();


Vertex a = new Vertex
{
    Position = new float3 { x = 4, y = 5, z = 6 },
    Normal = new float3 { x = 1, y = 2, z = 3 },
    UVW = new float3 { x = 7, y = 8, z = 9 },
};

Vertex b = new Vertex
{
    Position = new float3 { x = 4, y = 5, z = 6 },
    Normal = new float3 { x = 1, y = 2, z = 3 },
    UVW = new float3 { x = 7, y = 8, z = 9 },
};


// Equals
Console.WriteLine("Is a == b: " + a.Equals(b));

// Struct & Class mixed

Vertexmixed c = new Vertexmixed
{
    Position = new cfloat3 { x = 4, y = 5, z = 6 },
    Normal = new cfloat3 { x = 1, y = 2, z = 3 },
    UVW = new cfloat3 { x = 7, y = 8, z = 9 },
};

Vertexmixed d = new Vertexmixed
{
    Position = new cfloat3 { x = 4, y = 5, z = 6 },
    Normal = new cfloat3 { x = 1, y = 2, z = 3 },
    UVW = new cfloat3 { x = 7, y = 8, z = 9 },
};

Console.WriteLine("Is c == d: " + c.Equals(d));


// Struct
Vertex[] vertexarray = new Vertex[1_000_000];

sw.Start();

for (int i = 0; i < vertexarray.Length; i++)
{
    vertexarray[i] = new Vertex
    {
        Position = new float3
        {
            x = i * 3,
            y = i * 3 + 1,
            z = i * 3 + 2
        },
        Normal = new float3
        {
            x = i * 3 + 2,
            y = i * 3 + 1,
            z = i * 3
        },
        UVW = new float3
        {
            x = i * 3.1415f,
            y = i * 3.1415f + 1,
            z = i * 3.1415f + 2
        },
    };
}

sw.Stop();

Console.WriteLine("Time to write 1M struct-based vertices: " + sw.ElapsedMilliseconds + "ms");

// Class
cVertex[] vertexarray_c = new cVertex[1_000_000];


sw.Reset();
sw.Start();

for (int i = 0; i < vertexarray_c.Length; i++)
{
    vertexarray_c[i] = new cVertex
    {
        Position = new cfloat3
        {
            x = i * 3,
            y = i * 3 + 1,
            z = i * 3 + 2
        },
        Normal = new cfloat3
        {
            x = i * 3 + 2,
            y = i * 3 + 1,
            z = i * 3
        },
        UVW = new cfloat3
        {
            x = i * 3.1415f,
            y = i * 3.1415f + 1,
            z = i * 3.1415f + 2
        },
    };
}

sw.Stop();

Console.WriteLine("Time to write 1M class-based vertices: " + sw.ElapsedMilliseconds + "ms");

// hier ist struct praktischer da es schneller ist 

// Grund dafür ist dass struct value-typ ist und class reference-typ ist 

// der Zugriff in den werte der Classes braucht man sehr viele Speicheraddressen die vom compiler generiert werden muss

// Objekte, die eher als Datencontainer fungieren, die wenig Speicher verwenden und von denen große Mengen, 
// z.B. in Arrays oder Listen angelegt werden, eher als struct. Bei C# structs ist Vererbung NICHT erlaubt.

// Objekte, mit vielen Methoden und viel Intelligenz, die ggf. viel Speicher verwenden eher als class. Vererbung funktioniert nur mit class 


public struct float3
{
    public float x;
    public float y;
    public float z;
}

public struct Vertex
{
    public float3 Position;
    public float3 Normal;
    public float3 UVW;
}

public class cfloat3
{
    public float x;
    public float y;
    public float z;
}

public class cVertex
{
    public cfloat3 Position;
    public cfloat3 Normal;
    public cfloat3 UVW;
}

public struct Vertexmixed
{
    public cfloat3 Position;
    public cfloat3 Normal;
    public cfloat3 UVW;
}

