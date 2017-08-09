using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcContrib;
using NUnit.Framework;

namespace bugUnitTest
{
	[TestFixture]
	public class CLASSTester
	{
		[Test]
		public void TEST_NAME()
		{
			var foo = typeof(ISubController).Assembly.GetTypes();
		}
	}
}