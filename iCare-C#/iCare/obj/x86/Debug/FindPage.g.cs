﻿#pragma checksum "D:\1-专业课程资料与作业\大四\专业综合实习-王华敏\iCare代码-04孙明鑫13蒋超15刘志伟18邓月喜\iCare-C#\iCare\FindPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C630CA158D1DE7A670AA909C98AAFB8E"
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
    partial class FindPage : 
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
                    #line 93 "..\..\..\FindPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HomeBtn).Click += this.HomeBtn_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.FindBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 3:
                {
                    this.AddBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 99 "..\..\..\FindPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddBtn).Click += this.AddBtn_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.HandleBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 102 "..\..\..\FindPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HandleBtn).Click += this.HandleBtn_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.UserBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 105 "..\..\..\FindPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.UserBtn).Click += this.UserBtn_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.coolEventListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 7:
                {
                    this.hotEventListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 8:
                {
                    this.SearchBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

