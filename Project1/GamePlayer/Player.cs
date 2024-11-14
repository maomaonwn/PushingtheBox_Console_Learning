using Project1.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.GamePlayer
{
    internal class Player
    {
        //构造方法（如果不强制Player生成时传入初始位置，那么x、y会默认为0）
        public Player(int x, int y, char ch)
        {
            playerPosX = x;
            playerPosY = y;
            avatar = ch;
        }


        public int playerPosX { get; set; }
        public int playerPosY { get; set; }
        public char avatar { get; set; }
    }
}
