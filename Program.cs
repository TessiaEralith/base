using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

//чтение файла
static List<User> bd()
{
    var bd= new List<User>();
    using (StreamReader fstream = new StreamReader("note2.txt"))
{   
        while (true)
        {
            User user = new User();
            string textFromFile = fstream.ReadLine();
            if (textFromFile == null) break;
            user.id = int.Parse(textFromFile.Substring(0,1));
            textFromFile = textFromFile.Substring(2);
            foreach (char i in textFromFile)
            {
                if (i != ' ')
                {   
                    user.login += i;
                    textFromFile = textFromFile.Substring(1);
                }
                else
                {
                    user.password = textFromFile.Substring(1, textFromFile.Length - 2);
                    user.isAdmin = int.Parse(textFromFile.Substring(textFromFile.Length - 1));

                    break;
                }
            }
            bd.Add(user);
        }
    }
    return bd;
}

////запись в файл
static void Write(List<User> list)
{
    using (StreamWriter fstream = new StreamWriter("note2.txt"))
    {
        foreach (var us in list)
        {

            fstream.WriteLine($"{us.id} {us.login} {us.password} {us.isAdmin}");
        }
    }
}

static bool Reg( string log)
{
    List<User> list = bd();
    foreach (var us in list)
    {
        if (us.login == log) return false;
    }
    return true;
 }
//мб эти две функции позже в вынесут в другую библиотеку
static string sing(string log)
{
    List<User> list = bd();
    foreach (var us in list)
    {
        if (us.login == log) return us.password;
    }
    return "неверный логин";
}

//IPHostEntry ipHost = Dns.GetHostEntry("localhost");
//IPAddress ipAddr = ipHost.AddressList[1];
//IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 8080);

//Socket socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//socket.Connect(ipEndPoint);


//String msg;
//while (true)
//{
//    msg = Console.ReadLine();
//    byte[] data = Encoding.UTF8.GetBytes(msg);
//    socket.Send(data);
//}

//socket.Close();
public class User
{
    public string login = "";
    public string password = "";
    public int isAdmin;
    public int id;
};

