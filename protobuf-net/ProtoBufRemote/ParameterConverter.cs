﻿using System;
using System.IO;
using ProtoBuf;

namespace ProtoBufRemote
{
    /// <summary>
    /// Helper functions for converting parameters to and from protobuf messages. Only public because Reflection Emit
    /// generated proxies are technically in a different assembly.
    /// </summary>
    public static class ParameterConverter
    {
        /// <summary>
        /// Converts a parameter message into an object.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="parameterType"></param>
        /// <param name="parameter"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool FromMessage(RpcMessage.Parameter message, Type parameterType, out object parameter,
                                       out string errorMsg)
        {
            if (parameterType.IsPrimitive)
            {
                if (parameterType == typeof(bool) && message.BoolParamSpecified)
                    parameter = message.BoolParam;
                else if (parameterType == typeof(byte) && message.UintParamSpecified)
                    parameter = (byte)message.UintParam;
                else if (parameterType == typeof(sbyte) && message.IntParamSpecified)
                    parameter = (sbyte)message.IntParam;
                else if (parameterType == typeof(char) && message.UintParamSpecified)
                    parameter = (char)message.UintParam;
                else if (parameterType == typeof(short) && message.IntParamSpecified)
                    parameter = (short)message.IntParam;
                else if (parameterType == typeof(ushort) && message.UintParamSpecified)
                    parameter = (ushort)message.UintParam;
                else if (parameterType == typeof(int) && message.IntParamSpecified)
                    parameter = message.IntParam;
                else if (parameterType == typeof(uint) && message.UintParamSpecified)
                    parameter = message.UintParam;
                else if (parameterType == typeof(long) && message.Int64ParamSpecified)
                    parameter = message.Int64Param;
                else if (parameterType == typeof(ulong) && message.Uint64ParamSpecified)
                    parameter = message.Uint64Param;
                else if (parameterType == typeof(float) && message.FloatParamSpecified)
                    parameter = message.FloatParam;
                else if (parameterType == typeof(double) && message.DoubleParamSpecified)
                    parameter = message.DoubleParam;
                else
                {
                    errorMsg = String.Format("Expected return type '{0}' was not found in the parameter message, or type is not supported. Only integral, string, and protobuf types are supported",
                        parameterType);
                    parameter = null;
                    return false;
                }
            }
            else if (parameterType == typeof(string))
            {
                if (message.IsNull)
                {
                    parameter = null;
                }
                else
                {
                    if (!message.StringParamSpecified)
                    {
                        errorMsg = String.Format("Expected string return type was not found in the parameter message");
                        parameter = null;
                        return false;
                    }
                    parameter = message.StringParam;
                }
            }
            else
            {
                //not a primitive or string, so it must be a protobuf message
                object[] attrs = parameterType.GetCustomAttributes(typeof(ProtoContractAttribute), true);
                if (attrs.Length < 1)
                {
                    errorMsg = String.Format("Expected return type '{0}' is not supported. Only integral, string, and protobuf types are supported",
                        parameterType);
                    parameter = null;
                    return false;
                }

                if (message.IsNull)
                {
                    parameter = null;
                }
                else
                {
                    //check the server returned a protobuf message
                    if (message.ProtoParam != null)
                    {
                        //can't check the protobuf message was the expected type, as protobuf-net is much too lenient, it doesn't
                        //check required fields or care about invalid fields either
                        var memStream = new MemoryStream(message.ProtoParam);
                        parameter = Serializer.NonGeneric.Deserialize(parameterType, memStream);
                    }
                    else
                    {
                        errorMsg = String.Format("Server had unexpected return type, was expecting a ProtoBuf message of type {0}.",
                            parameterType);
                        parameter = null;
                        return false;
                    }
                }
            }

            errorMsg = null;
            return true;
        }

        /// <summary>
        /// Converts an object to a parameter message.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="message"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool ToMessage(object parameter, out RpcMessage.Parameter message, out string errorMsg)
        {
            message = new RpcMessage.Parameter();
            if (parameter == null)
            {
                message.IsNull = true;
            }
            else
            {
                if (parameter is string)
                    message.StringParam = (string)parameter;
                else if (parameter is bool)
                    message.BoolParam = (bool)parameter;
                else if (parameter is int)
                    message.IntParam = (int)parameter;
                else if (parameter is uint)
                    message.UintParam = (uint)parameter;
                else if (parameter is float)
                    message.FloatParam = (float)parameter;
                else if (parameter is double)
                    message.DoubleParam = (double)parameter;
                else if (parameter is sbyte)
                    message.IntParam = (sbyte)parameter;
                else if (parameter is byte)
                    message.UintParam = (byte)parameter;
                else if (parameter is char)
                    message.UintParam = (char)parameter;
                else if (parameter is short)
                    message.IntParam = (short)parameter;
                else if (parameter is ushort)
                    message.UintParam = (ushort)parameter;
                else if (parameter is long)
                    message.Int64Param = (long)parameter;
                else if (parameter is ulong)
                    message.Uint64Param = (ulong)parameter;
                else
                {
                    //Must be a protobuf message
                    Type parameterType = parameter.GetType();
                    object[] attrs = parameterType.GetCustomAttributes(typeof(ProtoContractAttribute), true);
                    if (attrs.Length < 1)
                    {
                        errorMsg = String.Format("Parameter of type '{0}' is not supported. Only integral, string, and protobuf types are supported",
                            parameterType);
                        return false;
                    }
                    var memStream = new MemoryStream();
                    Serializer.NonGeneric.Serialize(memStream, parameter);
                    message.ProtoParam = memStream.ToArray();
                }
            }

            errorMsg = null;
            return true;
        }

