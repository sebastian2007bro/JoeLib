Public Class CodeContainer
    Public Shared Function DoesTheFileExist(Path As String, Optional SkipPutingMainProgramPath As Boolean = False) As Boolean
        If SkipPutingMainProgramPath = True Then
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & Path) Then
                Return True
            Else
                Return False
            End If
        ElseIf SkipPutingMainProgramPath = False Then
            If My.Computer.FileSystem.FileExists(Path) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Shared Function DoesTheDirectoryExist(Path As String, Optional SkipPutingMainProgramPath As Boolean = False) As Boolean
        If SkipPutingMainProgramPath = True Then
            If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & Path) Then
                Return True
            Else
                Return False
            End If
        ElseIf SkipPutingMainProgramPath = False Then
            If My.Computer.FileSystem.DirectoryExists(Path) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Shared Function ReadFileText(Path As String) As String
        If DoesTheFileExist(Path) Then
            Try
                Return My.Computer.FileSystem.ReadAllText(Path)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "JoeLib")
                Return Nothing
            End Try

        Else
            Return Nothing
        End If
    End Function

    Public Shared Function WriteFileText(Path As String, TextData As String, Optional OverExistingFile As Boolean = False) As Boolean

        If DoesTheFileExist(Path) = True Then
            If OverExistingFile = False Then
                MsgBox("Couldn't create the file. ", MsgBoxStyle.Critical, "JoeLib")
                Return False
            ElseIf OverExistingFile = True Then
                Try
                    My.Computer.FileSystem.WriteAllText(Path, TextData, False)
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "JoeLib")
                    Return False
                End Try
            End If
        ElseIf DoesTheFileExist(Path) = False Then
            Try
                My.Computer.FileSystem.WriteAllText(Path, TextData, False)
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "JoeLib")
                Return False
            End Try
        End If
    End Function

    Public Shared Function DoesThisSettingsExist(SettingsName As String) As Boolean
        If DoesTheFileExist("\Settings\Software.swfiles", True) = True Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
            If Reader.Contains(SettingsName) = True Then
                Return True
            Else
                Return False
            End If
        ElseIf DoesTheFileExist("\Settings\Software.swfiles", True) = False Then
            MsgBox("The Required File Does Not Exist", MsgBoxStyle.Critical, "JoeLib")
            Return False
        End If
    End Function

    Public Shared Sub AddSettingToConfigFile(SettingsName As String)
        If DoesTheFileExist("\Settings\Software.swfiles", True) = True Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
            If Reader.Contains(SettingsName) = True Then

            Else
                Reader = Reader & Environment.NewLine & SettingsName
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles", Reader, False)
            End If
        ElseIf DoesTheFileExist("\Settings\Software.swfiles", True) = False Then
            MsgBox("The Required File Does Not Exist", MsgBoxStyle.Critical, "JoeLib")
        End If
    End Sub

    Public Shared Sub RemoveSettingToConfigFile(SettingsName As String)
        If DoesTheFileExist("\Settings\Software.swfiles", True) = True Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
            If Reader.Contains(SettingsName) = True Then

            Else
                Reader = Reader.Replace(SettingsName, "")
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles", Reader, False)
            End If
        ElseIf DoesTheFileExist("\Settings\Software.swfiles", True) = False Then
            MsgBox("The Required File Does Not Exist", MsgBoxStyle.Critical, "JoeLib")
        End If
    End Sub

    Public Shared Sub ReplaceSettingToConfigFile(SettingsName As String, ConvertToSettingsName As String)
        If DoesTheFileExist("\Settings\Software.swfiles", True) = True Then
            Dim Reader As String = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
            If Reader.Contains(SettingsName) = True Then

            Else
                Reader = Reader.Replace(SettingsName, ConvertToSettingsName)
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles")
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\Settings\Software.swfiles", Reader, False)
            End If
        ElseIf DoesTheFileExist("\Settings\Software.swfiles", True) = False Then
            MsgBox("The Required File Does Not Exist", MsgBoxStyle.Critical, "JoeLib")
        End If
    End Sub
End Class

