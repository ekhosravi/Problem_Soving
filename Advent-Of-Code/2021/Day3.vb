Imports System.IO
Imports System.Collections.Generic

Module Day3

    Public Sub DoDay3()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day3.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010"

        Dim PositiveBitCounts(12) As Int16
        Dim NegetiveBitCounts(12) As Int16

        'Dim LineArr() As String
        Dim i As Int16 = 0
        'Dim Line As String

        'While SR.Peek > -1
        '    Line = SR.ReadLine()
        For Each Line As String In Data.Split(ControlChars.CrLf.ToCharArray)
            'LineArr = Line.Split("")
            For i = 1 To Line.Length
                If Mid(Line, i, 1) = "1" Then
                    PositiveBitCounts(i) += 1
                Else
                    NegetiveBitCounts(i) += 1
                End If
            Next
        Next
        'End While

        Dim Gamma As String = "", Epsilon As String = ""
        Dim GammaDecimal As Long, EpsilonDecimal As Long
        Dim j As Int16
        For j = 1 To PositiveBitCounts.Length - 1
            If PositiveBitCounts(j) > NegetiveBitCounts(j) Then
                Gamma += "1"
                Epsilon += "0"
            Else
                Gamma += "0"
                Epsilon += "1"
            End If
        Next

        GammaDecimal = Convert.ToInt64(Gamma, 2)
        EpsilonDecimal = Convert.ToInt64(Epsilon, 2)

        MsgBox(CStr(GammaDecimal * EpsilonDecimal))

        SR.Close()
    End Sub


    Public Sub DoDay3_2()
        Dim Fs As New FileStream("E:\AOC\D3\input.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010"


        Dim Ox As String = "", Co2 As String = ""
        Dim OxDecimal As Long, Co2Decimal As Long

        Dim iList As New List(Of String)()
        Dim Line As String

        While SR.Peek > -1
            Line = SR.ReadLine()
            'For Each Line As String In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line <> "" Then iList.Add(Line)
            'Next
        End While

        Ox = GetValue(iList, "1", True)
        Co2 = GetValue(iList, "0", False)

        OxDecimal = Convert.ToInt64(Ox, 2)
        Co2Decimal = Convert.ToInt64(Co2, 2)

        MsgBox(CStr(OxDecimal * Co2Decimal))

        SR.Close()
    End Sub

    Private Function GetValue(ByVal NewData As Object, ByVal SelectCriteria As String, ByVal KeepMost As Boolean) As String
        Dim column As Int16 = 1
        Dim Pos As Int16
        Dim Neg As Int16
        'Dim Line As String

        While (NewData.Count > 1)
            Pos = 0
            Neg = 0
            For Each Line As String In NewData
                'For column = 1 To Line.Length
                If Mid(Line, column, 1) = "1" Then
                    Pos += 1
                Else
                    Neg += 1
                End If
            Next

            Dim Keepcriteria As String = SelectCriteria

            If Pos > Neg Then
                If KeepMost Then
                    Keepcriteria = "1"
                Else
                    Keepcriteria = "0"
                End If
            ElseIf Pos < Neg Then
                If KeepMost Then
                    Keepcriteria = "0"
                Else
                    Keepcriteria = "1"
                End If
            End If

            Dim KeepList As New List(Of String)()
            For Each Line As String In NewData
                If Mid(Line, column, 1) = Keepcriteria Then
                    KeepList.Add(Line)
                End If
            Next

            NewData = KeepList

            column += 1
        End While

        Return NewData.Item(0)

    End Function


    Private Sub Test1()
        Dim Fs As New FileStream("E:\AOC\input.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Cnt As Integer = 0
        Dim Data As String = "", gamma As String = "", epsilon As String = ""
        Dim GammaDecimal As Integer = 0, EpsilonDecimal As Integer = 0

        Dim ZeroCnt1 As Int16 = 0, OneCnt1 As Int16 = 0
        Dim ZeroCnt2 As Int16 = 0, OneCnt2 As Int16 = 0
        Dim ZeroCnt3 As Int16 = 0, OneCnt3 As Int16 = 0
        Dim ZeroCnt4 As Int16 = 0, OneCnt4 As Int16 = 0
        Dim ZeroCnt5 As Int16 = 0, OneCnt5 As Int16 = 0
        Dim ZeroCnt6 As Int16 = 0, OneCnt6 As Int16 = 0
        Dim ZeroCnt7 As Int16 = 0, OneCnt7 As Int16 = 0
        Dim ZeroCnt8 As Int16 = 0, OneCnt8 As Int16 = 0
        Dim ZeroCnt9 As Int16 = 0, OneCnt9 As Int16 = 0
        Dim ZeroCnt10 As Int16 = 0, OneCnt10 As Int16 = 0
        Dim ZeroCnt11 As Int16 = 0, OneCnt11 As Int16 = 0
        Dim ZeroCnt12 As Int16 = 0, OneCnt12 As Int16 = 0

        While SR.Peek > -1
            Data = SR.ReadLine()
            'TextBox1.Text &= CStr(Data) + vbNewLine

            If Mid(Data, 1, 1) = "0" Then ZeroCnt1 += 1 Else OneCnt1 += 1
            If Mid(Data, 2, 1) = "0" Then ZeroCnt2 += 1 Else OneCnt2 += 1
            If Mid(Data, 3, 1) = "0" Then ZeroCnt3 += 1 Else OneCnt3 += 1
            If Mid(Data, 4, 1) = "0" Then ZeroCnt4 += 1 Else OneCnt4 += 1
            If Mid(Data, 5, 1) = "0" Then ZeroCnt5 += 1 Else OneCnt5 += 1
            If Mid(Data, 6, 1) = "0" Then ZeroCnt6 += 1 Else OneCnt6 += 1
            If Mid(Data, 7, 1) = "0" Then ZeroCnt7 += 1 Else OneCnt7 += 1
            If Mid(Data, 8, 1) = "0" Then ZeroCnt8 += 1 Else OneCnt8 += 1
            If Mid(Data, 9, 1) = "0" Then ZeroCnt9 += 1 Else OneCnt9 += 1
            If Mid(Data, 10, 1) = "0" Then ZeroCnt10 += 1 Else OneCnt10 += 1
            If Mid(Data, 11, 1) = "0" Then ZeroCnt11 += 1 Else OneCnt11 += 1
            If Mid(Data, 12, 1) = "0" Then ZeroCnt12 += 1 Else OneCnt12 += 1

        End While

        gamma &= IIf(ZeroCnt1 > OneCnt1, "0", "1")
        epsilon &= IIf(ZeroCnt1 > OneCnt1, "1", "0")

        gamma &= IIf(ZeroCnt2 > OneCnt2, "0", "1")
        epsilon &= IIf(ZeroCnt2 > OneCnt2, "1", "0")

        gamma &= IIf(ZeroCnt3 > OneCnt3, "0", "1")
        epsilon &= IIf(ZeroCnt3 > OneCnt3, "1", "0")

        gamma &= IIf(ZeroCnt4 > OneCnt4, "0", "1")
        epsilon &= IIf(ZeroCnt4 > OneCnt4, "1", "0")

        gamma &= IIf(ZeroCnt5 > OneCnt5, "0", "1")
        epsilon &= IIf(ZeroCnt5 > OneCnt5, "1", "0")

        gamma &= IIf(ZeroCnt6 > OneCnt6, "0", "1")
        epsilon &= IIf(ZeroCnt6 > OneCnt6, "1", "0")

        gamma &= IIf(ZeroCnt7 > OneCnt7, "0", "1")
        epsilon &= IIf(ZeroCnt7 > OneCnt7, "1", "0")

        gamma &= IIf(ZeroCnt8 > OneCnt8, "0", "1")
        epsilon &= IIf(ZeroCnt8 > OneCnt8, "1", "0")

        gamma &= IIf(ZeroCnt9 > OneCnt9, "0", "1")
        epsilon &= IIf(ZeroCnt9 > OneCnt9, "1", "0")

        gamma &= IIf(ZeroCnt5 > OneCnt5, "0", "1")
        epsilon &= IIf(ZeroCnt5 > OneCnt5, "1", "0")

        gamma &= IIf(ZeroCnt5 > OneCnt5, "0", "1")
        epsilon &= IIf(ZeroCnt5 > OneCnt5, "1", "0")

        gamma &= IIf(ZeroCnt5 > OneCnt5, "0", "1")
        epsilon &= IIf(ZeroCnt5 > OneCnt5, "1", "0")


        GammaDecimal = Convert.ToInt32(gamma, 2)
        EpsilonDecimal = Convert.ToInt32(epsilon, 2)

        MsgBox(GammaDecimal * EpsilonDecimal)

        SR.Close()
    End Sub


End Module
