using System;
using System.Numerics;


namespace DDDacr.工具
{
    public class 坐标计算
    {
        /// <summary>
        /// 计算point相对于centre的八方位
        /// </summary>
        /// <param name="point">需要计算的坐标</param>
        /// <param name="centre">中心坐标</param>
        /// <returns>返回八方位置的序号，<para />
        ///     7__0__1<para />
        ///     6__X__2<para />
        ///     5__4__3 <para />
        /// </returns>
        public static int PositionTo8Dir(Vector3 point, Vector3 centre)
        {
            // Dirs: N = 0, NE = 1, ..., NW = 7
            var r = Math.Round(4 - 4 * Math.Atan2(point.X - centre.X, point.Z - centre.Z) / Math.PI) % 8;
            return (int)r;

        }
        
        /// <summary>
        /// 计算point相对于centre的六方位
        /// </summary>
        /// <param name="point">需要计算的坐标</param>
        /// <param name="centre">中心坐标</param>
        /// <returns>返回六方位置的序号</returns>
        public static int PositionTo6Dir(Vector3 point, Vector3 centre)
        {
            var r = Math.Round(3 - 3 * Math.Atan2(point.X - centre.X, point.Z - centre.Z) / Math.PI) % 6;
            return (int)r;

        }
        /// <summary>
        /// 计算坐标Y以X为中心旋转R度之后的坐标
        /// </summary>
        /// <param name="point">当前坐标或者预设坐标</param>
        /// <param name="centre">中心坐标</param>
        /// <param name="radian">旋转角度</param>
        /// <returns>旋转后的坐标</returns>
        public static Vector3 RotatePoint(Vector3 point, Vector3 centre, float radian)
        {

            Vector2 v2 = new Vector2(point.X - centre.X, point.Z - centre.Z);

            var rot = (MathF.PI - MathF.Atan2(v2.X, v2.Y) + radian);
            var lenth = v2.Length();
            return new Vector3(centre.X + MathF.Sin(rot) * lenth, centre.Y, centre.Z - MathF.Cos(rot) * lenth);
        }

        /// <summary>
        /// 计算坐标Y以X为中心旋转R度之后的坐标
        /// </summary>
        /// <param name="point">当前坐标或者预设坐标</param>
        /// <param name="centre">中心坐标</param>
        /// <param name="radian">旋转角度</param>
        /// <returns>旋转后的坐标</returns>
        public static Vector3 坐标Y以X为中心旋转R度(Vector3 point, Vector3 centre, float radian)
        {

            Vector2 v2 = new Vector2(point.X - centre.X, point.Z - centre.Z);

            var rot = (MathF.PI - MathF.Atan2(v2.X, v2.Y) + radian);
            var lenth = v2.Length();
            return new Vector3(centre.X + MathF.Sin(rot) * lenth, centre.Y, centre.Z - MathF.Cos(rot) * lenth);
        }
    }
}