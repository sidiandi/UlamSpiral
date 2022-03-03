const int size = 3;

// apply sieve of erastosthenes
var count = size * size;
var isPrime = new bool[count];
for (int i=1; i< count+1; i++)
{
    isPrime[i-1] = true;
}
for (int i=2;i< count+ 1; i++)
{
    if (isPrime[i-1])
    {
        for (int j = i * 2; j < count+1; j = j + i)
        {
            isPrime[j-1] = false;
        }
    }
}

// arrange
var canvas = new bool[size, size];
using var e = UlamSpiral(size).GetEnumerator();
for (int i = 1; i < count + 1; i++)
{
    e.MoveNext();
    canvas[e.Current.y, e.Current.x] = isPrime[i-1];
}

// output
for (int y= 0; y<size; y++)
{
    for (int x = 0; x < size; x++)
    {
        Console.Write(canvas[y, x] ? "X" : " ");
    }
    Console.WriteLine();
}

IEnumerable<Point> UlamSpiral(int size)
{
    var x = (size-1) / 2;
    var y = (size) / 2;

    Point Index() => new Point { x = x, y = y };

    var maxCount = size * size;
    var count = 0;
    var steps = 1;

    yield return Index();
    ++count;
    var d = Direction.Right;

    void Move()
    {
        switch (d)
        {
            case Direction.Right:
                ++x;
                break;
            case Direction.Up:
                --y;
                break;
            case Direction.Left:
                --x;
                break;
            case Direction.Down:
                ++y;
                break;
        }
    }

    void Turn()
    {
        if (d == Direction.Down)
        {
            d = Direction.Right;
        }
        else
        {
            ++d;
        }
    }

    while (true)
    {
        for (int r = 0; r < 2; ++r)
        {
            for (int i = 0; i < steps; ++i)
            {
                if (count >= maxCount) goto end;
                ++count;
                Move();
                yield return Index();
            }
            Turn();
        }
        ++steps;
    }

end:;
}

enum Direction
{
    Right,
    Up,
    Left,
    Down,
};

record Point
{
    public int x;
    public int y;
}


