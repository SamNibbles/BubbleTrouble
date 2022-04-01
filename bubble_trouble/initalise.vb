Module initalise

    Public arena_ypos As Decimal = 5
    Public arena_xpos As Decimal = 5
    Public arena_width As Decimal = gamescreen.Width - 11
    Public arena_height As Decimal = 300
    Public arena As Rectangle
    Public arena_pen As New Pen(Brushes.Aqua, 1)
    Public arena_top_move_down As Boolean = False

    Public shoot_delay_counter(2) As Integer

    Public spike_wall_delay_counter(2) As Integer

    Public combo_xpos As Integer

    Public pressed As Boolean = False

    Public drawn_combo As Boolean = False
    Public combo_counter As Integer = 0

    Public buffermanager As BufferedGraphicsContext
    Public offscreen As BufferedGraphics

    Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Int32) As Short
    Declare Function sound Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hWndCallback As Int32) As Short
    Public lRet As String

    Public Sub initalise_arena()
        arena = New Rectangle(arena_xpos, arena_ypos, arena_width, arena_height)
    End Sub

    Public Sub initalise_sounds()
        sound("open " & Chr(34) & My.Computer.FileSystem.CurrentDirectory & "\Sounds\pop.wav" & Chr(34) & " alias pop", lRet, 0, 0)
    End Sub

    Public Sub initialise_buffer()
        buffermanager = BufferedGraphicsManager.Current
        buffermanager.MaximumBuffer = New Size(gamescreen.Width, gamescreen.Height)
        offscreen = buffermanager.Allocate(gamescreen.CreateGraphics, New Rectangle(0, 0, gamescreen.Width, gamescreen.Height))
    End Sub

    Public bubble_big(50) As big_bubble
    Public bubble_med(50) As med_bubble
    Public bubble_small(50) As small_bubble
    Public bubble_amount As Integer = 50

    Public Sub initalise_bubbles()
        For counter As Integer = 1 To bubble_amount
            bubble_big(counter) = New big_bubble
            bubble_big(counter).initalise()
            bubble_med(counter) = New med_bubble
            bubble_med(counter).initalise()
            bubble_small(counter) = New small_bubble
            bubble_small(counter).initalise()
        Next
        bubble_big(1).enabled = True
        bubble_big(2).enabled = True
        bubble_big(2).moveright = False
        bubble_big(3).enabled = True
        bubble_big(4).enabled = True
        bubble_big(3).xpos = 400
        bubble_big(4).xpos = 400
        bubble_big(4).moveright = False
    End Sub

    Public player(2) As player_object

    Public Sub initalise_player()
        For counter As Integer = 1 To 2
            player(counter) = New player_object
            player(counter).initalise()
        Next
        player(1).enabled = True
        'player(2).enabled = True
        'player(2).sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Player\player2.png")
        'player(2).xpos = 200
    End Sub

    Public shot(2) As shooting_object

    Public Sub initalise_weapons()
        For counter As Integer = 1 To 2
            shot(counter) = New shooting_object
            shot(counter).initalise()
        Next
    End Sub

    Public power_spike(10) As spike_chain_object
    Public amount_of_power_ups As Integer = 10

    Public Sub initalise_power_ups()
        For counter As Integer = 1 To amount_of_power_ups
            power_spike(counter) = New spike_chain_object
            power_spike(counter).initalise()
        Next
    End Sub

    Public power_spike_wall(10) As spike_wall
    Public amount_of_actual_power_ups As Integer = 10

    Public Sub initalise_actual_power_ups()
        For counter As Integer = 1 To amount_of_actual_power_ups
            power_spike_wall(counter) = New spike_wall
            power_spike_wall(counter).initalise()
        Next
    End Sub

End Module
