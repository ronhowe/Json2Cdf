using System.Diagnostics;
using System.Text;

namespace Json2Cdf;

internal static class Write
{
    public static async Task WriteAsync(
        string path,
        string content,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            Debug.WriteLine($"Writing {Path.GetFullPath(path)}");
            await File.WriteAllTextAsync(path, content, Encoding.ASCII, cancellationToken);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed Writing CDF To {path}.  {ex}");
            throw;
        }
    }
}
