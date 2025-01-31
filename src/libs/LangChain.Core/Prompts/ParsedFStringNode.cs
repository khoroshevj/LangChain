namespace LangChain.Prompts;

public abstract class ParsedFStringNode
{
    public string Type { get; }

    protected ParsedFStringNode(string type)
    {
        Type = type;
    }
}