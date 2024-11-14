using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Map
{
    internal class GameMap
    {
        //长宽
        public int Width { get; set; }
        public int Height { get; set; } 

        //地图元素
        //静态地图元素（围墙、空白元素）
        public MapElement[,] staticElements {  get; set; }

        //箱子元素
        public MapElement[] pushBoxs { get; set; }

        //目标元素
        public MapElement[] targets { get; set; }



        /// <summary>
        ///构造方法
        /// </summary>
        public GameMap()
        {
            InitMap();
        }

        ///<summary>
        ///初始化地图数据
        /// </summary>
        public void InitMap()
        {
            Width = 9;
            Height = 9;

            //地图数据
            int[,] mapInfoArr =
            {
                {1,1,1,1,1,0,0,0,0 },
                {1,0,0,0,1,0,0,0,0 },
                {1,0,2,2,1,0,1,1,1 },
                {1,0,2,0,1,0,1,3,1 },
                {1,1,1,0,1,1,1,3,1 },
                {0,1,1,0,0,0,0,3,1 },
                {0,1,0,0,0,1,0,0,1 },
                {0,1,0,0,0,1,1,1,1 },
                {0,1,1,1,1,1,0,0,0 },
             };

            //生成对应存储数组
            staticElements = new MapElement[9, 9];
            pushBoxs = new MapElement[3];
            targets = new MapElement[3];
            //生成对应元素，并放置在数组中
            int boxCount = 0;
            int targetCount = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x <Width; x++)
                {
                    switch (mapInfoArr[y, x])
                    {
                        case 0:
                            staticElements[y, x] = new Empty(x, y, ' '); break;
                        case 1:
                            staticElements[y, x] = new Block(x, y, '#'); break;
                        //数组中没有存变量的部分是null
                        case 2:
                            {
                                pushBoxs[boxCount++] = new PushBox(x, y, '@');
                                staticElements[y, x] = new Empty(x, y, ' '); break;
                            }
                        case 3:
                            {
                                targets[targetCount++] = new Target(x, y, 'A');
                                staticElements[y, x] = new Empty(x, y, ' '); break;
                            }
                    }
                }
            }
        }

        public void CreateMapElement(int[,] mapInfos,int width,int height)
        {
            //生成对应元素，并放置在数组中
            int boxCount = 0;
            int targetCount = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    switch (mapInfos[y, x])
                    {
                        case 0:
                            staticElements[y, x] = new Empty(x, y, ' '); break;
                        case 1:
                            staticElements[y, x] = new Block(x, y, '#'); break;
                        //数组中没有存变量的部分是null
                        case 2:
                            {
                                pushBoxs[boxCount++] = new PushBox(x, y, '@');
                                staticElements[y, x] = new Empty(x, y, ' '); break;
                            }
                        case 3:
                            {
                                targets[targetCount++] = new Target(x, y, 'A');
                                staticElements[y, x] = new Empty(x, y, ' '); break;
                            }
                    }
                }
            }
        }
    }
}
