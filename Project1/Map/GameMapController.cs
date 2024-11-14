using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Map
{
    internal class GameMapController
    {
        //单例类
        static private GameMapController instance = new GameMapController();
        public static GameMapController Instance()
        {
            return instance;
        }

        private GameMapController() { }
        public GameMap CurrentMap { get; set; }

        /// <summary>
        /// 玩家移动检测：检测移动方向、移动、和实现推箱子
        /// </summary>
        /// <param name="key">移动方向</param>
        /// <param name="x">Player x轴坐标</param>
        /// <param name="y">Player y轴坐标</param>
        public bool CheckMove(Input input, int x, int y)
        {
            var staticElements = CurrentMap.staticElements;
            var pushBoxs = CurrentMap.pushBoxs;

            //1.围墙检测
            if (staticElements[y, x] is Block)
            {
                return false;
            }

            //2.箱子检测和推箱子
            for (int i = 0; i < pushBoxs.Length; i++)
            {
                //如果遇到箱子
                if (pushBoxs[i].mapPosX == x && pushBoxs[i].mapPosY == y)
                {
                    MapElement box = pushBoxs[i];

                    int oldX = box.mapPosX;
                    int oldY = box.mapPosY;
                    //箱子移动
                    switch (input)
                    {
                        case Input.UP: box.mapPosY--; break;
                        case Input.LEFT: box.mapPosX--; break;
                        case Input.DOWN: box.mapPosY++; break;
                        case Input.RIGHT: box.mapPosX++; break;
                    }
                    //如果有围墙阻挡，移动失败
                    if (staticElements[box.mapPosY, box.mapPosX] is Block)
                    {
                        //回退坐标
                        box.mapPosX = oldX;
                        box.mapPosY = oldY;
                        return false;
                    }
                    //如果有其他箱子阻挡，移动失败
                    foreach (MapElement n in pushBoxs)
                    {
                        if (n != box)
                        {
                            if (n.mapPosX == box.mapPosX && n.mapPosY == box.mapPosY)
                            {
                                //坐标归位
                                box.mapPosX = oldX;
                                box.mapPosY = oldY;
                                return false;
                            }
                        }
                    }
                }
            }


            return true;
        }
    }
}
