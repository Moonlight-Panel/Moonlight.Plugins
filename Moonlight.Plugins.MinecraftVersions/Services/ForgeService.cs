﻿using System.Text;
using Microsoft.Extensions.Configuration;

namespace Moonlight.Plugins.MinecraftVersions.Services;

public class ForgeService
{
    private readonly HttpClient Client;

    public ForgeService()
    {
        Client = new();
    }

    // Key: 1.9.4-recommended Value: 12.17.0.2317
    public async Task<Dictionary<string, string>> GetVersions()
    {
        var data = await Client.GetStringAsync(
            "https://files.minecraftforge.net/net/minecraftforge/forge/promotions_slim.json");
        
        var json = new ConfigurationBuilder().AddJsonStream(
            new MemoryStream(Encoding.ASCII.GetBytes(
                    data
                )
            )
        ).Build();

        var d = new Dictionary<string, string>();

        foreach (var section in json.GetSection("promos").GetChildren())
        {
            d.Add(section.Key, section.Value!);
        }
        
        return d;
    }
}