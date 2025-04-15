using ImGuiNET;

namespace DDDacr.Settings
{
    public class BLMSettingUI
    {
        public static BLMSettingUI Instance = new BLMSettingUI();
        public BLMSettings BLMSettings => BLMSettings.Instance;
    
        public void Draw()
        {
            /*ImGui.Checkbox("使用速行", ref 设置.Instance.UsePeloton);
            ImGuiHelper.LeftInputInt("非爆发期Apex值达到多少时才使用", ref 设置.ApexArrowValue);*/
        
            if (ImGui.Button("Save"))
            {
                BLMSettings.Instance.Save();
            }
        }
    }
}