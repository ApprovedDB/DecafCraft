using System;
using DecafCraft.Utils;

namespace DecafCraft.Server
{
    public class Location : ICloneable, IEquatable<Location>
    {
        public World World { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public float Pitch { get; private set; }
        public float Yaw { get; private set; }

        public double GetLength() => Math.Sqrt(GetSquareLength());
        public double GetSquareLength() => X * X + Y * Y + Z * Z;
        public double GetDistance(Location l) => Math.Sqrt(GetSquareDistance(l));
        public double GetSquareDistance(Location l) => l == null
            ? throw new ArgumentNullException()
            : (X - l.X) * (X - l.X) + (Y - l.Y) * (Y - l.Y) + (Z - l.Z) * (Z - l.Z); 

        /// <summary>
        /// Creates a new Location with the given coordinates and direction.
        /// </summary>
        /// <param name="world">World that contains this location</param>
        /// <param name="x">The x-coordinate of this location</param>
        /// <param name="y">The y-coordinate of this location</param>
        /// <param name="z">The z-coordinate of this location</param>
        /// <param name="pitch">The pitch of this location</param>
        /// <param name="yaw">The yaw of this location</param>
        public Location(World world, double x, double y, double z, float pitch = 0, float yaw = 0)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
            Pitch = pitch;
            Yaw = yaw;
        }

        /// <summary>
        /// Gets the world that this location is in.
        /// </summary>
        /// <returns>World that contains this location</returns>
        public World GetWorld() => World;

        /// <summary>
        /// Sets the world that this location is in.
        /// </summary>
        /// <param name="world">New world that contains this location</param>
        public void SetWorld(World world)
        {
            World = world;
        }

        /// <summary>
        /// Gets the x-coordinate.
        /// </summary>
        /// <returns>x-coordinate</returns>
        public double GetX() => X;

        /// <summary>
        /// Sets the x-coordinate.
        /// </summary>
        /// <param name="x">x-coordinate</param>
        public void SetX(double x)
        {
            X = x;
        }

        /// <summary>
        /// Gets the y-coordinate.
        /// </summary>
        /// <returns>y-coordinate</returns>
        public double GetY() => Y;

        /// <summary>
        /// Sets the y-coordinate.
        /// </summary>
        /// <param name="y">y-coordinate</param>
        public void SetY(double y)
        {
            Y = y;
        }

        /// <summary>
        /// Gets the z-coordinate.
        /// </summary>
        /// <returns>z-coordinate</returns>
        public double GetZ() => Z;
        
        /// <summary>
        /// Sets the z-coordinate.
        /// </summary>
        /// <param name="z">z-coordinate</param>
        public void SetZ(double z)
        {
            Z = z;
        }

        /// <summary>
        /// Gets the pitch, measured in degrees.
        /// A pitch of 0 represents level forward facing.
        /// A pitch of 90 represents downward facing, or negative y direction
        /// A pitch of -90 represents upward facing, or positive y direction.
        /// </summary>
        /// <returns>pitch in degrees</returns>
        public float GetPitch() => Pitch;

        /// <summary>
        /// Sets the pitch, measured in degrees.
        /// A pitch of 0 represents level forward facing.
        /// A pitch of 90 represents downward facing, or negative y direction
        /// A pitch of -90 represents upward facing, or positive y direction.
        /// </summary>
        /// <param name="pitch">pitch in degrees</param>
        public void SetPitch(float pitch)
        {
            Pitch = pitch;
        }

        /// <summary>
        /// Set the yaw, measured in degrees.
        /// A yaw of 0 or 360 represents the positive z direction.
        /// A yaw of 180 represents the negative z direction.
        /// A yaw of 90 represents the negative x direction.
        /// A yaw of 270 represents the positive x direction. 
        /// </summary>
        /// <returns>yaw in degrees</returns>
        public float GetYaw() => Yaw;
        
        /// <summary>
        /// Set the yaw, measured in degrees.
        /// A yaw of 0 or 360 represents the positive z direction.
        /// A yaw of 180 represents the negative z direction.
        /// A yaw of 90 represents the negative x direction.
        /// A yaw of 270 represents the positive x direction. 
        /// </summary>
        /// <param name="yaw">yaw in degrees</param>
        public void SetYaw(float yaw)
        {
            Yaw = yaw;
        }
        
        /// <summary>
        /// Gets a unit-vector pointing in the direction that this Location is facing.
        /// </summary>
        /// <returns>A vector pointing the direction of this location's Pitch and Yaw</returns>
        public Vector GetDirection()
        {
            Vector vector = new Vector();
            
            double rotX = Yaw;
            double rotY = Pitch;

            vector.SetY(-Math.Sin(MathE.ToRadians(rotY)));

            double xz = Math.Cos(MathE.ToRadians(rotY));
            
            vector.SetX(-xz * Math.Sin(MathE.ToRadians(rotX)));
            vector.SetZ(xz * Math.Cos(MathE.ToRadians(rotX)));

            return vector;
        }

        /// <summary>
        /// Sets the Pitch and Yaw to point in the direction of the vector.
        /// </summary>
        /// <param name="vector">Point the entity will look at</param>
        /// <returns>The location with the new Pitch and Yaw</returns>
        public Location SetDirection(Vector vector)
        {
            const double double2Pi = 2 * Math.PI;
            double x = vector.GetX();
            double z = vector.GetZ();

            if (x == 0 && z == 0)
            {
                Pitch = vector.GetY() > 0 ? -90 : 90;
                return this;
            }

            double theta = Math.Atan2(-x, z);
            Yaw = (float) MathE.ToDegrees((theta + double2Pi) % double2Pi);

            double x2 = Math.Pow(x, 2);
            double z2 = Math.Pow(z, 2);
            double xz = Math.Sqrt(x2 + z2);
            Pitch = (float) MathE.ToDegrees(Math.Atan(-vector.GetY() / xz));

            return this;
        }

        public Vector ToVector()
        {
            return new Vector(X, Y, Z);
        }

        public static Location operator +(Location a, double b)
        {
            a.X += b;
            a.Y += b;
            a.Z += b;
            return a;
        }

        public static Location operator +(Location a, Location b)
        {
            a.X += b.X;
            a.Y += b.Y;
            a.Z += b.Z;
            return a;
        }

        public static Location operator +(Location a, Vector b)
        {
            a.X += b.GetX();
            a.Y += b.GetY();
            a.Z += b.GetZ();
            return a;
        }

        public static Location operator -(Location a, double b)
        {
            a.X -= b;
            a.Y -= b;
            a.Z -= b;
            return a;
        }

        public static Location operator -(Location a, Location b)
        {
            a.X -= b.X;
            a.Y -= b.Y;
            a.Z -= b.Z;
            return a;
        }

        public static Location operator -(Location a, Vector b)
        {
            a.X -= b.GetX();
            a.Y -= b.GetY();
            a.Z -= b.GetZ();
            return a;
        }

        public static Location operator *(Location a, double b)
        {
            a.X *= b;
            a.Y *= b;
            a.Z *= b;
            return a;
        }

        public object Clone()
        {
            return this;
        }

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(World, other.World) && X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && Pitch.Equals(other.Pitch) && Yaw.Equals(other.Yaw);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (World != null ? World.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ Pitch.GetHashCode();
                hashCode = (hashCode * 397) ^ Yaw.GetHashCode();
                return hashCode;
            }
        }
    }
}