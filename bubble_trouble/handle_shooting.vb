Public Class shooting_object

    Public sprite As Bitmap
    Public xpos As Decimal
    Public ypos As Decimal
    Public xsize As Decimal = 5
    Public ysize As Decimal = 20
    Public fire As Boolean = False
    Public movement_speed As Decimal = 0.3

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Weapon\shot.png")
        ypos = arena.Bottom
    End Sub

    Public Sub draw()
        offscreen.Graphics.DrawImage(sprite, xpos, ypos, xsize, ysize)
    End Sub

    Public Sub fired()
        Dim amount_enabled As Integer = 0
        If fire = True Then
            If ypos > arena.Top Then
                ysize += movement_speed
                ypos -= movement_speed
            End If
            If ypos <= arena.Top Then
                For counter As Integer = 1 To 2
                    If player(counter).power_up_spike = True Then
                        For counter2 As Integer = 1 To amount_of_actual_power_ups
                            If amount_enabled < 1 Then
                                If power_spike_wall(counter2).enabled = False Then
                                    amount_enabled += 1
                                    power_spike_wall(counter2).enabled = True
                                    power_spike_wall(counter2).xpos = xpos
                                    gamescreen.tim_1_spike_delay.Enabled = True
                                End If
                            End If
                        Next
                    End If
                Next
                fire = False
                ysize = 20
                set_bullets()
            End If
        End If
    End Sub

    Public Sub hit_detection()
        For counter As Integer = 1 To bubble_amount
            If bubble_big(counter).enabled = True Then
                If xpos + xsize >= bubble_big(counter).xpos And xpos <= bubble_big(counter).xpos + bubble_big(counter).xsize Then
                    If ypos <= bubble_big(counter).ypos + bubble_big(counter).ysize Then
                        sound("play pop from 0", lRet, 0, 0)
                        bubble_big(counter).split = True
                        fire = False
                        ysize = 20
                        set_bullets()
                    End If
                End If
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_med(counter).enabled = True Then
                If xpos + xsize >= bubble_med(counter).xpos And xpos <= bubble_med(counter).xpos + bubble_med(counter).xsize Then
                    If ypos <= bubble_med(counter).ypos + bubble_med(counter).ysize Then
                        sound("play pop from 0", lRet, 0, 0)
                        bubble_med(counter).split = True
                        gamescreen.tim_1_shoot_delay.Enabled = False
                        player(1).shoot_delay = False
                        shoot_delay_counter(1) = 0
                        fire = False
                        ysize = 20
                        set_bullets()
                    End If
                End If
            End If
        Next
        For counter As Integer = 1 To bubble_amount
            If bubble_small(counter).enabled = True Then
                If xpos + xsize >= bubble_small(counter).xpos And xpos <= bubble_small(counter).xpos + bubble_small(counter).xsize Then
                    If ypos <= bubble_small(counter).ypos + bubble_small(counter).ysize Then
                        sound("play pop from 0", lRet, 0, 0)
                        bubble_small(counter).split = True
                        gamescreen.tim_1_shoot_delay.Enabled = False
                        player(2).shoot_delay = False
                        shoot_delay_counter(2) = 0
                        fire = False
                        ysize = 20
                        set_bullets()
                    End If
                End If
            End If
        Next
    End Sub

End Class

Public Module shooting

    Public Sub set_bullets()
        If shot(1).fire = False Then
            shot(1).xpos = (player(1).xpos + (player(1).xsize / 2)) - (shot(1).xsize / 2)
            shot(1).ypos = arena.Bottom - 20
        End If
        If shot(2).fire = False Then
            shot(2).xpos = (player(2).xpos + (player(2).xsize / 2)) - (shot(2).xsize / 2)
            shot(2).ypos = arena.Bottom - 20
        End If
    End Sub

    Public Sub bullet_fire()
        For counter As Integer = 1 To 2
            shot(counter).fired()
        Next
    End Sub

    Public Sub bullet_hit_detection()
        For counter As Integer = 1 To 2
            If shot(counter).fire = True Then
                shot(counter).hit_detection()
            End If
        Next
    End Sub

    Public Sub bullet_draw()
        For counter As Integer = 1 To 2
            If shot(counter).fire = True Then
                shot(counter).draw()
            End If
        Next
    End Sub

End Module
