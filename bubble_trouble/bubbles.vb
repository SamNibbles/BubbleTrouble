Module bubbles


    Public Sub handle_big_bubbles()
        For counter As Integer = 1 To bubble_amount
            If bubble_big(counter).enabled = True Then
                bubble_big(counter).move()
                bubble_big(counter).bounce()
                bubble_big(counter).handle_gravity()
                bubble_big(counter).hit_detection()
            End If
        Next
    End Sub

    Public Sub handle_med_bubbles()
        For counter As Integer = 1 To bubble_amount
            If bubble_med(counter).enabled = True Then
                bubble_med(counter).move()
                bubble_med(counter).bounce()
                bubble_med(counter).handle_gravity()
                bubble_med(counter).hit_detection()
            End If
        Next
    End Sub

    Public Sub handle_small_bubbles()
        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).enabled = True Then
                bubble_small(counter).move()
                bubble_small(counter).bounce()
                bubble_small(counter).handle_gravity()
                bubble_small(counter).hit_detection()
            End If
        Next
    End Sub

    Public Sub handle_bubble_draw()
        For counter As Integer = 1 To bubble_amount
            If bubble_big(counter).enabled = True Then
                bubble_big(counter).draw()
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_med(counter).enabled = True Then
                bubble_med(counter).draw()
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).enabled = True Then
                bubble_small(counter).draw()
            End If
        Next
    End Sub

End Module
