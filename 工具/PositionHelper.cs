using System;
using System.Numerics;
using AEAssist;
using AEAssist.MemoryApi;

namespace DDDacr.工具
{
    public static class PositionHelper
    {
        private static readonly Random rand = new Random();


        public static Vector3 GetRandomOffsetPosition(Vector3 basePosition, float maxOffset)
        {
            float num1 = (float) (PositionHelper.rand.NextDouble() * 2.0 - 1.0) * maxOffset;
            float num2 = (float) (PositionHelper.rand.NextDouble() * 2.0 - 1.0) * maxOffset;
            return new Vector3(basePosition.X + num1, basePosition.Y, basePosition.Z + num2);
        }

        /// <summary>
        /// 绿玩移动，带有随机值
        /// </summary>
        /// <param name="basePosition">需要移动到位置坐标</param>
        /// <param name="maxOffset">随机值正负变动范围</param>
        public static void MoveToPositionWithOffset(Vector3 basePosition, float maxOffset)
        {
            Share.TrustDebugPoint.Clear();
            Vector3 randomOffsetPosition = PositionHelper.GetRandomOffsetPosition(basePosition, maxOffset);
            Core.Resolve<MemApiMove>().MoveToTarget(randomOffsetPosition);
            Share.TrustDebugPoint.Add(randomOffsetPosition);
        }

        /// <summary>
        /// 在游戏中画出pos位置
        /// </summary>
        /// <param name="pos">坐标</param>
        public static void SharePoint(this Vector3 pos)
        {
            Share.TrustDebugPoint.Clear();
            Share.TrustDebugPoint.Add(pos);
        }
    }
}