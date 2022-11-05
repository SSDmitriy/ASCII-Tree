using ASCII_Tree;

namespace ASCII_Tree
{
    class Program
    {
        static void Main()
        {
            DrawToConsole drawToConsole = new DrawToConsole(120, 30, 1);

            Circle circle = new Circle(new Vector2(0, 0), 0.3f, new char[] { '-', ':', 'o', '@' });
                       

            drawToConsole.BeforeDraw();
            drawToConsole.DrawShape(circle);
            drawToConsole.ShowDraw();

            Console.ReadKey();

            Circle circle2 = new Circle(new Vector2(0, 0), 1f, new char[] { '-', ':', 'o', '@' });


            drawToConsole.BeforeDraw();
            drawToConsole.DrawShape(circle2);
            drawToConsole.ShowDraw();

            Console.ReadKey();

        }
    }
}