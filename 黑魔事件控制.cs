using System.Threading.Tasks;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;

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
        
        }
    }
}