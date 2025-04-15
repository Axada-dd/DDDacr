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
        public static bool IsTankOrHealer(this IBattleChara chara)
        {
            return chara.IsInParty() && (chara.IsTank()|| chara.IsHealer());
        }

        /// <summary>
        /// 获取职业
        /// </summary>
        /// <returns></returns>
        public static string GetObjcetJobName(this IBattleChara chara)
        {
            return !chara.IsInParty() ? "" : JobHelper.GetTranslation(chara.CurrentJob());
        }
    }
}