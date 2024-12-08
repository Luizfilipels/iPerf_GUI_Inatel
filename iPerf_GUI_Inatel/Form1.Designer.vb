<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.chkClient = New System.Windows.Forms.CheckBox()
        Me.chkServer = New System.Windows.Forms.CheckBox()
        Me.chartSpeeds = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.nudConnections = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.chartSpeeds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(57, 90)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(214, 20)
        Me.txtIP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "iPerf GUI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "IP -"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Porta -"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(82, 132)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(189, 20)
        Me.txtPort.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Duração do Teste -"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(171, 171)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(100, 20)
        Me.txtTime.TabIndex = 6
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(23, 241)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(102, 23)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Iniciar Teste"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(23, 270)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(102, 23)
        Me.btnStop.TabIndex = 8
        Me.btnStop.Text = "Parar Teste"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'chkClient
        '
        Me.chkClient.AutoSize = True
        Me.chkClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClient.Location = New System.Drawing.Point(171, 243)
        Me.chkClient.Name = "chkClient"
        Me.chkClient.Size = New System.Drawing.Size(67, 20)
        Me.chkClient.TabIndex = 10
        Me.chkClient.Text = "Cliente"
        Me.chkClient.UseVisualStyleBackColor = True
        '
        'chkServer
        '
        Me.chkServer.AutoSize = True
        Me.chkServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkServer.Location = New System.Drawing.Point(171, 270)
        Me.chkServer.Name = "chkServer"
        Me.chkServer.Size = New System.Drawing.Size(77, 20)
        Me.chkServer.TabIndex = 11
        Me.chkServer.Text = "Servidor"
        Me.chkServer.UseVisualStyleBackColor = True
        '
        'chartSpeeds
        '
        ChartArea3.Name = "ChartArea1"
        Me.chartSpeeds.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chartSpeeds.Legends.Add(Legend3)
        Me.chartSpeeds.Location = New System.Drawing.Point(277, 80)
        Me.chartSpeeds.Name = "chartSpeeds"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.Name = "Velocidade"
        Me.chartSpeeds.Series.Add(Series3)
        Me.chartSpeeds.Size = New System.Drawing.Size(693, 300)
        Me.chartSpeeds.TabIndex = 12
        Me.chartSpeeds.Text = "Chart1"
        '
        'nudConnections
        '
        Me.nudConnections.Location = New System.Drawing.Point(188, 207)
        Me.nudConnections.Name = "nudConnections"
        Me.nudConnections.Size = New System.Drawing.Size(83, 20)
        Me.nudConnections.TabIndex = 13
        Me.nudConnections.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Quant. de Conexões -"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 450)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudConnections)
        Me.Controls.Add(Me.chartSpeeds)
        Me.Controls.Add(Me.chkServer)
        Me.Controls.Add(Me.chkClient)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIP)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "iPerf GUI - Inatel"
        CType(Me.chartSpeeds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtIP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTime As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents chkClient As CheckBox
    Friend WithEvents chkServer As CheckBox
    Friend WithEvents chartSpeeds As DataVisualization.Charting.Chart
    Friend WithEvents nudConnections As NumericUpDown
    Friend WithEvents Label5 As Label
End Class
