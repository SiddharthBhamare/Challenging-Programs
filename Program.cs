using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class MainApp
    {

        static public void Main(string[] args)
        {
            // このコードは標準入力と標準出力を用いたサンプルコードです。
            // このコードは好きなように編集・削除してもらって構いません。
            // ---
            // This is a sample code to use stdin and stdout.
            // Edit and remove this code as you like.

            //var lines = GetStdin();
            string SubStringCheck = String.Empty;
            string PalindromeString = String.Empty;
            int index = 0;
            List<string> PalindromArrays = new List<string>();
            string[] arrFile = File.ReadAllLines(@"D:\Projects\InputFile.txt");
            foreach (var line in arrFile)
            {
                for (index = 0; index < line.Length - 1; index++)
                {
                    SubStringCheck = GetSubString(line, index);
                    if (SubStringCheck != String.Empty && PalindromeString.Length < SubStringCheck.Length)
                    {
                        PalindromeString = IsPalindrome(SubStringCheck);
                        if (PalindromeString != string.Empty)
                        {
                            PalindromArrays.Add(PalindromeString);
                        }
                    }
                }

            }
            if (PalindromArrays.Count > 0)
            {
                //Console.WriteLine("Longest Palindrome String is " + PalindromeString);
                PalindromeString = PalindromArrays[0];
                PalindromArrays.RemoveAt(0);
                foreach (var item in PalindromArrays)
                {

                    if (PalindromeString.Length < item.Length )
                    {
                        PalindromeString = item;
                       
                    }
                    if(item.Length > 2)
                    {
                        Console.WriteLine("Palindrome String is  : " + item);
                    }
                }
                Console.WriteLine("Final Longest Palindrome String is  : " + PalindromeString);
            }
            else
            {
                Console.WriteLine("Results not found");
            }
        }

        //static private string[] GetStdin()
        //{

        //    // return list.ToArray();
        //}
        static private string GetSubString(string line, int startPos)
        {
            string MySubString = String.Empty;
            for (int i = startPos; i < line.Length - 1; i++)
            {
                MySubString = MySubString + line[i];
                for (int j = i + 1; j < line.Length - 1; j++)
                {
                    if (line[i] != line[j])
                    {
                        MySubString = MySubString + line[j];
                    }
                    if (line[i] == line[j])
                    {
                        MySubString = MySubString + line[j];
                        return MySubString;
                    }
                }
            }
            return String.Empty;
        }

        static private string IsPalindrome(string SubStringCheck)
        {
            int j = SubStringCheck.Length - 1;
            for (int i = 0; i < (SubStringCheck.Length / 2); i++)
            {
                if (SubStringCheck[i] != SubStringCheck[j])
                {
                    return string.Empty;
                }
                j--;
            }
            return SubStringCheck;
        }
    }

}

