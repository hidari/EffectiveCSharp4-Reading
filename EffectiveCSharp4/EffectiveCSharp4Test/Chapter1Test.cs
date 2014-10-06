using EffectiveCSharp4.Chapter1.Topic5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharp4Test
{
	[TestFixture]
	public class Chapter1Test
	{
		[Test]
		public void CustomerToString()
		{
			var customer = new Customer();
			customer.ToString().Is("EffectiveCSharp4.Chapter1.Topic5.Customer");
		}

		[Test]
		public void CustomerOverriddenToString()
		{
			var customer2 = new Customer_2 { Name = "Hidari" };
			customer2.ToString().Is("Hidari");
		}

		[Test]
		public void NamelessFunctionToString()
		{
			int[] list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var test = new { Name = "Me", Numbers = list.Select(x => x) };
			Console.WriteLine(test);
		}

	}

	[TestFixture]
	public class Topic_ToString
	{
		CustomerWithIFoFormattable customer;

		[SetUp]
		public void Init()
		{
			this.customer = new CustomerWithIFoFormattable{
				Name = "Hidari", 
				Revenue = 10000000000, 
				ContactPhone = "09012345678" };
		}

		[Test]
		public void ToStringReturnsName()
		{
			customer.ToString("n", null).Is("Hidari");
		}
		
		[Test]
		public void ToStringReturnsNameWhenNull()
		{
			customer.ToString(null, null).Is("Hidari");
		}

		[Test]
		public void ToStringReturnsRevenue()
		{
			customer.ToString("r", null).Is('\u00a5' + "10,000,000,000");
		}

		[Test]
		public void ToStringReturnsContactPhone()
		{
			customer.ToString("p", null).Is("    09012345678");
		}

		[Test]
		public void ToStringRevenueAndPhone()
		{
			customer.ToString("rp", null).Is('\u00a5' + "10,000,000,000,     09012345678");
		}
		
		[Test]
		public void TostringReturnsRevenueAndName()
		{
			customer.ToString("rn", null).Is('\u00a5' + "10,000,000,000,               Hidari");
		}

		[Test]
		public void Phone_Revenue()
		{
			customer.ToString("pr", null).Is("    09012345678, " + '\u00a5' + "10,000,000,000");
		}

		[Test]
		public void Phone_Name()
		{
			customer.ToString("pn", null).Is("    09012345678,               Hidari");
		}

		[Test]
		public void Name_Revenue()
		{
			customer.ToString("nr", null).Is("              Hidari, " + '\u00a5' + "10,000,000,000");
		}

		[Test]
		public void Name_phone()
		{
			customer.ToString("np", null).Is("              Hidari,     09012345678");
		}

		[Test]
		public void Revenue_Phone_Name()
		{
			customer.ToString("rpn", null).Is('\u00a5' + "10,000,000,000,     09012345678,               Hidari");
		}

		[Test]
		public void Revenue_Name_Phone()
		{
			customer.ToString("rnp", null).Is('\u00a5' + "10,000,000,000,               Hidari,     09012345678");
		}

		[Test]
		public void Phone_Revenue_Name()
		{
			customer.ToString("prn", null).Is("    09012345678, " + '\u00a5' + "10,000,000,000,               Hidari");
		}

		[Test]
		public void Phone_Name_Revenue()
		{
			customer.ToString("pnr", null).Is("    09012345678,               Hidari, " + '\u00a5' + "10,000,000,000");
		}

		[Test]
		public void Name_Revenue_Phone()
		{
			customer.ToString("nrp", null).Is("              Hidari, " + '\u00a5' + "10,000,000,000,     09012345678");
		}

		[Test]
		public void Name_Phone_Revenue()
		{
			customer.ToString("npr", null).Is("              Hidari,     09012345678, " + '\u00a5' + "10,000,000,000");
		}
	}
}
