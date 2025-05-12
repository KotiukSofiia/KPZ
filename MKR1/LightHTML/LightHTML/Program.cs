using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LightHTML
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
            string content = await DownloadTextFile(url);

            string[] lines = content
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Take(50)
                .ToArray();

            GC.Collect();
            long memoryBeforeWithoutFlyweight = GC.GetTotalMemory(true);
            List<LightNode> htmlElementsWithoutFlyweight = CreateHTMLWithoutFlyweight(lines);
            long memoryAfterWithoutFlyweight = GC.GetTotalMemory(true);

            Console.WriteLine($"Memory used without Flyweight: {memoryAfterWithoutFlyweight - memoryBeforeWithoutFlyweight} bytes");

            GC.Collect();
            long memoryBeforeWithFlyweight = GC.GetTotalMemory(true);
            List<LightNode> htmlElementsWithFlyweight = CreateHTMLWithFlyweight(lines);
            long memoryAfterWithFlyweight = GC.GetTotalMemory(true);

            Console.WriteLine($"Memory used with Flyweight: {memoryAfterWithFlyweight - memoryBeforeWithFlyweight} bytes");

            Console.WriteLine($"Number of cached Flyweight nodes: {htmlElementsWithFlyweight.Count}");

            Console.WriteLine("\n--- Depth-First Traversal ---");
            var dfs = new DepthFirstIterator();
            foreach (var node in dfs.Traverse(htmlElementsWithFlyweight.First()))
            {
                Console.WriteLine(node.GetOuterHtml(1));
            }

            Console.WriteLine("\n--- Breadth-First Traversal ---");
            var bfs = new BreadthFirstIterator();
            foreach (var node in bfs.Traverse(htmlElementsWithFlyweight.First()))
            {
                Console.WriteLine(node.GetOuterHtml(1));
            }

            Console.WriteLine($"\nMemory used by HTML tree: {memoryAfterWithFlyweight - memoryBeforeWithFlyweight} bytes");
            Console.ReadLine();
        }

        static async Task<string> DownloadTextFile(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(url);
                return content;
            }
        }

        static List<LightNode> CreateHTMLWithoutFlyweight(string[] lines)
        {
            List<LightNode> htmlElements = new List<LightNode>();

            foreach (var line in lines)
            {
                LightElementNode node;

                if (line.Length == 0)
                    continue;

                if (line.StartsWith(" "))
                {
                    node = new LightElementNode("blockquote");
                }
                else if (line.Length <= 20)
                {
                    node = new LightElementNode("h2");
                }
                else if (line.Equals(lines[0]))
                {
                    node = new LightElementNode("h1");
                }
                else
                {
                    node = new LightElementNode("p");
                }

                node.AddChild(new LightTextNode(line));
                htmlElements.Add(node);
            }

            return htmlElements;
        }

        static List<LightNode> CreateHTMLWithFlyweight(string[] lines)
        {
            HTMLNodeFactory nodeFactory = new HTMLNodeFactory();
            List<LightNode> htmlElements = new List<LightNode>();

            foreach (var line in lines)
            {
                LightElementNode node;

                if (line.Length == 0)
                    continue;

                if (line.StartsWith(" "))
                {
                    node = nodeFactory.GetNode("blockquote");
                }
                else if (line.Length <= 20)
                {
                    node = nodeFactory.GetNode("h2");
                }
                else if (line.Equals(lines[0]))
                {
                    node = nodeFactory.GetNode("h1");
                }
                else
                {
                    node = nodeFactory.GetNode("p");
                }

                node.AddChild(new LightTextNode(line));
                htmlElements.Add(node);
            }

            return htmlElements;
        }
    }
}
