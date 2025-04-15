using System;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.GUI;
using ImGuiNET;

namespace DDDacr.Triggers
{
    public class TriggerAction_QT: ITriggerAction
    {
        public string DisplayName { get; } = "Bard/QT";
        public string Remark { get; set; }
    
        public string Key = "";
        public bool Value;
    
        // 辅助数据 因为是private 所以不存档
        private int _selectIndex;
        private string[] _qtArray;

        public TriggerAction_QT()
        {
            _qtArray = 黑魔acr入口.QT.GetQtArray();
        }

        public bool Draw()
        {
            _selectIndex = Array.IndexOf(_qtArray, Key);
            if (_selectIndex == -1)
            {
                _selectIndex = 0;
            }
            ImGuiHelper.LeftCombo("选择Key",ref _selectIndex,_qtArray);
            Key = _qtArray[_selectIndex];
            ImGui.SameLine();
            using (new GroupWrapper())
            {
                ImGui.Checkbox("",ref Value);   
            }
            return true;
        }

        public bool Handle()
        {
            黑魔acr入口.QT.SetQt(Key, Value);
            return true;
        }
    }
}