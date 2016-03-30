namespace SweepAndPrune
{
    public class GameObject : IBoundable
    {

        public GameObject(string name, int x1, int y1)
        {
            this.Name = name;
            this.Bounds = new Rectangle(x1,y1);
        }

        public string Name { get; set; }

        public Rectangle Bounds { get; set; }
    }
}
