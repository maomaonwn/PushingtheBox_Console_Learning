using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    enum Input
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ENTER,
        NONE
    }

    static class InputTools
    {
        static public Input GetInput()
        {
            Input input = Input.NONE;

            //即时获取用户输入
            ConsoleKey key = Console.ReadKey(true).Key;
            
            //将C#的ConsoleKey枚举翻译成自定义的Input枚举
            switch(key)
            {
                case ConsoleKey.W: input = Input.UP;   break;
                case ConsoleKey.S: input = Input.DOWN; break;
                case ConsoleKey.A: input = Input.LEFT; break;
                case ConsoleKey.D: input = Input.RIGHT; break;
                case ConsoleKey.Enter: input = Input.ENTER; break;
                default: input = Input.NONE; break;
            }

            return input;
        }
    }
}
