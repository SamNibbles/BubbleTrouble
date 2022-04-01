Public Class gamescreen

    Private Sub tim_combo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tim_combo.Tick
        combo_counter += 1
        If combo_counter = 10 Then
            combo_counter = 0
            tim_combo.Enabled = False
            drawn_combo = False
        End If
    End Sub

    Private Sub tim_1_shoot_delay_Tick(sender As System.Object, e As System.EventArgs) Handles tim_1_shoot_delay.Tick
        shoot_delay_counter(1) += 1
        If shoot_delay_counter(1) = 10 Then
            shoot_delay_counter(1) = 0
            tim_1_shoot_delay.Enabled = False
            player(1).shoot_delay = False
        End If
    End Sub

    Private Sub tim_2_shoot_delay_Tick(sender As System.Object, e As System.EventArgs) Handles tim_2_shoot_delay.Tick
        shoot_delay_counter(2) += 1
        If shoot_delay_counter(2) = 10 Then
            shoot_delay_counter(2) = 0
            tim_1_shoot_delay.Enabled = False
            player(2).shoot_delay = False
        End If
    End Sub

    Private Sub tim_1_spike_delay_Tick(sender As System.Object, e As System.EventArgs) Handles tim_1_spike_delay.Tick
        spike_wall_delay_counter(1) += 1
        If spike_wall_delay_counter(1) = 200 Then
            spike_wall_delay_counter(1) = 0
            tim_1_spike_delay.Enabled = False
            player(1).power_up_spike = False
            For counter As Integer = 1 To amount_of_actual_power_ups
                If power_spike_wall(counter).enabled = True Then power_spike_wall(counter).enabled = False
            Next
        End If
    End Sub

    Private Sub tim_2_spike_delay_Tick(sender As System.Object, e As System.EventArgs) Handles tim_2_spike_delay.Tick
        spike_wall_delay_counter(2) += 1
        If spike_wall_delay_counter(2) = 10 Then
            spike_wall_delay_counter(2) = 0
            tim_2_spike_delay.Enabled = False
            player(2).power_up_spike = False
            For counter As Integer = 1 To amount_of_actual_power_ups
                If power_spike_wall(counter).enabled = True Then power_spike_wall(counter).enabled = False
            Next
        End If
    End Sub

End Class
