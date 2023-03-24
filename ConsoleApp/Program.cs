using DotnetOmar.Logger;

TestLogger();


static void TestLogger()
{
    var dictionary = new Dictionary<string, string>
    {
        { "name", "value" },
        { "name1", "value" },
        { "name2", "value" },
        { "name3", "value" },
    };

    Logger.LogDictionary(dictionary);
}