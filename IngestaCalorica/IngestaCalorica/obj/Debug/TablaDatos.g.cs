﻿#pragma checksum "..\..\TablaDatos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D79706EA6E544D6AF426FA2DCECB4736CC45985A8148DE8F424AD875C26DB80"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using IngestaCalorica;
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


namespace IngestaCalorica {
    
    
    /// <summary>
    /// TablaDatos
    /// </summary>
    public partial class TablaDatos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal IngestaCalorica.TablaDatos ventana;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calendario;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cajaCalorias;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label et;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvFechas;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\TablaDatos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvComidas;
        
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
            System.Uri resourceLocater = new System.Uri("/IngestaCalorica;component/tabladatos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TablaDatos.xaml"
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
            this.ventana = ((IngestaCalorica.TablaDatos)(target));
            
            #line 8 "..\..\TablaDatos.xaml"
            this.ventana.SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.calendario = ((System.Windows.Controls.Calendar)(target));
            return;
            case 3:
            this.comBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cajaCalorias = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.et = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 49 "..\..\TablaDatos.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.anadirComida_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lvFechas = ((System.Windows.Controls.ListView)(target));
            
            #line 53 "..\..\TablaDatos.xaml"
            this.lvFechas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvFechas_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lvComidas = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

