using System;

namespace DecafCraft.Utils
{
    public class BoundingBox : IEquatable<BoundingBox>
    {
        public Vector Min;
        public Vector Max;

        public BoundingBox(Vector min, Vector max)
        {
            Min = min;
            Max = max;
        }

        public BoundingBox(BoundingBox box)
        {
            Min = box.Min;
            Max = box.Max;
        }

        public double Height => Max.GetY() - Min.GetY();

        public double Width => Max.GetX() - Min.GetX();

        public double Depth => Max.GetZ() - Min.GetZ();
        
        public static BoundingBox operator +(BoundingBox a, double b)
        {
            return new BoundingBox(a.Min - b, a.Max + b);
        }

        public static BoundingBox operator -(BoundingBox a, double b)
        {
            return new BoundingBox(a.Min + b, a.Max - b);
        }

        public static bool operator ==(BoundingBox a, BoundingBox b)
        {
            return a != null && a.Equals(b);
        }

        public static bool operator !=(BoundingBox a, BoundingBox b)
        {
            return a != null && !a.Equals(b);
        }

        public bool Equals(BoundingBox other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Min, other.Min) && Equals(Max, other.Max);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((BoundingBox) obj);
        }

        public override int GetHashCode()
        {
            return Max.GetHashCode() + Min.GetHashCode();
        }

        public override string ToString()
        {
            return $"({Min}, {Max})";
        }
    }
}