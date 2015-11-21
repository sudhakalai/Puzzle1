using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number:");
            int n = Int32.Parse(Console.ReadLine());

            int[] result=  findAdditionArray(n);
            if(result!=null)
            {
                Console.WriteLine(string.Join("+", result));
            }
            else
            {
                Console.WriteLine("IMPOSSIBLE");
            }
            Console.ReadLine();

        }


        private static int[] findAdditionArray(int n)
        {
            
            if (((n % 2) == 1) && (n != 1))
            {
                int[] numbers = new int[2]; 
                int x = n / 2;
                numbers[0] = x;
                numbers[1] = x+1 ;
                return numbers;
            }
            else
            {
                if (expoftwo(n) == true)
                {
                    return null; 
                }
                else if ((n == 1) || (n == 2))
                {
                    return null;
                }
                else
                {
                    int noOfIntergers = smallestoddprimefactor(n);
                    int midNumber = n / noOfIntergers;
                    if ((midNumber - (noOfIntergers / 2)) > 0)
                    {
                        int[] numbers = new int[noOfIntergers];

                        int middleIndex = (noOfIntergers / 2) + 1;
                        int firstNumber = midNumber - (noOfIntergers - middleIndex);
                        for (int i = 0; i < noOfIntergers; i++)
                        {
                            numbers[i] = firstNumber;
                            firstNumber++;
                        }
                        return numbers; 
                    }
                    else
                    {
                        return negativeCondition(n, 4);                        
                    }
                }

            }
        }

        private static int[] negativeCondition(int n, int noOfIntergers)
        {
            int[] numbers = new int[noOfIntergers];
            int firstMiddleNumber = n / noOfIntergers;
            int firstMiddleIndex = noOfIntergers/2;
            int firstNumber = firstMiddleNumber - (noOfIntergers - firstMiddleIndex - 1);
            for (int i = 0; i < noOfIntergers; i++)
            {
                numbers[i] = firstNumber;
                firstNumber++;
            }
            if (numbers.Sum() != n)
                return negativeCondition(n, noOfIntergers * 2);
            else
                return numbers;
        }

        private static bool expoftwo(int x)
        {
            return x > 0 && (x & (x - 1)) == 0;
        }
        private static int smallestoddprimefactor(int x)
        {
            bool c;
            
                for (int i = 3; i <= x; i++ )
                {
                    c = isoddPrime(i); 
                    if(c==true)
                    {
                        if ((x % i) == 0)
                            return i;
                    }                      
                }
            return x;
        }
        private static bool isoddPrime(int x)
        {
            if (x == 1) return false;
            if (x == 2) return false;
            for (int i = 2; i < x; ++i)
            {
                if (x % i == 0) return false;
            }

            return true;

        }
        }
    
}
