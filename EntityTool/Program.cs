using System;
using System.IO;

class Program
{

    static void IService(string entity, string basePath)
    {
        string serviceContent = $@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{{
    public interface I{entity}Service
    {{
    }}
}}
";

        string entityPath = Path.Combine(basePath, "Business", "Abstract", $"I{entity}Service.cs");
        File.WriteAllText(entityPath, serviceContent);
    }


    static void Manager(string entity, string basePath)
    {
        string serviceContent = $@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{{
    public class {entity}Manager : I{entity}Service
    {{
    }}
}}
";

        string entityPath = Path.Combine(basePath, "Business", "Concrete", $"{entity}Manager.cs");
        File.WriteAllText(entityPath, serviceContent);
    }




    static void EntityLayer(string entity, string basePath)
    {
        string entityContent = $@"using Core.Entities;

 namespace Entities.Concrete
{{
     public class {entity} : IEntity
     {{
         public int Id {{ get; set; }}

     }}
}}";

        string entityPath = Path.Combine(basePath, "Entities", "Concrete", $"{entity}.cs");
        File.WriteAllText(entityPath, entityContent);
    }



    static void InterfaceLayer(string entity, string basePath)
    {
        string interfaceContent = $@"using Core.DataAccess;
using Entities.Concrete;
using Core.DataAccess;

namespace DataAccess.Abstract
{{
     public interface I{entity}Dal : IEntityRepository<{entity}>
    {{
    }}
}}";


        string interfacePath = Path.Combine(basePath, "DataAccess", "Abstract", $"I{entity}Dal.cs");
        File.WriteAllText(interfacePath, interfaceContent);
    }




    static void EfLayer(string entity, string context, string basePath)
    {
        string efContent = $@"using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{{
     public class Ef{entity}Dal : EfEntityRepositoryBase<{entity}, {context}>, I{entity}Dal
    {{
    }}
}}";



        string efPath = Path.Combine(basePath, "DataAccess", "Concrete", "EntityFramework", $"Ef{entity}Dal.cs");
        File.WriteAllText(efPath, efContent);
    }


     static void CreateDataAccessFiles(string basePath, string context)
    {
        string[] filePaths = Directory.GetFiles(basePath + "\\Entities\\Concrete");


        foreach (string filePath in filePaths)
        {
            string entity = Path.GetFileNameWithoutExtension(filePath);
            InterfaceLayer(entity,basePath);
            EfLayer(entity, context,basePath);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{entity} ile ilgili 2 dosya oluşturuldu!");
        }
    }


    static void CreateBusinessFiles(string basePath, string context)
    {
        string[] filePaths = Directory.GetFiles(basePath + "\\Entities\\Concrete");


        foreach (string filePath in filePaths)
        {
            string entity = Path.GetFileNameWithoutExtension(filePath);
            IService(entity, basePath);
            Manager(entity, basePath);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{entity} ile ilgili 2 dosya oluşturuldu!");
        }
    }



    static void Main()
    {
        string entity = "";
        string context;
        string chosen;
        string basePath;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("--Entity Dosyaları Entities/Concrete--\n--IEntityDal dosyaları DataAccess/Abstract--\n--EfEntityDosyaları DataAccess/Concrete/EntityFramework--\n--Business Dosyaları Business/Abstract && Business/Concrete");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Entity dosyaları için 1\nDataAccess dosyaları için 2\nBusiness Dosyaları için 3\nHepsini hazırlamak için 4");
        Console.Write("----------Entity Dosyaları hazırsa--------\nDataAccess dosyaları için 5\nBusiness Dosyaları için 6\nÇıkış için 0\nSeçim: ");
        chosen = Console.ReadLine();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Context Adını giriniz.");
        context = Console.ReadLine();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Projenin bulunduğu dosya yolunu giriniz.");
        basePath = Console.ReadLine();



        while (true)
        {
            if ("1234".Contains(chosen))
            {
                Console.WriteLine("--------------------------------------");
                Console.Write("Çıkış için 0\nEntity adı girin (örnek: Product): ");
                entity = Console.ReadLine();
            }
            if (entity == "0")
                break;

            switch (chosen)
            {
                case "0":
                    return;
                case "1":
                    EntityLayer(entity, basePath);
                    break;
                case "2":
                    InterfaceLayer(entity, basePath);
                    EfLayer(entity, context, basePath);
                    break;
                case "3":
                    IService(entity, basePath);
                    Manager(entity,basePath);
                    break;
                case "4":
                    EntityLayer(entity, basePath);
                    InterfaceLayer(entity, basePath);
                    EfLayer(entity, context,basePath);
                    IService(entity, basePath);
                    Manager(entity, basePath);
                    break;
                case "5":
                    CreateDataAccessFiles(basePath, context);
                    return;
                case "6":
                    CreateBusinessFiles(basePath, context);
                    return;
                default:
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                    continue;
            }
        }
    }
}

