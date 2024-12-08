Imports System.Diagnostics
Imports System.IO

Public Class Form1
    Private iperfProcess As Process

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

            iperfProcess.Start()
            iperfProcess.BeginOutputReadLine()

            txtOutput.AppendText("Teste iniciado..." & Environment.NewLine)
        Catch ex As Exception
            MessageBox.Show($"Erro ao iniciar o iPerf: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Botão "Parar"
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If iperfProcess IsNot Nothing AndAlso Not iperfProcess.HasExited Then
            iperfProcess.Kill()
            txtOutput.AppendText("Teste parado." & Environment.NewLine)
        End If
    End Sub

    ' Capturar saída do iPerf
    Private Sub OnOutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If e.Data IsNot Nothing Then
            Me.Invoke(Sub()
                          txtOutput.AppendText(e.Data & Environment.NewLine)
                      End Sub)
        End If
    End Sub
End Class

