﻿#pragma checksum "..\..\..\..\View\InfoTicket.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B1E038E2969D9DB91EEAD6C1AAC77E97422361E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using lab4_5;


namespace lab4_5 {
    
    
    /// <summary>
    /// ChangeTicket
    /// </summary>
    public partial class ChangeTicket : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChangeNameWay;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChangeNumberTrain;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChangePrice;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TicketTimePicker;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Train;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Electric;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChangeDescription;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonChange;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\InfoTicket.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/lab4-5;component/view/infoticket.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\InfoTicket.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ChangeNameWay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ChangeNumberTrain = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ChangePrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TicketTimePicker = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Train = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.Electric = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.ChangeDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ButtonChange = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\View\InfoTicket.xaml"
            this.ButtonChange.Click += new System.Windows.RoutedEventHandler(this.SaveChange_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\View\InfoTicket.xaml"
            this.ButtonDelete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

