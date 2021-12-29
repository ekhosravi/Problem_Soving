Imports System.IO

Module Day11

    Public Sub DoDay11()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day9.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        '        Dim Data As String = "5483143223
        '2745854711
        '5264556173
        '6141336146
        '6357385478
        '4167524645
        '2176841721
        '6882881134
        '4846848554
        '5283751526"

        Dim Data As String = "8271653836
7567626775
2315713316
6542655315
2453637333
1247264328
2325146614
2115843171
6182376282
2384738675"

        Dim LenSample As Int16 = 10

        Dim board = New Integer(LenSample, LenSample) {}
        Dim board_Bool = New Boolean(LenSample, LenSample) {}
        Dim Line As String = ""
        Dim CntColumn As Int16 = 1
        Dim CntRows As Int16 = 1

        '  While SR.Peek > -1
        '   Line = SR.ReadLine()
        For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line.Trim = "" Then Continue For  '  While   '
            For CntColumn = 1 To Line.Length
                board(CntRows, CntColumn) = Mid(Line, CntColumn, 1)
            Next
            CntRows += 1
        Next
        '   End While

        Dim CntZeoNum As Int16 = 0
        Dim k As Int16
        Dim ExitFullFor As Boolean = False
        For k = 1 To 1000
            board_Bool = New Boolean(LenSample, LenSample) {}
            For i As Int16 = 1 To 10
                For j As Int16 = 1 To 10
                    If board_Bool(i, j) = True And board(i, j) = 0 Then Continue For
                    board(i, j) += 1
                    CntZeoNum += DoSteps(board_Bool, board, i, j)
                    If CheckAllFlashes(board) Then
                        ExitFullFor = True
                        Exit For
                    End If
                Next j
                If ExitFullFor Then Exit For
            Next i
            If ExitFullFor Then Exit For
        Next k

        MsgBox(k)

        SR.Close()
    End Sub

    Private Function CheckAllFlashes(board As Integer(,)) As Boolean
        For i As Int16 = 1 To 10
            For j As Int16 = 1 To 10
                If board(i, j) <> 0 Then Return False
            Next
        Next
        Return True
    End Function

    Private Function DoSteps(ByRef brd_Bool As Boolean(,), ByRef board As Integer(,), i As Int16, j As Int16) As Int16
        If board(i, j) < 10 Then
            Return 0
        Else
            brd_Bool(i, j) = True
            board(i, j) = 0
            Dim Cnt As Int16 = 0

            CalculateBrd(brd_Bool, board, i, j - 1, Cnt)

            CalculateBrd(brd_Bool, board, i - 1, j - 1, Cnt)
            CalculateBrd(brd_Bool, board, i + 1, j - 1, Cnt)

            CalculateBrd(brd_Bool, board, i, j + 1, Cnt)

            CalculateBrd(brd_Bool, board, i - 1, j + 1, Cnt)
            CalculateBrd(brd_Bool, board, i + 1, j + 1, Cnt)

            CalculateBrd(brd_Bool, board, i - 1, j, Cnt)
            CalculateBrd(brd_Bool, board, i + 1, j, Cnt)

            Cnt += 1
            Return Cnt
        End If
    End Function

    Private Sub CalculateBrd(ByRef brd_Bool As Boolean(,), ByRef board As Integer(,), i As Int16, j As Int16, ByRef Cnt As Int16)
        If i > 0 And i <= 10 And j > 0 And j <= 10 Then
            If brd_Bool(i, j) = True And board(i, j) = 0 Then Return
            board(i, j) += 1
            Cnt += DoSteps(brd_Bool, board, i, j)
        End If
    End Sub



End Module
