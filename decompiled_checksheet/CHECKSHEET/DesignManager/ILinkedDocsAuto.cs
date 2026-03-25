using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DesignManager;

[ComImport]
[CompilerGenerated]
[InterfaceType(2)]
[Guid("5CAC1975-0CD0-11D1-BC6F-0800360E1E02")]
[TypeIdentifier]
public interface ILinkedDocsAuto : IEnumerable
{
	[DispId(3)]
	int Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		set;
	}

	void _VtblGap1_4();

	[DispId(4)]
	object Item
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[IndexerName("_Item")]
	[DispId(0)]
	object this[[MarshalAs(UnmanagedType.Struct)] object Index]
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}
}
