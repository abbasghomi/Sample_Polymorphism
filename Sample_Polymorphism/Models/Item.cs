using Sample_Polymorphism.Enums;

namespace Sample_Polymorphism.Models
{
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
}
