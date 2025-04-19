using System.Collections.Generic;

namespace DDDacr
{
    public class BLMBattleData
    {
        public static BLMBattleData Instance  = new BLMBattleData();
        public  Dictionary<string, string> PartyRole = new Dictionary<string, string>();
        public List<string> PartyMembers = new List<string>();
    }
}