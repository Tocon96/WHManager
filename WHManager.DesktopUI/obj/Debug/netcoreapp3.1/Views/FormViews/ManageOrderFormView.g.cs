﻿#pragma checksum "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8A0B3982FCF7CD46860CE2B635DE9E9831ADA00E"
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
    /// ManageOrderFormView
    /// </summary>
    public partial class ManageOrderFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageOrder;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datepickerOrdersDate;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxOrdersClients;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxOrdersProducts;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridItems;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/formviews/manageorderformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlockManageOrder = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.datepickerOrdersDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.comboBoxOrdersClients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.comboBoxOrdersProducts = ((System.Windows.Controls.ComboBox)(target));
            
            #line 94 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
            this.comboBoxOrdersProducts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxOrdersProducts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 96 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonOrdersCancel);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 100 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonOrdersConfirm);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gridItems = ((System.Windows.Controls.DataGrid)(target));
            
            #line 107 "..\..\..\..\..\Views\FormViews\ManageOrderFormView.xaml"
            this.gridItems.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.gridItems_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

