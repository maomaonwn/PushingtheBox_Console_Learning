using Newtonsoft.Json;
using Project1.GamePlayer;
using Project1.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Stages
{
    internal class StageController
    {

        private static StageController instance = new StageController();
        public static StageController Instance()
        {
            return instance;
        }

        private StageController() { }


        private StageInfo[] stageInfos = null;     //存储反序列化后的信息
        /// <summary>
        /// 读取关卡配置文件并反序列化
        /// </summary>
        public void ReadInfo(string path)
        {
            string jsonStr = File.ReadAllText(path);
            stageInfos = JsonConvert.DeserializeObject<StageInfo[]>(jsonStr);    
        }

        /// <summary>
        /// 开启第id个关卡
        /// </summary>
        /// <returns>存在第id个关卡返回true，否返回false</returns>
        public bool StartStage(int id)
        {
            if(id >= stageInfos.Length)
            {
                return false;
            }

            //1.根据Id,取出对应关卡的信息
            StageInfo stageInfo = stageInfos[id];

            //2.初始化玩家信息
            Player player = new Player(stageInfo.PlayerX,stageInfo.PlayerY,'&');
            PlayerController.Instance().CurrentPlayer = player;     //用新实例替代旧的   

            //3.初始化地图信息
            int[,] mapInfos = stageInfo.Elements;
            int width = stageInfo.Width;
            int height = stageInfo.Height;
            int boxCount = stageInfo.BoxCount;

            GameMap map = new GameMap();
            GameMapController.Instance().CurrentMap = map;
            map.Width = width; 
            map.Height = height;

            //开辟存储数组的空间
            map.staticElements = new MapElement[height, width];
            map.pushBoxs = new MapElement[boxCount];
            map.targets = new MapElement[boxCount];
            map.CreateMapElement(mapInfos,width,height);

            return true;
        }

       /// <summary>
       /// 选择页面逻辑
       /// </summary>
        public void ShowSelection()
        {
            //清理屏幕、显示光标
            Console.Clear();
            Console.CursorVisible = true;
            //选择页面信息
            Console.WriteLine("******欢迎来到推箱子的世界******");
            for(int i = 0;i< stageInfos.Length;i++)
            {
                Console.WriteLine($"{i + 1}" + stageInfos[i].Name);
            }
            //光标归位
            Console.CursorTop = 1;


            int selection = 0;        //记录用户选择了哪个关卡(0~Length-1)
            bool selectionOver = false;
            //循环获取用户输入：直到用户点击了Enter键
            while (true)
            {
                Input input = InputTools.GetInput();
                switch(input)
                {
                    case Input.UP:
                        {
                            if (selection > 0)
                            {
                                selection--;
                                Console.CursorTop--;
                            }
                        }
                         break;
                    case Input.DOWN:
                        {
                            if(selection < stageInfos.Length - 1)
                            {
                                selection++;
                                Console.CursorTop++;
                            }
                        }
                        break;
                    case Input.ENTER:
                        {
                            selectionOver = true;
                        }
                        break;
                }

                if(selectionOver)
                {
                    break;
                }
            }


            Console.Clear();
            Console.CursorVisible= false;
            //开启关卡
            StartStage(selection);
        }

        /// <summary>
        /// 游戏通关逻辑
        /// 通关：每个目标上面都覆盖了一个箱子
        /// </summary>
        /// <returns></returns>
        public bool CheckClear()
        {
            //1.从当前地图对象中，取出targets数组/pushBoxs数组
            GameMap map = GameMapController.Instance().CurrentMap;
            MapElement[] targets = map.targets;
            MapElement[] pushBoxs = map.pushBoxs;

            //2.遍历判断，是否每个目标上都有一个箱子
            bool flag = false;
            foreach(MapElement target in targets)
            {
                flag = false;
                foreach(MapElement pushBox in pushBoxs) 
                {
                    if(pushBox.mapPosX == target.mapPosX && pushBox.mapPosY == target.mapPosY)
                    {
                        flag = true;
                        break;
                    }
                }

                if(!flag)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
