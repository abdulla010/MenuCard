using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConsole
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string connectionstring = "Server=.\\SQLEXPRESS; Database=SchoolDB; Trusted_Connection=True; Integrated Security=true; MultipleActiveResultSets=true; TrustServerCertificate=true";

            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            const string sql = "SELECT Id, Name, SubjectId, DepartmentId FROM Teachers";

            var result = con.Query(sql);

            con.Close();

            int[] arr = new int[5] { 1, 9, 4, 2, 5 };

            sort(arr);
            int sm = sum(arr);
            Console.WriteLine(sm);

            int num = 1235445321;
            int pal = palindrome( num);
            Console.WriteLine(num);

            int[,] arr2= new int[3,3] { { 1, 2, 3 }, { 3, 2, 1 }, { 6, 5, 4 } };
            int dsum= diagnolsum(arr2);
            Console.WriteLine(dsum);

            duplicate();
            Console.ReadLine();
        }
        public static void sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int mn = arr[i];

                for (int j = i + 1; j < arr.Length; j++)

                {
                    if (mn > arr[j])
                    {
                        int temp = mn;
                        mn = arr[j];
                        arr[j] = temp;
                    }

                }
            }

        }
        public static int sum(int[] arr)
        {
            int sum= 0;
            for (int i = 0;i < arr.Length;i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        public static int palindrome(int num)
        {

            int n=num, r, sum = 0, temp;
            temp = n;
            while (n > 0)
            {
                r = n % 10;
                sum = (sum * 10) + r;
                n = n / 10;
            }

                if (temp == sum)
                    Console.Write("Number is Palindrome.");
                else
                    Console.Write("Number is not Palindrome");
            return sum;

        }
        public static int diagnolsum(int[,] arr)
        {
            int sum = 0;
            for(int i=0;i<arr.GetLength(0);i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if  (i == j)
                    sum += arr[i,j];
                    
                }

            } return sum;
        }
        static void duplicate()
            
        {
        readlabel:
            Console.Write("enter a string array:");
            string str = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(str))
            goto readlabel;

            string[] strArr = str.Split(',');
            if (strArr.Length == 0)
                goto readlabel;
            for(int i=0;i<strArr.Length;i++)
            { 
                string curr = strArr[i];
                int count = 1;
                for(int j=1;j<strArr.Length;j++) 
                {
                    if (curr == strArr[j])
                    {
                        count++;


                        if (i < strArr.Length-1)
                        {
                            string temp = curr;
                            strArr[i + 1] = strArr[j];
                            strArr[j] = temp;
                            i++;
                        }
                    }
                }


                Console.WriteLine(curr + ':'+count);
            }

        }





    }
}
