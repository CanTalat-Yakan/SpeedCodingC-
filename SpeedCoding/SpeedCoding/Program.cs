using System;

namespace SpeedCoding
{
    class Program
    {
        static string m_stringWord;
        static char[] m_charWord;
        static char m_currentChar;
        static void Main(string[] args)
        {
            m_stringWord = Console.ReadLine();
            Console.WriteLine(m_stringWord);
            m_charWord = new char[m_stringWord.Length];
            m_charWord = m_stringWord.ToCharArray();
            for (int i = 0; i < m_stringWord.Length; i++)
            {
                m_currentChar = m_charWord[i];
                //buchstabe i
                for (int a = 0; a < m_stringWord.Length; a++)
                {
                    //gucken ob andere außer i auch das gleiche ist, wenn nicht, dann win und return, sonst, geh weiter und am ende fail
                    if (m_currentChar == (m_charWord[a + i]))
                        Console.WriteLine("continue");
                    else
                    {
                        Console.WriteLine("win");
                        return;
                    }
                }
            }
            Console.WriteLine("fail");
        }

        void Check()
        {
            m_stringWord = Console.ReadLine();
        }
    }
}
