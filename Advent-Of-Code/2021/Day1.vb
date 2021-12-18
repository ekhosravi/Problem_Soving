Imports System.IO

Module Day1

    Public Sub DoDay1()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day1.txt", FileMode.Open, FileAccess.Read) ' input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Cnt As Integer = 0
        Dim LastData As Integer = SR.ReadLine()
        Dim Data As Integer = SR.ReadLine()
        Dim Data3 As Integer = SR.ReadLine()
        Dim Data4 As Integer
        'TextBox1.Text &= CStr(LastData) + vbNewLine
        'TextBox1.Text &= CStr(Data) + vbNewLine
        'TextBox1.Text &= CStr(Data3) + vbNewLine

        While SR.Peek > -1
            Data4 = SR.ReadLine()
            'TextBox1.Text &= CStr(Data4) + vbNewLine

            If Data4 + Data3 + Data > LastData + Data3 + Data Then
                Cnt += 1
            End If
            LastData = Data
            Data = Data3
            Data3 = Data4
        End While

        MsgBox(Cnt)

        SR.Close()

    End Sub



End Module
