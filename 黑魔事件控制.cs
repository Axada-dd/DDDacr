using System.Threading.Tasks;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using DDDacr.Settings;
using DDDacr.工具;

namespace DDDacr
{
    public class 黑魔事件控制: IRotationEventHandler
    {
        public async Task OnPreCombat()
        {
        }

        public void OnResetBattle()
        {
        }
        public async Task OnNoTarget()
        {
            await Task.CompletedTask;
        }
        public void OnSpellCastSuccess(Slot slot, Spell spell)
        {
       
        }

        public void AfterSpell(Slot slot, Spell spell)
        {
       
        }

        public void OnBattleUpdate(int currTimeInMs)
        {
        
        }

        public void OnEnterRotation()
        {
        
        }

        public void OnExitRotation()
        {
        
        }

        public void OnTerritoryChanged()
        {
            /*if (Core.Resolve<MemApiZoneInfo>().GetCurrTerrId() == 1238)
            {
                LogHelper.Print("ACR:进入LGBT讨伐战，自动开启上天血乱");
                OnEnterDungeon();
                BLMSettings.Instance.IsOpenPartyRoleSettingWindow = true;
                PartyRoleWindow.Draw();
            }*/
        }
        public void OnEnterDungeon()
        {
            // 获取队伍成员
            foreach (var member in PartyHelper.Party)
            {
                BLMBattleData.Instance.PartyMembers.Add(member.Name.TextValue);
                BLMBattleData.Instance.PartyRole[member.Name.TextValue] = "";
            }
        }
    }
}