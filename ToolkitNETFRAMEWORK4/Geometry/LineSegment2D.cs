namespace ToolkitNFW4.Geometry {
    using System;
    public class LineSegment2D {

        public double X1 { get; private set; }
        public double Y1 { get; private set; }
        public double X2 { get; private set; }
        public double Y2 { get; private set; }
        public double Slope { get; private set; }
        public double YIntercept { get; private set; }
        public double Theta { get; private set; }
        public double Length { get; private set; }

        public LineSegment2D(Point2D point) : this(point.X, point.Y, 0, 0) { }
        public LineSegment2D(Point2D point2, Point2D point1) : this(point2.X, point2.Y,point1.X, point1.Y) { }

        public LineSegment2D(double x2, double y2, double x1, double y1) {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            double deltaY = Y2 - Y1;
            double deltaX = X2 - X1;

            if (deltaX == 0) {
                Slope = double.PositiveInfinity;
                YIntercept = double.PositiveInfinity;
                Theta = (deltaY < 0 ? 1.5 * Math.PI : Math.PI);
            }
            else {
                Slope = deltaY / deltaX;
                YIntercept = Y2 - (Slope * X2);
                Theta = Math.Atan(Convert.ToDouble(deltaY / deltaX));
                Theta += deltaX < 0 ? Math.PI : (deltaY < 0 ? 2 * Math.PI : 0);
            }

            Length = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public LineSegment2D(double length, double theta) {
            Length = length;
            Theta = theta;

            X1 = 0;
            Y1 = 0;
            YIntercept = 0;
            X2 = length * Math.Cos(theta);
            Y2 = length * Math.Sin(theta);

            double deltaY = Y2 - Y1;
            double deltaX = X2 - X1;

            Slope = deltaX == 0 ? double.PositiveInfinity : deltaY / deltaX;
        } 
    }
}