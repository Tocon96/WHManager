﻿#pragma checksum "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8E0FEE0DE66D2C87A0AF4EE50DA5790A3E028C60"
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
    /// DeliveryView
    /// </summary>
    public partial class DeliveryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 151 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDeliveryId;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxProviderName;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxRealized;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerEarlierDateOrdered;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerLaterDateOrdered;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerEarlierDateRealized;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerLaterDateRealized;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridDeliveries;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridCheckBoxColumn Realized;
        
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
            System.Uri resourceLocater = new System.Uri("/WHManager.DesktopUI;V1.0.0.0;component/views/businessviews/deliveryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
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
            
            #line 118 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClearClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxDeliveryId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxProviderName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.comboBoxRealized = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.datePickerEarlierDateOrdered = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.datePickerLaterDateOrdered = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.datePickerEarlierDateRealized = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.datePickerLaterDateRealized = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            
            #line 166 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SearchClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.gridDeliveries = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.Realized = ((System.Windows.Controls.DataGridCheckBoxColumn)(target));
            return;
            case 14:
            
            #line 206 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridDeliveryRealizeDelivery);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 207 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridDeliveryDisplayItems);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 208 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.gridDeliveryGeneratePz);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 223 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddDeliveryClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 12:
            
            #line 191 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDeliveryClick);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 198 "..\..\..\..\..\Views\BusinessViews\DeliveryView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteDeliveryClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

