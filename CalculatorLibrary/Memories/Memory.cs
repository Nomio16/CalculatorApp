using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary.Memories
{
    /*Санах үйлдэлтэй байх бөгөөд Memory болон санах ойн (MemoryItem) классуудтай байна. 
      Memory класс нь MemoryItem уудыг Array эсвэл List хэлбэрээр агуулдаг, санах ойнуудаа 
      (MemoryItem) зохицуулдаг байх.
     */
    public class Memory
    {
        private List<MemoryItem> memoryItems = new List<MemoryItem>();

        /// <summary>
        /// Store a new value in memory.
        /// </summary>
        public void Store(double value)
        {
            memoryItems.Add(new MemoryItem(value));
        }

        /// <summary>
        /// Get all memory items as a list.
        /// </summary>
        public List<double> RecallAll()
        {
            List<double> values = new List<double>();
            foreach (var item in memoryItems)
            {
                values.Add(item.Value);
            }
            return values;
        }

        /// <summary>
        /// Add a value to an existing memory item (M+).
        /// </summary>
        public void AddToMemory(int index, double value)
        {
            if (index >= 0 && index < memoryItems.Count)
            {
                (memoryItems[index].Value) += value;
            }
        }

        /// <summary>
        /// Subtract a value from an existing memory item (M-).
        /// </summary>
        public void SubtractFromMemory(int index, double value)
        {
            if (index >= 0 && index < memoryItems.Count)
            {
                (memoryItems[index].Value) -= value;
            }
        }

        public void ClearMemoryItem(int index)
        {
            if (index >= 0 && index < memoryItems.Count)
            {
                memoryItems.RemoveAt(index);
            }
        }

        /// <summary>
        /// Clear all memory items.
        /// </summary>
        public void ClearMemory()
        {
            memoryItems.Clear();
        }

        /// <summary>
        /// Get the number of stored memory items.
        /// </summary>
        public int Count => memoryItems.Count;
    }
}
