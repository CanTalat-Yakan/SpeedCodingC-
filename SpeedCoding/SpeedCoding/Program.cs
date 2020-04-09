using System;

namespace SpeedCoding
{
    class Program
    {
        static int[] m_array;
        static int m_currentHighest;
        static int m_secondHighest;
        static int m_currentHighestIndex;
        static int m_secondHighestIndex;

        static void Main(string[] args)
        {
            Console.WriteLine("Give the Length of the int-array");
            //size of the int-array
            int arrayLength = int.Parse(Console.ReadLine());
            m_array = new int[arrayLength];

            Console.WriteLine("\nGive the value of int from each of index's in the int-array\n");
            //get array in list
            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine($"CurrentIndex: {i}\n");
                Console.Write("CurrentValue: ");
                m_array[i] = int.Parse(Console.ReadLine());
            }

            //get the highest number (betrag)
            for (int i = 0; i < arrayLength; i++)
            {
                int current;
                if (m_array[i] < 0)
                    current = m_array[i] * -1;
                else
                    current = m_array[i];

                if (current > m_currentHighest)
                {
                    m_secondHighest = m_currentHighest;
                    m_secondHighestIndex = m_currentHighestIndex;

                    m_currentHighest = current;
                    m_currentHighestIndex = m_array[i];
                }
            }

            if(m_currentHighest == m_secondHighest)
            {
                if (m_currentHighest == m_array[m_currentHighestIndex])
                {
                    if (m_secondHighest == m_array[m_secondHighestIndex])
                    {
                        //both are highest
                        return;
                    }
                }
                else if (m_secondHighest == m_array[m_secondHighestIndex])
                {
                    if (m_currentHighest != m_array[m_currentHighestIndex])
                    {
                        m_currentHighest = m_secondHighest;
                        m_currentHighestIndex = m_secondHighestIndex;
                        //second is highest
                    }
                }
                else
                {
                    //current is highest
                }
            }
            Console.WriteLine("\n\nThe highest number in the array is");
            Console.WriteLine(m_array[m_currentHighestIndex]);
        }
    }
}
