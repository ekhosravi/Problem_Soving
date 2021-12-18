Imports System.IO

Module Day6

    Public Sub DoDay6()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day6.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        Dim Data As String = "3,4,3,1,2"

        Dim iList As New List(Of Int16)()
        Dim iList2 As New List(Of Int16)()
        Dim Line As String

        'While SR.Peek > -1
        '    Data = SR.ReadLine()
        For Each Line In Data.Split(",")
            If Line <> "" Then
                iList.Add(Line)
            End If
        Next
        'End While

        Dim AddZeroToSix As Long = 0
        Dim i As Long = 0

        For j As Long = 0 To 255
            AddZeroToSix = 0
            For i = 0 To iList.Count - 1
                If iList(i) = 0 Then
                    iList(i) = 6
                    AddZeroToSix += 1
                    'If AddZeroToSix > 1000000 Then
                    '    MsgBox("AddZeroToSix so many")
                    'End If
                Else
                    iList(i) -= 1
                End If
            Next

            For i = 0 To AddZeroToSix - 1
                iList.Add(8)
            Next
        Next

        MsgBox(iList.Count)

        SR.Close()
    End Sub


    Public Sub DoDay5_B()
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
