namespace Moonlight.Plugins.MinecraftPlugins.ApiClient;

public class ModrinthException : Exception
{
    public int StatusCode { get; set; }
    
    public ModrinthException()
    {
    }

    public ModrinthException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public ModrinthException(string message, Exception inner) : base(message, inner)
    {
    }
}