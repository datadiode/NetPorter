using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Unclassified
{
	public class WinApi
	{
		/// <summary>Maximal Length of unmanaged Windows-Path-strings</summary>
		public const int MAX_PATH = 260;
		/// <summary>Maximal Length of unmanaged Typename</summary>
		public const int MAX_TYPE = 80;

		// from http://www.pinvoke.net/default.aspx/shell32/SHGetFileInfo.html
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SHFILEINFO
		{
			public SHFILEINFO(bool b)
			{
				hIcon = IntPtr.Zero;
				iIcon = 0;
				dwAttributes = 0;
				szDisplayName = "";
				szTypeName = "";
			}
			public IntPtr hIcon;
			public int iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TYPE)]
			public string szTypeName;
		};

		[Flags]
		public enum SHGFI : int
		{
			/// <summary>get icon</summary>
			Icon = 0x000000100,
			/// <summary>get display name</summary>
			DisplayName = 0x000000200,
			/// <summary>get type name</summary>
			TypeName = 0x000000400,
			/// <summary>get attributes</summary>
			Attributes = 0x000000800,
			/// <summary>get icon location</summary>
			IconLocatin = 0x000001000,
			/// <summary>return exe type</summary>
			ExeType = 0x000002000,
			/// <summary>get system icon index</summary>
			SysIconIndex = 0x000004000,
			/// <summary>put a link overlay on icon</summary>
			LinkOverlay = 0x000008000,
			/// <summary>show icon in selected state</summary>
			Selected = 0x000010000,
			/// <summary>get only specified attributes</summary>
			Attr_Specified = 0x000020000,
			/// <summary>get large icon</summary>
			LargeIcon = 0x000000000,
			/// <summary>get small icon</summary>
			SmallIcon = 0x000000001,
			/// <summary>get open icon</summary>
			OpenIcon = 0x000000002,
			/// <summary>get shell size icon</summary>
			ShellIconize = 0x000000004,
			/// <summary>pszPath is a pidl</summary>
			PIDL = 0x000000008,
			/// <summary>use passed dwFileAttribute</summary>
			UseFileAttributes = 0x000000010,
			/// <summary>apply the appropriate overlays</summary>
			AddOverlays = 0x000000020,
			/// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
			OverlayIndex = 0x000000040,
		}

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);
	}
}
