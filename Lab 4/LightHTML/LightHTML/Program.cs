using System;
using System.Linq;
using System.Threading.Tasks;

namespace LightHTML
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
            string content = await DownloadTextFile(url);

            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Take(5).ToArray();

            HTMLNodeFactory nodeFactory = new HTMLNodeFactory();
            List<LightNode> htmlElements = new List<LightNode>();
            foreach (var line in lines)
            {
                LightElementNode node = nodeFactory.GetNode("p");
                node.AddChild(new LightTextNode(line));

                node.AddEventListener("click", () => Console.WriteLine($"Clicked on: {line}"));
                node.AddEventListener("mouseover", () => Console.WriteLine($"Mouse over: {line}"));

                htmlElements.Add(node);
            }

            foreach (var element in htmlElements)
            {
                Console.WriteLine(element.GetOuterHtml());
            }

            Console.WriteLine("\nSimulating events...\n");
            foreach (var element in htmlElements)
            {
                element.TriggerEvent("click");
                element.TriggerEvent("mouseover"); 
            }

            Console.ReadLine();
        }

        static async Task<string> DownloadTextFile(string url)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
