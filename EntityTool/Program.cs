using System;
using System.IO;

class Program
{

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




    static void EfLayer(string entity, string basePath)
    {
        string efContent = $@"using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{{
     public class Ef{entity}Dal : EfEntityRepositoryBase<{entity}, AnaokuluContext>, I{entity}Dal
    {{
    }}
}}";



        string efPath = Path.Combine(basePath, "DataAccess", "Concrete", "EntityFramework", $"Ef{entity}Dal.cs");
        File.WriteAllText(efPath, efContent);
    }


     static void CreateFiles(string basePath)
    {
        string[] filePaths = Directory.GetFiles(basePath + "\\Entities\\Concrete");


        foreach (string filePath in filePaths)
        {
            string entity = Path.GetFileNameWithoutExtension(filePath);
            InterfaceLayer(entity, basePath);
            EfLayer(entity, basePath);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{entity} ile ilgili 2 dosya oluşturuldu!");
        }
    }




    static void Main()
    {
        string entity = "";
        string chosen;
        string basePath;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("--Entity Dosyaları Entities/Concrete--\n--IEntityDal dosyaları DataAccess/Abstract--\n--EfEntityDosyaları DataAccess/Concrete/EntityFramework--");
        Console.WriteLine("--------------------------------------");
        Console.Write("Sadece Entity dosyaları için 1\nSadece IEntityDal dosyaları için 2\nSadece EfEntityDal dosyaları için 3\nHepsini hazırlamak için 4\nEntity Dosyaları hazırsa 5\nÇıkış için 0: ");
        chosen = Console.ReadLine();
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Projenin bulunduğu dosya yolunu giriniz.");
        basePath = Console.ReadLine();



        while (true)
        {
            if (chosen != "5")
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
                    break;
                case "3":
                    EfLayer(entity, basePath);
                    break;
                case "4":
                    EntityLayer(entity, basePath);
                    InterfaceLayer(entity, basePath);
                    EfLayer(entity, basePath);
                    break;
                case "5":
                    CreateFiles(basePath);
                    return;
                default:
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyin.");
                    continue;
            }
        }
    }
}

