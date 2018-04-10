using System;

namespace DecafCraft.Utils
{
    public class Vector : IEquatable<Vector>
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector(double x = 0, double y = 0, double z = 0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double GetX() => _x;
        
        public void SetX(double x)
        {
            _x = x;
        }

        public double GetY() => _y;

        public void SetY(double y)
        {
            _y = y;
        }

        public double GetZ() => _z;

        public void SetZ(double z)
        {
            _z = z;
        }

        public static Vector operator +(Vector a, double b)
        {
            return new Vector(a.GetX() + b, a.GetY() + b, a.GetZ() + b);
        }

        public static Vector operator -(Vector a, double b)
        {
            return new Vector(a.GetX() - b, a.GetY() - b, a.GetZ() - b);
        }

        public bool Equals(Vector other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _x.Equals(other._x) && _y.Equals(other._y) && _z.Equals(other._z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vector) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _x.GetHashCode();
                hashCode = (hashCode * 397) ^ _y.GetHashCode();
                hashCode = (hashCode * 397) ^ _z.GetHashCode();
                return hashCode;
            }
        }
    }
}