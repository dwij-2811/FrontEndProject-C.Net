﻿#pragma checksum "..\..\..\Auth.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30BE0212B1153DA0ADFF2406DCB9A9AE60205B58"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
using SoledoutUI;
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


namespace SoledoutUI {
    
    
    /// <summary>
    /// Window3
    /// </summary>
    public partial class Window3 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button close_window;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimize_window;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox key_input;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock checking;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock valid;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock invalid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock invalid_user;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Auth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock no_key;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SoledoutUI;V1.0.0.8;component/auth.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Auth.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\Auth.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.close_window = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Auth.xaml"
            this.close_window.Click += new System.Windows.RoutedEventHandler(this.close_window_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.minimize_window = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Auth.xaml"
            this.minimize_window.Click += new System.Windows.RoutedEventHandler(this.minimize_window_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 50 "..\..\..\Auth.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\Auth.xaml"
            ((System.Windows.Controls.Button)(target)).Initialized += new System.EventHandler(this.Button_Initialized);
            
            #line default
            #line hidden
            return;
            case 5:
            this.key_input = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\Auth.xaml"
            this.key_input.GotFocus += new System.Windows.RoutedEventHandler(this.key_input_GotFocus);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\Auth.xaml"
            this.key_input.LostFocus += new System.Windows.RoutedEventHandler(this.key_input_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.checking = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.valid = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.invalid = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.invalid_user = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.no_key = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

