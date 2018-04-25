using System;
namespace Nonogram
{
    public static class Utilities
    {

        public static int GetClueLength(Clues clues, int startAt = 0, int endAt = -1)
        {
            if (endAt == -1)
            {
                endAt = clues.GetClueCount()-1;
            }
            if (endAt > clues.GetClueCount()-1)
            {
                endAt = clues.GetClueCount() - 1;
            }
            if (startAt > endAt)
            {
                return 0;
            }
            int totalLength = 0;
            string lastColour = "";
            for (int i = startAt; i <= endAt; i++)
            {
                totalLength += clues.getClue(i).Number;
                if (lastColour == clues.getClue(i).Colour)
                {
                    totalLength += 1;
                }
                lastColour = clues.getClue(i).Colour;
            }
            return totalLength;
        }


    }
}
