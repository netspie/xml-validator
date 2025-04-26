namespace XMLValidator.Tests;

public class XMLValidatorTests
{
    [TestCaseSource(nameof(XmlTestCases))]
    public void IsXML(string input, bool expectedResult)
    {
        Assert.That(input.IsXML(), Is.EqualTo(expectedResult));
    }

    [TestCase("<>", 0, false, -1)]
    [TestCase("</>", 0, true, 2)]
    [TestCase("<xml>", 0, true, 4)]
    [TestCase("<xml>x", 0, true, 4)]
    [TestCase("x<xml>", 0, false, -1)]
    [TestCase("x<xml>x", 1, true, 5)]
    public void GetNextXMLTag_Opening(string input, int startIndex, bool expectedResult, int expectedEndIndex)
    {
        int endIndex;
        bool result = input.StartsWithTag(tagOpening: "<", startIndex: startIndex, out endIndex, out var _);

        Assert.That(result, Is.EqualTo(expectedResult));
        Assert.That(endIndex, Is.EqualTo(expectedEndIndex));
    }

    [TestCase("</xml>", 0, true, 5)]
    [TestCase("</xml>x", 0, true, 5)]
    [TestCase("x</xml>", 0, false, -1)]
    [TestCase("x</xml>x", 1, true, 6)]
    [TestCase(">x</xml>x", 2, true, 7)]
    public void GetNextXMLTag_Closing(string input, int startIndex, bool expectedResult, int expectedEndIndex)
    {
        int endIndex;
        bool result = input.StartsWithTag(tagOpening: "</", startIndex: startIndex, out endIndex, out var _);

        Assert.That(result, Is.EqualTo(expectedResult));
        Assert.That(endIndex, Is.EqualTo(expectedEndIndex));
    }

    private static IEnumerable<TestCaseData> XmlTestCases()
    {
        foreach (var line in File.ReadLines("XmlTestCases.txt"))
        {
            var parts = line.Split(',', 2);
            if (parts.Length == 2)
            {
                var input = parts[0];
                var expected = bool.Parse(parts[1]);
                yield return new TestCaseData(input, expected);
            }
        }
    }
}