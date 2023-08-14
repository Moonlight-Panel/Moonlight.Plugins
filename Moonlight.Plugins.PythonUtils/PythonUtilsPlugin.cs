using Moonlight.App.Helpers;
using Moonlight.App.Plugin;
using Moonlight.Plugins.PythonUtils.UI;

namespace Moonlight.Plugins.PythonUtils;

public class PythonUtilsPlugin : MoonlightPlugin
{
    public PythonUtilsPlugin()
    {
        Name = "PythonUtils";
        Version = "01.08.2023";
        Author = "Moonlight Panel";
        
        OnBuildServerPage += context =>
        {
            if (context.ImageTags.Any(x => x == "pythonversion"))
            {
                context.Settings.Add(new()
                {
                    Name = "Python version",
                    Component = ComponentHelper.FromType(typeof(PythonVersionSetting))
                });
            }
            
            if (context.ImageTags.Any(x => x == "pythonfile"))
            {
                context.Settings.Add(new()
                {
                    Name = "Python file",
                    Component = ComponentHelper.FromType(typeof(PythonFileSetting))
                });
            }

            return Task.CompletedTask;
        };
    }
}