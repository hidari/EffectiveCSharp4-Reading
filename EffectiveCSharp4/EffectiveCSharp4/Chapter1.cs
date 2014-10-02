﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharp4.Chapter1.Topic5
{
	public class Customer
	{
		public string Name { get; set; }
		public decimal Revenue { get; set; }
		public string ContactPhone { get; set; }
	}
	public class Customer_2
	{
		public string Name { get; set; }
		public decimal Revenue { get; set; }
		public string ContactPhone { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}

	public class CustomerWithIFoFormattable : IFormattable
	{
		public string Name { get; set; }
		public decimal Revenue { get; set; }
		public string ContactPhone { get; set; }

		public string ToString(string format, IFormatProvider formatProvider)
		{
			switch (format)
			{
				case "r":
					return string.Format("{0,10:C}", this.Revenue);
				case "p":
					return string.Format("{0,15}", this.ContactPhone);
				case "n":
				case "G":
				default:
					return Name;
			}

		}
	}
}
