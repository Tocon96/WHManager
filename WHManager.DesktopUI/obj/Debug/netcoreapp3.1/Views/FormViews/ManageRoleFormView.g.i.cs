﻿#pragma checksum "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31C17E87EEBE4F75CAFF8A3F6694FBA70EB0EBEC"
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
    /// ManageRoleFormView
    /// </summary>
    public partial class ManageRoleFormView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockManageRole;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxAdmin;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxDocuments;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxBusiness;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxContractors;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxWarehouse;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkboxReports;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;component/views/formviews/manageroleformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
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
            this.textBlockManageRole = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            
            #line 68 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
            ((System.Windows.Controls.TextBlock)(target)).PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.textBoxName_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.checkboxAdmin = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.checkboxDocuments = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.checkboxBusiness = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.checkboxContractors = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.checkboxWarehouse = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.checkboxReports = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancelClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.buttonAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\..\Views\FormViews\ManageRoleFormView.xaml"
            this.buttonAddUser.Click += new System.Windows.RoutedEventHandler(this.ButtonAddRoleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

