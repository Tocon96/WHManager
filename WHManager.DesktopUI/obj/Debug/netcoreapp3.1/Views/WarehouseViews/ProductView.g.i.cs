﻿#pragma checksum "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "418CF3C45E5CA595BA5E0DBDB716E7BC6CE94F8B"
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
    /// ProductView
    /// </summary>
    public partial class ProductView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 116 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox productTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox manufacturerComboBox;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox taxComboBox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceBuyMinTextBox;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceBuyMaxTextBox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceSellMinTextBox;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceSellMaxTextBox;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridProduct;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/warehouseviews/productview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
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
            
            #line 88 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearSearchClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.productTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.manufacturerComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.taxComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.priceBuyMinTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.priceBuyMaxTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.priceSellMinTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.priceSellMaxTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 132 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.gridProduct = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            
            #line 174 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridProductOpenItemView);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 175 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridProductOpenEmittedItemView);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 190 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddProductClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 191 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteAllProductsClick);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 193 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteMultipleProductsClick);
            
            #line default
            #line hidden
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
            case 12:
            
            #line 160 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateProductClick);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 167 "..\..\..\..\..\Views\WarehouseViews\ProductView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteProductClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