        public static bool IsSupportedType(Type paramType)
        {
            if (paramType.IsPrimitive && paramType != typeof(decimal))
                return true;

            if (paramType == typeof(string))
                return true;

            object[] attrs = paramType.GetCustomAttributes(typeof(ProtoContractAttribute), true);
            if (attrs.Length >= 1)
                return true;

            return false;
        }

        public static RpcMessage.Parameter IntToMessage(int parameter)
        {
            var message = new RpcMessage.Parameter();
            message.IntParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter UintToMessage(uint parameter)
        {
            var message = new RpcMessage.Parameter();
            message.UintParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter Int64ToMessage(long parameter)
        {
            var message = new RpcMessage.Parameter();
            message.Int64Param = parameter;
            return message;
        }

        public static RpcMessage.Parameter Uint64ToMessage(ulong parameter)
        {
            var message = new RpcMessage.Parameter();
            message.Uint64Param = parameter;
            return message;
        }

        public static RpcMessage.Parameter BoolToMessage(bool parameter)
        {
            var message = new RpcMessage.Parameter();
            message.BoolParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter FloatToMessage(float parameter)
        {
            var message = new RpcMessage.Parameter();
            message.FloatParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter DoubleToMessage(double parameter)
        {
            var message = new RpcMessage.Parameter();
            message.DoubleParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter StringToMessage(string parameter)
        {
            var message = new RpcMessage.Parameter();
            if (parameter == null)
                message.IsNull = true;
            else
                message.StringParam = parameter;
            return message;
        }

        public static RpcMessage.Parameter ProtoToMessage(object parameter)
        {
            var message = new RpcMessage.Parameter();
            if (parameter == null)
            {
                message.IsNull = true;
            }
            else
            {
                var memStream = new MemoryStream();
                Serializer.NonGeneric.Serialize(memStream, parameter);
                message.ProtoParam = memStream.ToArray();
            }
            return message;
        }

        public static bool IntFromMessage(RpcMessage.Parameter message, ref int value, ref string error)
        {
            if (!message.IntParamSpecified)
            {
                error = "Parameter did not have expected int type.";
                return false;
            }
            value = message.IntParam;
            return true;
        }

        public static bool UintFromMessage(RpcMessage.Parameter message, ref uint value, ref string error)
        {
            if (!message.UintParamSpecified)
            {
                error = "Parameter did not have expected uint type.";
                return false;
            }
            value = message.UintParam;
            return true;
        }

        public static bool Int64FromMessage(RpcMessage.Parameter message, ref long value, ref string error)
        {
            if (!message.Int64ParamSpecified)
            {
                error = "Parameter did not have expected long type.";
                return false;
            }
            value = message.Int64Param;
            return true;
        }

        public static bool Uint64FromMessage(RpcMessage.Parameter message, ref ulong value, ref string error)
        {
            if (!message.Uint64ParamSpecified)
            {
                error = "Parameter did not have expected ulong type.";
                return false;
            }
            value = message.Uint64Param;
            return true;
        }

        public static bool BoolFromMessage(RpcMessage.Parameter message, ref bool value, ref string error)
        {
            if (!message.BoolParamSpecified)
            {
                error = "Parameter did not have expected bool type.";
                return false;
            }
            value = message.BoolParam;
            return true;
        }

        public static bool FloatFromMessage(RpcMessage.Parameter message, ref float value, ref string error)
        {
            if (!message.FloatParamSpecified)
            {
                error = "Parameter did not have expected float type.";
                return false;
            }
            value = message.FloatParam;
            return true;
        }

        public static bool DoubleFromMessage(RpcMessage.Parameter message, ref double value, ref string error)
        {
            if (!message.DoubleParamSpecified)
            {
                error = "Parameter did not have expected double type.";
                return false;
            }
            value = message.DoubleParam;
            return true;
        }

        public static bool StringFromMessage(RpcMessage.Parameter message, ref string value, ref string error)
        {
            if (message.IsNull)
            {
                value = null;
                return true;
            }
            if (!message.StringParamSpecified)
            {
                error = "Parameter did not have expected string type.";
                return false;
            }
            value = message.StringParam;
            return true;
        }

        public static bool ProtoFromMessage(RpcMessage.Parameter message, Type type, ref object value,
                                              ref string error)
        {
            if (message.IsNull)
            {
                value = null;
                return true;
            }

            //check the server returned a protobuf message
            if (message.ProtoParam == null)
            {
                error = String.Format(
                    "Server had unexpected return type, was expecting a ProtoBuf message of type {0}.", type);
                return false;
            }

            //can't check the protobuf message was the expected type, as protobuf-net is much too lenient, it doesn't
            //check required fields or care about invalid fields either
            var memStream = new MemoryStream(message.ProtoParam);
            value = Serializer.NonGeneric.Deserialize(type, memStream);
            return true;
        }
    }
}
