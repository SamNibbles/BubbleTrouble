Module main_game

    Public Sub draw_screen()
        offscreen.Graphics.Clear(Color.Black)
        handle_bubble_draw()
        bullet_draw()
        offscreen.Graphics.DrawRectangle(arena_pen, arena)
        actual_power_ups_draw()
        player_draw()
        power_ups_draw()
        draw_combo()
        offscreen.Render()
    End Sub

    Public Sub main()
        initialise_buffer()
        initalise_sounds()
        initalise_bubbles()
        initalise_player()
        initalise_weapons()
        set_bullets()
        initalise_arena()
        initalise_power_ups()
        initalise_actual_power_ups()
        gamescreen.Show()
        Do
            'arena_move()
            player_handle_inputs()
            bullet_fire()
            bullet_hit_detection()
            player_hit_detection()
            power_ups_gravity()
            handle_big_bubbles()
            handle_med_bubbles()
            handle_small_bubbles()
            handle_splitting()
            draw_screen()
            Application.DoEvents()
            Sleep(0.00075)
        Loop While (GetKeyState(Keys.Escape) And &H1000) = False
    End Sub

    Public Sub reset()
        player(1).xpos = 300
        player(2).xpos = 200
        For counter = 1 To bubble_amount
            bubble_big(counter).enabled = False
            bubble_med(counter).enabled = False
            bubble_small(counter).enabled = False
            bubble_big(counter).ypos = 100
            bubble_med(counter).ypos = 100
            bubble_small(counter).ypos = 100
            bubble_big(counter).gravity = bubble_big(counter).gravity_value
            bubble_med(counter).gravity = bubble_med(counter).gravity_value
            bubble_small(counter).gravity = bubble_small(counter).gravity_value
            bubble_big(counter).bouncing = False
            bubble_med(counter).bouncing = False
            bubble_small(counter).bouncing = False
        Next
        bubble_big(1).xpos = 150
        bubble_big(2).xpos = 150
        bubble_big(1).enabled = True
        bubble_big(2).enabled = True
        bubble_big(1).moveright = True
        bubble_big(2).moveright = False
        bubble_big(3).enabled = True
        bubble_big(4).enabled = True
        bubble_big(3).xpos = 400
        bubble_big(4).xpos = 400
        bubble_big(3).moveright = False
        bubble_big(4).moveright = True
        For counter As Integer = 1 To amount_of_power_ups
            power_spike(counter).enabled = False
            power_spike_wall(counter).enabled = False
        Next
    End Sub

    Public Sub arena_move()
        If arena_top_move_down = True Then
            arena_ypos += 0.5
            arena_height -= 0.5
        End If
    End Sub

    Private Sub Sleep(durationSeconds As Double)
        Dim durationTicks As Double = Math.Round(durationSeconds * Stopwatch.Frequency)
        Dim sw As Stopwatch = Stopwatch.StartNew()

        While (sw.ElapsedTicks < durationTicks)

        End While
    End Sub

End Module
