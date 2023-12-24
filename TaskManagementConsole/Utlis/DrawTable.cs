using DataAcessLayer.Classes.designPattern.singletonClas;
using DataAcessLayer.Classes.dtoConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementConsole.Utlis
{
    public class DrawTable
    {
        public static void Draw(IEnumerable<TaskInformation> userData)
        {
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("| TaskID | TaskDescription | Status | DueDate |");
            Console.WriteLine("|_____________________________________________|");
            foreach (var item in userData)
            {
                Console.WriteLine($"| {item.TaskId} | {item.TaskDescription} | {item.Status} | {item.DueDate} |");
                Console.WriteLine("|_____________________________________________|");
            }
           
        }
    }
}
