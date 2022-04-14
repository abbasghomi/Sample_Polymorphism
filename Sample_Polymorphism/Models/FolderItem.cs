using Sample_Polymorphism.Enums;

namespace Sample_Polymorphism.Models
{
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
}
