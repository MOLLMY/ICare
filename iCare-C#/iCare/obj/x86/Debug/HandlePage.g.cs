﻿#pragma checksum "D:\1-专业课程资料与作业\大四\专业综合实习-王华敏\iCare代码-04孙明鑫13蒋超15刘志伟18邓月喜\iCare-C#\iCare\HandlePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "52DB70B31EEEC607990016FBED68194A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iCare
{
    partial class HandlePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.HomeBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 86 "..\..\..\HandlePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HomeBtn).Click += this.HomeBtn_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.FindBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 89 "..\..\..\HandlePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.FindBtn).Click += this.FindBtn_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.AddBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 92 "..\..\..\HandlePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddBtn).Click += this.AddBtn_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.HandleBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5:
                {
                    this.UserBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 98 "..\..\..\HandlePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.UserBtn).Click += this.UserBtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.HandledListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 7:
                {
                    this.HandlingListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

