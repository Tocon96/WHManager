﻿#pragma checksum "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71F72DB3F1412F5AE4293B0CB3EEF570CD9329F2"
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
    /// ManageInvoiceFormView
    /// </summary>
    public partial class ManageInvoiceFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageClient;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datepickerInvoicesDateIssued;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxInvoicesClients;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxInvoicesOrderId;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonConfirm;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/formviews/manageinvoiceformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
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
            this.textBlockManageClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.datepickerInvoicesDateIssued = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.comboBoxInvoicesClients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.textBoxInvoicesOrderId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\..\..\Views\FormViews\ManageInvoiceFormView.xaml"
            this.buttonConfirm.Click += new System.Windows.RoutedEventHandler(this.buttonConfirmClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

