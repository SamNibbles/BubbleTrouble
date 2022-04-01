<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gamescreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tim_combo = New System.Windows.Forms.Timer(Me.components)
        Me.tim_1_shoot_delay = New System.Windows.Forms.Timer(Me.components)
        Me.tim_2_shoot_delay = New System.Windows.Forms.Timer(Me.components)
        Me.tim_1_spike_delay = New System.Windows.Forms.Timer(Me.components)
        Me.tim_2_spike_delay = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'tim_combo
        '
        '
        'tim_1_shoot_delay
        '
        Me.tim_1_shoot_delay.Interval = 10
        '
        'tim_2_shoot_delay
        '
        Me.tim_2_shoot_delay.Interval = 10
        '
        'tim_1_spike_delay
        '
        Me.tim_1_spike_delay.Interval = 10
        '
        'tim_2_spike_delay
        '
        Me.tim_2_spike_delay.Interval = 10
        '
        'gamescreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 350)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "gamescreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bubble Trouble"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tim_combo As System.Windows.Forms.Timer
    Friend WithEvents tim_1_shoot_delay As System.Windows.Forms.Timer
    Friend WithEvents tim_2_shoot_delay As System.Windows.Forms.Timer
    Friend WithEvents tim_1_spike_delay As System.Windows.Forms.Timer
    Friend WithEvents tim_2_spike_delay As System.Windows.Forms.Timer

End Class
