namespace MusiciansGearRegistry.Api.Core.Entities;

public class MGR_SvcResponse<T> where T : class
{
    public bool success { get; set; }
    public T responseContent { get; set; }
    public string message { get; set; }

    public MGR_SvcResponse()
    { }

    public MGR_SvcResponse(string message = null)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            this.message = message;
        }
    }

    public MGR_SvcResponse(T contentData = null)
    {
        if (contentData != null)
            this.responseContent = contentData;
    }
}
