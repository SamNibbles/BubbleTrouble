Module handle_combo

    Public Sub draw_combo()
        Dim amount_comboed As Integer = 0
        Dim bubble_num(2) As Integer
        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).combo = True Then
                bubble_small(counter).combo = False
                If amount_comboed < 2 Then
                    amount_comboed += 1
                    bubble_num(amount_comboed) = counter
                End If
            End If
        Next
        If amount_comboed = 2 Then
            combo_xpos = bubble_small(bubble_num(1)).xpos + 20
            gamescreen.tim_combo.Enabled = True
            drawn_combo = True
            amount_comboed = 0
        End If
        If drawn_combo = True Then
            offscreen.Graphics.DrawString("COMBO", New Font("Century Gothic", 10), Brushes.Orange, combo_xpos, arena.Top + 10)
        End If
    End Sub

End Module
