namespace SweepAndPrune
{
    public class Rectangle
    {
        private const int Width = 10;
        private const int Height = 10;


        public Rectangle(int x1, int y1)
        {
            this.X1 = x1;
            this.Y1 = y1;
        }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2
        {
            get { return this.X1 + Width; }
            
        }

        public int Y2
        {
            get { return this.Y1 + Height; }
        }

        public bool Intersects(Rectangle other)
        {
            return this.X1 <= other.X2 &&
                   other.X1 <= this.X2 &&
                   this.Y1 <= other.Y2 &&
                   other.Y1 <= this.Y2;
        }
    }
}
