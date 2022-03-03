// ulam spiral enumerable

IEnumerable<int> UlamSpiral(int size)
{
    var x = size / 2;
    var y = x;

    int Index() => y * size + y;

    while (true)
    {
        for (var d = Direction.Right; d <= Direction.Down; ++d)
        {
            yield return Index();
            switch(d)
        }
    }

}

enum Direction
{
    Right,
    Up,
    Left,
    Down,
};

// apply sieve of erastosthenes

// output

