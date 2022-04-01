Public Class bubble_object

    Public sprite As Bitmap
    Public xpos As Decimal = 150
    Public ypos As Decimal = 100
    Public xsize As Decimal
    Public ysize As Decimal
    Public moveright As Boolean = True
    Public movement_speed As Decimal = 0.04
    Public gravity As Decimal = 0.07
    Public gravity_value As Decimal = 0.07
    Public gravity_increase_value As Decimal = 0.0007
    Public bouncing As Boolean = False
    Public bounce_value As Decimal
    Public falling As Boolean = True
    Public split As Boolean = False
    Public enabled As Boolean = False
    Public hit_detection_xpos As Decimal
    Public hit_detection_ypos As Decimal
    Public hit_detection_xsize As Decimal
    Public hit_detection_ysize As Decimal
    Public combo As Boolean = False

    Public Sub draw()
        offscreen.Graphics.DrawImage(sprite, xpos, ypos, xsize, ysize)
    End Sub

    Public Sub bounce()
        If bouncing = True Then
            ypos -= bounce_value
        End If
    End Sub

    Public Sub handle_gravity()
        ypos += gravity
        gravity += gravity_increase_value
        If ypos + ysize > arena.Bottom Then
            ypos = arena.Bottom - ysize
            bouncing = True
            gravity = gravity_value
        End If
    End Sub

    Public Sub move()
        If moveright = True Then xpos += movement_speed
        If moveright = False Then xpos -= movement_speed
    End Sub

    Public Sub hit_detection()
        If xpos <= arena.Left Then moveright = True
        If xpos + xsize >= arena.Right Then moveright = False
        If ypos <= arena.Top Then
            split = True
            combo = True
        End If
        For counter As Integer = 1 To amount_of_actual_power_ups
            If power_spike_wall(counter).enabled = True Then
                If xpos + xsize >= power_spike_wall(counter).xpos And xpos <= power_spike_wall(counter).xpos + power_spike_wall(counter).xsize Then
                    split = True
                    power_spike_wall(counter).enabled = False
                    gamescreen.tim_1_spike_delay.Enabled = False
                    player(1).power_up_spike = False
                    spike_wall_delay_counter(1) = 0
                End If
            End If
        Next
        For counter As Integer = 1 To 2
            If player(counter).enabled = True Then
                hit_detection_xsize = (xsize / 10) * 7
                hit_detection_ysize = (ysize / 10) * 7
                hit_detection_xpos = xpos + ((xsize - hit_detection_xsize) / 2)
                hit_detection_ypos = ypos + ((ysize - hit_detection_ysize) / 2)
                If hit_detection_xpos + hit_detection_xsize >= player(counter).xpos And xpos <= player(counter).xpos + player(counter).xsize Then
                    If hit_detection_ypos + hit_detection_ysize >= player(counter).ypos Then
                        MsgBox("GAME OVER")
                        reset()
                    End If
                End If
            End If
        Next
    End Sub

End Class

Public Class big_bubble : Inherits bubble_object

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Bubbles\bubble.png")
        xsize = 50
        ysize = 50
        bounce_value = 0.5
    End Sub

End Class

Public Class med_bubble : Inherits bubble_object

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Bubbles\bubble.png")
        xsize = 25
        ysize = 25
        bounce_value = 0.425
    End Sub

End Class

Public Class small_bubble : Inherits bubble_object

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Bubbles\bubble.png")
        xsize = 10
        ysize = 10
        bounce_value = 0.35
    End Sub

End Class

