﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using ICSharpCode.Reports.Addin.ReportWizard;
using ICSharpCode.Reports.Core;
using ICSharpCode.Reports.Core.Globals;
using NUnit.Framework;

namespace ICSharpCode.Reports.Addin.Test.Wizard.Generators
{
	[TestFixture]
	public class LayoutFixture
	{
		[Test]
		public void ListLayoutTest()
		{
			AbstractLayout l = LayoutFactory .CreateGenerator(GlobalEnums.ReportLayout.ListLayout,
			                                                     ReportModel.Create(),
			                                                     new ReportItemCollection());
			Assert.IsAssignableFrom<ListLayout>(l,"Should be 'ListLayout'");
		}
		
		[Test]
		public void TableLayoutTest()
		{
			AbstractLayout l = LayoutFactory.CreateGenerator(GlobalEnums.ReportLayout.TableLayout,
			                                                     ReportModel.Create(),
			                                                     new ReportItemCollection());
			Assert.IsAssignableFrom<TableLayout>(l,"Should be 'TableLayout'");
		}
	}
}
