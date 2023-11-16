using System.ComponentModel;
using System.Security.Cryptography;

namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string information = Console.ReadLine();
            List<Box> boxes = new List<Box>();
            while (information != "end")
            {
                string[] arr = information.Split(' ').ToArray();

                string a = arr[0];
                int serialNumber = int.Parse(a);//1
                string name = arr[1];//2
                string b = arr[2];
                int itemQuantity = int.Parse(b);//3
                string c = arr[3];
                double itemPrice = double.Parse(c);//4
                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemQuantity = itemQuantity,

                };
                box.Item = new Item()
                {
                    Name = name,
                    Price = itemPrice
                };

                box.BoxPrice = itemQuantity * itemPrice;
                boxes.Add(box);

                information = Console.ReadLine();
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                Box curentBox = boxes[i];
                if (i < boxes.Count - 1)
                {
                    if (curentBox.BoxPrice <= boxes[i + 1].BoxPrice)
                    {
                        boxes[i] = boxes[i + 1];
                        boxes[i + 1] = curentBox;
                        i = -1;
                    }
                }
            }
            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }

        }
    }
    class Item
    {
        public Item()
        {

        }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double BoxPrice { get; set; }

    }
}