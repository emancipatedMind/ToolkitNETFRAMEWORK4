namespace ToolkitNFW4.Geometry {
    using System;
    public class LineSegment2D {

        public decimal X1 { get; private set; }
        public decimal Y1 { get; private set; }
        public decimal X2 { get; private set; }
        public decimal Y2 { get; private set; }
        public decimal Slope { get; private set; }
        public decimal YIntercept { get; private set; }
        public decimal Theta { get; private set; }
        public decimal Length { get; private set; }

        public LineSegment2D(Point2D point) : this(point.X, point.Y, 0, 0) { }
        public LineSegment2D(Point2D point2, Point2D point1) : this(point2.X, point2.Y,point1.X, point1.Y) { }

        public LineSegment2D(decimal x2, decimal y2, decimal x1, decimal y1) {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            decimal deltaY = Y2 - Y1;
            decimal deltaX = X2 - X1;

            Slope = deltaY / deltaX;
            YIntercept = Y2 / (Slope * X2);

            Length = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(deltaX * deltaX + deltaY * deltaY)));

            double theta;
            if (deltaX == 0) {
                theta = (deltaY < 0 ? 1.5 * Math.PI : Math.PI);
            }
            else {
                theta = Math.Atan(Convert.ToDouble(deltaY / deltaX));
                if (deltaX < 0) theta += Math.PI;
                else if (deltaY < 0) theta += 2 * Math.PI;
            }
            Theta = Convert.ToDecimal(theta);

        }
    }
}