using OpenAI.Official.Chat;
using System;

namespace OpenAI.Official.Assistants;

public partial class RunError
{
    public RunErrorCode ErrorCode { get; }
    public string ErrorMessage { get; }

    internal RunError(RunErrorCode errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    internal RunError(Internal.RunObjectLastError internalError)
    {
        if (internalError.Code != null)
        {
            ErrorCode = new(internalError.Code.ToString());
        }
        ErrorMessage = internalError.Message;
    }
}
