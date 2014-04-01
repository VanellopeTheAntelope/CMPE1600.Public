﻿using System;
using System.Threading;

namespace Demo_9
{
	class MainClass
	{
		static Random rand = new Random ();
		public static void Main (string[] args)
		{
			//Below won't work, because signature doesn't match delegate.
			//Thread dancer1 = new Thread(new ThreadStart(Dance));
			Dance ();
			//But:

			Thread dancer1 = new Thread (new ParameterizedThreadStart (Dancer));
			Object[] parameters = new object[]{ "Bloort", 'c', 200u, 200u };
			dancer1.Start (parameters);

			//Wait for other threads...
			Thread.Sleep (500);
			//Kill them if they can't take a joke.
			System.Environment.Exit (System.Environment.ExitCode);
		}

		public static void Dancer(object stuff)
		{
			object[] pars = (object[]) stuff;
			Dance ((string)pars [0], (char)pars [1], (uint)pars [2], (uint)pars [3]);
		}

		public static string Dance(string start = "Hammer Time!", char precede = ' ',
			uint delay = 0, uint count = 10)
		{
			char[] symbols = { '\u2b05', '\u2b06', '\u2b07', '\u2b08', '\u2b09', '\u2b0a', '\u2b0b', '\u2b0c', '\u2b0d' };
			Console.WriteLine (start);
			for (int i = 0; i < count; ++i) 
			{
				if (delay > 0) Thread.Sleep ((int)delay);
				Console.Write (precede);
				//Print a random element of symbols.
				Console.Write(symbols[rand.Next(symbols.Length)]);
			}
			return start;
		}
	}
}