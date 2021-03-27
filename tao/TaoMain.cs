using System;
using System.IO;
using System.Configuration;

namespace Tao
{
    class TaoConfigReader
    {
        public static string TaoSaveFilePath = ConfigurationManager.AppSettings["FilePath"];
    }
    class TaoMain
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter an argument.");
                Console.WriteLine("Usage: tao <arg0> <arg1>");
                Console.WriteLine("Possibilities:\nhelp use\nhelp info\ncreate bug\ncreate todo\ncreate log");
                return 1;
            }
            if (args.Length > 2)
            {
                Console.WriteLine("Please enter the correct number of arguments");
                Console.WriteLine("Usage: tao <arg0> <arg1>");
                Console.WriteLine("Possibilities:\nhelp use\nhelp info\ncreate bug\ncreate todo\ncreate log");
                return 1;
            }
            if (args[0] == "help" && args[1] == "use")
            {
                Console.WriteLine("Welcome to TAO - Task Action Operator - v1.0");
                Console.WriteLine("Possibilities:\nhelp use\nhelp info\ncreate bug\ncreate todo\ncreate log");
            }
            if (args[0] == "help" && args[1] == "info")
            {
                Console.WriteLine("Welcome to TAO - Task Action Operator - v1.0");
                Console.WriteLine("Possibilities:\nhelp use\nhelp info\ncreate bug\ncreate todo\ncreate log");
            }
            if (args[0] == "create" && args[1] == "bug")
            {
                TaoBugReport.Begin();
                return 0;
            }
            if (args[0] == "create" && args[1] == "todo")
            {
                TaoTodoReport.Begin();
                return 0;
            }
            if (args[0] == "create" && args[1] == "log")
            {
                TaoLogReport.Begin();
                return 0;
            }
            return 0;
        }
    }
    class TaoBugReport
    {
        public static void Begin()
        {
            int tao_id = TaoRand.TaoGenRandom(100000, 999999);
            string tao_priority;
            int tao_date;
            string tao_project;
            string tao_description;

            Console.WriteLine("\n\nEnter a Bug Priority: ");
            tao_priority = Console.ReadLine();

            Console.WriteLine("Enter a Bug Found Date: ");
            tao_date = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Project: ");
            tao_project = Console.ReadLine();

            Console.WriteLine("Enter a Bug Description: ");
            tao_description = Console.ReadLine();

            string tao_create_json =
            "{\n" +
            " \"id\":" + tao_id + ",\n" +
            " \"priority\":" + "\"" + tao_priority + "\"" + ",\n" +
            " \"date\":" + tao_date + ",\n" +
            " \"project\":" + "\"" + tao_project + "\"" + ",\n" +
            " \"description\":" + "\"" + tao_description + "\"" +
            "\n}";

            File.WriteAllText(TaoConfigReader.TaoSaveFilePath + "TAO-" + "B" + tao_id, tao_create_json);
            if (File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "B" + tao_id))
            {
                Console.WriteLine("\nTAO: " + "TAO-" + "B" + tao_id + " created.");
            }
            if (!File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "B" + tao_id))
            {
                Console.WriteLine("\nTAO ERROR: File creation failed.");
            }
        }
    }
    class TaoTodoReport
    {
        public static void Begin()
        {
            int tao_id = TaoRand.TaoGenRandom(100000, 999999);
            string tao_priority;
            string tao_description;

            Console.WriteLine("\n\nEnter a Priority: ");
            tao_priority = Console.ReadLine();

            Console.WriteLine("Enter a Todo Description: ");
            tao_description = Console.ReadLine();

            string tao_create_json =
            "{\n" +
            " \"id\":" + tao_id + ",\n" +
            " \"priority\":" + "\"" + tao_priority + "\"" + ",\n" +
            " \"description\":" + "\"" + tao_description + "\"" +
            "\n}";

            File.WriteAllText(TaoConfigReader.TaoSaveFilePath + "TAO-" + "T" + tao_id, tao_create_json);
            if (File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "T" + tao_id))
            {
                Console.WriteLine("\nTAO: " + "TAO-" + "T" + tao_id + " created.");
            }
            if (!File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "T" + tao_id))
            {
                Console.WriteLine("\nTAO ERROR: File creation failed.");
            }
        }
    }
    class TaoLogReport
    {
        public static void Begin()
        {
            int tao_id = TaoRand.TaoGenRandom(100000, 999999);
            string tao_description;

            Console.WriteLine("Enter a Log Description: ");
            tao_description = Console.ReadLine();

            string tao_create_json =
            "{\n" +
            " \"id\":" + tao_id + ",\n" +
            " \"description\":" + "\"" + tao_description + "\"" +
            "\n}";

            File.WriteAllText(TaoConfigReader.TaoSaveFilePath + "TAO-" + "L" + tao_id, tao_create_json);
            if (File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "L" + tao_id))
            {
                Console.WriteLine("\nTAO: " + "TAO-" + "L" + tao_id + " created.");
            }
            if (!File.Exists(TaoConfigReader.TaoSaveFilePath + "TAO-" + "L" + tao_id))
            {
                Console.WriteLine("\nTAO ERROR: File creation failed.");
            }
        }
    }
    class TaoRand
    {
        private static readonly Random tao_rand = new Random();
        public static int TaoGenRandom(int min, int max)
        {
            lock (tao_rand)
            {
                return tao_rand.Next(min, max);
            }
        }
    }
}