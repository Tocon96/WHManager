﻿#pragma checksum "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50BF9172534C07221CE2BC69C64070B1BD7D9368"
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
using WHManager.DesktopUI.Views.FormViews.LoginForm;


namespace WHManager.DesktopUI.Views.FormViews.LoginForm {
    
    
    /// <summary>
    /// InitializeCompanyFormView
    /// </summary>
    public partial class InitializeCompanyFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textboxPassword;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCompanyName;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCompanyPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCompanyNip;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/formviews/loginform/initializecompa" +
                    "nyformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
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
            this.textboxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 2:
            this.textBoxCompanyName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxCompanyPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxCompanyNip = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 68 "..\..\..\..\..\..\Views\FormViews\LoginForm\InitializeCompanyFormView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InitializeClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

