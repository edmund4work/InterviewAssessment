using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _20240916RushDigital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class fibonacciController : ControllerBase
    {
        [HttpGet(Name = "getFibonacci")]
        public returnFieldsFibonacci CalculateFibonacciRecursive(int n)
        {
            returnFieldsFibonacci returnData = new returnFieldsFibonacci();
            returnData.listOfFibonacci = new List<int>();

            //https://en.wikipedia.org/wiki/Fibonacci_sequence
            if (n <= 1)
            {
                returnData.returnValue = "0";// "Enter value must more than 1";
            }
            else
            {
                int number = n - 1; //Need to decrement by 1 since we are starting from 0
                int[] Fib = new int[number + 1];
                Fib[0] = 0;
                Fib[1] = 1;
                for (int i = 2; i <= number; i++)
                {
                    Fib[i] = Fib[i - 2] + Fib[i - 1];
                    if (Fib[i] > n)
                        break;
                    else if (Fib[i] < n)
                        returnData.returnValue = "It is not Fibonacci Number"; //break;
                    else if (Fib[i] == n)
                        returnData.returnValue = "It is Fibonacci Number";// Fib[i - 1].ToString();
                    else
                        returnData.returnValue = "";

                    returnData.listOfFibonacci.Add(Fib[i]);
                }
            }


            return returnData;
        }

        public class returnFieldsFibonacci
        {
            public string returnValue { get; set; }
            public List<int> listOfFibonacci { get; set; }
        }
    }
}

