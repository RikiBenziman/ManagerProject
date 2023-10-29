// See https://aka.ms/new-console-template for more information

using UsersServer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UsersServer;

class Progrom
    {
    
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
       int InsertData= dataAccess.InsertData("Data Source = SRV2\\PUPILS; Initial Catalog = AdoNetUsersl; Integrated Security = True");
        Console.WriteLine(InsertData);
        int InsertProduct = dataAccess.InsertProduct("Data Source = SRV2\\PUPILS; Initial Catalog = AdoNetUsersl; Integrated Security = True");
        Console.WriteLine(InsertProduct);
         dataAccess.readData("Data Source = SRV2\\PUPILS; Initial Catalog = AdoNetUsersl; Integrated Security = True");
       

    }
       
    }


