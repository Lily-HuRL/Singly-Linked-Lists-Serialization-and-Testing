using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
	public class LinkedList<T> : ILinkedListADT<T>
	{
		public Node<T> Head { get; set; }
		public Node<T> Tail { get; set; }
		public int count { get; set; }

		public LinkedList()
		{
			Head = null;
			Tail = null;
			count = 0;
		}

		public void Add(T data, int index)
		{
			if (index < 0 || index > count)
			{
				throw new IndexOutOfRangeException("Index out of range");
			}
			else if (index == 0)
			{
				AddFirst(data);
			}
			else if (index == count)
			{
				AddLast(data);
			}
			else
			{
				Node<T> newNode = new Node<T>(data);
				Node<T> current = Head;
				for (int i = 0; i < index - 1; i++)
				{
					current = current.Next;
				}
				newNode.Next = current.Next;
				current.Next = newNode;
				count++;
			}
		}

		public void AddFirst(T data)
		{
			Node<T> newNode = new Node<T>(data);
			newNode.Next = Head;
			Head = newNode;
			count++;
		}

		public void AddLast(T data)
		{
			Node<T> newNode = new Node<T>(data);
			if (Head == null)
			{
				Head = newNode;
			}
			else
			{
				Node<T> current = Head;
				while (current.Next != null)
				{
					current = current.Next;
				}
				current.Next = newNode;
			}
			count++;
		}

		public void Replace(T data, int index)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of range");
			}
			Node<T> current = Head;
			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
			current.Data = data;
		}

		public int Count()
		{		
			return count;
		}

		public T GetValue(int index)
		{
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException("Index out of range");
			}
			else
			{
				Node<T> current = Head;
				for (int i = 0; i < index; i++)
				{
					current = current.Next;
				}
				return current.Data;
			}
		}

		public int IndexOf(T data)
		{
			Node<T> current = Head;
			int index = 0;
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					return index;
				}
				current = current.Next;
				index++;
			}
			throw new InvalidOperationException("Data not found in the linked list.");
		}

		public bool Contains(T data)
		{
			Node<T> current = Head;
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					return true;
				}
				current = current.Next;
			}
			return false;
		}

		public bool IsEmpty()
		{
			if (Head == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//public void Clear()
		//{
		//	if (Head == null)
		//	{
		//		throw new InvalidOperationException("List is empty");
		//	}
		//	else
		//	{
		//		Head = null;
		//		Tail = null;
		//		count = 0;
		//	}
		//}
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public void Remove(T data)
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}

			Node<T> current = Head;
			Node<T> previous = null;
			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					if (previous == null)
					{
						Head = current.Next;
					}
					else
					{
						previous.Next = current.Next;
					}
					count--;
					return;
				}
				previous = current;
				current = current.Next;
			}
			throw new InvalidOperationException("Data not found in the linked list.");

		}

		public void RemoveFirst()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			else
			{
				Head = Head.Next;
				count--;
			}
		}

		public void RemoveLast()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			if (Head.Next == null)
			{
				Head = null;
			}
			else
			{
				Node<T> current = Head;
				while (current.Next.Next != null)
				{
					current = current.Next;
				}
				current.Next = null;
			}
			count--;
		}
	}
}
