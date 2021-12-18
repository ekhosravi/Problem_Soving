Imports System.IO

Module Day2

    Public Sub DoDay2()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day2.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Cnt As Integer = 0
        Dim Data As String '= SR.ReadLine()
        Dim Moving As Int16 = 0, Indx As Int16
        Dim H As Integer = 0
        Dim D As Integer = 0
        Dim aim As Integer = 0


        While SR.Peek > -1
            Data = SR.ReadLine()
            'TextBox1.Text &= CStr(Data) + vbNewLine

            Indx = InStr(Data, " ")
            Moving = Mid(Data, Indx + 1)

            Select Case Mid(Data, 1, 1).ToLower
                Case "f"
                    H += Moving
                    D += Moving * aim

                Case "d"
                    aim += Moving

                Case "u"
                    aim -= Moving

            End Select

        End While

        MsgBox(H * D)

        'TextBox1.Clear()
        SR.Close()
    End Sub



End Module
