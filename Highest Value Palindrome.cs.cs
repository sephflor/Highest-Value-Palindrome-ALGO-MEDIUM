using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'highestValuePalindrome' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER n
     *  3. INTEGER k
     */

    public static string highestValuePalindrome(string s, int n, int k)
    {
         char[] arr = s.ToCharArray();
        bool[] changed = new bool[n];

        // Step 1: Make the string a palindrome with minimal changes
        for (int i = 0; i < n / 2; i++)
        {
            int j = n - 1 - i;
            if (arr[i] != arr[j])
            {
                char maxChar = arr[i] > arr[j] ? arr[i] : arr[j];
                arr[i] = arr[j] = maxChar;
                changed[i] = changed[j] = true;
                k--;
            }
        }

        if (k < 0) return "-1";

        // Step 2: Maximize the palindrome value
        for (int i = 0; i < n / 2 && k > 0; i++)
        {
            int j = n - 1 - i;
            if (arr[i] != '9')
            {
                if (changed[i] && k >= 1)
                {
                    arr[i] = arr[j] = '9';
                    k--;
                }
                else if (!changed[i] && k >= 2)
                {
                    arr[i] = arr[j] = '9';
                    k -= 2;
                }
            }
        }

        // Handle middle element for odd-length strings
        if (n % 2 == 1 && k > 0)
        {
            arr[n / 2] = '9';
        }

        return new string(arr);
    }

    }

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string s = Console.ReadLine();

        string result = Result.highestValuePalindrome(s, n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
