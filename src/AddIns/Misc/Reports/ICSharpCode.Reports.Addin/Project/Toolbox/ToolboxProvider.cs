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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;

using ICSharpCode.Core;
using ICSharpCode.Core.WinForms;
using ICSharpCode.Reports.Core;
using ICSharpCode.Reports.Core.Globals;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Widgets.SideBar;

namespace ICSharpCode.Reports.Addin
{
	
	//http://developer.sharpdevelop.net/corsavy/translation/default.asp
	
	
	internal sealed class ReportingSideTabProvider
	{
		
		private static SideTab standardSideTab;
		private static int viewCount;
		private static bool initialised;
		
		
		private  ReportingSideTabProvider()
		{
		}
		
		public static void AddViewContent(IViewContent viewContent)
		{
			if (viewContent == null)
				throw new ArgumentNullException("viewContent");
			
			if (!initialised)
				Initialise();
			
			// Make sure the standard workflow sidebar exists
			if (standardSideTab == null) {
				LoggingService.Debug("Creating standard workflow sidetab");
				standardSideTab = CreateReportingSidetab();
			}
			ViewCount++;
		}
		
		private static void Initialise()
		{
			initialised = true;
		}
		
		
		private static SideTab CreateReportingSidetab ()
		{
			SideTab sideTab = new SideTab("ReportDesigner");
			sideTab.CanSaved = false;
			AddPointerToSideTab(sideTab);
			
			// TextItem
			ToolboxItem tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseTextItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.TextBox");
			tb.Bitmap = WinFormsResourceService.GetIcon("Icons.16.16.SharpReport.Textbox").ToBitmap();
			sideTab.Items.Add(new SideTabItemDesigner(tb));	
			
		
			
		
			//GroupHeader
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.GroupHeader));
			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.NameSpace");
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.GroupHeader");
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
			
			//GroupFooter
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.GroupFooter));
			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.NameSpace");
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.GroupFooter");
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
			// Row
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseRowItem));
			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.SharpQuery.Table");
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.DataRow");
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
			//BaseTable
//			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.SharpQuery.Table");
			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.SharpQuery.Table");
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseTableItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.Table");
			sideTab.Items.Add(new SideTabItemDesigner(tb));	
			
			
			//BaseDataItem
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseDataItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.DataField");
//				tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.SharpQuery.Column");
			tb.Bitmap = WinFormsResourceService.GetBitmap("Icons.16x16.SharpQuery.Column");
			sideTab.Items.Add(new SideTabItemDesigner(tb));	
			
			//Grahics
			// Line
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseLineItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.Line");
			tb.Bitmap = WinFormsResourceService.GetIcon("Icons.16.16.SharpReport.Line").ToBitmap();
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
			// Rectangle
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseRectangleItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.Rectangle");
			tb.Bitmap = GlobalValues.RectangleBitmap();
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
			// Circle
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseCircleItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.Circle");
			tb.Bitmap = GlobalValues.CircleBitmap();
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			
		
			// Image
			tb = new ToolboxItem(typeof(ICSharpCode.Reports.Addin.BaseImageItem));
			tb.DisplayName = ResourceService.GetString("SharpReport.Toolbar.Image");
			tb.Bitmap = WinFormsResourceService.GetIcon("Icons.16x16.ResourceEditor.bmp").ToBitmap();
			sideTab.Items.Add(new SideTabItemDesigner(tb));
			return sideTab;
		}
		
		
		private static void AddPointerToSideTab(SideTab sideTab)
		{
			// Add the standard pointer.
			SharpDevelopSideTabItem sti = new SharpDevelopSideTabItem("Pointer");
			sti.CanBeRenamed = false;
			sti.CanBeDeleted = false;
			Bitmap pointerBitmap = new Bitmap(IconService.GetBitmap("Icons.16x16.FormsDesigner.PointerIcon"), 16, 16);
			sti.Icon = pointerBitmap;
			sti.Tag = null;
			sideTab.Items.Add(sti);
		}
		
		
		static SharpDevelopSideBar reportingSideBar;
		
		public static SharpDevelopSideBar ReportingSideBar {
			get {
				SD.MainThread.VerifyAccess();
				if (reportingSideBar == null) {
					reportingSideBar = new SharpDevelopSideBar();
					reportingSideBar.Tabs.Add(standardSideTab);
					ReportingSideBar.ActiveTab = standardSideTab;
				}
				return reportingSideBar;
			}
		}
		
		
		private static int ViewCount {
			get { return viewCount; }
			set {
				viewCount = value;
				
				if (viewCount == 0)	{
					standardSideTab = null;
				}
			}
		}
	}
}
