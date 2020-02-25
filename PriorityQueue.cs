using System;

namespace WpfPriorityQueue
{
    class PriorityQueue<T>
    {
        private T[] list;

        public int Length
        {
            get { return list.Length; }
        }

        public PriorityQueue(params T[] ts) //Variable amount of parameters
        {
            list = new T[ts.Length]; //Create list with the size equal to the number of variables
            Array.Copy(ts, list, ts.Length); //Copy the variables into the list
        }

        public T OnThisIndex(int index)
        {
            return list[index];
        }

        public T Peek()
        {
            return list[0];
        }

        public void Add(T itemToAdd) //Queue
        {
            T[] temp = new T[list.Length + 1]; //Create a temporary array, one element larger
            Array.Copy(list, temp, list.Length); //Copy current array into the temporary one
            temp[temp.Length - 1] = itemToAdd; //Add the new item to the temporary array
            list = temp; //Save the temporary array in the list with the new item. Temporary array should now fall out of scope
        }

        public void AddPriority(T itemToAdd)
        {
            T[] temp = new T[list.Length + 1];
            Array.Copy(list, 0, temp, 1, list.Length);
            temp[0] = itemToAdd;
            list = temp;
        }

        public void Remove(T itemToRemove)
        {
            T[] temp = new T[list.Length - 1];
            int index = -1; //Set default value to -1, so if no matching item is found it is still set
            for (int i = 0; i < list.Length; i++) //Find index to remove
            {
                if (object.Equals(list[i], itemToRemove))
                {
                    index = i;
                }
            }

            int j = 0;
            for (int i = 0; i < list.Length; i++) //Paste all indexes into new array, except for the one to remove
            {
                if (index != -1 && i != index)
                {
                    temp[j] = list[i];
                    j++;
                }
                else if(index == -1) //If no match was found; return
                {
                    return;
                }
            }
            list = temp;
        }
        public void Dequeue() //Remove first element
        {
            if (list.Length < 1)
            {
                throw new Exception("Queue is empty");
            }

            T[] temp = new T[list.Length - 1];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = list[i + 1];
            }
            list = temp;
        }

        public void Clear()
        {
            list = Array.Empty<T>();
        }
    }
}
