

Imports System.IO

Public Class homepageFRM



    '==================================================== Initial Variables ================================================================


    Dim path As String = My.Application.Info.DirectoryPath
    Dim allCollapsed As Boolean = True
    Dim finishedLoading As Boolean = False

    Dim randomOutput As Integer

    Dim counterA As Integer
    Dim lineCounter As Integer
    Dim lineFound As Integer
    Dim searchTermPosition

    Dim filedir As String = IO.Path.Combine(path, "treeData.sav")
    Dim indexesfiledir As String = IO.Path.Combine(path, "nodeData.csv")
    Dim versioncontroldir As String = IO.Path.Combine(path, "versionData.txt")



    '==================================================== Initialisation Loads =====================================================================


    Private Sub homepageFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Console.WriteLine("")

        Console.WriteLine("CALLS Load Indexes")
        loadIndexes()

        Console.WriteLine("FINISHED Load Indexes")
        Console.WriteLine("")

        Console.WriteLine("CALLS Load Tree")
        loadTree()

        Console.WriteLine("FINISHED Load Tree")
        Console.WriteLine("")

        Console.WriteLine("CALLS Load Version")
        loadVersionControl()

        Console.WriteLine("FINISHED Load Version")
        Console.WriteLine("")

        finishedLoading = True

    End Sub



    Private Sub loadIndexes()

        If System.IO.File.Exists(indexesfiledir) Then
            Console.WriteLine("  DEBUG Index File Found")

        Else
            Console.WriteLine("  ERROR no tree index found, CREATING new file")

            Using se As New StreamWriter(File.Open(indexesfiledir, FileMode.Create))
                se.WriteLine("1,TEAM TEST")
                se.WriteLine("2,INDIVIDUAL TEST")
            End Using

            Console.WriteLine("  DEBUG finished creating new index file")

        End If
    End Sub




    Private Sub loadTree()

        TreeView1.Nodes.Clear()
        Dim oTreeList As New List(Of clsTreeFile)

        If System.IO.File.Exists(filedir) Then
            Console.WriteLine("  DEBUG tree file identified")

            Console.WriteLine("  DEBUG initiating tree desteralization")

            Using oFileStream As IO.FileStream = IO.File.Open(filedir, IO.FileMode.Open)
                Dim oBinaryFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                oTreeList = CType(oBinaryFormatter.Deserialize(oFileStream), List(Of clsTreeFile))
            End Using


            For Each oNode As clsTreeFile In oTreeList
                TreeView1.Nodes.Add(oNode.oTreeNode)
            Next

            Console.WriteLine("  DEBUG successfully desteralized tree")

            TreeView1.ExpandAll()

        Else

            Console.WriteLine("  ERROR: unable to load tree, CREATING new, initialising default nodes")

            TreeView1.Nodes.Add(1, "Teams:")
            TreeView1.Nodes.Add(2, "Individuals:")
            saveTree()
            Console.WriteLine("  DEBUG ERROR: added nodes, created save file, RECURSING tree load")
            loadTree()

        End If
    End Sub




    Private Sub loadVersionControl()

        Dim versionIntegrityGood As Boolean = False
        Dim outputValue As String = "Program Last Opened At: " + TimeString + " - " + DateString

        While versionIntegrityGood = False
            versionIntegrityGood = True

            If System.IO.File.Exists(versioncontroldir) Then
                Console.WriteLine("  DEBUG version file identified")

                Console.WriteLine("  DEBUG initiating version log update")

                Using sw As New StreamWriter(File.Open(versioncontroldir, FileMode.Append))
                    sw.WriteLine(outputValue)
                End Using

                Console.WriteLine("  DEBUG successfully completed version log")

            Else

                versionIntegrityGood = False
                Console.WriteLine("  ERROR no version file found, CREATING new")

                IO.File.Create(versioncontroldir)
                Console.WriteLine("  DEBUG ERROR: created version file, RECURSING while loop")

            End If

        End While

    End Sub




    '==================================================== Saves / Creates =====================================================================


    Private Sub createPlayer(ByVal Playername As String)

        counterA += 1

        Console.WriteLine("CALLS create player process initialised")

        Console.WriteLine("  DEBUG calls createIndexValue()")
        Dim indexValue As String = createIndexValue()

        Console.WriteLine("  DEBUG calls checkAvaliability()")
        Dim checkAvaliabilityResult As Boolean = checkAvaliability(indexesfiledir, indexValue, ",", 1)

        If checkAvaliabilityResult = False Then

            If counterA > 10 Then
                Console.WriteLine("    CRITICAL ERROR index allocation unavaliable, KILLS program")
                containerFRM.Close()
            Else
                Console.WriteLine("  ERROR index unavaliable, RECURSING")
                createPlayer(Playername)
            End If

        End If

        If checkAvaliabilityResult = True Then

            Console.WriteLine("  DEBUG Index avaliable, CREATING Index")

            Using sw As New StreamWriter(File.Open(indexesfiledir, FileMode.Append))
                sw.WriteLine(indexValue + ",Enter Player Notes Here...")
            End Using

            Console.WriteLine("  DEBUG Index created, CREATING node twin")

            TreeView1.SelectedNode.Nodes.Add(indexValue, Playername)

            Console.WriteLine("FINISHED created new player (index, nodes)")
            Console.WriteLine("")

        End If
    End Sub



    Private Function createIndexValue()

        Console.WriteLine("  DEBUG createIndexValue process initialised")

        Dim randoms As Integer
        Dim createIndex As System.Random = New System.Random()
        randoms = createIndex.Next(5, 999999)

        Console.WriteLine("  DEBUG random index created successfully, returns index")

        Return randoms
    End Function



    Private Sub saveTree()


        Console.WriteLine("CALLS initiating tree steralization")

        Dim oTreeList As New List(Of clsTreeFile)

        Console.WriteLine("  DEBUG building tree node array")

        For Each oNode As TreeNode In TreeView1.Nodes
            Dim oTree As New clsTreeFile

            oTree.oTreeNode = oNode
            oTreeList.Add(oTree)
        Next

        Console.WriteLine("  DEBUG creating/overwrites tree node array file")

        Using oFileStream As IO.FileStream = IO.File.Open(filedir, IO.FileMode.Create)
            Dim oBinaryFormatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            oBinaryFormatter.Serialize(oFileStream, oTreeList)
        End Using

        Console.WriteLine("FINISHED tree steralization process")
        Console.WriteLine("")

    End Sub



    <Serializable()>
    Public Class clsTreeFile
        Public oTreeNode As TreeNode
    End Class




    '==================================================== Searches =====================================================================


    Function checkAvaliability(ByVal filepath As String, ByVal searchTerm As String, ByVal delimiter As String, ByVal searchTermPosition As Integer) As String
        lineCounter = 0

        Console.WriteLine("CALLS initialises checkAvaliability search [OR for finding node index line]")

        Dim currentLine As String 'variable for the line of csv being read  
        Dim found As Boolean = False 'variable for true/false of the search term being found
        Dim indexAvaliable As Boolean = False

        Try
            Dim fileReader As New System.IO.StreamReader(filepath)
            Do While fileReader.Peek() <> -1    'peeks the first line in the csv to read
                currentLine = fileReader.ReadLine()     'reads current line being searched

                Dim currentRecord() As String = Split(currentLine, delimiter) 'uses the csv commas to split and make an array out of values

                'if comparison function that check if the csv array holds the searchterm value
                If String.Compare(currentRecord(0), searchTerm) = 0 Then 'searches first column of the current row if it is the search term
                    found = True
                    lineFound = lineCounter
                End If
                lineCounter += 1
            Loop

            fileReader.Close()

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

        While found = False 'outputs that the index is avaliable
            Console.WriteLine("  DEBUG checkAvaliabilty search unable to locate index, index is avaliable")
            indexAvaliable = True
            found = True
        End While

        Console.WriteLine("FINISHED checkAvaliability search, returning index avaliability status")
        Console.WriteLine("")

        Return indexAvaliable
    End Function



    Function searchIndex(ByVal filepath As String, ByVal searchTerm As String, ByVal delimiter As String, ByVal searchTermPosition As Integer) As String

        Console.WriteLine("CALLS and initialises searchIndex search")

        Dim currentLine As String 'variable for the line of csv being read  
        Dim found As Boolean = False 'variable for true/false of the search term being found
        Dim textValue As String = "OOPS, something went wrong, no notes data found..."

        Try
            Dim fileReader As New System.IO.StreamReader(filepath)
            Do While fileReader.Peek() <> -1
                currentLine = fileReader.ReadLine()

                Dim currentRecord() As String = Split(currentLine, delimiter)

                If String.Compare(currentRecord(0), searchTerm) = 0 Then
                    textValue = currentRecord(1)
                    found = True
                End If
            Loop

            fileReader.Close()

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

        If found = False Then
            Console.WriteLine("  ERROR unable to locate target index for player notes")
        End If

        Console.WriteLine("FINISHED searchIndex search, returning notes value")
        Console.WriteLine("")

        Return textValue
    End Function



    Private Function findNodeIndex()
        Dim nodeIndex As String = TreeView1.SelectedNode.Name
        Console.WriteLine("  DEBUG findNodeIndex CALLED, node index is: " + nodeIndex)
        Return nodeIndex
    End Function




    '==================================================== TEMP ONCLICKS =====================================================================


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim nodeName As String = TreeView1.SelectedNode.Text

        Console.WriteLine("==========================================================================")
        Console.WriteLine("*CALLS tree node afterselect process, for node: " + nodeName)
        Console.WriteLine("")

        Dim nodeIndex = findNodeIndex()
        Dim textValue As String

        textValue = searchIndex(indexesfiledir, nodeIndex, ",", 1)
        notesTextBox.Text = textValue

        Console.WriteLine("*FINISHED tree node afterselect process")
        Console.WriteLine("==========================================================================")
        Console.WriteLine("")

    End Sub



    Private Sub notesTextBox_TextChanged(sender As Object, e As EventArgs) Handles notesTextBox.TextChanged

        Console.WriteLine("*CALLS update notes process [VIA: notesbox_TextChanged]")
        updateNotes()
        Console.WriteLine("*FINISHED update notes process [VIA: notesboxTextChanged]")
        Console.WriteLine("")

    End Sub




    '==================================================== Notes Box: =====================================================================


    Private Sub updateNotes()

        Console.WriteLine("  DEBUG initialises update notes process")

        Dim indexValue As String = findNodeIndex()
        Dim found As Boolean = checkAvaliability(indexesfiledir, indexValue, ",", 1)

        If found = False Then

            Console.WriteLine("  DEBUG updateNotes node confirm index value: " + indexValue)

            Dim fileExists As Boolean = File.Exists(indexesfiledir)

            Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
            Dim countValue As Integer = lineFound
            Dim lineData As String = indexValue + "," + notesTextBox.Text

            lines(countValue) = lineData

            If fileExists = True Then
                System.IO.File.WriteAllLines(indexesfiledir, lines)
            End If

            Console.WriteLine("  DEBUG comleted update notes process")

        End If
    End Sub




    '==================================================== Buttons =====================================================================


    Private Sub testBTN_Click(sender As Object, e As EventArgs) Handles testBTN.Click

        Console.WriteLine("DEBUG test button clicked")

        containerFRM.Close()
    End Sub



    Private Sub newPlayerBTN_Click(sender As Object, e As EventArgs) Handles newPlayerBTN.Click

        Dim playerName As String
        Console.WriteLine("CALLS DEBUG new player create")

        If TreeView1.SelectedNode Is Nothing Then
            MessageBox.Show("Please select a team Or individual node first!", "Error 001: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            playerName = InputBox("Enter New Player Name:")
            If playerName = "" Then
                MessageBox.Show("A player's name cannot be blank!", "Error 002:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                createPlayer(playerName)
                TreeView1.SelectedNode.ExpandAll()
                saveTree()

                Console.WriteLine("  DEBUG successfully created player")

            End If
        End If

        Console.WriteLine("FINISHED newPlayerBTN create process finished")
        Console.WriteLine("")

    End Sub



    Private Sub renameBTN_Click(sender As Object, e As EventArgs) Handles renameBTN.Click

        Dim newName As String
        Console.WriteLine("CALLS player renameBTN process")

        If TreeView1.SelectedNode Is Nothing Then
            MessageBox.Show("Please select a team Or individual node first!", "Error 003: ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            newName = InputBox("Enter New Player Name:", "Rename Players", TreeView1.SelectedNode.Text)

            If newName = "" Then
                MessageBox.Show("A player's name cannot be blank!", "Error 004:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else

                TreeView1.SelectedNode.Text = newName
                saveTree()

                Console.WriteLine("  DEBUG successfully renamed player")

            End If
        End If

        Console.WriteLine("FINISHED renameBTN process ")
        Console.WriteLine("")

    End Sub



    Private Sub removeBTN_Click(sender As Object, e As EventArgs) Handles removeBTN.Click

        Console.WriteLine("CALLS removeBTN player")

        If TreeView1.SelectedNode Is Nothing Then
            MessageBox.Show("Please select a player first!", "Error 005:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result As DialogResult = MessageBox.Show("This player will be deleteted permenantly!", "Confirm Task Deletion:", MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then
                Console.WriteLine("cancelled")

            ElseIf result = DialogResult.OK Then
                TreeView1.SelectedNode.Remove()
                saveTree()

                Console.WriteLine("  DEBUG successfully removed player")

            End If
        End If

        Console.WriteLine("FINISHED removeBTN process")

    End Sub



    Private Sub collapseallBTN_Click(sender As Object, e As EventArgs) Handles collapseallBTN.Click

        If allCollapsed = False Then
            TreeView1.ExpandAll()
            allCollapsed = True
            collapseallBTN.Text = "^"

            Console.WriteLine("DROP DEBUG tree nodes expanded process")

        Else
            TreeView1.CollapseAll()
            allCollapsed = False
            collapseallBTN.Text = "V"

            Console.WriteLine("DROP DEBUG tree nodes collapsed process")

        End If
    End Sub

End Class