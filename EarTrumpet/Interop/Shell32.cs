﻿using System;
using System.Runtime.InteropServices;

namespace EarTrumpet.Interop
{
    class Shell32
    {
        public const int KF_FLAG_DONT_VERIFY = 0x00004000;

        [Flags]
        public enum AppBarState
        {
            ABS_AUTOHIDE = 1
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IShellItem2 SHCreateItemInKnownFolder(
            ref Guid kfid,
            uint dwKFFlags,
            [MarshalAs(UnmanagedType.LPWStr)]string pszItem,
            ref Guid riid);

        [DllImport("shell32.dll", PreserveSig = true)]
        public static extern UIntPtr SHAppBarMessage(
            AppBarMessage dwMessage, 
            ref APPBARDATA pData);

        [DllImport("shell32.dll", PreserveSig = true)]
        public static extern IntPtr ExtractIcon(
            IntPtr instanceHandle, 
            string path, 
            int iconIndex);

        public enum NotifyIconMessage : int
        {
            NIM_ADD = 0x00000000,
            NIM_MODIFY = 0x00000001,
            NIM_DELETE = 0x00000002,
            NIM_SETVERSION = 0x00000004,
        }

        [DllImport("shell32.dll", PreserveSig = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Shell_NotifyIconW(
            NotifyIconMessage message, 
            NOTIFYICONDATAW pNotifyIconData);
    }
}
