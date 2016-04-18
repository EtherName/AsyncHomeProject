using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncHomeProject
{
    class TaskExample
    {
        public static async Task<double> MulTaskAsynk(double firstElem, double secondElem, CancellationToken token)
        {
            int count = 5;
            var result = await Task.Run(() => Mul(firstElem, secondElem));
            while (count-- > 0)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(500);
            }
            return result;
        }
        public static double Mul(double firstElem, double secondElem)
        {
            return firstElem * secondElem;
        }
    }
}
