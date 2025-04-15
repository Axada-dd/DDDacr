using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;

namespace DDDacr.GCD
{
    public class 火4:ISlotResolver
    {
        public int Check()
        {
            return 0;
        }

        public void Build(Slot slot)
        {
            slot.Add(new Spell(156u, SpellTargetType.Target));
        }
    }
}