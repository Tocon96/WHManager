﻿#pragma checksum "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33A5312DBF6C5446D7D51D4FD8CB28913ACAC9F4"
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
using WHManager.DesktopUI.Views.FormViews;


namespace WHManager.DesktopUI.Views.FormViews {
    
    
    /// <summary>
    /// ManageProductFormView
    /// </summary>
    public partial class ManageProductFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 62 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageProduct;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProductName;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxProductType;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxManufacturer;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxProductTax;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProductPriceBuy;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProductPriceSell;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/formviews/manageproductformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
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
            this.textBlockManageProduct = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBoxProductName = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
            this.textBoxProductName.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxProductName_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.comboBoxProductType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.comboBoxManufacturer = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.comboBoxProductTax = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.textBoxProductPriceBuy = ((System.Windows.Controls.TextBox)(target));
            
            #line 73 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
            this.textBoxProductPriceBuy.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxProductPriceBuy_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBoxProductPriceSell = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
            this.textBoxProductPriceSell.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxProductPriceSell_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 76 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 80 "..\..\..\..\..\..\Views\FormViews\ManageProductFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddProductClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

