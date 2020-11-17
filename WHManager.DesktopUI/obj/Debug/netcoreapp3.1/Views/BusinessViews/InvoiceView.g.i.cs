﻿#pragma checksum "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EC79893AC8D8CF7AD5ADCBFF698213C2090C5EAC"
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
using WHManager.DesktopUI.Views.BusinessViews;


namespace WHManager.DesktopUI.Views.BusinessViews {
    
    
    /// <summary>
    /// InvoiceView
    /// </summary>
    public partial class InvoiceView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 25 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridInvoices;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxInvoicesSearch;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonId;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonClient;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radioButtonDate;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerEarlierDate;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerLaterDate;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/businessviews/invoiceview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
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
            this.gridInvoices = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 47 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridProductGeneratePdf);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 53 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonSearchClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 54 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonClearClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 55 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonAddInvoiceClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxInvoicesSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.radioButtonId = ((System.Windows.Controls.RadioButton)(target));
            
            #line 59 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            this.radioButtonId.Click += new System.Windows.RoutedEventHandler(this.radioButtonIdClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.radioButtonClient = ((System.Windows.Controls.RadioButton)(target));
            
            #line 60 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            this.radioButtonClient.Click += new System.Windows.RoutedEventHandler(this.radioButtonClientClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.radioButtonDate = ((System.Windows.Controls.RadioButton)(target));
            
            #line 61 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            this.radioButtonDate.Click += new System.Windows.RoutedEventHandler(this.radioButtonDateClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.datePickerEarlierDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.datePickerLaterDate = ((System.Windows.Controls.DatePicker)(target));
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
            case 2:
            
            #line 33 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonUpdateInvoiceClick);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 40 "..\..\..\..\..\Views\BusinessViews\InvoiceView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonDeleteInvoiceClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

