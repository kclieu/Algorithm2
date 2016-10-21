using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algos
{
    public static class BitManipulations
    {
        //O(n) where n is number of bits in integer
        //Best case is given interger is 0, function never executes while loop
        public static int NumberofOnesInBinary(int number)
        {
            int numOnes = 0;
            while (number != 0) {
                if ((number & 1) == 1)
                    numOnes++;

                number = number >> 1;
            }

            return numOnes;
        }

        public static bool GetBit(int num, int n)
        {
            //int mask = 1 << n;
            return (num & (1 << n)) != 0;
        }

        public static int SetBit(int num, int n)
        {
            return num | (1 << n);
        }

        public static int ClearBit(int num, int n)
        {
            int mask = ~(1 << n);
            return num & mask;
        }

        //public static int clearBitMSBthroughI(int num, int i);

        //public static int ClearBitsIthrough0(int num, int i )

        // how to test whether the high-order bit is set in a byte.
        //Decimal  Binary
        //128    1000 0000
        // 64    0100 0000
        // 32    0010 0000
        // 16    0001 0000
        //  8    0000 1000
        //  4    0000 0100
        //  2    0000 0010
        //  1    0000 0001
        //public static int TestBitinAByte 
        public static bool IsHighOrderBitSetinAByte()
        {
            //0x indicates hex
            uint operand = 0x80000000;       // operand to be tested
            uint mask = 0x80000000;    // mask which has the bit to be tested, SET.

            return ((operand & mask) != 0);
        }


        //How to check if the binary representation of an integer is a palindrome
        //bool palidrome(int number)
        //{
        //    int rev = 0;
        //    num = number;
        //    while (num != 0)
        //    {
        //        rev = (rev << 1) | (num & 1); num >> 1;
        //    }

        //    return (rev = number); 
        //}
      
    }
}
