using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartArrayConsole
{
    public class SmartArray
    {
        int[] UnderlyingArray; // using the C# simple array to hold our data

        public int Length
        {
            get { return UnderlyingArray.Length; }
        }

        public SmartArray(int origSize)  // constructor sets initial size
        {
            UnderlyingArray = new int[origSize];

        }

        public void SetAtIndex(int index, int val)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("too small");
            }
            else if (index > UnderlyingArray.Length - 1)
            {
                throw new IndexOutOfRangeException("too big");
                // could instead call 
                // Resize(index);
                // UnderlyingArray[index] = val;
            }
            else
            {
                UnderlyingArray[index] = val;
                return;
            }
        }

        public int GetAtIndex(int index)
        {
            try
            {
                return UnderlyingArray[index];
            }
            catch (Exception)
            {

                if (index < 0)
                {
                    throw new IndexOutOfRangeException("too small");
                }
                else if (index > UnderlyingArray.Length - 1)
                {
                    throw new IndexOutOfRangeException("too big");
                }
            }
            finally
            {

            }
            return Int32.MinValue;
        }

        public void PrintAllElements()
        {
            for (int i = 0; i < UnderlyingArray.Length; i++)
            {
                Console.WriteLine(UnderlyingArray[i]);
            }
        }

        public bool Find(int val)
        {
            for (int i = 0; i < UnderlyingArray.Length; i++)
            {
                if (UnderlyingArray[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public void Resize(int newsize)
        {
            // create new array of new size

            int[] NewArray = new int[newsize];

            if (newsize >= UnderlyingArray.Length)
            {
                for (int i = 0; i < UnderlyingArray.Length; i++)
                {
                    NewArray[i] = UnderlyingArray[i];

                }
            }
            else
            {
                for (int i = 0; i < newsize; i++)
                {
                    NewArray[i] = UnderlyingArray[i];

                }
            }

            // rename new to old
            UnderlyingArray = NewArray;
        }
    } // end of SmartArray class
}
