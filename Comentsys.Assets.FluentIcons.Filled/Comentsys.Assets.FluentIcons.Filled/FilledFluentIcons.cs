namespace Comentsys.Assets.FluentIcons;

/// <summary>
/// Fluent UI Icons designed by Microsoft - a collection of familiar, friendly and modern icons. License: MIT License
/// </summary>
public class FilledFluentIcons : AssetBase<FilledFluentIcons>
{
    private const int width = 32;
    private const int height = 32;
    private const string folder = "Filled";
    private const string root = "Comentsys.Assets.FluentIcons.Filled.Resources";
    private static readonly Color source = Color.FromArgb(255, 33, 33, 33);

    /// <summary>
    /// Path
    /// </summary>
    /// <param name="type">Fluent Icon Type</param>
    /// <returns>Fluent Icon Path</returns>
    private static string Path(FluentIconType type) =>
        $"{folder}.{Enum.GetName(typeof(FluentIconType), type) ?? string.Empty}";

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="type">Fluent Icon Type</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(FluentIconType type) =>
        new(AsStream(root, Path(type)) ?? 
            new MemoryStream(), height, width);

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="type">Fluent Icon Type</param>
    /// <param name="filled">Filled Colour</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(FluentIconType type, Color? filled) =>
        new(AsStream(root, Path(type), source, filled) ?? 
            new MemoryStream(), height, width);
}