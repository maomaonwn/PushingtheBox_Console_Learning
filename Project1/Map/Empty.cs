using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///<summary>
///地图上的空元素（空格）
/// </summary>


namespace Project1.Map
{
    internal class Empty:MapElement
    {
        public Empty(int x,int y,char ch) : base(x,y,ch)
        {

        }
    }
}
