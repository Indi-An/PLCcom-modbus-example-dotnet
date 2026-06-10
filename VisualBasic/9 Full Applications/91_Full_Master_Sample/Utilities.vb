Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Text

Friend Class Utilities
    <DebuggerStepThrough>
    Friend Shared Function CheckValues(ValueString As [String], ValueType As PLCcomModbus.Core.eDataType) As sValues_to_Write
        Dim Result As New sValues_to_Write()
        Try

            'convert PLCcomModbus.Core.eDataType to .Net type
            Dim T As Type = ModbusDataTypeToNetType(ValueType)

            If String.IsNullOrEmpty(ValueString) OrElse T Is Nothing Then
                Result.ParseError = True
                Return Result
            End If

            'create typeconverter
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(T)

            'split and parse string
            Dim Separator As Char() = vbLf.ToCharArray()
            ValueString = ValueString.Replace(vbCr & vbLf, vbLf).TrimEnd(Separator)

            Dim rawValues As String() = ValueString.Split(Separator)

            If ValueType = PLCcomModbus.Core.eDataType.STRING Then
                Dim sb As New StringBuilder()
                For Each ValuePart As String In rawValues
                    sb.Append(tc.ConvertFromString(ValuePart))
                Next
                Result.values.Add(sb.ToString())
            Else
                For Each ValuePart As String In rawValues
                    Try
                        Result.values.Add(tc.ConvertFromString(ValuePart))
                    Catch generatedExceptionName As FormatException
                        Result.ParseError = True
                        Return Result
                    End Try
                Next
            End If


            Return Result
        Catch generatedExceptionName As Exception
            Result.ParseError = True
            Return Result
        End Try
    End Function


    <DebuggerStepThrough()>
    Friend Class sValues_to_Write
        Friend values As System.Collections.ArrayList = New System.Collections.ArrayList()
        Friend ParseError As Boolean
    End Class

    ''' <summary>
    ''' convert PLCcomModbus.Core.eDataType to .Net type
    ''' </summary>
    ''' <param name="ValueType"></param>
    ''' <returns>Type</returns>
    Friend Shared Function ModbusDataTypeToNetType(ValueType As PLCcomModbus.Core.eDataType) As Type
        Select Case ValueType
            Case PLCcomModbus.Core.eDataType.[BOOLEAN]
                Return GetType(Boolean)
            Case PLCcomModbus.Core.eDataType.[BYTE]
                Return GetType(Byte)
            Case PLCcomModbus.Core.eDataType.[SHORT]
                Return GetType(Short)
            Case PLCcomModbus.Core.eDataType.[USHORT]
                Return GetType(UShort)
            Case PLCcomModbus.Core.eDataType.[INTEGER]
                Return GetType(Integer)
            Case PLCcomModbus.Core.eDataType.[UINTEGER]
                Return GetType(UInteger)
            Case PLCcomModbus.Core.eDataType.[LONG]
                Return GetType(Long)
            Case PLCcomModbus.Core.eDataType.[ULONG]
                Return GetType(ULong)
            Case PLCcomModbus.Core.eDataType.FLOAT
                Return GetType(Single)
            Case PLCcomModbus.Core.eDataType.[DOUBLE]
                Return GetType(Double)
            Case PLCcomModbus.Core.eDataType.[STRING]
                Return GetType(String)
            Case PLCcomModbus.Core.eDataType.PLC_INT
                Return GetType(Short)
            Case PLCcomModbus.Core.eDataType.PLC_DINT
                Return GetType(Integer)
            Case PLCcomModbus.Core.eDataType.PLC_LINT
                Return GetType(Long)
            Case PLCcomModbus.Core.eDataType.PLC_WORD
                Return GetType(UShort)
            Case PLCcomModbus.Core.eDataType.PLC_DWORD
                Return GetType(UInteger)
            Case PLCcomModbus.Core.eDataType.PLC_LWORD
                Return GetType(ULong)
            Case PLCcomModbus.Core.eDataType.PLC_BCD16
                Return GetType(UShort)
            Case PLCcomModbus.Core.eDataType.PLC_BCD32
                Return GetType(UInteger)
            Case Else
                Return Nothing
        End Select
    End Function


End Class
