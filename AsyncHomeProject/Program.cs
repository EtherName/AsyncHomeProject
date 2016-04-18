using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncHomeProject {

	class Program {
		static void Main(string[] args) {
			CancellationTokenSource cts = new CancellationTokenSource();
			double firstElem = 4;
			double secondElem = 3;
			var rsultMulAsync = TaskExample.MulTaskAsynk(firstElem, secondElem, cts.Token);

			var secondRes = rsultMulAsync.ContinueWith(task => {
				var res = TaskExample.Mul(task.Result, task.Result);
				Console.WriteLine($"Mul {firstElem} * {secondElem} = {task.Result}");
				Console.WriteLine($"MulContinue {task.Result} * {task.Result} = {res}");
			}, TaskContinuationOptions.OnlyOnRanToCompletion);

			var thirdRes = rsultMulAsync.ContinueWith(task => Console.WriteLine("Operation was canceled!"),
													  TaskContinuationOptions.OnlyOnCanceled);

			Task.Run(() => {
				Thread.Sleep(1500);
				cts.Cancel();
			});
			Console.ReadLine();
		}
	}
}
