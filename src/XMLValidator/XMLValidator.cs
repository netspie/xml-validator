namespace XMLValidator;

public static class XMLValidator
{
    public const string OpeningTagStartStr = "<";
    public const string ClosingTagStartStr = "</";
    public const char TagEndStr = '>';

    public static bool IsXML(this string xml)
    {
        if (!xml.StartsWithTag(OpeningTagStartStr, startIndex: 0, out var endIndex, out var openingTagName))
            return false;

        var tagNameStack = new Stack<string>([openingTagName]);

        int i = endIndex + 1;
        while (i < xml.Length)
        {
            if (xml.StartsWithTag(ClosingTagStartStr, startIndex: i, out endIndex, out var closingTagName))
            {
                openingTagName = tagNameStack.Pop();
                if (openingTagName != closingTagName)
                    return false;

                i = endIndex + 1;
            }
            else
            if (xml.StartsWithTag(OpeningTagStartStr, startIndex: i, out endIndex, out openingTagName))
            {
                tagNameStack.Push(openingTagName);
                i = endIndex + 1;
            }
            else
            {
                i++;
            }
        }

        return tagNameStack.Count == 0 && xml.Last() is TagEndStr;
    }

    public static bool StartsWithTag(this string xml, string tagOpening, int startIndex, out int endIndex, out string name)
    {
        endIndex = -1;
        name = "";

        if (!StartsWithTagOpening(xml, startIndex, out endIndex))
            return false;

        if (startIndex + 1 < xml.Length && xml[startIndex + 1] == TagEndStr)
        {
            endIndex = -1;
            return false;
        }

        for (int i = endIndex + 1; i < xml.Length; i++)
        {
            if (StartsWithTagOpening(xml, startIndex: i, out var _))
            {
                endIndex = -1;
                return false;
            }

            if (xml[i] == TagEndStr)
            {
                endIndex = i;
                name = xml[(startIndex + tagOpening.Length)..endIndex];

                return true;
            }
        }

        return false;

        bool StartsWithTagOpening(string str, int startIndex, out int endIndex)
        {
            bool startsWithTagOpening = 
                xml.Length - startIndex >= tagOpening.Length &&
                xml.Substring(startIndex, tagOpening.Length) == tagOpening;

            endIndex = startsWithTagOpening ? startIndex + tagOpening.Length : -1;

            return startsWithTagOpening;
        }
    }
}