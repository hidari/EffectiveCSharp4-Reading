using System;
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
			if (formatProvider != null)
			{
				var fmt = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
				if (fmt != null)
				{
					return fmt.Format(format, this, formatProvider);
				}
			}

			switch (format)
			{
				case "r":
					return string.Format("{0,10:C}", this.Revenue);
				case "p":
					return string.Format("{0,15}", this.ContactPhone);
				case "rp":
					return string.Format("{0,10:C}, {1,15}", this.Revenue, this.ContactPhone);
				case "rn":
					return string.Format("{0,10:C}, {1,20}", this.Revenue, this.Name);
				case "pr":
					return string.Format("{0,15}, {1,10:C}", this.ContactPhone, this.Revenue);
				case "pn":
					return string.Format("{0,15}, {1,20}", this.ContactPhone, this.Name);
				case "nr":
					return string.Format("{0,20}, {1,10:C}", this.Name, this.Revenue);
				case "np":
					return string.Format("{0,20}, {1,15}", this.Name, this.ContactPhone);
				case "rpn":
					return string.Format("{0,10:C}, {1,15}, {2,20}", this.Revenue, this.ContactPhone, this.Name);
				case "rnp":
					return string.Format("{0,10:C}, {1,20}, {2,15}", this.Revenue, this.Name, this.ContactPhone);
				case "prn":
					return string.Format("{0,15}, {1,10:C}, {2,20}", this.ContactPhone, this.Revenue, this.Name);
				case "pnr":
					return string.Format("{0,15}, {1,20}, {2,10:C}", this.ContactPhone, this.Name, this.Revenue);
				case "nrp":
					return string.Format("{0,20}, {1,10:C}, {2,15}", this.Name, this.Revenue, this.ContactPhone);
				case "npr":
					return string.Format("{0,20}, {1,15}, {2,10:C}", this.Name, this.ContactPhone, this.Revenue);
				case "n":
				case "G":
				default:
					return Name;
			}

		}
	}

	public class MyCustomFormattr : IFormatProvider
	{
		#region IFormatProvider
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter) || formatType == typeof(CustomerWithIFoFormattable))
			{
				return new MyCustomFormatProvider();
			}

			return null;
		}
		#endregion

		private class MyCustomFormatProvider : ICustomFormatter
		{
			#region ICustomFormatter
			public string Format(string format, object arg, IFormatProvider formatProvider)
			{
				var c = arg as CustomerWithIFoFormattable;
				if (c==null)
				{
					return arg.ToString();
				}

				return string.Format("{0,50}, {1,15}, {2,10:C}", c.Name, c.ContactPhone, c.Revenue);
			}
			#endregion
		}
	}
}
