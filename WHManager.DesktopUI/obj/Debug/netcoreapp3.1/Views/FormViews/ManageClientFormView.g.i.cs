﻿#pragma checksum "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DF57EF9AC5F31BB18231B2C37480529FFC632437"
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
    /// ManageClientFormView
    /// </summary>
    public partial class ManageClientFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageClient;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNip;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonConfirm;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/formviews/manageclientformview.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
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
            this.textBlockManageClient = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
            this.textBoxName.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxName_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBoxNip = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
            this.textBoxNip.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxNip_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
            this.textBoxPhoneNumber.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxPhoneNumber_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.CancelClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\..\Views\FormViews\ManageClientFormView.xaml"
            this.buttonConfirm.Click += new System.Windows.RoutedEventHandler(this.buttonConfirmClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

