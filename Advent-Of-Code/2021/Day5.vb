Imports System.IO

Module Day5

    Public Sub DoDay5_B()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day5.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2"

        Dim LenSample As Int16 = 1000

        Dim board = New Integer(LenSample, LenSample) {}

        Dim x1, y1, x2, y2 As Int16
        Dim Num1 As String, Num2 As String, Line As String

        Dim CntGreaterThanTwo As Int32 = 0

        Dim SwitchTwoInt As Int16 = 0
        Dim SignX As Int16 = 0
        Dim SignY As Int16 = 0

        While SR.Peek > -1
            Line = SR.ReadLine()
            'For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line <> "" Then
                    Num1 = Mid(Line, 1, InStr(Line, "->") - 2)
                    Num2 = Mid(Line, InStr(Line, "->") + 3)
                    x1 = Mid(Num1, 1, InStr(Num1, ",") - 1)
                    y1 = Mid(Num1, InStr(Num1, ",") + 1)
                    x2 = Mid(Num2, 1, InStr(Num2, ",") - 1)
                    y2 = Mid(Num2, InStr(Num2, ",") + 1)

                If y1 = y2 Then
                    If x1 > x2 Then
                        SwitchTwoNumber(x1, x2)
                    End If
                    For i As Int16 = x1 To x2
                        SetBoard(board, i, y1, CntGreaterThanTwo)
                    Next
                ElseIf x1 = x2 Then
                    If y1 > y2 Then
                        SwitchTwoNumber(y1, y2)
                    End If
                    For i As Int16 = y1 To y2
                        SetBoard(board, x1, i, CntGreaterThanTwo)
                    Next
                ElseIf Math.Abs(x2 - x1) = Math.Abs(y2 - y1) Then ' Or (x1 - y1) = 0 Or (x2 - y2) = 0 Then
                    SignX = (x2 - x1) / Math.Abs(x2 - x1)
                        SignY = (y2 - y1) / Math.Abs(y2 - y1)

                        Do
                            SetBoard(board, x1, y1, CntGreaterThanTwo)
                            x1 = x1 + SignX * 1
                            y1 = y1 + SignY * 1

                        Loop Until (x1 = x2)
                        SetBoard(board, x2, y2, CntGreaterThanTwo)

                    End If
                End If
            'Next
        End While
        MsgBox(CntGreaterThanTwo)
        SR.Close()
    End Sub

    Private Sub SetBoard(ByRef Brd As Integer(,), i As Int16, j As Int16, ByRef AddCnt As Int32)
        Brd(i, j) += 1
        If Brd(i, j) = 2 Then AddCnt += 1
    End Sub


    Private Sub SwitchTwoNumber(ByRef t1 As Int16, ByRef t2 As Int16)
        Dim SwitchTwoInt As Int16 = t1
        t1 = t2
        t2 = SwitchTwoInt
    End Sub

    Public Sub DoDay5()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day5.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2"

        Dim LenSample As Int16 = 1000

        Dim board = New Integer(LenSample, LenSample) {} ' (1000, 1000) {}

        Dim x1, y1, x2, y2 As Int16
        Dim Num1 As String, Num2 As String, Line As String

        Dim CntGreaterThanTwo As Int32 = 0

        Dim SwitchTwoInt As Int16 = 0

        While SR.Peek > -1
            Line = SR.ReadLine()
            'For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line <> "" Then
                Num1 = Mid(Line, 1, InStr(Line, "->") - 2)
                Num2 = Mid(Line, InStr(Line, "->") + 3)
                x1 = Mid(Num1, 1, InStr(Num1, ",") - 1)
                y1 = Mid(Num1, InStr(Num1, ",") + 1)
                x2 = Mid(Num2, 1, InStr(Num2, ",") - 1)
                y2 = Mid(Num2, InStr(Num2, ",") + 1)

                If y1 = y2 Then
                    If x1 > x2 Then
                        SwitchTwoInt = x1
                        x1 = x2
                        x2 = SwitchTwoInt
                    End If
                    For i As Int16 = x1 To x2
                        board(i, y1) += 1
                        If board(i, y1) = 2 Then CntGreaterThanTwo += 1
                    Next
                ElseIf x1 = x2 Then
                    If y1 > y2 Then
                        SwitchTwoInt = y1
                        y1 = y2
                        y2 = SwitchTwoInt
                    End If
                    For i As Int16 = y1 To y2
                        board(x1, i) += 1
                        If board(x1, i) = 2 Then CntGreaterThanTwo += 1
                    Next
                End If
            End If
            'Next
        End While

        MsgBox(CntGreaterThanTwo)

        SR.Close()
    End Sub



End Module
