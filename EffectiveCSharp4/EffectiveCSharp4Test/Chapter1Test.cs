using EffectiveCSharp4.Chapter1.Topic5;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharp4Test.Chapter1.Topic5
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
		private readonly string _expectedRevenue = '\u00a5' + "10,000,000";

		[SetUp]
		public void Init()
		{
			this.customer = new CustomerWithIFoFormattable{
				Name = "Hidari", 
				Revenue = 10000000, 
				ContactPhone = "09012345678" };
		}

		[TestCase("n", "Hidari")]
		[TestCase(null, "Hidari")]
		[TestCase("p", "    09012345678")]
		[TestCase("pn", "    09012345678,               Hidari")]
		[TestCase("np", "              Hidari,     09012345678")]
		public void ToStringWithFormatString(string format, string expect)
		{
			customer.ToString(format, null).Is(expect);
		}
		
		[Test]
		public void ToStringReturnsRevenue()
		{
			customer.ToString("r", null).Is(_expectedRevenue);
		}

		[Test]
		public void ToStringRevenueAndPhone()
		{
			customer.ToString("rp", null).Is( _expectedRevenue + ",     09012345678");
		}
		
		[Test]
		public void TostringReturnsRevenueAndName()
		{
			customer.ToString("rn", null).Is(_expectedRevenue + ",               Hidari");
		}

		[Test]
		public void Phone_Revenue()
		{
			customer.ToString("pr", null).Is("    09012345678, " + _expectedRevenue);
		}

		[Test]
		public void Name_Revenue()
		{
			customer.ToString("nr", null).Is("              Hidari, " + _expectedRevenue);
		}

		[Test]
		public void Revenue_Phone_Name()
		{
			customer.ToString("rpn", null).Is(_expectedRevenue + ",     09012345678,               Hidari");
		}

		[Test]
		public void Revenue_Name_Phone()
		{
			customer.ToString("rnp", null).Is(_expectedRevenue + ",               Hidari,     09012345678");
		}

		[Test]
		public void Phone_Revenue_Name()
		{
			customer.ToString("prn", null).Is("    09012345678, " + _expectedRevenue + ",               Hidari");
		}

		[Test]
		public void Phone_Name_Revenue()
		{
			customer.ToString("pnr", null).Is("    09012345678,               Hidari, " + _expectedRevenue);
		}

		[Test]
		public void Name_Revenue_Phone()
		{
			customer.ToString("nrp", null).Is("              Hidari, " + _expectedRevenue + ",     09012345678");
		}

		[Test]
		public void Name_Phone_Revenue()
		{
			customer.ToString("npr", null).Is("              Hidari,     09012345678, " + _expectedRevenue);
		}

		[Test]
		public void IFormattableTest()
		{
			Console.WriteLine("Customer: {0}", customer.ToString("npr", null));
		}

		[Test]
		public void MyCustomFormatterTest()
		{
			Console.WriteLine("Custom Formatted Customer: {0}", customer.ToString("", new MyCustomFormattr()));
		}
	}

	[TestFixture]
	public class ShipGirlTest
	{
		ShipGirl girl;

		[SetUp]
		public void init()
		{
			girl = new ShipGirl { Name = "翔鶴", ShipKind = "正規空母" };
		}

		[Test]
		public void ToStringWithNoArg()
		{
			var girl = new ShipGirl { Name = "大和", ShipKind = "戦艦" };
			girl.ToString().Is("大和");
		}

		[TestCase("G", "        翔鶴")]
		[TestCase("n", "艦名:         翔鶴")]
		[TestCase("k", "艦種:       正規空母")]
		[TestCase("nk", "艦名:         翔鶴  艦種:       正規空母")]
		[TestCase("kn", "艦種:       正規空母  艦名:         翔鶴")]
		public void ToStringInIFormattableTest(string format, string expected)
		{
			girl.ToString(format, null).Is(expected);
		}

		[Test]
		public void ToStringWithIFormatProvider()
		{
			var girl = new ShipGirl { Name = "金剛", ShipKind = "戦艦" };
			girl.ToString(null, new MyFormatter()).Is("ShipName:         金剛, ShipKind:         戦艦");
		}
	}
}
