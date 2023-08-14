using Moonlight.App.Helpers;
using Moonlight.App.Plugin;
using Moonlight.Plugins.JavascriptUtils.UI;

namespace Moonlight.Plugins.JavascriptUtils;

public class JavascriptUtilsPlugin : MoonlightPlugin
{
    public JavascriptUtilsPlugin()
    {
        Name = "JavascriptUtils";
        Version = "01.08.2023";
        Author = "Moonlight Panel";

        OnBuildServerPage += context =>
        {
            if (context.ImageTags.Any(x => x == "javascriptversion"))
            {
                context.Settings.Add(new()
                {
                    Name = "Javascript version",
                    Component = ComponentHelper.FromType(typeof(JavascriptVersionSetting))
                });
            }
            
            if (context.ImageTags.Any(x => x == "javascriptfile"))
            {
                context.Settings.Add(new()
                {
                    Name = "Javascript file",
                    Component = ComponentHelper.FromType(typeof(JavascriptFileSetting))
                });
            }

            return Task.CompletedTask;
        };
    }
}