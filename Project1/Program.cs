using Project1.Map;
using Project1.GamePlayer;
using Project1.Stages;
using Newtonsoft.Json;

namespace Project1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //读取配置文件
            StageController.Instance().ReadInfo("stageInfos.json");
            //进入选择页面
            StageController.Instance().ShowSelection();

            Renderer renderer = new Renderer();
            


            //光标不可见
            Console.CursorVisible = false;

            //首帧动画（解决开局黑屏）
            renderer.Render(GameMapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
            /*帧动画循环*/
            while (true)
            {
                //1.获取用户输入
                Input input = InputTools.GetInput();

                //2.玩家移动逻辑
                PlayerController.Instance().Move(input);

                //3.分层绘制：玩家和地图   
                renderer.Render(GameMapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);   

                if(StageController.Instance().CheckClear())
                {
                    Console.Clear();          //1.清理当前屏幕 2.将Cursor放在黑框开始的地方
                    Console.WriteLine("恭喜过关！\n 按任意键继续...");
                    //等待用户按任意键
                    Console.ReadKey(true);    
                    
                    //进入下一关
                    StageController.Instance().ShowSelection();

                    renderer.Render(GameMapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
                }
            }                  
        }
    }
}
