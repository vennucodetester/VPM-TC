using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DesignManager;

[ComImport]
[CompilerGenerated]
[Guid("B885CA13-186B-41BA-8432-510A107D569D")]
[InterfaceType(2)]
[TypeIdentifier]
public interface IDMgrApp
{
	void _VtblGap1_14();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object Open([MarshalAs(UnmanagedType.BStr)] string FileName, [Optional][In][MarshalAs(UnmanagedType.Struct)] object RevisionRuleOption, [Optional][In][MarshalAs(UnmanagedType.Struct)] object StopFileOpenIfRevisionRuleNotApplicable);
}
