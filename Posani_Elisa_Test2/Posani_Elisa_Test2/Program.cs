using System;
using Posani_Elisa_Test2.Entitites;
using Posani_Elisa_Test2.BusinessLayer;
using System.Collections;
using Posani_Elisa_Test2.DataLayer;

namespace Posani_Elisa_Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList allTasks = FileManagement.GetTasksFromFile();

            Console.WriteLine("Ciao! Sono il tuo assistente. Cosa vuoi fare? Ho già letto la tua agenda e imparato i tuoi mpegni futuri.");
            Console.Write("0 - Dimmi i miei impegni.\n1 - Inserisci un nuovo impegno.\n2 - Elimina un impegno.\n3 - Visualizza solo gli impegni con una data priorità.\n4 - Aggiorna la mia agenda.");
            bool conversionOk = false;
            int scelta = -1;
            while (conversionOk == false)
            { 
                conversionOk = Int32.TryParse(Console.ReadLine(), out scelta);
                if (scelta!= 0 && scelta != 1 && scelta != 2 && scelta != 3 && scelta != 4)
                {
                    Console.WriteLine("Riprova, non valido.");
                    conversionOk = false;
                }  
                if (conversionOk == false)
                {
                    Console.WriteLine("Non valido.");
                } 
            }

            switch (scelta)
            {
                case 0:
                    TaskManagement.PrintAllTasks(allTasks);
                    break;
                case 1:
                    TaskDef newTask = TaskManagement.GetNewTask();
                    TaskManagement.AddNewTask(ref allTasks, newTask);
                    break;
                case 2:
                    string tasktodelete = "andrebbe preso da terminale ma non faccio in tempo";
                    TaskManagement.DeleteTask(ref allTasks, tasktodelete);
                    break;
                case 3:
                    TaskManagement.FilterTasks(allTasks);
                    break;
                case 4:
                    FileManagement.WriteTasksInFile(allTasks);
                    break;
                default:
                    break;
            }
        }
    }
}
