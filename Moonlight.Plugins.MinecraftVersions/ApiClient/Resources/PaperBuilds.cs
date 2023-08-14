using Newtonsoft.Json;

namespace Moonlight.Plugins.MinecraftVersions.ApiClient.Resources;

public class PaperBuilds
{
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }

    [JsonProperty("project_name")]
    public string ProjectName { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("builds")]
    public List<string> Builds { get; set; }
}