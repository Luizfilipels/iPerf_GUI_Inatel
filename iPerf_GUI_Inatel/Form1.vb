Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Private iperfProcess As Process
    Private timeIndex As Integer = 0 ' Começa o tempo em 0

    ' Botão "Iniciar"
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ' Verifica se cliente e servidor estão ambos selecionados ou ambos desmarcados
        If chkClient.Checked = chkServer.Checked Then
            MessageBox.Show("Selecione apenas Cliente ou Servidor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Configurar argumentos do iPerf
        Dim arguments As String
        If chkServer.Checked Then
            arguments = "-s"
        Else
            Dim ip As String = txtIP.Text
            Dim port As String = txtPort.Text
            Dim time As String = txtTime.Text
            arguments = $"-c {ip} -p {port} -t {time}"
        End If

        ' Caminho para o iPerf
        Dim iperfPath As String = ".\Bin\iperf3.exe"
        If Not File.Exists(iperfPath) Then
            MessageBox.Show($"O arquivo iPerf não foi encontrado no caminho: {iperfPath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Finalizar o processo anterior se ainda estiver rodando
        If iperfProcess IsNot Nothing AndAlso Not iperfProcess.HasExited Then
            iperfProcess.Kill()
        End If

        ' Configurar e iniciar o processo do iPerf
        Try
            iperfProcess = New Process()
            iperfProcess.StartInfo.FileName = iperfPath
            iperfProcess.StartInfo.Arguments = arguments
            iperfProcess.StartInfo.RedirectStandardOutput = True
            iperfProcess.StartInfo.UseShellExecute = False
            iperfProcess.StartInfo.CreateNoWindow = True

            ' Mostrar mensagem informando que o teste foi iniciado
            MessageBox.Show("Teste iniciado. Por favor, aguarde a conclusão.", "Teste Iniciado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Capturar saída do processo
            AddHandler iperfProcess.OutputDataReceived, AddressOf OnOutputDataReceived
            AddHandler iperfProcess.Exited, AddressOf OnProcessExited ' Manipular conclusão do processo

            ' Limpar o gráfico
            chartSpeeds.Series("Velocidade").Points.Clear()
            timeIndex = 0 ' Reiniciar o contador de tempo

            iperfProcess.EnableRaisingEvents = True ' Permitir o evento Exited
            iperfProcess.Start()
            iperfProcess.BeginOutputReadLine()

        Catch ex As Exception
            MessageBox.Show($"Erro ao iniciar o iPerf: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botão "Parar"
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If iperfProcess IsNot Nothing AndAlso Not iperfProcess.HasExited Then
            iperfProcess.Kill()
        End If
    End Sub

    ' Capturar saída do iPerf
    Private Sub OnOutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If e.Data IsNot Nothing Then
            ' Processar a saída do iPerf para extrair as velocidades
            Dim line As String = e.Data
            If line.Contains("bits/sec") Then
                ' Extração da velocidade da linha
                Dim speedMbps As Double = ExtractSpeed(line)

                ' Atualizar o gráfico no thread principal
                Me.Invoke(Sub()
                              ' Adicionar ponto ao gráfico
                              chartSpeeds.Series("Velocidade").Points.AddXY(timeIndex, speedMbps)
                              timeIndex += 1 ' Incrementar tempo para o próximo ponto

                              ' Verificar se a velocidade ultrapassou o limite atual
                              If speedMbps > chartSpeeds.ChartAreas(0).AxisY.Maximum Then
                                  Dim newMax As Double = Math.Ceiling(speedMbps / 10) * 10 ' Ajustar para o próximo múltiplo de 10
                                  chartSpeeds.ChartAreas(0).AxisY.Maximum = newMax
                              End If
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
            ' Retorna 0 em caso de erro
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
            Dim chartArea As New ChartArea()
            chartArea.AxisX.Title = "Tempo (s)" ' Eixo X: segundos
            chartArea.AxisX.TitleFont = New Font("Arial", 10, FontStyle.Bold)
            chartArea.AxisX.Interval = 1 ' Intervalo de 1 segundo no eixo X

            chartArea.AxisY.Title = "Velocidade (Mbps)" ' Eixo Y: Mbps
            chartArea.AxisY.TitleFont = New Font("Arial", 10, FontStyle.Bold)
            chartArea.AxisY.Interval = 10 ' Saltos de 10 Mbps
            chartArea.AxisY.Minimum = 0 ' Valor mínimo fixo
            chartArea.AxisY.Maximum = 100 ' Escala inicial

            .ChartAreas.Add(chartArea)

            ' Configurar série
            Dim series As New Series("Velocidade") ' Nome alterado para "Velocidade"
            series.ChartType = SeriesChartType.Line ' Tipo de gráfico: linha
            series.BorderWidth = 2 ' Largura da linha
            series.Color = Color.Blue ' Cor da linha

            .Series.Add(series)
        End With
    End Sub
End Class
