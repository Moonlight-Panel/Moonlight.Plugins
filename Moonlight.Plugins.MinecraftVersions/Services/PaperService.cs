using Moonlight.Plugins.MinecraftVersions.ApiClient;
using Moonlight.Plugins.MinecraftVersions.ApiClient.Resources;

namespace Moonlight.Plugins.MinecraftVersions.Services;

public class PaperService
{
    private readonly PaperApiHelper ApiHelper;

    public PaperService(PaperApiHelper apiHelper)
    {
        ApiHelper = apiHelper;
    }

    public async Task<string[]> GetVersions()
    {
        var data = await ApiHelper.Get<PaperVersions>("paper");

        return data.Versions.ToArray();
    }

    public async Task<string[]> GetBuilds(string version)
    {
        var data = await ApiHelper.Get<PaperBuilds>($"paper/versions/{version}");

        return data.Builds.ToArray();
    }
}