static class Extension
{
    public static DV Size(this Rect r) => new(r.Width, r.Height);
    public static Size ToSize(this Rect r) => new(r.Width, r.Height);
    public static Point ToPoint(this Rect r) => new(r.X, r.Y);
    public static DV Point(this Rect r) => new(r.X, r.Y);
    public static DV Point(this Point p) => p;
    public static DV Size(this Size s) => s;
}

readonly record struct DV(double X, double Y)
{
    public Point Point => new(X, Y);
    public Size Size => new(X, Y);

    public static DV operator +(DV a, double b)
        => new(a.X + b, a.Y + b);
    public static DV operator +(DV a, DV b)
        => new(a.X + b.X, a.Y + b.Y);
    public static DV operator -(DV a)
        => new(-a.X, -a.Y);
    public static DV operator -(DV a, DV b)
        => a + -b;
    public static implicit operator Point(DV p) => p.Point;
    public static implicit operator Size(DV s) => s.Size;
    public static implicit operator DV(Point p) => new(p.X, p.Y);
    public static implicit operator DV(Size s) => new(s.Width, s.Height);
    public static implicit operator Vector3(DV p) => new((float)p.X, (float)p.Y, 0);
}