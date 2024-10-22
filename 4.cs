namespace _4
{
    public abstract class Circle
    {
        public abstract void Draw();
    }
    public abstract class Rectangle
    {
        public abstract void Draw();
    }
    public abstract class Square
    {
        public abstract void Draw();
    }
    public abstract class ShapeFactory
    {
        public abstract Circle CreateCircle();
        public abstract Rectangle CreateRectangle();
        public abstract Square CreateSquare();
    }
    class BlueCircle : Circle
    {
        public override void Draw()
        {
            Console.WriteLine("Синя окръжност.");
        }
    }
    class BlueRectangle : Rectangle
    {
        public override void Draw()
        {
            Console.WriteLine("Син правоъгълник.");
        }
    }
    class BlueSquare : Square
    {
        public override void Draw()
        {
            Console.WriteLine("Син квадрат.");
        }
    }
    class RedCircle : Circle
    {
        public override void Draw()
        {
            Console.WriteLine("Червена окръжност.");
        }
    }
    class RedRectangle : Rectangle
    {
        public override void Draw()
        {
            Console.WriteLine("Червен правоъгълник.");
        }
    }
    class RedSquare : Square
    {
        public override void Draw()
        {
            Console.WriteLine("Червен квадрат.");
        }
    }
    public class BlueFactory : ShapeFactory
    {
        public override Circle CreateCircle()
        {
            return new BlueCircle();
        }
        public override Rectangle CreateRectangle()
        {
            return new BlueRectangle();
        }
        public override Square CreateSquare() { 
            return new BlueSquare();
        }
    }
    public class RedFactory : ShapeFactory
    {
        public override Circle CreateCircle()
        {
            return new RedCircle();
        }
        public override Rectangle CreateRectangle()
        {
            return new RedRectangle();
        }
        public override Square CreateSquare() {
            return new RedSquare();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory blue=new BlueFactory();
            Circle blueCircle=blue.CreateCircle();
            blueCircle.Draw();
            Rectangle blueRectangle=blue.CreateRectangle();
            blueRectangle.Draw();
            Square blueSquare=blue.CreateSquare();
            blueSquare.Draw();
            ShapeFactory red=new RedFactory();
            Circle redCircle=red.CreateCircle();
            redCircle.Draw();
            Rectangle redRectangle=red.CreateRectangle();
            redRectangle.Draw();
            Square redSquare=red.CreateSquare();
            redSquare.Draw();
        }
    }
}
