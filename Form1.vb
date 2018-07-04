Public Class Form1
    Dim s, len As String
    Dim numb() As Integer
    Dim sequence(89) As Integer
    Private Sub Mining()
        s = My.Resources.htmlsource
        'adatcsökkentés
        Dim inx As Integer
        inx = 0
        While True
            inx += 1
            If s.Substring(inx, 5) = "</tr>" Then
                Exit While
            End If
        End While

        s = s.Substring(inx)


    End Sub
    Private Sub Repl()
        'csere
        s = Replace(s, "<tr>", ";")
        s = Replace(s, "<td>", ";")
        s = Replace(s, "</td>", ";")
        s = Replace(s, ";;", ";")

        s = Replace(s, "</tr>", "*")

        s = Replace(s, "Ft", "")
        s = Replace(s, " ", "")
        s = Replace(s, ".", "")
        s = s.Substring(1)
        RichTextBox1.Text = s
        Search()
    End Sub
    Private Sub Search()
        'számszűrés
        Dim inx As Integer = 0
        Dim cell As Integer = 0
        Dim x As Integer = 0
        While Not inx = s.Length
            If s.Substring(inx, 1) = ";" Then
                cell += 1
                If cell < 17 And cell > 11 Then
                    If s.Substring(inx + 2, 1) = ";" Then
                        ReDim Preserve numb(x + 1)
                        numb(x) = Convert.ToInt16(s.Substring(inx + 1, 1))
                        x += 1
                    Else
                        ReDim Preserve numb(x + 1)
                        numb(x) = Convert.ToInt16(s.Substring(inx + 1, 2))
                        x += 1
                    End If
                End If
            ElseIf s.Substring(inx, 1) = "*" Then
                cell = 0
            End If
            inx += 1

        End While
        For Each z As Integer In numb
            sequence(numb(z) - 1) += 1
        Next
        len = numb.Length.ToString
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        RichTextBox2.Clear()
        Int_text(Convert.ToInt32(NumericUpDown1.Value))
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        RichTextBox1.Text = My.Resources.htmlsource
        Mining()
        Repl()
        Int_text(0)
    End Sub
    Private Function calc_int(result As Integer) As Integer
        Dim res_int As Integer
        Dim seq() As Integer = sequence.Clone


        For x As Integer = 0 To result
            res_int = seq.Max
            seq(Array.IndexOf(seq, res_int)) = 0
        Next
        Return res_int
    End Function
    Private Function calc_inx(res_int As Integer) As Integer
        Dim res_inx As Integer = Array.IndexOf(sequence, res_int)

        Return res_inx
    End Function
    Private Sub Int_text(val As Integer)
        Dim srt As String = ""
        For y As Integer = 0 To Convert.ToInt32(val) - 1
            srt += (calc_inx(calc_int(y)) & "-" & calc_int(y) & ";")
        Next
        srt += vbCrLf + "Összes szám mennyisége:" + len
        srt += vbCrLf + "Valószínűség:" + Convert.ToString(calc_int(0) / Convert.ToInt16(len) * 100) + "%"

        RichTextBox2.Text = srt

    End Sub
End Class
