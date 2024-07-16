using ExportHistoryLib.Common;

namespace ExportHistoryViewer.Configuration
{
    public static class LayoutConfigurationHelper
    {
        public static string GetLayoutRegKey(string controlName) => $@"{ServiceConstants.DevexpressLayoutSettingsRegistryPath}{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}\{controlName}";

    }
}
