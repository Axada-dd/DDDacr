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

        public static Vector3 坐标远离中心(Vector3 point, Vector3 centre, float distance, float radian)
        {
            
            Vector2 v2 = new Vector2(point.X - centre.X, point.Z - centre.Z);// 计算方向向量
            var lenth = v2.Length();
            var pointNew = new Vector3(0,0,100-lenth-distance);
            
            return RotatePoint(pointNew,centre,radian); // 计算新的坐标点
        }
        /// <summary>
        /// 在原始点与中心点的连线上，计算距离原始点指定距离的新坐标点
        /// </summary>
        /// <param name="originalPoint">原始坐标点</param>
        /// <param name="center">中心点</param>
        /// <param name="distance">目标点与原始点的距离（可正可负，符号决定方向）</param>
        /// <returns>计算得到的新坐标点</returns>
        /// <exception cref="ArgumentException">当原始点与中心点重合时抛出</exception>
        public static Vector3 CalculatePointOnLine(Vector3 originalPoint, Vector3 center, float distance)
        {
            var originalPoint2D = new Vector2(originalPoint.X, originalPoint.Z);
            var center2D = new Vector2(center.X, center.Z);
            // 处理原始点与中心点重合的情况
            if (originalPoint2D == center2D)
            {
                throw new ArgumentException("原始点与中心点不能重合", nameof(originalPoint));
            }
        
            // 计算从中心点到原始点的方向向量并归一化
            Vector2 direction = Vector2.Normalize(originalPoint2D - center2D);
            var result = originalPoint2D + direction * distance;
            // 计算新点：原始点沿着方向向量移动指定距离
            return new Vector3(result.X, 0, result.Y);
        }
    }
}