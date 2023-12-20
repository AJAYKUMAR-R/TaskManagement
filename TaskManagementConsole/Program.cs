using DataAcessLayer.Classes.designPattern;
using LoginLayer.Classes.LoginConsole;

var isAuthenticated  = false;
var isContinue = false;
var dI = new DependecyInjection();
//Registering the Dependency
dI.Register<ISingleton, UserData>();

var data = dI.Resolve<ISingleton>();

while (!isAuthenticated)
{
    Console.WriteLine("Enter the username and Password");
    var username = Console.ReadLine();
    var password = Console.ReadLine();
    var login = new BLLogin(data).Authentication(username, password);
    if (login)
    {
        isAuthenticated = true;
    }
    else
    {
        isAuthenticated = false;
    }
}