<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ChartPromiseServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.ChartPromiseServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'ChartPromiseServiceProcessInstaller
        '
        Me.ChartPromiseServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.ChartPromiseServiceProcessInstaller.Password = Nothing
        Me.ChartPromiseServiceProcessInstaller.Username = Nothing
        '
        'ChartPromiseServiceInstaller
        '
        Me.ChartPromiseServiceInstaller.DisplayName = "Headletters_ChartPromise"
        Me.ChartPromiseServiceInstaller.ServiceName = "ChartPromiseService"
        Me.ChartPromiseServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ChartPromiseServiceProcessInstaller, Me.ChartPromiseServiceInstaller})

    End Sub

    Friend WithEvents ChartPromiseServiceProcessInstaller As ServiceProcess.ServiceProcessInstaller
    Friend WithEvents ChartPromiseServiceInstaller As ServiceProcess.ServiceInstaller
End Class
