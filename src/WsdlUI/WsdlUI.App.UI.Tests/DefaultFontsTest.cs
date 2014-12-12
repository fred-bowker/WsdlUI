using System;

using NUnit.Framework;

namespace WsdlUI.App.UI.Tests
{
	[TestFixture]
	public class DefaultFontsTest
	{
		/// <summary>
		/// This checks that WsdlUI will use the correct font on each system.
		/// For the test to pass succesffuly on linux the Inconsolata font needs to be installed 
		/// </summary>
		[Test]
		public void TestCheckForFonts() {
		
			string[] availableFonts = new string[] {
				"Consolas",
				"Inconsolata",
				"Courier"
			};

			//test 1: test that inconsolata font is installed
			string consolasFont = WsdlUI.App.UI.DefaultFonts.Instance.CheckForFonts (availableFonts);
			// on mono Inconsolata font will be installed
			#if __MonoCS__
			Assert.AreEqual(consolasFont, "Inconsolata");
			#endif
			// on windows Consolas will be installed
			#if !__MonoCS__
			Assert.AreEqual(consolasFont, "Consolas");
			#endif

			//test 2: test that courier font is installed
			string courierFont = WsdlUI.App.UI.DefaultFonts.Instance.CheckForFonts(new string[] {"Courier", "Courier New"});
            // on mono Courier
            #if __MonoCS__
			Assert.AreEqual(courierFont, "Courier");
            #endif
            // on windows Courier New
            #if !__MonoCS__
            Assert.AreEqual(courierFont, "Courier New");
            #endif
		}
	}
}

