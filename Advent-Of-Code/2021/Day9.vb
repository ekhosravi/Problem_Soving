Imports System.IO

Module Day9

    Public Sub DoDay9()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day9.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "2199943210
3987894921
9856789892
8767896789
9899965678"

        Dim LenSample As Int16 = 100

        Dim board = New Integer(LenSample, LenSample) {}
        Dim board_Bool = New Boolean(LenSample, LenSample) {}
        Dim Line As String = ""
        Dim CntColumn As Int16 = 1
        Dim CntRows As Int16 = 1

        While SR.Peek > -1
            Line = SR.ReadLine()
            'For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line = "" Then Continue While   'For  '
            For CntColumn = 1 To Line.Length
                    board(CntRows, CntColumn) = Mid(Line, CntColumn, 1)
                Next
                CntRows += 1
            '   Next
        End While

        CntRows -= 1
        CntColumn -= 1

        Dim Result = New Integer(LenSample * 100) {}
        Dim Result2 = New Integer(LenSample * 100) {}
        Dim Indx_Result As Int16 = 1

        Dim Cell As Int16

        For i As Int16 = 1 To CntRows
            For j As Int16 = 1 To CntColumn
                board_Bool = New Boolean(LenSample, LenSample) {}

                Cell = board(i, j)
                If j - 1 > 0 AndAlso board(i, j - 1) <= Cell Then Continue For

                If j + 1 <= CntColumn AndAlso board(i, j + 1) <= Cell Then Continue For

                If i - 1 > 0 AndAlso board(i - 1, j) <= Cell Then Continue For

                If i + 1 <= CntRows AndAlso board(i + 1, j) <= Cell Then Continue For

                Result(Indx_Result) = Cell + 1
                Result2(Indx_Result) = FindRecursiveNums(board_Bool, board, i, j, CntColumn, CntRows)  
                Indx_Result += 1
            Next
        Next

        Dim SumResult As Integer = 0
        For i As Int16 = 1 To Indx_Result - 1
            SumResult += Result(i)
        Next

        MsgBox(SumResult)

        System.Array.Sort(Result2)
        System.Array.Reverse(Result2)
        MsgBox(Result2(0) * Result2(1) * Result2(2))


        SR.Close()
    End Sub

    Private Function FindRecursiveNums(board_Bool As Boolean(,), board As Integer(,),
                                       i As Int16, j As Int16, CntColumn As Int16, CntRows As Int16,
                                       Optional Left As Boolean = True, Optional Rigth As Boolean = True,
                                       Optional Top As Boolean = True, Optional Bottom As Boolean = True) As Int16
        board_Bool(i, j) = True
        If board(i, j) = 9 Then
            Return 0
        Else
            Dim Cnt As Int16 = 0
            If j - 1 > 0 AndAlso board_Bool(i, j - 1) = False Then Cnt += FindRecursiveNums(board_Bool, board, i, j - 1, CntColumn, CntRows)

            If j + 1 <= CntColumn AndAlso board_Bool(i, j + 1) = False Then Cnt += FindRecursiveNums(board_Bool, board, i, j + 1, CntColumn, CntRows)

            If i - 1 > 0 AndAlso board_Bool(i - 1, j) = False Then Cnt += FindRecursiveNums(board_Bool, board, i - 1, j, CntColumn, CntRows)

            If i + 1 <= CntRows AndAlso board_Bool(i + 1, j) = False Then Cnt += FindRecursiveNums(board_Bool, board, i + 1, j, CntColumn, CntRows)

            'If Cnt = 0 Then
            Cnt += 1
            Return Cnt
        End If
    End Function



End Module
