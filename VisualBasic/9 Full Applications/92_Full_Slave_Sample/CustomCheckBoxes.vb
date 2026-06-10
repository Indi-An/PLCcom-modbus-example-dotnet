''' <summary>
''' object stores and uses the current values ​​of the bitbar checkboxes
''' </summary>
Friend Class CustomCheckBoxes
#Region "private member"
    Private mCheckBoxes As New List(Of CheckBox)()
#End Region

#Region "propertys"
    Friend ReadOnly Property CheckBoxes() As CheckBox()
        Get
            Return mCheckBoxes.ToArray()
        End Get
    End Property
#End Region

#Region "global member"
    Friend Sub addCheckBox(value As CheckBox)
        mCheckBoxes.Add(value)
    End Sub

    ''' <summary>
    ''' enabled or disabled check state
    ''' </summary>
    ''' <param name="index">index from desired checkbox</param>
    ''' <param name="value">true or false</param>
    ''' <returns>true, if the operation successfully, otherwise false</returns>
    Friend Function setChecked(index As Integer, value As Boolean) As Boolean
        Try
            If mCheckBoxes.Count < index - 1 Then
                Return False
            End If
            mCheckBoxes(index).Checked = value
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' enabled or disabled checkbox
    ''' </summary>
    ''' <param name="index">index from desired checkbox</param>
    ''' <param name="value">true or false</param>
    ''' <returns>true, if the operation successfully, otherwise false</returns>
    Friend Function setEnabled(index As Integer, value As Boolean) As Boolean
        Try
            If mCheckBoxes.Count < index - 1 Then
                Return False
            End If
            mCheckBoxes(index).Enabled = value
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' enabled all ckecboxes of bitbar
    ''' </summary>
    ''' <param name="Enable16BitBoxes">enable bitbar 0-15</param>
    ''' <param name="Enable32BitBoxes">enable bitbar 16-31</param>
    ''' <returns>true, if the operation successfully, otherwise false</returns>
    Friend Function EnableBitBarComplete(Enable16BitBoxes As Boolean, Enable32BitBoxes As Boolean) As Boolean
        Try
            For i As Integer = 0 To mCheckBoxes.Count - 1
                If i < 16 Then
                    mCheckBoxes(i).Enabled = Enable16BitBoxes
                Else
                    mCheckBoxes(i).Enabled = Enable32BitBoxes
                End If
            Next
            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' set complete bitbar to true or false
    ''' </summary>
    ''' <param name="value">true or false</param>
    ''' <returns>true, if the operation successfully, otherwise false</returns>
    Friend Function SetBitBarComplete(value As Boolean) As Boolean
        Try
            For Each c As CheckBox In mCheckBoxes
                c.Checked = value
            Next

            Return True
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' set bitbar depending on the value
    ''' </summary>
    ''' <param name="value">a Int32 value</param>
    Friend Sub SetCheckBoxesfromValue(value As UInteger)
        Dim b As Byte() = System.BitConverter.GetBytes(value)
        Dim BitAr As New BitArray(b)
        For i As Integer = 0 To BitAr.Length - 1
            mCheckBoxes(i).Checked = BitAr(i)
        Next
    End Sub

    ''' <summary>
    ''' set bitbar depending on the value
    ''' </summary>
    ''' <param name="value">a Int16 value</param>
    Friend Sub SetCheckBoxesfromValue(value As UShort)
        Dim b As Byte() = System.BitConverter.GetBytes(value)
        Dim BitAr As New BitArray(b)
        For i As Integer = 0 To BitAr.Length - 1
            mCheckBoxes(i).Checked = BitAr(i)
        Next
    End Sub

    ''' <summary>
    ''' get value depending on the current bitbar
    ''' </summary>
    ''' <returns>a Int32 value</returns>
    Friend Function getValue() As UInteger
        Dim Value As UInteger = 0
        For i As Integer = 0 To mCheckBoxes.Count - 1
            If mCheckBoxes(i).Checked Then
                Value += CUInt(1 << i)
            End If
        Next
        Return Value
    End Function

#End Region
End Class

