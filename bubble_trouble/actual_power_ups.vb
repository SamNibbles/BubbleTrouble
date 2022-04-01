Public Class actual_power_ups

    Public sprite As Bitmap
    Public xpos As Decimal
    Public ypos As Decimal = arena.Top
    Public xsize As Decimal
    Public ysize As Decimal
    Public enabled As Boolean = False

    Public Sub draw()
        offscreen.Graphics.DrawImage(sprite, xpos, ypos, xsize, ysize)
    End Sub

End Class

Public Class spike_wall : Inherits actual_power_ups

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Weapon\shot.png")
        xsize = 5
        ysize = arena_height
    End Sub

End Class

Public Module handle_actual_power_ups

    Public Sub actual_power_ups_draw()
        For counter As Integer = 1 To amount_of_actual_power_ups
            If power_spike_wall(counter).enabled = True Then
                power_spike_wall(counter).draw()
            End If
        Next
    End Sub

End Module
