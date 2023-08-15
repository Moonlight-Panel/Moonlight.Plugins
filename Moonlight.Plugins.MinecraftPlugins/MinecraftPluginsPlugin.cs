using Microsoft.Extensions.DependencyInjection;
using Moonlight.App.Helpers;
using Moonlight.App.Plugin;
using Moonlight.Plugins.MinecraftPlugins.ApiClient;
using Moonlight.Plugins.MinecraftPlugins.Services;
using Moonlight.Plugins.MinecraftPlugins.UI;

namespace Moonlight.Plugins.MinecraftPlugins;

public class MinecraftPluginsPlugin : MoonlightPlugin
{
    public MinecraftPluginsPlugin()
    {
        Name = "MinecraftPlugins";
        Version = "15.08.2023";
        Author = "Moonlight Panel";

        OnBuildServerPage += context =>
        {
            if (context.ImageTags.Any(x => x == "minecraft-plugins"))
            {
                context.Tabs.Add(new()
                {
                    Name = "Plugins",
                    Icon = "bxs-customize",
                    Route = "/plugins",
                    Component = ComponentHelper.FromType(typeof(PluginPage))
                });
            }
            
            return Task.CompletedTask;
        };

        OnBuildServices += collection =>
        {
            collection.AddScoped<MinecraftPluginService>();
            collection.AddSingleton<ModrinthApiHelper>();
            
            return Task.CompletedTask;
        };
    }
}