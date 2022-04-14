// See https://aka.ms/new-console-template for more information
using Sample_Polymorphism.Enums;
using Sample_Polymorphism.Models;

List<Item> items = new List<Item>();

items.Add(new FolderItem { Id = "1", Name = "Folder 1", Items = 10 });
items.Add(new FileItem { Id = "2", Name = "File 2", Ext = "xls", Size = 200 });
items.Add(new FolderItem { Id = "3", Name = "Folder 3", Items = 32 });
items.Add(new EmailItem { Id = "4", Name = "Email 4", Subject = "Subject 4", From = "From 4", To = "To 4", Body = "Body 4" });
items.Add(new EmailItem { Id = "5", Name = "Email 1", Subject = "Subject 1", From = "From 1", To = "To 1", Body = "Body 1" });
items.Add(new FolderItem { Id = "6", Name = "Folder 2", Items = 18 });
items.Add(new FileItem { Id = "7", Name = "File 3", Ext = "ptt", Size = 300 });
items.Add(new EmailItem { Id = "8", Name = "Email 3", Subject = "Subject 3", From = "From 3", To = "To 3", Body = "Body 3" });
items.Add(new FileItem { Id = "9", Name = "File 1", Ext = "doc", Size = 100 });
items.Add(new EmailItem { Id = "10", Name = "Email 2", Subject = "Subject 2", From = "From 2", To = "To 2", Body = "Body 2" });
items.Add(new FileItem { Id = "11", Name = "File 4", Ext = "pdf", Size = 400 });
items.Add(new FolderItem { Id = "12", Name = "Folder 4", Items = 6 });

//Common way of writing to console using polymorphism
Console.WriteLine("Common way of writing to console using polymorphism");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine();
foreach (var item in items.OrderBy(ent => ent.IsFolderOrder).ThenBy(ent => ent.ItemType))
{
    Console.WriteLine($"{item.Name}, {(item.IsFolder ? "Folder" : "File") }");

    if (item.IsFolder)
    {
        var tempItem = (FolderItem)item;
        Console.WriteLine($"{tempItem.Items}");
    }
    else
    {
        if (item.ItemType == ItemTypeEnum.File)
        {
            var tempItem = (FileItem)item;
            Console.WriteLine($"{tempItem.Ext}, {tempItem.Size}");
        }
        else if (item.ItemType == ItemTypeEnum.Email)
        {
            var tempItem = (EmailItem)item;
            Console.WriteLine($"{tempItem.Subject},{tempItem.To},{tempItem.From},{tempItem.Body}");
        }
    }
    Console.WriteLine();
}

//Polymorphism way of writing to console
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Polymorphism way of writing to console");
Console.WriteLine("---------------------------------------------------");
Console.WriteLine();
foreach (var item in items.OrderBy(ent => ent.IsFolderOrder).ThenBy(ent => ent.ItemType))
{
    item.WriteToConsole();
    Console.WriteLine();
}

Console.ReadKey();

