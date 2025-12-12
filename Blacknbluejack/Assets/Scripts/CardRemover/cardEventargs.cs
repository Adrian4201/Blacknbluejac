using System;

public class cardEventargs : EventArgs
{
    public int cardIndex { get; private set; }

    public cardEventargs(int CardIndex)
    {
        cardIndex = CardIndex;
    }
}