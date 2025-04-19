using System;
using System.Collections.Generic;
using System.Numerics;
using AEAssist.Helper;
using DDDacr.Settings;
using ImGuiNET;

namespace DDDacr.工具
{
    public  class PartyRoleWindow
    {

        public static void Draw()
        {
            var isOpen = BLMSettings.Instance.IsOpenPartyRoleSettingWindow;
            var partyMembers = BLMBattleData.Instance.PartyMembers;
            if (!isOpen) return;

            ImGui.SetNextWindowSize(new Vector2(400, 300), ImGuiCond.FirstUseEver);
            if (ImGui.Begin("职能设置窗口", ref isOpen))
            {
                for (int i = 0; i < partyMembers.Count; i++)
                {
                    string member = partyMembers[i];

                    ImGui.Text(member);
                    ImGui.SameLine();

                    // 显示职能选择下拉框
                    string[] roles = { "MT", "ST", "H1", "H2", "D1", "D2", "D3", "D4" };
                    int currentRoleIndex = Array.IndexOf(roles, BLMBattleData.Instance.PartyRole[member]);
                    if (ImGui.Combo($"##Role_{member}", ref currentRoleIndex, roles, roles.Length))
                    {
                        BLMBattleData.Instance.PartyRole[member] = roles[currentRoleIndex];
                    }
                }

                if (ImGui.Button("保存设置"))
                {
                    // 保存职能设置的逻辑
                    SaveRoleSettings();
                    BLMSettings.Instance.IsOpenPartyRoleSettingWindow = false;
                }

                ImGui.End();
            }
        }

        private static void SaveRoleSettings()
        {
            // 这里可以添加保存职能设置到配置文件或其他操作的逻辑
            foreach (var kvp in BLMBattleData.Instance.PartyRole)
            {
                LogHelper.Print($"成员: {kvp.Key}, 职能: {kvp.Value}");
            }
        }
    }
}