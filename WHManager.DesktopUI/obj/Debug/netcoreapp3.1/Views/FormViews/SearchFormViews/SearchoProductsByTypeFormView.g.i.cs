﻿#pragma checksum "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9A270F17A61526B9D546FAB21437F9F9538B670B"
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
using WHManager.DesktopUI.Views.FormViews.SearchFormViews;


namespace WHManager.DesktopUI.Views.FormViews.SearchFormViews {
    
    
    /// <summary>
    /// SearchProductsByTypeFormView
    /// </summary>
    public partial class SearchProductsByTypeFormView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSearch;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonID;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonName;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/formviews/searchformviews/searchoproductsbyt" +
                    "ypeformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
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
            this.textBoxSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 28 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.radioButtonID = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.radioButtonName = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.gridProduct = ((System.Windows.Controls.DataGrid)(target));
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
            case 6:
            
            #line 45 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateProductClick);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 52 "..\..\..\..\..\..\Views\FormViews\SearchFormViews\SearchoProductsByTypeFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteProductClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
