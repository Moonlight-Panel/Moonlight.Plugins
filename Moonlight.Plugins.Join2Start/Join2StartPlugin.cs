using Moonlight.App.Helpers;
using Moonlight.App.Plugin;
using Moonlight.Plugins.Join2Start.UI;

namespace Moonlight.Plugins.Join2Start;

public class Join2StartPlugin : MoonlightPlugin
{
    public Join2StartPlugin()
    {
        Name = "Join2Start";
        Version = "13.09.2023";
        Author = "Moonlight Panel";

        OnBuildServerPage += context =>
        {
            context.Settings.Add(new()
            {
                Name = "Join2Start",
                Component = ComponentHelper.FromType(typeof(Join2StartSetting))
            });
            
            return Task.CompletedTask;
        };
    }
}