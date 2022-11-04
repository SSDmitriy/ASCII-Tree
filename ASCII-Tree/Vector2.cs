using System;

class Vector2
{

    public float x { get; private set; }
    public float y { get; private set; }

    public Vector2()
    {
        x = 0.0f;
        y = 0.0f;
    }

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    //здесь перегружается оператор "+" https://metanit.com/sharp/tutorial/3.36.php
    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2 { x = a.x + b.x, y = a.y + b.y };
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
        return new Vector2 { x = a.x - b.x, y = a.y - b.y };
    }



}
