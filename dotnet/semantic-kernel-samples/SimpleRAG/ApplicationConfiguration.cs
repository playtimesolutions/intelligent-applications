namespace SimpleRAG;

public class AzureAISearchConfiguration
{
    public string ApiKey { get; set; } = null!;

    public string Endpoint { get; set; } = null!;

    public string IndexName { get; set; } = null!;
}

public class ApplicationConfiguration
{
    public string ApiKey { get; set; } = null!;

    public AzureAISearchConfiguration AzureAISearch { get; set; } = null!;

    public string DeploymentName { get; set; } = null!;

    public string Endpoint { get; set; } = null!;
}