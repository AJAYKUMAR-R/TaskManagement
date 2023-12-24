using BusinessLayer.Classes.businessLogic;
using BusinessLayer.Classes.designPattern.factoryDesignPattern;
using DataAcessLayer.Classes.designPattern.dependencyContainers;
using DataAcessLayer.Classes.designPattern.singletonClas;
using DataAcessLayer.Classes.dtoConsole;
using LoginLayer.Classes.LoginConsole;
using TaskManagementConsole.Utlis;

var isAuthenticated  = false;
var isContinue = false;
var dI = new DependecyInjection();
//Registering the Dependency
dI.Register<IUserData, UserData>();
dI.Register<IUserTask, TaskCollection>();

var userlist = dI.Resolve<IUserData, UserData>();
var tasklist = dI.Resolve<IUserTask, TaskCollection>();
string username = string.Empty;
while (!isAuthenticated)
{
    Console.WriteLine("Enter the username");
    username = Console.ReadLine();
    Console.WriteLine("Enter the Password");
    var password = Console.ReadLine();
    var login = new BLLogin(userlist).isAccessible(username, password);
    if (login)
    {
        Console.Clear();
        isAuthenticated = true;
    }
    else
    {
        Console.Clear();
        isAuthenticated = false;
    }
}

//Defing what they want to Do
//do you wan to Add or read or delete the Task
Console.WriteLine(@"Enter what Type of Modification you want to do
Read - read the the Task which is Incomplete -- Type 0
Create - create the new Task -- Type 1
Update - Update the Task Details -- Type 2
Delete - Delete the Task -- Type 3
");
DrawTable.Draw(tasklist.UserTask);
bool isExist = false;
var userAction = Console.ReadLine();
while (!isExist)
{
    var type = int.Parse(userAction);
    if (type == 0)
    {
        var isQuit = false;
        var read = new TaskReadFactory(username).createRead(0, userlist, tasklist);
        while (!isQuit)
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
        Console.WriteLine(@"Do you want Quit or Continue Modifying if yes click 0 or No click 1");
        if (bool.Parse(Console.ReadLine()))
        {
            continue;
        }
        else
        {
            break;
        }
        //}else if (type == 1)
        //{
        //    var read = new TaskReadFactory().createRead(0, userlist, tasklist);
        //    Console.WriteLine(@"Enter the Columns one by one by providing space
        //    between each such as Description,DueData,Status
        //    ");
        //    var input = Console.ReadLine();
        //    if (input != null)
        //    {
        //        int lastTask = tasklist.GetInstance.UserTask.Count;
        //        var task = Serlizer.Serialize(input, lastTask);
        //        read.
        //    }
        //}
    }
}