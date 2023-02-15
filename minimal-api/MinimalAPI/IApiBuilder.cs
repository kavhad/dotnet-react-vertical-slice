namespace MinimalAPI;

/// <summary>
/// A plugin interface that enables a feature to build it's API routes using the Minimal API model
/// </summary>
public interface IApiBuilder
{
    void BuildApi(WebApplication app);
}