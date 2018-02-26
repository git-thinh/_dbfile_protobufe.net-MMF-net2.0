//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Option: missing-value detection (*Specified/ShouldSerialize*/Reset*) enabled
    
// Generated from: RpcMessage.proto
namespace ProtoBufRemote
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"RpcMessage")]
  public partial class RpcMessage : global::ProtoBuf.IExtensible
  {
    public RpcMessage() {}
    
    private int _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    private ProtoBufRemote.RpcMessage.Call _callMessage = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"call_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ProtoBufRemote.RpcMessage.Call CallMessage
    {
      get { return _callMessage; }
      set { _callMessage = value; }
    }

    private ProtoBufRemote.RpcMessage.Result _resultMessage = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"result_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ProtoBufRemote.RpcMessage.Result ResultMessage
    {
      get { return _resultMessage; }
      set { _resultMessage = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Call")]
  public partial class Call : global::ProtoBuf.IExtensible
  {
    public Call() {}
    
    private string _service;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"service", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Service
    {
      get { return _service; }
      set { _service = value; }
    }
    private string _method;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"method", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string Method
    {
      get { return _method; }
      set { _method = value; }
    }
    private readonly global::System.Collections.Generic.List<ProtoBufRemote.RpcMessage.Parameter> _parameters = new global::System.Collections.Generic.List<ProtoBufRemote.RpcMessage.Parameter>();
    [global::ProtoBuf.ProtoMember(3, Name=@"parameters", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<ProtoBufRemote.RpcMessage.Parameter> Parameters
    {
      get { return _parameters; }
    }
  
    private bool _expectsResult;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"expects_result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool ExpectsResult
    {
      get { return _expectsResult; }
      set { _expectsResult = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Result")]
  public partial class Result : global::ProtoBuf.IExtensible
  {
    public Result() {}
    

    private bool? _isFailed;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"is_failed", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool IsFailed
    {
      get { return _isFailed?? default(bool); }
      set { _isFailed = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool IsFailedSpecified
    {
      get { return _isFailed != null; }
      set { if (value == (_isFailed== null)) _isFailed = value ? IsFailed : (bool?)null; }
    }
    private bool ShouldSerializeIsFailed() { return IsFailedSpecified; }
    private void ResetIsFailed() { IsFailedSpecified = false; }
    

    private string _errorMessage;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"error_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string ErrorMessage
    {
      get { return _errorMessage?? ""; }
      set { _errorMessage = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool ErrorMessageSpecified
    {
      get { return _errorMessage != null; }
      set { if (value == (_errorMessage== null)) _errorMessage = value ? ErrorMessage : (string)null; }
    }
    private bool ShouldSerializeErrorMessage() { return ErrorMessageSpecified; }
    private void ResetErrorMessage() { ErrorMessageSpecified = false; }
    

    private ProtoBufRemote.RpcMessage.Parameter _callResult = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"call_result", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public ProtoBufRemote.RpcMessage.Parameter CallResult
    {
      get { return _callResult; }
      set { _callResult = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Parameter")]
  public partial class Parameter : global::ProtoBuf.IExtensible
  {
    public Parameter() {}
    

    private byte[] _protoParam;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"proto_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public byte[] ProtoParam
    {
      get { return _protoParam?? null; }
      set { _protoParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool ProtoParamSpecified
    {
      get { return _protoParam != null; }
      set { if (value == (_protoParam== null)) _protoParam = value ? ProtoParam : (byte[])null; }
    }
    private bool ShouldSerializeProtoParam() { return ProtoParamSpecified; }
    private void ResetProtoParam() { ProtoParamSpecified = false; }
    

    private string _stringParam;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"string_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string StringParam
    {
      get { return _stringParam?? ""; }
      set { _stringParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool StringParamSpecified
    {
      get { return _stringParam != null; }
      set { if (value == (_stringParam== null)) _stringParam = value ? StringParam : (string)null; }
    }
    private bool ShouldSerializeStringParam() { return StringParamSpecified; }
    private void ResetStringParam() { StringParamSpecified = false; }
    

    private int? _intParam;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"int_param", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int IntParam
    {
      get { return _intParam?? default(int); }
      set { _intParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool IntParamSpecified
    {
      get { return _intParam != null; }
      set { if (value == (_intParam== null)) _intParam = value ? IntParam : (int?)null; }
    }
    private bool ShouldSerializeIntParam() { return IntParamSpecified; }
    private void ResetIntParam() { IntParamSpecified = false; }
    

    private uint? _uintParam;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"uint_param", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint UintParam
    {
      get { return _uintParam?? default(uint); }
      set { _uintParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool UintParamSpecified
    {
      get { return _uintParam != null; }
      set { if (value == (_uintParam== null)) _uintParam = value ? UintParam : (uint?)null; }
    }
    private bool ShouldSerializeUintParam() { return UintParamSpecified; }
    private void ResetUintParam() { UintParamSpecified = false; }
    

    private long? _int64Param;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"int64_param", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public long Int64Param
    {
      get { return _int64Param?? default(long); }
      set { _int64Param = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool Int64ParamSpecified
    {
      get { return _int64Param != null; }
      set { if (value == (_int64Param== null)) _int64Param = value ? Int64Param : (long?)null; }
    }
    private bool ShouldSerializeInt64Param() { return Int64ParamSpecified; }
    private void ResetInt64Param() { Int64ParamSpecified = false; }
    

    private ulong? _uint64Param;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"uint64_param", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong Uint64Param
    {
      get { return _uint64Param?? default(ulong); }
      set { _uint64Param = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool Uint64ParamSpecified
    {
      get { return _uint64Param != null; }
      set { if (value == (_uint64Param== null)) _uint64Param = value ? Uint64Param : (ulong?)null; }
    }
    private bool ShouldSerializeUint64Param() { return Uint64ParamSpecified; }
    private void ResetUint64Param() { Uint64ParamSpecified = false; }
    

    private bool? _boolParam;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"bool_param", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool BoolParam
    {
      get { return _boolParam?? default(bool); }
      set { _boolParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool BoolParamSpecified
    {
      get { return _boolParam != null; }
      set { if (value == (_boolParam== null)) _boolParam = value ? BoolParam : (bool?)null; }
    }
    private bool ShouldSerializeBoolParam() { return BoolParamSpecified; }
    private void ResetBoolParam() { BoolParamSpecified = false; }
    

    private float? _floatParam;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"float_param", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public float FloatParam
    {
      get { return _floatParam?? default(float); }
      set { _floatParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool FloatParamSpecified
    {
      get { return _floatParam != null; }
      set { if (value == (_floatParam== null)) _floatParam = value ? FloatParam : (float?)null; }
    }
    private bool ShouldSerializeFloatParam() { return FloatParamSpecified; }
    private void ResetFloatParam() { FloatParamSpecified = false; }
    

    private double? _doubleParam;
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"double_param", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double DoubleParam
    {
      get { return _doubleParam?? default(double); }
      set { _doubleParam = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool DoubleParamSpecified
    {
      get { return _doubleParam != null; }
      set { if (value == (_doubleParam== null)) _doubleParam = value ? DoubleParam : (double?)null; }
    }
    private bool ShouldSerializeDoubleParam() { return DoubleParamSpecified; }
    private void ResetDoubleParam() { DoubleParamSpecified = false; }
    

    private bool? _isNull;
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"is_null", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool IsNull
    {
      get { return _isNull?? default(bool); }
      set { _isNull = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    [global::System.ComponentModel.Browsable(false)]
    public bool IsNullSpecified
    {
      get { return _isNull != null; }
      set { if (value == (_isNull== null)) _isNull = value ? IsNull : (bool?)null; }
    }
    private bool ShouldSerializeIsNull() { return IsNullSpecified; }
    private void ResetIsNull() { IsNullSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}
