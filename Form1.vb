Public Class Form1
    Dim s As String
    Dim numb() As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mining()
        Repl()
    End Sub
    Private Sub Mining()
        s = RichTextBox1.Text
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
        ' RichTextBox1.Text = s
        Search()
    End Sub
    Private Sub Search()
        Dim inx, cell As Integer
        inx = 0
        cell = 0
        While Not s.Substring(inx, 1) = "*"
            inx += 1
            If s.Substring(inx, 1) = ";" Then
                cell += 1
            End If
            If cell = 12 Then
                Exit While
            End If
        End While


        For k As Integer = 0 To 5
            If s.Substring(inx + 2, 1) = ";" Then
                ReDim Preserve numb(numb.Length + 1)
                numb(numb.Length) = s.Substring(inx + 1, 1)
                inx += 2
            Else
                ReDim Preserve numb(numb.Length + 1)
                numb(numb.Length) = 50 's.Substring(inx + 1, 2)
                inx += 3
            End If
            RichTextBox1.Text = numb.Length
        Next
    End Sub
End Class
