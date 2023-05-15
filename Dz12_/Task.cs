using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz12_
{
    public class Task1<T>
    {
        public void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }



    public class Task2<T>
    {
        public List<T> element;
        public Func<T, T, int> comparison;

        public int Count { get { return element.Count; } }

        public Task2()
        {
            element = new List<T>();
        }

        public Task2(Func<T, T, int> comparison) : this()
        {
            this.comparison = comparison;
        }

        public void Enqueue(T item)
        {
            element.Add(item);
            int currentIndex = Count - 1;

            while (currentIndex > 0)
            {
                int mainIndex = (currentIndex - 1) / 2;

                if (comparison(element[currentIndex], element[mainIndex]) >= 0)
                    break;

                Swap(currentIndex, mainIndex);
                currentIndex = mainIndex;
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }

            T frontElement = element[0];
            int lastIndex = Count - 1;
            element[0] = element[lastIndex];
            element.RemoveAt(lastIndex);

            int currentIndex = 0;
            while (true)
            {
                int leftIndex = 2 * currentIndex + 1;
                int rightIndex = 2 * currentIndex + 2;
                int smallIndex = currentIndex;

                if (leftIndex < Count && comparison(element[leftIndex], element[smallIndex]) < 0)
                    smallIndex = leftIndex;

                if (rightIndex < Count && comparison(element[rightIndex], element[smallIndex]) < 0)
                    smallIndex = rightIndex;

                if (smallIndex == currentIndex)
                    break;

                Swap(currentIndex, smallIndex);
                currentIndex = smallIndex;
            }
            return frontElement;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }
            return element[0];
        }

        private void Swap(int index1, int index2)
        {
            T temp = element[index1];
            element[index1] = element[index2];
            element[index2] = temp;
        }
    }



    public class Task3<T>
    {
        private T[] elements;
        private int front;  
        private int rear;
        private int count;  

        public int Count { get { return count; } }
        public int Capacity { get { return elements.Length; } }
        public bool Empty { get { return count == 0; } }
        public bool Full { get { return count == elements.Length; } }

        public Task3(int capacity)
        {
            if (capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than zero");
                Environment.Exit(0);
            }
            elements = new T[capacity];
            front = 0;
            rear = -1;
            count = 0;
        }

        public void Enqueue(T item)
        {
            if (Full)
            {
                Console.WriteLine("The queue is full");
                Environment.Exit(0);
            }
            rear = (rear + 1) % elements.Length;
            elements[rear] = item;
            count++;
        }

        public T Dequeue()
        {
            if (Empty)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }
            T dequeuedItem = elements[front];
            elements[front] = default(T);
            front = (front + 1) % elements.Length;
            count--;

            return dequeuedItem;
        }

        public T Peek()
        {
            if (Empty)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }
            return elements[front];
        }
    }



    public class Task4<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public Task4()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);
            
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Node newNode = new Node(value);
            
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            
            Count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty");
                Environment.Exit(0);
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }
            
            Count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                Console.WriteLine("The list is empty");
                Environment.Exit(0);
            }
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node currentNode = head;
                while (currentNode.Next != tail)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = null;
                tail = currentNode;
            }
            
            Count--;
        }

        public void Print()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }



    public class Task5<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Previous = null;
                Next = null;
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty");
                Environment.Exit(0);
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (tail == null)
            {
                Console.WriteLine("The list is empty");
                Environment.Exit(0);
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            Count--;
        }

        public void PrintForward()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public void PrintBackward()
        {
            Node current = tail;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Previous;
            }
        }
    }
}