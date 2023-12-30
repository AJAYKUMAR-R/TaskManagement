using BusinessLayer.Classes.businessLogic;
using BusinessLayer.Classes.designPattern.factoryDesignPattern;
using DataAcessLayer.Classes.designPattern.dependencyContainers;
using DataAcessLayer.Classes.designPattern.singletonClas;
using DataAcessLayer.Classes.dtoConsole;
using LoginLayer.Classes.LoginConsole;
using TaskManagementConsole.Utlis;


var dI = new DependecyInjection();
//Registering the Dependency
dI.Register<IUserData, UserData>();
dI.Register<IUserTask, TaskCollection>();

var userlist = dI.Resolve<IUserData, UserData>();
var tasklist = dI.Resolve<IUserTask, TaskCollection>();
string username = string.Empty;
while (true)
{
    Console.WriteLine("Enter the username");
    username = Console.ReadLine();
    Console.WriteLine("Enter the Password");
    var password = Console.ReadLine();
    var login = new BLLogin(userlist).isAccessible(username, password);
    StatusCheck status = new StatusCheck(tasklist);
    Thread thread = new Thread(status.checkStatus);
    thread.Start();
    //thread.Join();
    if (login)
    {
        Console.Clear();
        break;
    }
    else
    {
        Console.Clear();
        continue;
    }
}

//Defing what they want to Do

while (true)
{
        //do you wan to Add or read or delete the Task
        Console.WriteLine(@"Enter what Type of Modification you want to do
    Read - read the the Task which is Incomplete -- Type 0
    Create - create the new Task -- Type 1
    Update - Update the Task Details -- Type 2
    Delete - Delete the Task -- Type 3
    ");
    DrawTable.Draw(tasklist.UserTask);
    var userAction = Console.ReadLine();
    var type = int.Parse(userAction);
    if (type == 0)
    { 
        var read = new TaskReadFactory(username).createRead(0, userlist, tasklist);
        while (true)
        {
            Console.WriteLine(@"Search using Status 0 - deleted,1 - Achived ,2 - Inprogress");
            var input = int.Parse(Console.ReadLine());
            Status status = (Status)input;
            var list = read.ReadTaskDetails(status);
            DrawTable.Draw(list);
            Console.WriteLine(@"Do you want Quit or Continue Searching if yes click 0 or No click 1");
            bool flag = Console.ReadLine() == "0" ? false : true;
            if (flag)
            {
                continue;
            }
            else
            {
                break;
            }

        }
        continue;
    }
   
    else if (type == 1)
    {
        while (true)
        {
            var create = new TaskCreateFactory(username).createTask(0, userlist, tasklist);
            Console.WriteLine(@"Enter the Columns one by one by providing space
            between each such as Description,DueData,Status
            ");
            var input = Console.ReadLine();

            if (input != null)
            {
                int lastTask = tasklist.UserTask.Count;
                var task = Serlizer.Serialize(input, lastTask);
                create.CreateTasks(task, out bool isActive);
                if (isActive)
                {
                    Console.WriteLine("Task has been Created Successfully");
                }
                else
                {
                    Console.WriteLine("User is not Active");
                }
                Console.WriteLine(@"Do you want Quit or Continue Creating if yes click 1 or No click 0");
                bool flag = Console.ReadLine() == "0" ? false : true;
                if (flag)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            continue;
        }
    }
    else if (type == 2)
    {
        while (true)
        {
            Console.WriteLine("Enter the Task Id first");
            int taskId = Convert.ToInt32(Console.ReadLine());
            var update = new TaskUpdateFactory(username).createUpdate(0, userlist, tasklist);
            Console.WriteLine(@"Enter the Field you want to Update 
            Task Description - 0,
            Task Due Date    - 1,
            Task Status      - 2
            with Value Example 1,17/02/19
            or 2,InProgress
            ");
            var input = Console.ReadLine();

            if (input != null)
            {

                var isDeleted = update.UpdateTaskDetails(taskId, input);
                if (isDeleted)
                {
                    Console.WriteLine("Task has been Updated Successfully");
                }
                else
                {
                    Console.WriteLine("Task Not Found");
                }
                Console.WriteLine(@"Do you want Quit or Continue Updating if yes click 0 or No click 1");
                bool flag = Console.ReadLine() == "0" ? false : true;
                if (flag)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

        }
    }
    else if (type == 3)
    {
        while(true)
        {
            var delete = new TaskDeleteFactory(username).createDelete(0, userlist, tasklist);
            Console.WriteLine(@"Enter the Id to Delete the Task if you don't know Id 
              Just Find it by Searching the Progress Tasks
            ");
            var input = Console.ReadLine();

            if (input != null)
            {
                int number = int.Parse(input);
                var isDeleted = delete.DeleteTaskDetails(number);

                if (isDeleted)
                {
                    Console.WriteLine("Task has been Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Task Not Found");
                }
                Console.WriteLine(@"Do you want Quit or Continue Deleting if yes click 0 or No click 1");
                bool flag = Console.ReadLine() == "0" ? false : true;
                if (flag)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}