using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystemAPI
{

    public delegate void CustomQueueEventHandler<T, U>(T sender, U eventargs);

    public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        Queue<T> queue;

        public event CustomQueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

        public CustomQueue()
        {
            queue = new Queue<T>();
        }

        public int QueueLength
        {
            get { return queue.Count; }
        }

        public void AddItem(T item)
        {
            queue.Enqueue(item);

            QueueEventArgs queueEventArgs = new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id ({item.Id}), Name ({item.Name}), Type ({item.Type}), Quantity ({item.Quantity}), has been added to the queue." };

            CustomQueueEvent?.Invoke(this, queueEventArgs);
        }        
        public T GetItem()
        {
            T item = queue.Dequeue();

            QueueEventArgs queueEventArgs = new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id ({item.Id}), Name ({item.Name}), Type ({item.Type}), Quantity ({item.Quantity}), has been processed." };

            CustomQueueEvent?.Invoke(this, queueEventArgs);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }
    }

    public class QueueEventArgs
        {
            public string Message { get; set; }
        }

    internal class Program
    {
        static void Main(string[] arr)
        {

        }
    }
}
