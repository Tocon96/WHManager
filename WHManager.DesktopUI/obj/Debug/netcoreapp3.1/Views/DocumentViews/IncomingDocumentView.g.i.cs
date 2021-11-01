﻿#pragma checksum "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "154DF08D12F4C26878F5E44EF99301B29A520053"
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
using WHManager.DesktopUI.Views.DocumentViews;


namespace WHManager.DesktopUI.Views.DocumentViews {
    
    
    /// <summary>
    /// IncomingDocumentView
    /// </summary>
    public partial class IncomingDocumentView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 113 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDocumentId;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProviderName;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDeliveryId;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerEarlierDate;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerLaterDate;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridDocuments;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/documentviews/incomingdocumentview." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
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
            
            #line 87 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClearClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxDocumentId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxProviderName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxDeliveryId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.datePickerEarlierDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.datePickerLaterDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            
            #line 126 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.gridDocuments = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 150 "..\..\..\..\..\Views\DocumentViews\IncomingDocumentView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DownloadDocumentClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

