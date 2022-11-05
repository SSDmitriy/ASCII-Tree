using System;
using System.Drawing;


namespace ASCII_Tree
{
    // родительский класс создания фигур Shape
    public class Shape
    {
        // proteccted - т.к. Shape будет иметь наследников и в них должны быть доступны эти поля
        protected Vector2 position;
        protected char[] fill; // заливка фигуры

        public Shape(Vector2 position, char[] fill)
        {
            this.position = position;
            this.fill = fill;
        }

        //метод возвращает массив символов, которыми составлена фигура
        //помечен как virtual, чтобы переопределять его в наследниках
        public virtual char[] DrawShape(DrawToConsole drawToConsole)
        {
            return new char[drawToConsole.width * drawToConsole.height];
        }

        //передвинуть фигуру
        public void Move(Vector2 direction)
        {
            position += direction;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public Vector2 GetPosition()
        {
            return position;
        }



    }

    //
    //дочерний класс Circle (унаследован от Shape)
    public class Circle : Shape
    {

        protected float diameter;


        // конструктор
        public Circle(Vector2 position, float diameter, char[] fill) : base(position, fill)
        {
            this.diameter = diameter;
        }

        //переопределим метод char[] DrawShape
        override public char[] DrawShape(DrawToConsole drawToConsole)
        {
            char[] buffer = new char[drawToConsole.buffer.Length];

            for (int i = 0; i < drawToConsole.width; i++)
            {
                for (int j = 0; j < drawToConsole.height; j++)
                {

                    float x = (float)i / drawToConsole.width * 2.0f * drawToConsole.multiplier - 1.0f * drawToConsole.multiplier;
                    float y = (float)j / drawToConsole.height * 2.0f * drawToConsole.multiplier - 1.0f * drawToConsole.multiplier;
                    x *= drawToConsole.aspect * drawToConsole.pixelAspect;

                    //геометрическое место точек окружности f = x ^ 2 + y ^ 2
                    float f = (x - position.x) * (x - position.x) + (y - position.y) * (y - position.y);


                    char pixel;


                    //Простая заливка символом
                    pixel = 'O';
                    if (f < diameter) buffer[i + j * drawToConsole.width] = pixel;



                    //тут заливка ТЕКСТУРОЙ из массива символов
                    //if (f < diameter)
                    //{
                    //    if (f < diameter / 8)
                    //        pixel = fill[3];
                    //    else if (f < diameter / 3)
                    //        pixel = fill[2];
                    //    else if (f < diameter / 1.5f)
                    //        pixel = fill[1];
                    //    else
                    //        pixel = fill[0];

                    //    //закрасить элемент буфера пикселем
                    //    buffer[i + j * drawToConsole.width] = pixel;
                    //}
                }
            }

            //вернуть кадровый буфер с нарисованной в нем фигурой
            return buffer;
        }


    }
}
