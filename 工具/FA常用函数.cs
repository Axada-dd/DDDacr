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

        /// <summary>
        /// 获取玩家职能序号
        /// </summary>
        public static int GetRoleByPlayerObjctIndex(this IGameObject? chara)
        {
            int playerIndex = chara.GetRoleByPlayerObjct() switch
            {
                "MT" => 0,
                "ST" => 1,
                "H1" => 2,
                "H2" => 3,
                "D1" => 4,
                "D2" => 5,
                "D3" => 6,
                "D4" => 7,
                _ => -1
            };
            return playerIndex;
        }
    }
}