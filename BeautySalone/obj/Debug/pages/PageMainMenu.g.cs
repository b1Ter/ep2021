﻿#pragma checksum "..\..\..\pages\PageMainMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4023CC7BA630E3B3368078219D634B4637F687492F6FBF41A1EBA387F72B6DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BeautySalone.pages;
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


namespace BeautySalone.pages {
    
    
    /// <summary>
    /// PageMainMenu
    /// </summary>
    public partial class PageMainMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\pages\PageMainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonClients;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\pages\PageMainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEmployees;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\pages\PageMainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonProducts;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\pages\PageMainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonServices;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\pages\PageMainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonManagment;
        
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
            System.Uri resourceLocater = new System.Uri("/BeautySalone;component/pages/pagemainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\PageMainMenu.xaml"
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
            this.buttonClients = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\pages\PageMainMenu.xaml"
            this.buttonClients.Click += new System.Windows.RoutedEventHandler(this.buttonClients_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonEmployees = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\pages\PageMainMenu.xaml"
            this.buttonEmployees.Click += new System.Windows.RoutedEventHandler(this.buttonError_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonProducts = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\pages\PageMainMenu.xaml"
            this.buttonProducts.Click += new System.Windows.RoutedEventHandler(this.buttonError_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonServices = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\pages\PageMainMenu.xaml"
            this.buttonServices.Click += new System.Windows.RoutedEventHandler(this.buttonError_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.buttonManagment = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\pages\PageMainMenu.xaml"
            this.buttonManagment.Click += new System.Windows.RoutedEventHandler(this.buttonError_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
