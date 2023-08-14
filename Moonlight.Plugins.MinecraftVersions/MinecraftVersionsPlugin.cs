using Microsoft.Extensions.DependencyInjection;
using Moonlight.App.Helpers;
using Moonlight.App.Plugin;
using Moonlight.Plugins.MinecraftVersions.ApiClient;
using Moonlight.Plugins.MinecraftVersions.Services;
using Moonlight.Plugins.MinecraftVersions.UI;

namespace Moonlight.Plugins.MinecraftVersions;

public class MinecraftVersionsPlugin : MoonlightPlugin
{
    public MinecraftVersionsPlugin()
    {
        Name = "Minecraft Versions";
        Author = "Moonlight Panel";
        Version = "24.07.2023";

        OnBuildServices += collection =>
        {
            collection.AddSingleton<FabricService>();
            collection.AddSingleton<ForgeService>();
            collection.AddSingleton<PaperService>();
            collection.AddSingleton<PaperApiHelper>();
            
            return Task.CompletedTask;
        };

        OnBuildServerPage += context =>
        {
            if (context.ImageTags.Any(x => x == "paperversion"))
            {
                context.Settings.Add(new()
                {
                    Name = "Paper version",
                    Component = ComponentHelper.FromType(typeof(PaperVersionSetting))
                });
            }
            
            if (context.ImageTags.Any(x => x == "fabricversion"))
            {
                context.Settings.Add(new()
                {
                    Name = "Fabric version",
                    Component = ComponentHelper.FromType(typeof(FabricVersionSetting))
                });
            }
            
            if (context.ImageTags.Any(x => x == "forgeversion"))
            {
                context.Settings.Add(new()
                {
                    Name = "Forge version",
                    Component = ComponentHelper.FromType(typeof(ForgeVersionSetting))
                });
            }
            
            return Task.CompletedTask;
        };
    }
}