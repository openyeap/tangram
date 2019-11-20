﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.IO;
using CefSharp.WinForms;
using CefSharp;

namespace Tangram.CEF
{
    public class GlobalSettings
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void LoadApp()
        {
            AppDomain.CurrentDomain.AssemblyResolve += GlobalSettings.Resolver;
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            CefSettings settings = new CefSettings()
            {
                Locale = "zh-CN",
                IgnoreCertificateErrors = true,
                BrowserSubprocessPath = @"x64\CefSharp.BrowserSubprocess.exe",
                //MultiThreadedMessageLoop = false,
                WindowlessRenderingEnabled = true, 
            };
            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            //flash
            //settings.CefCommandLineArgs.Add("ppapi-flash-path", AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\pepflash\\pepflashplayer.dll");
            settings.CefCommandLineArgs.Add("--ignore-urlfetcher-cert-requests", "1");
            settings.CefCommandLineArgs.Add("--ignore-certificate-errors", "1");

            CefSharp.Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
        }
        // Will attempt to load missing assembly from either x86 or x64 subdir
        public static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86", assemblyName);
                return File.Exists(archSpecificPath) ? Assembly.LoadFile(archSpecificPath) : null;
            }
            return null;
        }


    }

}