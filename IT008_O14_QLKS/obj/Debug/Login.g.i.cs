﻿#pragma checksum "..\..\Login.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AB4C176B7C9DE230350C6A7DEF0F71147DCCD6CE7EDC83ABD14FAF84904C0D3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IT008_O14_QLKS;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace IT008_O14_QLKS {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border minibtn_border;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock minibtn_text;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border delbtn_border;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock delbtn_text;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IT008_O14_QLKS;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\Login.xaml"
            ((IT008_O14_QLKS.MainWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\Login.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.minibtn_border = ((System.Windows.Controls.Border)(target));
            
            #line 42 "..\..\Login.xaml"
            this.minibtn_border.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.minibtn_border_MouseDown);
            
            #line default
            #line hidden
            
            #line 42 "..\..\Login.xaml"
            this.minibtn_border.MouseEnter += new System.Windows.Input.MouseEventHandler(this.minibtn_border_MouseEnter);
            
            #line default
            #line hidden
            
            #line 42 "..\..\Login.xaml"
            this.minibtn_border.MouseLeave += new System.Windows.Input.MouseEventHandler(this.minibtn_border_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.minibtn_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.delbtn_border = ((System.Windows.Controls.Border)(target));
            
            #line 54 "..\..\Login.xaml"
            this.delbtn_border.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            
            #line 54 "..\..\Login.xaml"
            this.delbtn_border.MouseEnter += new System.Windows.Input.MouseEventHandler(this.delbtn_border_MouseEnter);
            
            #line default
            #line hidden
            
            #line 54 "..\..\Login.xaml"
            this.delbtn_border.MouseLeave += new System.Windows.Input.MouseEventHandler(this.delbtn_border_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.delbtn_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

