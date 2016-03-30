namespace K_DTree.Core
{
    public class Star : ICoordinatable
    {
        public Star(string name, double x, double y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public string Name { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
