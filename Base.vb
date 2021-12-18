Imports System.IO

Module Day__

    Public Sub DoDay__()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day6.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "3,4,3,1,2"

        Dim iList = New Integer() {}
        Dim Line As String
        Dim CntGreaterThanTwo As Int32 = 0

        Dim FirstListCnt As Int16 = 0

        'While SR.Peek > -1
        '    Line = SR.ReadLine()
        For Each Line In Data.Split(",")
            If Line <> "" Then
                iList(FirstListCnt) = Line
                FirstListCnt += 1
            End If
        Next
        'End While

        Dim AddZeroToSix As Int32 = 0
        Dim i As Int32 = 0

        For j As Int16 = 0 To 80
            AddZeroToSix = 0
            For i = 0 To iList.Length - 1
                iList(i) -= 1
                If iList(i) = 0 Then iList(i) = 6
                AddZeroToSix += 1
            Next

            For i = FirstListCnt To FirstListCnt + AddZeroToSix - 1
                iList(i) = 8
                FirstListCnt += 1
            Next
        Next

        MsgBox(FirstListCnt)

        SR.Close()
    End Sub


    Public Sub DoDay__B()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day6.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "3,4,3,1,2"

        Dim LenSample As Int16 = 1000
        Dim board = New Integer(LenSample, LenSample) {}
        Dim Line As String
        Dim CntGreaterThanTwo As Int32 = 0

        While SR.Peek > -1
            Line = SR.ReadLine()
            'For Each Line In Data.Split(ControlChars.CrLf.ToCharArray)
            If Line <> "" Then

            End If
            'Next
        End While
        MsgBox(CntGreaterThanTwo)
        SR.Close()
    End Sub


End Module
