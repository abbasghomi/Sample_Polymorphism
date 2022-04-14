using Sample_Polymorphism.Enums;

namespace Sample_Polymorphism.Models
{
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
}
