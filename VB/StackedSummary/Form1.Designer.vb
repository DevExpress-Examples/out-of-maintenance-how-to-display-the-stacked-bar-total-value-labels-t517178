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
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.label1 = New System.Windows.Forms.Label()
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl
            ' 
            Me.chartControl.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.chartControl.DataBindings = Nothing
            Me.chartControl.Legend.Name = "Default Legend"
            Me.chartControl.Location = New System.Drawing.Point(4, 34)
            Me.chartControl.Name = "chartControl"
            Me.chartControl.SeriesSerializable = New DevExpress.XtraCharts.Series(){}
            Me.chartControl.Size = New System.Drawing.Size(664, 424)
            Me.chartControl.TabIndex = 0
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(337, 4)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(116, 23)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Text Annotations"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(482, 4)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(131, 23)
            Me.button2.TabIndex = 2
            Me.button2.Text = "Extra Series"
            Me.button2.UseVisualStyleBackColor = True
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(149, 9)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(128, 13)
            Me.label1.TabIndex = 3
            Me.label1.Text = "Display Total value using:"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(669, 461)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.chartControl)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.chartControl, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private chartControl As DevExpress.XtraCharts.ChartControl
        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label
    End Class
End Namespace

