Public Class power_ups_object

    Public sprite As Bitmap
    Public xpos As Decimal = 280
    Public ypos As Decimal = 100
    Public xsize As Decimal
    Public ysize As Decimal
    Public gravity As Decimal = 0.15
    Public gravity_value As Decimal = 0.15
    Public gravity_increase_value As Decimal = 0.002
    Public enabled As Boolean = False

    Public Sub draw()
        offscreen.Graphics.DrawImage(sprite, xpos, ypos, xsize, ysize)
    End Sub

    Public Sub handle_gravity()
        ypos += gravity
        gravity += gravity_increase_value
        If ypos + ysize > arena.Bottom Then
            ypos = arena.Bottom - ysize
        End If
    End Sub

End Class

Public Class spike_chain_object : Inherits power_ups_object

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Power_ups\spike.png")
        xsize = 10
        ysize = 15
    End Sub

End Class

Public Class shield_object : Inherits power_ups_object

    Public Sub initalise()
        sprite = New System.Drawing.Bitmap(My.Computer.FileSystem.CurrentDirectory & "\Graphics\Power_ups\shield.png")
        xsize = 50
        ysize = 50
    End Sub

End Class

Public Module handle_power_ups

    Public Sub power_ups_draw()
        For counter As Integer = 1 To amount_of_power_ups
            If power_spike(counter).enabled = True Then
                power_spike(counter).draw()
            End If
        Next
    End Sub

    Public Sub power_ups_gravity()
        For counter As Integer = 1 To amount_of_power_ups
            If power_spike(counter).enabled = True Then
                power_spike(counter).handle_gravity()
            End If
        Next
    End Sub

End Module
