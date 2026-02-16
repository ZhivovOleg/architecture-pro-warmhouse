namespace SmartHomeBFF;

public class CommandDto
{
    public required int CommandType { get; set; }

    public required string CommandValue { get; set; }
}