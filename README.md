# Sample C# Polymorphism
Demonstrate a simple way of keeping and handling several types with a common base type in a list

There are 2 property for separating Items defined in base type:

* ItemTypeEnum : enum [Folder, File, Email]
* IsFolder :boolean [true: folder, false: non folder]



In this project 4 types is defined:

* FolderItem

  ```c#
  public class FolderItem : Item
  {
      public int Items { get; set; }
  
      public override bool IsFolder => true;
      public override FolderItem GetType => this;
  
      public FolderItem()
      {
          ItemType = ItemTypeEnum.Folder;
      }
  
      public override void WriteToConsole()
      {
          base.WriteToConsole();
          Console.WriteLine(Items);
      }
  }
  ```

* FileItem

  ```c#
  public class FileItem : Item
  {
      public int Size { get; set; }
      public string Ext { get; set; }
  
      public override bool IsFolder => false;
  
      public override FileItem GetType => this;
  
      public FileItem()
      {
          ItemType = ItemTypeEnum.File;
      }
  
      public override void WriteToConsole()
      {
          base.WriteToConsole();
          Console.WriteLine($"{Ext}, {Size}");
      }
  }
  ```

* EmailItem

  ```c#
  public class EmailItem : Item
  {
      public string Subject { get; set; }
      public string From { get; set; }
      public string To { get; set; }
      public string Body { get; set; }
  
      public override bool IsFolder => false;
  
      public override EmailItem GetType => this;
  
      public EmailItem()
      {
          ItemType = ItemTypeEnum.Email;
      }
  
      public override void WriteToConsole()
      {
          base.WriteToConsole();
          Console.WriteLine($"{Subject}, {To}, {From}, {Body}");
      }
  }
  ```

* Item (base model):

  ```c#
  public class Item
  {
      public string Id { get; set; }
      public string Name { get; set; }
      public ItemTypeEnum ItemType { get; set; }
  
      public virtual bool IsFolder => throw new NotImplementedException();
      public virtual int IsFolderOrder => IsFolder ? 0 : 1;
      public virtual Item GetType => throw new NotImplementedException();
      public virtual void WriteToConsole()
      {
          WriteToConsoleCommonFields();
      }
  
      protected void WriteToConsoleCommonFields()
      {
          Console.WriteLine($"{Name}, {(IsFolder ? "Folder" : "Not a folder") }");
      }
  }
  ```

Also an enum:

* ItemTypeEnum:

  

  ```c#
  public enum ItemTypeEnum
      {
          Folder = 0,
          File = 1,
          Email = 2,
      }
  ```



Sample list of items created like this:

```c#
List<Item> items = new List<Item>();
```

And Items added to list like this:

```c#
items.Add(new FolderItem { Id = "1", Name = "Folder 1", Items = 10 });
items.Add(new FileItem { Id = "2", Name = "File 2", Ext = "xls", Size = 200 });
items.Add(new FolderItem { Id = "3", Name = "Folder 3", Items = 32 });
items.Add(new EmailItem { Id = "4", Name = "Email 4", Subject = "Subject 4", From = "From 4", To = "To 4", Body = "Body 4" });
items.Add(new EmailItem { Id = "5", Name = "Email 1", Subject = "Subject 1", From = "From 1", To = "To 1", Body = "Body 1" });
```

This sample code is for differentiating between folder items and other ones

```c#
 if (item.IsFolder)
 {
     //Folder items
 }
else
{
    //Other items
}
```

This sample code is for differentiating between items based on ItemTypeEnum

```c#
if (item.ItemType == ItemTypeEnum.File)
{
  //File items
}
else if (item.ItemType == ItemTypeEnum.Email)
{
  //Email items
}
```

