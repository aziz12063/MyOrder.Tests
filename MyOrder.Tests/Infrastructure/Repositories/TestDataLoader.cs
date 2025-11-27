using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MyOrder.Tests.Infrastructure.Repositories;

public static class TestDataLoader
{
    public static string BaseDataPath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\Infrastructure\Data");

    public static T LoadJsonFromFile<T>(string fileName)
    {
        var fullPath = Path.Combine(BaseDataPath, fileName);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Test JSON file not found: {fullPath}");

        var json = File.ReadAllText(fullPath);

        return JsonConvert.DeserializeObject<T>(json);

    }
}
