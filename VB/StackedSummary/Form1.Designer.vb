Namespace StackedSummary
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.chartControl = New DevExpress.XtraCharts.ChartControl()
            Me.checkBox1 = New System.Windows.Forms.CheckBox()
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl
            ' 
            Me.chartControl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.chartControl.Legend.Name = "Default Legend"
            Me.chartControl.Location = New System.Drawing.Point(4, 34)
            Me.chartControl.Name = "chartControl"
            Me.chartControl.SeriesSerializable = New DevExpress.XtraCharts.Series(){}
            Me.chartControl.Size = New System.Drawing.Size(664, 424)
            Me.chartControl.TabIndex = 0
            ' 
            ' checkBox1
            ' 
            Me.checkBox1.AutoSize = True
            Me.checkBox1.Location = New System.Drawing.Point(290, 9)
            Me.checkBox1.Name = "checkBox1"
            Me.checkBox1.Size = New System.Drawing.Size(141, 17)
            Me.checkBox1.TabIndex = 4
            Me.checkBox1.Text = "Display Total value label"
            Me.checkBox1.UseVisualStyleBackColor = True
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(669, 461)
            Me.Controls.Add(Me.checkBox1)
            Me.Controls.Add(Me.chartControl)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private chartControl As DevExpress.XtraCharts.ChartControl
        Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
    End Class
End Namespace

