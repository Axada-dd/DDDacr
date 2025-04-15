using System;
using System.IO;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.IO;
using DDDacr.工具;

namespace DDDacr.Settings
{
    public class BLMSettings
    {
        public static BLMSettings Instance;
        #region 标准模板代码 可以直接复制后改掉类名即可
        private static string path;
        public static void Build(string settingPath)
        {
            path = Path.Combine(settingPath,nameof(BLMSettings) + ".json");
            if (!File.Exists(path))
            {
                Instance = new BLMSettings();
                Instance.Save();
                return;
            }
            try
            {
                Instance = JsonHelper.FromJson<BLMSettings>(File.ReadAllText(path));
            }
            catch (Exception e)
            {
                Instance = new BLMSettings();
                LogHelper.Error(e.ToString());
            }
        }

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, JsonHelper.ToJson(this));
        }
        #endregion
        
        public JobViewSave JobViewSave = new JobViewSave(); // QT设置存档
    }
}