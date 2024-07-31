using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
	public interface ILinkedListADT<T>
	{
		void Add(T data, int index);
		void AddFirst(T data);
		void AddLast(T data);
		void Replace(T data, int index);
		int Count();
		T GetValue(int index);
		int IndexOf(T data);
		bool Contains(T data);
		bool IsEmpty();
		void Clear();
		void Remove(T data);
		void RemoveFirst();
		void RemoveLast();
	}
}
