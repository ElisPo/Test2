using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Posani_Elisa_Test2.Entitites;

namespace Posani_Elisa_Test2.BusinessLayer
{
    public class TaskManagement
    {
        public static TaskDef GetNewTask()
        {
            TaskDef newTask = new TaskDef();
            Console.WriteLine("Nome del nuovo Task?");
            newTask.Description = Console.ReadLine();

            Console.WriteLine("Per quando va completato?");
            bool conversionToDateTimeOk;
            do
            {
                conversionToDateTimeOk = DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeTemp);

                if (conversionToDateTimeOk)
                {
                    if (dateTimeTemp < DateTime.Today)
                    {
                        Console.WriteLine("La data di scadenza deve essere un giorno successivo ad oggi!");
                        conversionToDateTimeOk = false;
                    }
                    else
                    {
                        newTask.ExpiryDate = dateTimeTemp;
                    }
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto. Prova di nuovo.");
                }
            } while (conversionToDateTimeOk == false);

            Console.Write("Priorità?\n0 - Bassa\n1 - Media\n2 - Alta\n");
            while (newTask.Priority == -1)
            {
                bool conversionPriorityOk = Int32.TryParse(Console.ReadLine(), out int priority);
                if (conversionPriorityOk)
                    newTask.Priority = priority;

                if (newTask.Priority == -1)
                {
                    Console.WriteLine("Non valido. Riprova.");
                }
            }

            return newTask;
        }

        public static void PrintAllTasks(ArrayList tasks)
        {
            foreach (TaskDef task in tasks)
            {
                string priority = "";
                if (task.Priority == 0)
                    priority = "Bassa";
                else if (task.Priority == 1)
                    priority = "Media";
                else if (task.Priority == 2)
                    priority = "Alta";

                Console.WriteLine(task.Description + " - " + task.ExpiryDate.Date.ToString("d") + " - Priorità: " + priority);
            }
        }

        public static void PrintTask(TaskDef task)
        {
            string priority = "";
            if (task.Priority == 0)
                priority = "Bassa";
            else if (task.Priority == 1)
                priority = "Media";
            else if (task.Priority == 2)
                priority = "Alta";

            Console.WriteLine(task.Description + " - " + task.ExpiryDate.Date.ToString("d") + " - Priorità: " + priority);
        }

        public static void AddNewTask(ref ArrayList allTasks, TaskDef newTask)
        {
            allTasks.Add(newTask);
        }

        public static void DeleteTask(ref ArrayList allTasks, string taskToDelete)
        {
            int iter = 0;
            
            foreach(TaskDef task in allTasks)
            {
                if (task.Description == taskToDelete)
                {
                    allTasks.RemoveAt(iter);
                    break;
                }
                iter++;
            }
        }

        public static void FilterTasks(ArrayList allTasks)
        {
            Console.WriteLine("Vuoi vedere solo gli impegni importanti (2), medi (1) o secondari (0)?");
            bool conversionOk= false;
            int priority=-1;
            while (conversionOk == false)
            {
                conversionOk = Int32.TryParse(Console.ReadLine(), out priority);
                if (priority != 0 && priority != 1 && priority!= 2)
                {
                    conversionOk = false;
                    Console.WriteLine("Non valido");
                }
            }

            foreach(TaskDef task in allTasks)
            {
                if (task.Priority == priority)
                {
                    PrintTask(task);   
                }
            }
        }
    }
}
