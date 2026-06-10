using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace PLCComMB_Master_Example_CSharp
{
    class Utilities
    {
        [DebuggerStepThrough()]
        internal static sValues_to_Write CheckValues(String ValueString, PLCcomModbus.Core.eDataType ValueType)
        {
            sValues_to_Write Result = new sValues_to_Write();
            try
            {

                //convert PLCcomModbus.Core.eDataType to .Net type
                Type T = ModbusDataTypeToNetType(ValueType);

                if (string.IsNullOrEmpty(ValueString) || T == null)
                {
                    Result.ParseError = true;
                    return Result;
                }

                //create typeconverter
                TypeConverter tc = TypeDescriptor.GetConverter(T);

                //split and parse string
                char[] Separator = "\n".ToCharArray();
                ValueString = ValueString.Replace("\r\n", "\n").TrimEnd(Separator);

                string[] rawValues = ValueString.Split(Separator);

                if (ValueType == PLCcomModbus.Core.eDataType.STRING)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string ValuePart in rawValues)
                    {
                        sb.Append(tc.ConvertFromString(ValuePart));
                    }
                    Result.values.Add(sb.ToString());
                }
                else
                {
                    foreach (string ValuePart in rawValues)
                    {
                        try
                        {
                            Result.values.Add(tc.ConvertFromString(ValuePart));
                        }
                        catch (FormatException)
                        {
                            Result.ParseError = true;
                            return Result;
                        }
                    }
                }
                return Result;
            }
            catch (Exception)
            {
                Result.ParseError = true;
                return Result;
            }
        }

        internal class sValues_to_Write
        {
            //internal List<object> values = new List<object>();
            internal System.Collections.ArrayList values = new System.Collections.ArrayList();
            internal bool ParseError;
        }

        /// <summary>
        /// convert PLCcomModbus.Core.eDataType to .Net type
        /// </summary>
        /// <param name="ValueType"></param>
        /// <returns>Type</returns>
        internal static Type ModbusDataTypeToNetType(PLCcomModbus.Core.eDataType ValueType)
        {
            switch (ValueType)
            {
                case PLCcomModbus.Core.eDataType.BOOLEAN:
                    return typeof(bool);
                case PLCcomModbus.Core.eDataType.BYTE:
                    return typeof(byte);
                case PLCcomModbus.Core.eDataType.SHORT:
                    return typeof(short);
                case PLCcomModbus.Core.eDataType.USHORT:
                    return typeof(ushort);
                case PLCcomModbus.Core.eDataType.INTEGER:
                    return typeof(int);
                case PLCcomModbus.Core.eDataType.UINTEGER:
                    return typeof(uint);
                case PLCcomModbus.Core.eDataType.LONG:
                    return typeof(long);
                case PLCcomModbus.Core.eDataType.ULONG:
                    return typeof(ulong);
                case PLCcomModbus.Core.eDataType.FLOAT:
                    return typeof(float);
                case PLCcomModbus.Core.eDataType.DOUBLE:
                    return typeof(double);
                case PLCcomModbus.Core.eDataType.STRING:
                    return typeof(string);
                case PLCcomModbus.Core.eDataType.PLC_INT:
                    return typeof(short);
                case PLCcomModbus.Core.eDataType.PLC_DINT:
                    return typeof(int);
                case PLCcomModbus.Core.eDataType.PLC_LINT:
                    return typeof(long);
                case PLCcomModbus.Core.eDataType.PLC_WORD:
                    return typeof(ushort);
                case PLCcomModbus.Core.eDataType.PLC_DWORD:
                    return typeof(uint);
                case PLCcomModbus.Core.eDataType.PLC_LWORD:
                    return typeof(ulong);
                case PLCcomModbus.Core.eDataType.PLC_BCD16:
                    return typeof(ushort);
                case PLCcomModbus.Core.eDataType.PLC_BCD32:
                    return typeof(uint);
                default:
                    return null;
            }
        }
    }

}
