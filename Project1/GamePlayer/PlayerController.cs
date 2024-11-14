using Project1.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.GamePlayer
{
    internal class PlayerController
    {
        //单例类
        static private PlayerController instance = new PlayerController();

        public static PlayerController Instance()
        {
            return instance;
        }
        private PlayerController() { }



        public Player CurrentPlayer {  get; set; }



        /// <summary>
        /// 玩家移动
        /// </summary>
        /// <param name="keyInfo"></param>
        public void Move(Input input)
        {
            //存一份位置值
            int oldX = CurrentPlayer.playerPosX;
            int oldY = CurrentPlayer.playerPosY;

            switch (input)
            {
                case Input.UP:      CurrentPlayer.playerPosY--; break;
                case Input.DOWN:    CurrentPlayer.playerPosY++; break;
                case Input.RIGHT:   CurrentPlayer.playerPosX++; break;
                case Input.LEFT:    CurrentPlayer.playerPosX--; break;
                default: break;
            }

            //如果判定无法移动
            if (!GameMapController.Instance().CheckMove(input, CurrentPlayer.playerPosX, CurrentPlayer.playerPosY))//非true执行
            {
                //回退到之前的位置
                CurrentPlayer.playerPosX = oldX;
                CurrentPlayer.playerPosY = oldY;
            }
        }
    }
}
