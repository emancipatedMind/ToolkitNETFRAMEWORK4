﻿namespace ToolkitNFW4.Geometry {
    public struct Point2D {

        public decimal X { get; private set; }
        public decimal Y { get; private set; }

        public Point2D(decimal x, decimal y) : this() {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{nameof(X)}:{X};{nameof(Y)}:{Y};";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => obj is Point2D && obj.GetHashCode() == GetHashCode();

    }
}