using System;
using System.Reflection.Metadata;

namespace ASCII_Tree
{

    //класс рисования в консоль. Подготавливается массив символов, размером
    // во весь экран (80симв х 20строк)
    // рисование происходит в три этапа
    // 1 - очистка кадра - заполнение буфера пробелами BeforeDraw
    // 2 - рисование фигур в буфере в нужных позициях Draw(Shape)
    // 3 - вывод всего буфера в консоль ShowDraw
    public class DrawToConsole
    {
        //параметры кадра в консоли
        public int width { get; }
        public int height { get; }

        //соотношение ширины и высоты консоли
        public float aspect { get; }

        //пропорции пикселя (он не квадратный)
        public float pixelAspect { get; }

        //типа фокусного расстояния для масштабирования
        public float multiplier { get; }

        //массив символов всего кадра (кадровый буфер)
        public char[] buffer { get; private set; }

        public DrawToConsole(int width, int height, float multiplier)
        {
            this.width = width;
            this.height = height;
            this.multiplier = multiplier;

            aspect = (float)width / height;
            pixelAspect = 8.0f / 16.0f; // ширина пикселя к высоте
            buffer = new char[width * height]; //общее количество пикселей
        }

        //стереть экран (заполнить буффер пробелами)
        private void ClearScreen() //приватный, т.к. использоваться будет только внутри этого класса
        {
            //пройти по каждой колонке и каждой строке (вложенный цикл)
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    buffer[i + j * width] = ' '; //записать пробел
                }
            }
        }

        // Начало рисования - подготовить кадр (т.е. очистить экран)
        public void BeforeDraw() //публичный, т.к. вызвываться будет из Program.cs
        {
            ClearScreen();
            Console.SetCursorPosition(0, 0);
        }

        public void DrawShape(Shape shape)
        {
            char[] shapeBuffer = shape.DrawShape(this);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (shapeBuffer[i + j * width] != 0)
                    {
                        buffer[i + j * width] = shapeBuffer[i + j * width];
                    }
                }
            }
        }



        // окончание рисования - вывести весь кадр в консоль
        public void ShowDraw()
        {
            Console.WriteLine(buffer);
        }

    }


}
