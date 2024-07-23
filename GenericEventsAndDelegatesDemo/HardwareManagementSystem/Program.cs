using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseManagementSystemAPI;

namespace HardwareManagementSystem
{
    internal class Program
    {
        const int batch_Size = 5;
        static void Main(string[] args)
        {
            CustomQueue<HardWare> hardwareQueue = new CustomQueue<HardWare>();

            hardwareQueue.CustomQueueEvent += CustomQueue_CustomQueueEvent;

            Thread.Sleep(2000);

            hardwareQueue.AddItem(new Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitValue = 10.00m, Quantity = 15 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Drill { Id = 3, Name = "Drill 3", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Ladder { Id = 4, Name = "Ladder 4", Type = "Ladder", UnitValue = 31.00m, Quantity = 19 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Ladder { Id = 5, Name = "Ladder 5", Type = "Ladder", UnitValue = 31.00m, Quantity = 16 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Ladder { Id = 6, Name = "Ladder 6", Type = "Ladder", UnitValue = 31.00m, Quantity = 27 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Hammer { Id = 7, Name = "Hammer 7", Type = "Hammer", UnitValue = 8.00m, Quantity = 22 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new Hammer { Id = 8, Name = "Hammer 8", Type = "Hammer", UnitValue = 4.00m, Quantity = 12 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new PaintBrush { Id = 9, Name = "PaintBrush 9", Type = "PaintBrush", UnitValue = 9.00m, Quantity = 30 });
            Thread.Sleep(2000);
            hardwareQueue.AddItem(new PaintBrush { Id = 10, Name = "PaintBrush 10", Type = "PaintBrush", UnitValue = 15.00m, Quantity = 10 });
            Thread.Sleep(2000);

            Console.ReadLine();

        }

        private static void ProcessItems(CustomQueue<HardWare> hardWares)
        {
            while (hardWares.QueueLength > 0)
            {
                Thread.Sleep(2000);
                hardWares.GetItem();
            }
        }

        private static void CustomQueue_CustomQueueEvent(CustomQueue<HardWare> sender, QueueEventArgs eventargs)
        {
            Console.Clear();

            Console.WriteLine(MainHeading());
            Console.WriteLine();
            Console.WriteLine(RealTimeUpdateHeading());

            if (sender.QueueLength > 0)
            {
                Console.WriteLine(eventargs.Message);
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(ItemsInQueueHeading());
                Console.WriteLine(FieldHeadings());

                WriteValuesInQueueToScreen(sender);
                
                if (sender.QueueLength == batch_Size)
                {
                    ProcessItems(sender);
                }
            }
            else
            {
                Console.WriteLine("All items have been processed");
            }
        }

        private static void WriteValuesInQueueToScreen(CustomQueue<HardWare> hardWares)
        {
            foreach (var hardWare in hardWares)
            {
                Console.WriteLine($"{hardWare.Id,-6}{hardWare.Name,-15}{hardWare.Type,-20}{hardWare.Quantity,10}{hardWare.UnitValue,10}");
            }
        }

        //Headings
        private static string FieldHeadings()
        {
            return UnderLine($"{"Id",-6}{"Name",-15}{"Type",-20}{"Quantity",10}{"Value",10}");
        }

        private static string RealTimeUpdateHeading()
        {
            return UnderLine("Real-time Update");
        }

        private static string ItemsInQueueHeading()
        {
            return UnderLine("Items Queued for Processing");
        }

        private static string MainHeading()
        {
            return UnderLine("Warehouse Management System");
        }

        private static string UnderLine(string heading)
        {
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
        //Headings
    }

    public abstract class HardWare : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }

    public class Drill : HardWare
    {

    }
   public class Hammer : HardWare
    {

    }
    public class Ladder : HardWare
    {

    }
    public class PaintBrush : HardWare
    {

    }

}
