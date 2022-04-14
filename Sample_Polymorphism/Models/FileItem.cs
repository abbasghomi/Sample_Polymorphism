using Sample_Polymorphism.Enums;

namespace Sample_Polymorphism.Models
{
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
}
