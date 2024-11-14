using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Map
{
    abstract internal class MapElement
    {
        public MapElement(int x,int y,char ch)
        {
            mapPosX = x;
            mapPosY = y;
            mapAvatar = ch;
        }

        public int mapPosX {  get; set; }
        public int mapPosY {  get; set; }
        public char mapAvatar {  get; set; }
    }
}
