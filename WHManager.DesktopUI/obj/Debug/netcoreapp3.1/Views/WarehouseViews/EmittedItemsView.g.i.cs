﻿#pragma checksum "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9BF73B3DF73D548784562DA566D535FBFDE458F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WHManager.DesktopUI.Views.WarehouseViews;


namespace WHManager.DesktopUI.Views.WarehouseViews {
    
    
    /// <summary>
    /// EmittedItemsView
    /// </summary>
    public partial class EmittedItemsView : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 25 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonId;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonDateOfPurchase;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerEarlierDate;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerLaterDate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridItems;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/warehouseviews/emitteditemsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.radioButtonId = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            this.radioButtonId.Click += new System.Windows.RoutedEventHandler(this.radioButtonIdClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.radioButtonDateOfPurchase = ((System.Windows.Controls.RadioButton)(target));
            
            #line 26 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            this.radioButtonDateOfPurchase.Click += new System.Windows.RoutedEventHandler(this.radioButtonDateOfPurchaseClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 27 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchItemsClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearSearchClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 29 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddItemClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.datePickerEarlierDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.datePickerLaterDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.gridItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 42 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateItemClick);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 49 "..\..\..\..\..\Views\WarehouseViews\EmittedItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteItemClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
