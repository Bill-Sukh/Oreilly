using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public struct StructExample
    {
        private double _x;
        private double _y;
        public StructExample(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X => _x;
        public double Y => _y;

        // It is required for structs to have its boolean operator's behaviors defined.
        public static bool operator ==(StructExample p1, StructExample p2)
        {
            return p1.X % 2 == 0 && p1.Y % 2 == 0 && p2.X % 2 == 0 && p2.Y % 2 == 0;
        }
        public static bool operator !=(StructExample p1, StructExample p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }
        public override bool Equals(object? obj)
        {
            return obj is StructExample p2 && this.X == p2.X && this.Y == p2.Y;
        }
        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }

    }

}
