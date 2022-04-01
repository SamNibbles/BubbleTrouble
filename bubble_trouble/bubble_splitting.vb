Module bubble_splitting

    Public Sub handle_splitting()
        For counter As Integer = 1 To bubble_amount
            If bubble_big(counter).split = True Then handle_big_split()
            If bubble_med(counter).split = True Then handle_med_split()
            If bubble_small(counter).split = True Then handle_small_split()
        Next
    End Sub

    Public Sub handle_big_split()
        Dim current_xpos As Decimal
        Dim current_ypos As Decimal
        Dim number_of_new_bubbles As Integer = 0
        Dim number_of_power_ups As Integer = 0
        Dim new_bubble(2) As Integer

        For counter As Integer = 1 To bubble_amount
            If bubble_big(counter).split = True Then
                bubble_big(counter).split = False
                bubble_big(counter).enabled = False
                current_xpos = bubble_big(counter).xpos + (bubble_big(counter).xsize / 2)
                current_ypos = bubble_big(counter).ypos + (bubble_big(counter).ysize / 2)
                For counter2 As Integer = 1 To amount_of_power_ups
                    If number_of_power_ups < 1 Then
                        If power_spike(counter2).enabled = False Then
                            number_of_power_ups += 1
                            power_spike(counter2).enabled = True
                            power_spike(counter2).xpos = bubble_big(counter).xpos + (bubble_big(counter).xsize / 2)
                            power_spike(counter2).ypos = bubble_big(counter).ypos + (bubble_big(counter).ysize / 2)
                        End If
                    End If
                Next
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_med(counter).enabled = False Then
                If number_of_new_bubbles < 2 Then
                    number_of_new_bubbles += 1
                    new_bubble(number_of_new_bubbles) = counter
                    bubble_med(counter).enabled = True
                    bubble_med(counter).ypos = current_ypos
                End If
            End If
        Next
        bubble_med(new_bubble(1)).moveright = False
        bubble_med(new_bubble(2)).moveright = True
        bubble_med(new_bubble(1)).xpos = current_xpos - 20
        bubble_med(new_bubble(2)).xpos = current_xpos + 20
        bubble_med(new_bubble(1)).gravity = 0.125
        bubble_med(new_bubble(2)).gravity = 0.125
        bubble_med(new_bubble(1)).bouncing = True
        bubble_med(new_bubble(2)).bouncing = True
    End Sub

    Public Sub handle_med_split()
        Dim current_xpos As Decimal
        Dim current_ypos As Decimal
        Dim number_of_new_bubbles As Integer = 0
        Dim new_bubble(2) As Integer

        For counter As Integer = 1 To bubble_amount
            If bubble_med(counter).split = True Then
                bubble_med(counter).split = False
                bubble_med(counter).enabled = False
                current_xpos = bubble_med(counter).xpos + (bubble_med(counter).xsize / 2)
                current_ypos = bubble_med(counter).ypos + (bubble_med(counter).ysize / 2)
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).enabled = False Then
                If number_of_new_bubbles < 2 Then
                    number_of_new_bubbles += 1
                    new_bubble(number_of_new_bubbles) = counter
                    bubble_small(counter).enabled = True
                    bubble_small(counter).ypos = current_ypos
                End If
            End If
        Next
        bubble_small(new_bubble(1)).moveright = False
        bubble_small(new_bubble(2)).moveright = True
        bubble_small(new_bubble(1)).xpos = current_xpos - 20
        bubble_small(new_bubble(2)).xpos = current_xpos + 20
        bubble_small(new_bubble(1)).gravity = 0
        bubble_small(new_bubble(2)).gravity = 0
        bubble_small(new_bubble(1)).bouncing = True
        bubble_small(new_bubble(2)).bouncing = True
    End Sub

    Public Sub handle_small_split()
        Dim splitting_bubble As Integer

        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).split = True Then splitting_bubble = counter
        Next

        bubble_small(splitting_bubble).split = False
        bubble_small(splitting_bubble).enabled = False
    End Sub

End Module
