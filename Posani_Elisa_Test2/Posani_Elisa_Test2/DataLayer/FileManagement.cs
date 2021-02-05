using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Posani_Elisa_Test2.Entitites;

namespace Posani_Elisa_Test2.DataLayer
{
    public class FileManagement
    {
        public static string path { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Corso/Week2/Posani_Test2/TasksList.txt");
        public static ArrayList GetTasksFromFile()
        {
            ArrayList tasks = new ArrayList { };
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader fileToRead = File.OpenText(path))
                    {
                        fileToRead.ReadLine();

                        while (!fileToRead.EndOfStream)
                        {
                            string[] lineSplit = fileToRead.ReadLine().Split(",");
                            DateTime.TryParse(lineSplit[1], out DateTime expiry);
                            Int32.TryParse(lineSplit[2], out int priority);
                            TaskDef newTask = new TaskDef();
                            newTask.Description = lineSplit[0];
                            newTask.ExpiryDate = expiry;
                            newTask.Priority = priority;
                            tasks.Add(newTask);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return tasks;
        }

        public static void WriteTasksInFile(ArrayList allTasks)
        {
            if (File.Exists(path))
            {
                using (StreamWriter fileToWrite = File.CreateText(path))
                {
                    fileToWrite.WriteLine("#Cosa devi fare,entro quando,priorità da 0 a 2");
                    foreach(TaskDef task in allTasks)
                    {
                        fileToWrite.WriteLine(task.Description + "," + task.ExpiryDate.Date.ToString("d") + "," + task.Priority.ToString());
                    }
                }
            }
        }
    }
}
