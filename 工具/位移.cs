using System.Numerics;
using System.Threading.Tasks;
using AEAssist;
using AEAssist.Extension;

namespace DDDacr.工具
{
    public static class 位移
    {
        /// <summary>
        /// tp到指定坐标
        /// </summary>
        /// <param name="pos">指定坐标</param>
        public static void Tp(Vector3 pos)
        {
            Core.Me.SetPos(pos);
            PositionHelper.SharePoint(pos);
        }
        /// <summary>
        /// 滑步tp到指定位置
        /// </summary>
        /// <param name="pos">指定位置</param>
        public static async Task SlideTPAsync(Vector3 pos)
        {
            while (!CanTP())
                await Task.Delay(50);
            Core.Me.SetPos(pos);
            PositionHelper.SharePoint(pos);
            await Task.Delay(1000);
        }
        private static bool CanTP()
        {
            var restCastTime = Core.Me.TotalCastTime - Core.Me.CurrentCastTime;
            if (!Core.Me.IsCasting)
                return true;
            if (restCastTime * 1000 <= WaitTillTime)
                return true;
            return false;
        }
        /// <summary>
        /// 等待时间，毫秒
        /// </summary>
        public static int WaitTillTime { get; set; }
    }
}