using System;
using System.Collections.Generic;
using System.Text;

class Color : IEquatable<Color>
{
    public uint R { get; set; }
    public uint G { get; set; }
    public uint B { get; set; }

    public Color(uint r, uint g, uint b)
    {
        R = r; G = g; B = b;
    }

    public bool Equals(Color other)
    {
        return other.R == R && other.G == G && other.B == B;
    }

    public override bool Equals(object obj)
    {
        if (obj is Color)
        {
            return Equals(obj as Color);
        }
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B);
    }

    public bool IsSimilar(Color other, int threshold)
    {
        if (Math.Abs(other.R - R) < threshold && Math.Abs(other.G - G) < threshold && Math.Abs(other.B - B) < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"RGB({R}, {G}, {B})";
    }
}