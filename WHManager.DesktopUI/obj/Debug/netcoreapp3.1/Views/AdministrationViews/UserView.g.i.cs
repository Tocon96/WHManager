﻿#pragma checksum "..\..\..\..\..\Views\AdministrationViews\UserView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BFBE9BFCA114D06BD8A6BEBA451CC5FDDD190728"
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
using WHManager.DesktopUI.Views.AdministrationViews;


namespace WHManager.DesktopUI.Views.AdministrationViews {
    
    
    /// <summary>
    /// UserView
    /// </summary>
    public partial class UserView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridUsers;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddUser;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSearchUser;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClearSearchUser;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textboxSearchUnit;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radiobuttonId;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radiobuttonName;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radiobuttonRole;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxSearchUnit;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/administrationviews/userview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
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
            this.gridUsers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.buttonAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.buttonAddUser.Click += new System.Windows.RoutedEventHandler(this.buttonAddUserClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonSearchUser = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.buttonSearchUser.Click += new System.Windows.RoutedEventHandler(this.buttonSearchUserClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonClearSearchUser = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.buttonClearSearchUser.Click += new System.Windows.RoutedEventHandler(this.buttonClearSearchUserClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textboxSearchUnit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.radiobuttonId = ((System.Windows.Controls.RadioButton)(target));
            
            #line 52 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.radiobuttonId.Click += new System.Windows.RoutedEventHandler(this.radiobuttonIdClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.radiobuttonName = ((System.Windows.Controls.RadioButton)(target));
            
            #line 53 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.radiobuttonName.Click += new System.Windows.RoutedEventHandler(this.radiobuttonNameClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.radiobuttonRole = ((System.Windows.Controls.RadioButton)(target));
            
            #line 54 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            this.radiobuttonRole.Click += new System.Windows.RoutedEventHandler(this.radiobuttonRoleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.comboBoxSearchUnit = ((System.Windows.Controls.ComboBox)(target));
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
            
            #line 32 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonUpdateUserClick);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 39 "..\..\..\..\..\Views\AdministrationViews\UserView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.buttonDeleteUserClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

