using System;

public class cardRemovedEventargs: EventArgs
{
    public int cardIndex { get; private set; }

    public cardRemovedEventargs(int CardIndex)
    {
        CardIndex = cardIndex;
    }
}