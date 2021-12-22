Imports System.IO

Module Day10

    Public Sub DoDay10()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day10.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]"

        Dim LenSample As Int16 = 100

        Dim board = New String(LenSample) {} ', LenSample) {}
        Dim board_Bool = New Boolean(LenSample, LenSample) {}
        Dim Line As String = ""
        Dim CntColumn As Int16 = 1
        Dim CntRows As Int16 = 1
        Dim Result = New Integer(LenSample) {}
        Dim Indx_Result As Integer = 1
        Dim Corrupted As Boolean = False
        Dim Cursor As Int16 = 1

        Dim SumResult As Integer = 0

        Dim CompleteResult = New Long(LenSample) {}
        Dim BoardCompleteResult As String = ""
        Dim Indx_CompleteResult As Integer = 1

        While SR.Peek > -1
            Line = SR.ReadLine()
            '   For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line = "" Then Continue  While   ' For  '
            Corrupted = False
            Cursor = 1
            For CntColumn = 1 To Line.Length
                Select Case Mid(Line, CntColumn, 1)
                    Case "(", "[", "{", "<"
                        board(Cursor) = Mid(Line, CntColumn, 1)
                        Cursor += 1
                    Case Else
                        If Mid(Line, CntColumn, 1) = ")" And board(Cursor - 1) = "(" Or
                                    Mid(Line, CntColumn, 1) = "]" And board(Cursor - 1) = "[" Or
                                    Mid(Line, CntColumn, 1) = "}" And board(Cursor - 1) = "{" Or
                                    Mid(Line, CntColumn, 1) = ">" And board(Cursor - 1) = "<" Then
                            Cursor -= 1
                        Else
                            Corrupted = True

                            Exit For
                        End If
                End Select
            Next

            If Corrupted Then
                Select Case Mid(Line, CntColumn, 1)
                    Case ")"
                        SumResult += 3
                    Case "]"
                        SumResult += 57
                    Case "}"
                        SumResult += 1197
                    Case ">"
                        SumResult += 25137
                End Select
                Indx_Result += 1
            Else
                BoardCompleteResult = ""
                For k As Int16 = Cursor - 1 To 1 Step -1
                    Select Case board(k)
                        Case "("
                            BoardCompleteResult &= ")"
                        Case "["
                            BoardCompleteResult &= "]"
                        Case "{"
                            BoardCompleteResult &= "}"
                        Case "<"
                            BoardCompleteResult &= ">"
                    End Select
                Next
                For k As Int16 = 1 To BoardCompleteResult.Length
                    CompleteResult(Indx_CompleteResult) = CompleteResult(Indx_CompleteResult) * 5 +
                                IIf(Mid(BoardCompleteResult, k, 1) = ")", 1,
                                    IIf(Mid(BoardCompleteResult, k, 1) = "]", 2,
                                        IIf(Mid(BoardCompleteResult, k, 1) = "}", 3, 4)))
                Next
                Indx_CompleteResult += 1
            End If

            CntRows += 1
            '   Next
        End While

        Array.Sort(CompleteResult)
        Array.Reverse(CompleteResult)



        MsgBox(CompleteResult(CInt((Indx_CompleteResult - 1) / 2)))

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
