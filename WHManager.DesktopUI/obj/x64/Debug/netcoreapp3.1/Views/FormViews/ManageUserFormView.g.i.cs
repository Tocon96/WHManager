﻿#pragma checksum "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D5731A5B65DBC05830F91836E80DFBE197A7CCE"
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
    /// ManageUserFormView
    /// </summary>
    public partial class ManageUserFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageUser;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboboxRoles;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddUser;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/formviews/manageuserformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
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
            this.textBlockManageUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            
            #line 58 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxName_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 59 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxPassword_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBoxPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.comboboxRoles = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\..\..\Views\FormViews\ManageUserFormView.xaml"
            this.buttonAddUser.Click += new System.Windows.RoutedEventHandler(this.ButtonAddUserClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

