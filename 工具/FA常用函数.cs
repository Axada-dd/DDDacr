using AEAssist;
using AEAssist.Extension;
using AEAssist.Helper;
using Dalamud.Game.ClientState.Objects.Types;

namespace DDDacr.工具
{
    public static class FA常用函数
    {
        /// <summary>
        /// 判断是否是T奶
        /// </summary>
        /// <returns></returns>
        public static bool IsTankOrHealer(this IGameObject? chara)
        {
            if (chara == null) return false;
            IBattleChara? battleChara = chara as IBattleChara;
            return battleChara.IsInParty() && (battleChara.IsTank()|| battleChara.IsHealer());
        }
        /// <summary>
        /// 判断是否是DPS
        /// </summary> 
        public static bool IsDpsRe(this IGameObject? chara)
        {
           if (chara == null) return false;
           IBattleChara? battleChara = chara as IBattleChara;
           return battleChara.IsInParty() && battleChara.IsDps();
        }
        /// <summary>
        /// 获取职业
        /// </summary>
        /// <returns></returns>
        public static string GetObjcetJobName(this IGameObject? chara)
        {
            if (chara == null) return "null";
            IBattleChara? battleChara = chara as IBattleChara;
            return !battleChara.IsInParty() ? "非玩家" : JobHelper.GetTranslation(battleChara.CurrentJob());
        }
        /// <summary>
        /// 获取玩家职能
        /// </summary>
        /// <param name="chara"></param>
        /// <returns></returns>
        public static string GetRoleByPlayerObjct(this IGameObject? chara)
        {
            if (chara == null) return "null";
            IBattleChara? battleChara = chara as IBattleChara;
           return !battleChara.IsInParty() ? "非玩家" : RemoteControlHelper.GetRoleByPlayerName(chara.Name.TextValue); 
        }
    }
}