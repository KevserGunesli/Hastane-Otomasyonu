using System;
using System.Collections;
using System.Collections.Generic;

namespace Hastane_Otomasyonu
{
    public class MaxHeap
    {
        private List<Hasta> heap = new List<Hasta>();

        public List<Hasta> ToList()
        {
            return heap;
        }

        public int Count => heap.Count;

        public void Add(Hasta hasta)
        {
            heap.Add(hasta);
            HeapifyUp(heap.Count - 1);
        }

        public Hasta ExtractMax()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");

            var max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return max;
        }

        public Hasta Peek()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty");
            return heap[0];
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[index].Oncelik > heap[(index - 1) / 2].Oncelik)
            {
                var temp = heap[index];
                heap[index] = heap[(index - 1) / 2];
                heap[(index - 1) / 2] = temp;
                index = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            while (2 * index + 1 < heap.Count)
            {
                int maxChildIndex = 2 * index + 1;
                if (2 * index + 2 < heap.Count && heap[2 * index + 2].Oncelik > heap[2 * index + 1].Oncelik)
                {
                    maxChildIndex = 2 * index + 2;
                }

                if (heap[index].Oncelik >= heap[maxChildIndex].Oncelik) break;

                var temp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = temp;
                index = maxChildIndex;
            }
        }
    }

}
