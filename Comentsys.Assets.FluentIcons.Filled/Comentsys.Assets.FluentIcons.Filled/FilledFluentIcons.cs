namespace Comentsys.Assets.FluentIcons;

/// <summary>
/// Fluent UI Icons designed by Microsoft - a collection of familiar, friendly and modern icons. License: MIT License
/// </summary>
public class FilledFluentIcons : AssetBase<FilledFluentIcons>
{
    private const int width = 32;
    private const int height = 32;
    private const string folder = "Filled";
    private const string asset_svg_tag = "svg";
    private const string asset_svg_path_data = "//svg:path/@d";
    private const string asset_svg_name_space = "http://www.w3.org/2000/svg";
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
    /// Get SVG String Path Markup
    /// </summary>
    /// <param name="content">SVG String</param>
    /// <returns>SVG Path Data</returns>
    private static string? GetPathMarkup(string? content)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(content))
                return null;
            var svg = new XmlDocument();
            svg.LoadXml(content);
            var navigator = svg.CreateNavigator();
            var manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace(asset_svg_tag, asset_svg_name_space);
            return svg.SelectSingleNode(asset_svg_path_data, manager).Value;
        }
        catch
        {
            return null;
        }
    }

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

    /// <summary>
    /// Get Asset Resource Path Markup
    /// </summary>
    /// <param name="type">Fluent Icon Type</param>
    /// <returns>Asset Resource Path Markup</returns>
    public static string? GetPathMarkup(FluentIconType type) =>
        GetPathMarkup(Get(type).ToSvgString());
}