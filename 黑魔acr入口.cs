using System;
using System.Collections.Generic;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using DDDacr.GCD;
using DDDacr.Settings;
using DDDacr.Triggers;
using ImGuiNET;
using PatchouliTC.Common;

namespace DDDacr
{
    public class 黑魔acr入口:IRotationEntry
    {
        public string AuthorName{get; set; } = "DDDacr";

        public List<SlotResolverData> SlotResolvers = new List<SlotResolverData>()
        {
            new SlotResolverData(new 火4(), SlotMode.Gcd)
        };

        public Rotation Build(string settingFolder)
        {
            // 初始化设置
            BLMSettings.Build(settingFolder);
            // 初始化QT （依赖了设置的数据）
            BuildQT();
            
            var rot = new Rotation(SlotResolvers)
            {
                TargetJob = Jobs.BlackMage,
                AcrType = AcrType.HighEnd,
                MinLevel = 100,
                MaxLevel = 100,
                Description = "这是一个测试描述\n123123123123",
            };
            // 添加各种事件回调
            rot.SetRotationEventHandler(new 黑魔事件控制());
            // 添加QT开关的时间轴行为
            rot.AddTriggerAction(new TriggerAction_QT());

            return rot; 
        }
        public static JobViewWindow QT { get; private set; }
        public IRotationUI GetRotationUI()
        {
            return QT;
        }
        public void BuildQT()
        {
            // JobViewSave是AE底层提供的QT设置存档类 在你自己的设置里定义即可
            // 第二个参数是你设置文件的Save类 第三个参数是QT窗口标题
            QT = new JobViewWindow(BLMSettings.Instance.JobViewSave, BLMSettings.Instance.Save, "AE BRD [仅作为开发示范]");
            QT.SetUpdateAction(OnUIUpdate); // 设置QT中的Update回调 不需要就不设置

            //添加QT分页 第一个参数是分页标题 第二个是分页里的内容
            QT.AddTab("通用", DrawQtGeneral);
            QT.AddTab("Dev", DrawQtDev);

            // 添加QT开关 第二个参数是默认值 (开or关) 第三个参数是鼠标悬浮时的tips
            QT.AddQt(QTKey.Test1, true);


            // 添加快捷按钮 (带技能图标)
            QT.AddHotkey("黑魔罩",new HotKeyResolver_NormalSpell(157u,SpellTargetType.Self));
            QT.AddHotkey("爆发药", new HotKeyResolver_Potion());
            QT.AddHotkey("极限技", new HotKeyResolver_法系LB());
        
            /*
            // 这是一个自定义的快捷按钮 一般用不到
            // 图片路径是相对路径 基于AEAssist(C|E)NVersion/AEAssist
            // 如果想用AE自带的图片资源 路径示例: Resources/AE2Logo.png
            QT.AddHotkey("极限技", new HotkeyResolver_General("#自定义图片路径", () =>
            {
                // 点击这个图片会触发什么行为
                LogHelper.Print("你好");
            }));
            */
        }
        // 设置界面
        public void OnDrawSetting()
        {
            BLMSettingUI.Instance.Draw();
        }

        public void OnUIUpdate()
        {

        }
    
        public void DrawQtGeneral(JobViewWindow jobViewWindow)
        {
            ImGui.Text("画通用信息");
        }

        public void DrawQtDev(JobViewWindow jobViewWindow)
        {
            ImGui.Text("画Dev信息");
            foreach (var v in jobViewWindow.GetQtArray())
            {
                ImGui.Text($"Qt按钮: {v}");
            }

            foreach (var v in jobViewWindow.GetHotkeyArray())
            {
                ImGui.Text($"Hotkey按钮: {v}");
            }
        }

    
        public void Dispose()
        {
            // 释放需要释放的东西 没有就留空
        }
    }
}