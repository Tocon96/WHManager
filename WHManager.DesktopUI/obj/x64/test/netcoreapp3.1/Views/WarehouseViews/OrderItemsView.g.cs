﻿#pragma checksum "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1F656F4A0B0235A73D339C4C3B75B43D032E2F22"
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
    /// OrderItemsView
    /// </summary>
    public partial class OrderItemsView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 112 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTextBox;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProduct;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridItems;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/warehouseviews/orderitemsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 89 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearSearchClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxProduct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 122 "..\..\..\..\..\..\Views\WarehouseViews\OrderItemsView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchItemClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

