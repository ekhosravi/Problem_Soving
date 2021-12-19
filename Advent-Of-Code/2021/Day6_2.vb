Imports System.IO

Module Day6_2

    Public Sub DoDay6_2()
        Dim Fs As New FileStream("E:\AOC\inputs\input-day6.txt", FileMode.Open, FileAccess.Read) ' AOC1 input
        Dim SR As New StreamReader(Fs)
        SR.BaseStream.Seek(0, SeekOrigin.Begin)

        ' Dim Data As String = "3,4,3,1,2"
        Dim Data As String = "5,1,5,3,2,2,3,1,1,4,2,4,1,2,1,4,1,1,5,3,5,1,5,3,1,2,4,4,1,1,3,1,1,3,1,1,5,1,5,4,5,4,5,1,3,2,4,3,5,3,5,4,3,1,4,3,1,1,1,4,5,1,1,1,2,1,2,1,1,4,1,4,1,1,3,3,2,2,4,2,1,1,5,3,1,3,1,1,4,3,3,3,1,5,2,3,1,3,1,5,2,2,1,2,1,1,1,3,4,1,1,1,5,4,1,1,1,4,4,2,1,5,4,3,1,2,5,1,1,1,1,2,1,5,5,1,1,1,1,3,1,4,1,3,1,5,1,1,1,5,5,1,4,5,4,5,4,3,3,1,3,1,1,5,5,5,5,1,2,5,4,1,1,1,2,2,1,3,1,1,2,4,2,2,2,1,1,2,2,1,5,2,1,1,2,1,3,1,3,2,2,4,3,1,2,4,5,2,1,4,5,4,2,1,1,1,5,4,1,1,4,1,4,3,1,2,5,2,4,1,1,5,1,5,4,1,1,4,1,1,5,5,1,5,4,2,5,2,5,4,1,1,4,1,2,4,1,2,2,2,1,1,1,5,5,1,2,5,1,3,4,1,1,1,1,5,3,4,1,1,2,1,1,3,5,5,2,3,5,1,1,1,5,4,3,4,2,2,1,3"

        Dim iList = New Long(8) {}
        Dim Line As String

        'While SR.Peek > -1
        '    Data = SR.ReadLine()
        For Each Line In Data.Split(",")
            iList(CInt(Line)) += 1
        Next
        'End While

        Dim AddZeroToSix As Long = 0
        Dim i As Int16 = 0
        Dim NumZero As Long = 0

        For j As Long = 1 To 256
            NumZero = iList(0)

            For i = 1 To 8
                iList(i - 1) = iList(i)
            Next

            iList(6) += NumZero
            iList(8) = NumZero
        Next

        Dim SumCnt As Long = 0

        For i = 0 To 8
            SumCnt += iList(i)
        Next

        MsgBox(SumCnt)

        SR.Close()
    End Sub


End Module
