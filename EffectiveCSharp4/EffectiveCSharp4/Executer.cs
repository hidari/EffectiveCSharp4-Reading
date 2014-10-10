using EffectiveCSharp4.Chapter1.Topic5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharp4
{
	class Executer
	{
		static void Main(string[] args)
		{
			var girl = new ShipGirl { Name = "金剛", ShipKind = "戦艦" };
			Console.WriteLine(girl.ToString(null, new MyFormatter()));
		}
	}
}
