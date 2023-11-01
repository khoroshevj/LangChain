using UglyToad.PdfPig;

namespace LangChain.Sources;

/// <summary>
/// 
/// </summary>
public class PdfPigPdfSource : ISource
{
    /// <summary>
    /// 
    /// </summary>
    public required string Path { get; init; }

    /// <inheritdoc/>
    public Task<IReadOnlyCollection<Document>> LoadAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            using PdfDocument document = PdfDocument.Open(Path, new ParsingOptions());
            var pages = document.GetPages();
            var content = String.Join("\n\n", pages.Select(page => page.Text));

            var documents = (Document.Empty with
            {
                Content = content,
            }).AsArray();

            return Task.FromResult(documents);
        }
        catch (Exception exception)
        {
            return Task.FromException<IReadOnlyCollection<Document>>(exception);
        }
    }
}