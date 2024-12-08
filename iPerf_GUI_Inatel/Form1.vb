Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private iperfProcess As Process
    Private timeIndex As Integer = 0 ' Tempo começa em 0

    ' Botão "Iniciar"
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ' Verifica se cliente e servidor estão ambos selecionados ou ambos desmarcados
        If chkClient.Checked = chkServer.Checked Then
            MessageBox.Show("Selecione apenas Cliente ou Servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Finalizar o processo anterior se ainda estiver ativo
        StopProcess()

        ' Configurar argumentos do iPerf
        Dim arguments As String
        If chkServer.Checked Then
            arguments = "-s"
        Else
            Dim ip As String = txtIP.Text
            Dim port As String = txtPort.Text
            Dim time As String = txtTime.Text
            arguments = $"-c {ip} -p {port} -t {time}" ' Uma única conexão
        End If

        ' Caminho para o iPerf
        Dim iperfPath As String = ".\Bin\iperf3.exe"
        If Not File.Exists(iperfPath) Then
            MessageBox.Show($"O arquivo iPerf não foi encontrado no caminho: {iperfPath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Mostrar mensagem informando que o teste foi iniciado
        MessageBox.Show("Teste iniciado. Por favor, aguarde a conclusão.", "Teste Iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Configurar e iniciar o processo do iPerf
        Try
            iperfProcess = New Process()
            iperfProcess.StartInfo.FileName = iperfPath
            iperfProcess.StartInfo.Arguments = arguments
            iperfProcess.StartInfo.RedirectStandardOutput = True
            iperfProcess.StartInfo.UseShellExecute = False
            iperfProcess.StartInfo.CreateNoWindow = True

            ' Capturar saída do processo
            AddHandler iperfProcess.OutputDataReceived, AddressOf OnOutputDataReceived
            AddHandler iperfProcess.Exited, AddressOf OnProcessExited

            ' Limpar o gráfico
            chartSpeeds.Series.Clear()
            timeIndex = 0 ' Reiniciar o contador de tempo

            ' Criar série no gráfico
            Dim series As New Series("Velocidade")
            series.ChartType = SeriesChartType.Line
            series.BorderWidth = 2
            series.Color = Color.Blue
            chartSpeeds.Series.Add(series)

            iperfProcess.EnableRaisingEvents = True
            iperfProcess.Start()
            iperfProcess.BeginOutputReadLine()
        Catch ex As Exception
            MessageBox.Show($"Erro ao iniciar o iPerf: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botão "Parar"
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopProcess()
    End Sub

    ' Parar o processo do iPerf
    Private Sub StopProcess()
        If iperfProcess IsNot Nothing AndAlso Not iperfProcess.HasExited Then
            iperfProcess.Kill()
        End If
        iperfProcess = Nothing
    End Sub

    ' Capturar saída do iPerf
    Private Sub OnOutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If e.Data IsNot Nothing Then
            ' Processar a saída do iPerf para extrair as velocidades
            Dim line As String = e.Data
            If line.Contains("bits/sec") Then
                Dim speedMbps As Double = ExtractSpeed(line)

                ' Atualizar o gráfico no thread principal
                Me.Invoke(Sub()
                              chartSpeeds.Series("Velocidade").Points.AddXY(timeIndex, speedMbps)
                              timeIndex += 1
                          End Sub)
            End If
        End If
    End Sub

    ' Manipular quando o processo terminar
    Private Sub OnProcessExited(sender As Object, e As EventArgs)
        Me.Invoke(Sub()
                      ' Mostrar mensagem informando que o teste foi finalizado
                      MessageBox.Show("O teste foi concluído com sucesso!", "Teste Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                      ' Garantir que o gráfico seja exibido
                      chartSpeeds.BringToFront()
                  End Sub)
    End Sub

    ' Função para extrair a velocidade em Mbps
    Private Function ExtractSpeed(line As String) As Double
        Try
            Dim parts As String() = line.Split(" "c)
            For i As Integer = 0 To parts.Length - 1
                If parts(i).Contains("bits/sec") Then
                    Dim value As Double = Convert.ToDouble(parts(i - 1).Replace(".", ","))
                    Dim unit As String = parts(i - 2).ToLower()

                    ' Converter para Mbps se necessário
                    If unit = "k" Then
                        value /= 1000
                    ElseIf unit = "g" Then
                        value *= 1000
                    End If

                    Return value
                End If
            Next
        Catch ex As Exception
            Debug.WriteLine($"Erro ao processar linha: {line}, Erro: {ex.Message}")
        End Try
        Return 0
    End Function

    ' Configuração inicial do gráfico
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuração do gráfico
        With chartSpeeds
            .Series.Clear()
            .ChartAreas.Clear()

            ' Configurar área do gráfico
            Dim chartArea As New ChartArea("MainArea")
            chartArea.AxisX.Title = "Tempo (s)" ' Eixo X: segundos
            chartArea.AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
            chartArea.AxisX.Interval = 1 ' Intervalo de 1 segundo no eixo X

            chartArea.AxisY.Title = "Velocidade (Mbps)" ' Eixo Y: Mbps
            chartArea.AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
            chartArea.AxisY.Interval = 10 ' Saltos de 10 Mbps
            chartArea.AxisY.Minimum = 0 ' Valor mínimo fixo
            chartArea.AxisY.Maximum = 100 ' Escala inicial

            .ChartAreas.Add(chartArea)
        End With
    End Sub
End Class
