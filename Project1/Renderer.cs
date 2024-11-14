using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Map;
using Project1.GamePlayer;

namespace Project1
{
    internal class Renderer
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public Renderer()
        {

        }

        public void Render(GameMap gameMap, Player player)
        {
            int width = gameMap.Width;
            int height = gameMap.Height;
            MapElement[,] staticElements = gameMap.staticElements;
            MapElement[] pushBoxs = gameMap.pushBoxs;
            MapElement[] targets = gameMap.targets;

            //1.第一层：绘制静态地图元素
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    APITools.Draw(staticElements[y, x].mapPosX, staticElements[y, x].mapPosY, staticElements[y, x].mapAvatar);
                }
            }
            //2.第二层：绘制目标元素
            for (int i = 0; i < targets.Length; i++)
            {
                APITools.Draw(targets[i].mapPosX, targets[i].mapPosY, targets[i].mapAvatar);
            }
            //3.第三层：绘制箱子元素
            for (int i = 0; i < pushBoxs.Length; i++)
            {
                APITools.Draw(pushBoxs[i].mapPosX, pushBoxs[i].mapPosY, pushBoxs[i].mapAvatar); 
            }
            //4.绘制玩家
            APITools.Draw(player.playerPosX, player.playerPosY, player.avatar);
        }
    }
}
