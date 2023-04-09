using DotnetOmar.Logger;

TestLogger();

static void TestLogger()
{
    var dictionary = new Dictionary<string, object>
    {
        { "name", "value" },
        { "name1", false },
        {
            "name2",
            new Dictionary<string, object>
            {
                { "name", "value" },
                { "name1", "value" },
                { "name2", new[] { 1, 2 } },
                { "name3", "value" },
            }
        },
        { "name3", 241 },
    };

    Logger.LogDictionary(dictionary);

}