Imports System.IO

Module Day4

    Public Sub DoDay4()
        Try

            Dim Fs As New FileStream("E:\AOC\inputs\input-day4.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7"

            Dim RandVal As String = ""
            Dim boards = New Integer(100, 4, 4) {}
            Dim boardsCheck = New Boolean(100, 4, 4) {}

            Dim Row As Int16 = 0
            Dim column As Int16 = 0
            Dim Brd As Int16 = 0

            Dim Line As String

            While SR.Peek > -1
                Line = SR.ReadLine()
                'For Each Line As String In Data.Split(ControlChars.CrLf.ToCharArray)
                If Line <> "" Then
                        If Brd = 0 And RandVal = "" Then
                            RandVal = Line '  Mid(Line, 1, InStr(Line, ControlChars.CrLf) - 1)
                            'Data = Mid(Data, InStr(Data, ControlChars.CrLf) + 4)
                        Else
                            column = 0
                            For Each s As String In LTrim(Line).Split(" ")
                                If s <> "" Then
                                    boards(Brd, Row, column) = s
                                    column += 1
                                End If
                            Next
                            Row += 1
                            If Row = 5 Then
                                Row = 0
                                Brd += 1
                            End If
                        End If
                    End If
                'Next
            End While

            Dim i As Int16
            Dim Num As String
            Dim WinBoard As Int16 = 0
            Dim WinBoardBool(Brd - 1) As Boolean

            For Each Num In RandVal.Split(",")
                'MsgBox(Num)
                For i = 0 To Brd - 1
                    For j = 0 To 4
                        For k = 0 To 4

                            If boards(i, j, k) = Num Then
                                boardsCheck(i, j, k) = True
                                If (boardsCheck(i, j, 0) = True And boardsCheck(i, j, 1) = True And boardsCheck(i, j, 2) = True And boardsCheck(i, j, 3) = True And boardsCheck(i, j, 4) = True) Or
                                        (boardsCheck(i, 0, k) = True And boardsCheck(i, 1, k) = True And boardsCheck(i, 2, k) = True And boardsCheck(i, 3, k) = True And boardsCheck(i, 4, k) = True) Then
                                    ' یعنی قبلا این برد فعال نشده بوده و الان تاره میخواهد فعال شود 
                                    '
                                    If WinBoardBool(i) = False Then
                                        WinBoard += 1
                                        If WinBoard = Brd Then
                                            GoTo Finish
                                        End If
                                    End If
                                    WinBoardBool(i) = True
                                End If
                            End If
                        Next
                    Next
                Next
            Next

Finish:
            Dim Sum As Long = 0

            For ii = 0 To 4
                For jj = 0 To 4
                    If boardsCheck(i, ii, jj) = False Then Sum += boards(i, ii, jj)
                Next
            Next

            MsgBox(CStr(Sum * Num))

            SR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



End Module
