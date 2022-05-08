using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Task4._1
{
    class Program
    {
        private static void BackupsJsonProcessing(Bridge instance)
        {
            string[] backups=null;
            if (File.Exists(@"backups.json"))
                backups = File.ReadAllLines(@"backups.json");
            else
                return;
            Bridge.Instance.Counter = 0;
            for (int i = 0; i < backups.Length; i++)
            {
                Bridge.Instance = null;
                Bridge.Instance.Counter = 0;
                Bridge.Instance = JsonConvert.DeserializeObject<Bridge>(backups[i]);
                Bridge.numbers.Add(Bridge.Instance.Counter);
                Bridge.paths.Add(Bridge.Instance.Path);
                Bridge.times.Add(Bridge.Instance.time);
            }
        }
        static void Main(string[] args)//"/o" — observe,
                                       //"/r" — rollback.
        {
            int Counter = 0;
            FileInfo fileInfo;
            using var watcher = new FileSystemWatcher(@"..");//bin\Debug
                                                             //(@"G:\Программы");
            if (args.Length == 0)//0 arguments.
                return;
            //try
            //{
            switch (args[0])
            {
                case "/o":
                    DirectoryInfo di = new DirectoryInfo(@"..\Backups");
                    if (!di.Exists)
                        Directory.CreateDirectory((@"..\Backups"));
                    FileInfo[] backups = di.GetFiles("*.txt");
                    Counter = backups.Length - 1;

                    BackupsJsonProcessing(Bridge.Instance);

                    watcher.NotifyFilter = NotifyFilters.Attributes
                                         | NotifyFilters.CreationTime
                                         | NotifyFilters.DirectoryName
                                         | NotifyFilters.FileName
                                         | NotifyFilters.LastAccess
                                         | NotifyFilters.LastWrite
                                         | NotifyFilters.Security
                                         | NotifyFilters.Size;

                    watcher.Changed += OnChanged;
                    watcher.Created += OnCreated;
                    watcher.Deleted += OnDeleted;
                    watcher.Renamed += OnRenamed;
                    watcher.Error += OnError;

                    watcher.Filter = "*.txt";
                    watcher.IncludeSubdirectories = true;
                    watcher.EnableRaisingEvents = true;

                    Console.WriteLine("Press enter to exit.");
                    Console.ReadLine();
                    //Console.WriteLine(Counter.Counter);
                    //Debug.WriteLine(Counter.Counter);
                    break;

                case "/r":
                    //DateTime dateValue = new DateTime(2022, 2, 25, 22, 0, 0);
                    int day, month, year, hours, minutes, seconds;
                    Console.WriteLine("Enter the date for rollback:");
                    Console.WriteLine("Day:");
                    int.TryParse(Console.ReadLine(), out day);
                    Console.WriteLine("Month:");
                    int.TryParse(Console.ReadLine(), out month);
                    Console.WriteLine("Year:");
                    int.TryParse(Console.ReadLine(), out year);
                    Console.WriteLine("Hours:");
                    int.TryParse(Console.ReadLine(), out hours);
                    Console.WriteLine("Minutes:");
                    int.TryParse(Console.ReadLine(), out minutes);
                    Console.WriteLine("Seconds:");
                    int.TryParse(Console.ReadLine(), out seconds);
                    DateTime dateValue = new DateTime(year,month,day,hours,minutes,seconds);

                    BackupsJsonProcessing(Bridge.Instance);

                    var paths = Bridge.paths.Distinct();
                    var dates = Bridge.times.Where(d => d <= dateValue);
                    List<string> pathsList = paths.ToList();//Lists have an indexator.
                    List<DateTime> datesList = dates.ToList();
                    int findIndex = 0;
                    int latest = -1;
                    for (int i = 0; i < pathsList.Count(); i++)
                    {
                        for (int j = 0; j<Bridge.paths.Count(); j++)
                        {
                            findIndex = Bridge.paths.FindIndex(findIndex, delegate (string s)
                               {
                                   return s == pathsList[i];
                               }
            );
                            if(findIndex!=-1)
                                findIndex = Bridge.times.FindIndex(findIndex, delegate (DateTime d)
                                {
                                    return d <= dateValue;
                                }
            );
                            if (findIndex != -1)
                                latest = findIndex;
                            if (findIndex == -1)
                            {
                                fileInfo = null;
                                fileInfo = new FileInfo($"..\\Backups\\{latest}.txt");
                                if(latest!=-1)
                                fileInfo.CopyTo(Bridge.paths[latest], true);
                                latest = -1;
                                findIndex = 0;
                                break;
                            }
                            findIndex++;
                        }
                    }
                    break;
                default:
                    //Default:
                    break;
            }
        }
        //catch
        //{}//Other argument.
        //Null:
        //    for (; ; )break;

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            string pattern = @"\.\.\\Backups\\";
            Bridge.fileInfo = null;
            Bridge.fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine(Regex.IsMatch(e.FullPath, pattern));
            if (Bridge.fileInfo.Exists && !Regex.IsMatch(e.FullPath, pattern))
            {
                for (double i = 0; i < 1000; i += 0.00001) ;
                Bridge.fileInfo.CopyTo($"..\\Backups\\{Bridge.Instance.Counter}.txt", true);
                Bridge.Instance.Counter++;
                Bridge.numbers.Add(Bridge.Instance.Counter);
                Bridge.paths.Add(e.FullPath);
                Bridge.Instance.Path = Bridge.paths[^1];
                Bridge.times.Add(DateTime.Now);
                Bridge.Instance.time = Bridge.times[^1];
                Bridge.ActionAllText();
            }
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            Console.WriteLine(JsonConvert.SerializeObject(Bridge.Instance));
        }
        private static void OnCreated(object sender,FileSystemEventArgs e)
        {
            string pattern = @"\.\.\\Backups\\";
            Bridge.fileInfo = null;
            Bridge.fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine(Regex.IsMatch(e.FullPath, pattern));
            if (Bridge.fileInfo.Exists && !Regex.IsMatch(e.FullPath, pattern))
            {
                for (double i = 0; i < 1000; i += 0.00001) ;
                Bridge.fileInfo.CopyTo($"..\\Backups\\{Bridge.Instance.Counter}.txt", true);
                Bridge.Instance.Counter++;
                Bridge.numbers.Add(Bridge.Instance.Counter);
                Bridge.paths.Add(e.FullPath);
                Bridge.Instance.Path = Bridge.paths[^1];
                Bridge.times.Add(DateTime.Now);
                Bridge.Instance.time = Bridge.times[^1];
                Bridge.ActionAllText();
            }
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e) =>
            Console.WriteLine($"Deleted: {e.FullPath}");

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
            }
    }
}
