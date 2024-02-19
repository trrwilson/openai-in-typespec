using System;
using System.ClientModel.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Official.Assistants;

public enum MessageRole
{
    User,
    Assistant,
    Tool,
}