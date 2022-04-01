Public Class player_object

    Public sprite(10) As Bitmap
    Public xpos As Decimal = 300
    Public ypos As Decimal
    Public xsize As Decimal = 32
    Public ysize As Decimal = 41
    Public enabled As Boolean
    Public shoot_delay As Boolean = False
    Public status As Integer = 1
    Public power_up_spike As Boolean = False

    Public Sub initalise()
        For counter As Integer = 1 To 3
            sprite(counter) = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Player\player_1_" & counter & ".png")
        Next
        ypos = (arena_xpos + arena_height) - ysize
    End Sub

    Public Sub draw()
        offscreen.Graphics.DrawImage(sprite(status), xpos, ypos, xsize, ysize)
    End Sub

    Public Sub hit_detection()
        If xpos < arena.Left Then xpos = arena.Left
        If xpos + xsize > arena.Right Then xpos = arena.Right - xsize
        For counter As Integer = 1 To amount_of_power_ups
            If xpos <= power_spike(counter).xpos + power_spike(counter).xsize And xpos + xsize >= power_spike(counter).xpos Then
                If ypos <= power_spike(counter).ypos + power_spike(counter).ysize Then
                    power_spike(counter).enabled = False
                    power_spike(counter).gravity = power_spike(counter).gravity_value
                    power_up_spike = True
                End If
            End If
        Next
    End Sub

End Class

Public Module handle_player

    Public movement_speed As Decimal = 0.2

    Public Sub player_hit_detection()
        For counter As Integer = 1 To 2
            If player(counter).enabled = True Then
                player(counter).hit_detection()
            End If
        Next
    End Sub

    Public Sub player_handle_inputs()
        If player(1).enabled = True Then
            If (GetKeyState(Keys.Up) And &H1000) And shot(1).fire = False And gamescreen.tim_1_spike_delay.Enabled = False Then
                player(1).shoot_delay = True
                shot(1).fire = True
            End If
            If (GetKeyState(Keys.Right) And &H1000) And player(1).shoot_delay = False Then
                player(1).status = 1
                player(1).xpos += movement_speed
            End If

            If (GetKeyState(Keys.Left) And &H1000) And player(1).shoot_delay = False Then
                player(1).status = 2
                player(1).xpos -= movement_speed
            End If
            If (GetKeyState(Keys.H) And &H1000) Then arena_top_move_down = True
        End If
        If player(2).enabled = True Then
            If (GetKeyState(Keys.W) And &H1000) And shot(2).fire = False And gamescreen.tim_2_spike_delay.Enabled = False Then
                player(2).shoot_delay = True
                shot(2).fire = True
            End If
            If (GetKeyState(Keys.D) And &H1000) And player(2).shoot_delay = False Then
                player(2).status = 1
                player(2).xpos += movement_speed
            End If
            If (GetKeyState(Keys.A) And &H1000) And player(2).shoot_delay = False Then
                player(2).status = 2
                player(2).xpos -= movement_speed
            End If

        End If
        set_bullets()
        player_1_shoot_delay()
        player_2_shoot_delay()
    End Sub

    Public Sub player_1_shoot_delay()
        If player(1).shoot_delay = True Then
            gamescreen.tim_1_shoot_delay.Enabled = True
            player(1).status = 3
        End If
    End Sub

    Public Sub player_2_shoot_delay()
        If player(2).shoot_delay = True Then
            gamescreen.tim_1_shoot_delay.Enabled = True
        End If
    End Sub

    Public Sub player_draw()
        For counter As Integer = 1 To 2
            If player(counter).enabled = True Then
                player(counter).draw()
            End If
        Next
    End Sub

End Module
