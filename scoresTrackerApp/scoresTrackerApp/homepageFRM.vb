

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
    Dim currentPlayerName As String
    Dim delimiter As String = "¦"

    Dim nextComboItem As String = "Error"
    Dim restartComboItems As Boolean = True
    Dim numberOfEvents As Integer
    Dim comboCount As Integer

    Dim textData1 As String = "Error"
    Dim textData2 As String = "Error"
    Dim textData3 As String = "Error"
    Dim textData4 As String = "Error"
    Dim textData5 As String = "Error"
    Dim valuesList As String()

    Dim filedir As String = IO.Path.Combine(path, "treeData.sav")
    Dim indexesfiledir As String = IO.Path.Combine(path, "nodeData.csv")
    Dim versioncontroldir As String = IO.Path.Combine(path, "versionData.txt")
    Dim eventsFileDir As String = IO.Path.Combine(path, "eventsData.txt")



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


        Console.WriteLine("CALLS Load Events")
        loadEventsData()

        Console.WriteLine("FINISHED Load Events")
        Console.WriteLine("")


        Console.WriteLine("CALLS Load Combo Boxes")

        Try
            Dim countFileReader As New System.IO.StreamReader(eventsFileDir)
            Dim readLine = countFileReader.ReadLine()
            Dim eventsList() As String = Split(readLine, delimiter)
            numberOfEvents = eventsList(0)
            comboCount = numberOfEvents
            countFileReader.Close()

        Catch ex As Exception
            MessageBox.Show("Oops, something went wrong with loading the app, please try again!", "Critical Error: 001", MessageBoxButtons.OK, MessageBoxIcon.Error)
            containerFRM.Close()
        End Try

        Do While comboCount > 0
            Dim addData As String = findnextComboItem()
            cboEvent1.Items.Add(addData)
            cboEvent2.Items.Add(addData)
            cboEvent3.Items.Add(addData)
            cboEvent4.Items.Add(addData)
            cboEvent5.Items.Add(addData)
            comboCount -= 1
        Loop

        Console.WriteLine("FINISHED Load Combo Boxes")
        Console.WriteLine("")


        Console.WriteLine("CALLS reloadIndividualsData")

        reloadIndividualsData()

        Console.WriteLine("FINISHED Load Combo Boxes")
        Console.WriteLine("")


        'initialising interfaces
        IndividualsHidePNL.Visible = False
        ListBox1.Visible = False
        individualsPlayerLBL.Visible = False
        IndividualsSelectedPointsTXT.Visible = False
        IndividualsTotalScoreLBL.Visible = False
        individualsTotalScoreTXT.Visible = False
        individualsNotesLBL.Visible = False
        individualsHideNotesBoxTXT.Visible = False



        invalidScoreResetTimer1.Interval = 9999
        invalidScoreResetTimer2.Interval = 9999
        invalidScoreResetTimer3.Interval = 9999
        invalidScoreResetTimer4.Interval = 9999
        invalidScoreResetTimer5.Interval = 9999

        finishedLoading = True
        If finishedLoading = False Then
            MessageBox.Show("Oops, something went wrong with loading the app, please try again!", "Critical Error: 002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            containerFRM.Close()
        End If

    End Sub




    Private Function findnextComboItem()

        Dim fileReader As New System.IO.StreamReader(eventsFileDir)
        Dim events = fileReader.ReadLine()
        Dim eventsList() As String = Split(events, delimiter)
        fileReader.Close()

        Try
            Return eventsList(comboCount)
        Catch ex As Exception
            MessageBox.Show("Oops, something is wrong with the events in the eventsData.txt file, please check it is the correct number at the start!", "User Setup Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "Error With Event"
        End Try

    End Function




    Private Sub loadIndexes()

        If System.IO.File.Exists(indexesfiledir) Then
            Console.WriteLine("  DEBUG Index File Found")

        Else
            Console.WriteLine("  ERROR no tree index found, CREATING new file")

            Using se As New StreamWriter(File.Open(indexesfiledir, FileMode.Create))
                se.WriteLine("2¦0¦¦0¦¦0¦¦0¦¦0¦¦INDIVIDUAL NOTES¦Individials")
                se.WriteLine("1¦0¦¦0¦¦0¦¦0¦¦0¦¦TEAM NOTES¦Teams")
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




    Private Sub loadEventsData()

        Dim fileIntegrityGood As Boolean = False

        While fileIntegrityGood = False
            fileIntegrityGood = True

            If System.IO.File.Exists(eventsFileDir) Then
                Console.WriteLine("  DEBUG events file identified")

            Else

                fileIntegrityGood = False
                Console.WriteLine("  ERROR no events file found, CREATING new")

                Using sw As New StreamWriter(File.Open(eventsFileDir, FileMode.Create))
                    sw.WriteLine("2¦Example Event¦Another Example Event")
                    sw.WriteLine("### Please put the correct amount of events as the starting number! ###")
                End Using

                Console.WriteLine("  DEBUG ERROR: created events file, RECURSING while loop")

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
        Dim checkAvaliabilityResult As Boolean = checkAvaliability(indexesfiledir, indexValue, delimiter, 1)

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
                sw.WriteLine(indexValue + "¦0¦¦0¦¦0¦¦0¦¦0¦¦Enter Player Notes Here...¦" + Playername)
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
                    textValue = currentRecord(11)
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




    '==================================================== AFTER SELECTS =====================================================================


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim loadDataGrid As Boolean = True
        currentPlayerName = TreeView1.SelectedNode.Text

        Console.WriteLine("")
        Console.WriteLine("===============================[ TICKET ]=================================")
        Console.WriteLine("CALLS tree node afterselect process, for node: " + currentPlayerName)
        Console.WriteLine("")

        Dim nodeIndex = findNodeIndex()
        Dim textValue As String

        textValue = searchIndex(indexesfiledir, nodeIndex, delimiter, 1)
        notesTextBox.Text = textValue

        If nodeIndex = 1 Then
            reloadTeamsData()

            IndividualsHidePNL.Visible = True
            ListBox1.Visible = True
            individualsPlayerLBL.Visible = True
            IndividualsSelectedPointsTXT.Visible = True
            IndividualsTotalScoreLBL.Visible = True
            individualsTotalScoreTXT.Visible = True
            individualsNotesLBL.Visible = True
            individualsHideNotesBoxTXT.Visible = True
            loadDataGrid = False

        ElseIf nodeIndex = 2 Then
            reloadIndividualsData()

            IndividualsHidePNL.Visible = True
            ListBox1.Visible = True
            individualsPlayerLBL.Visible = True
            IndividualsSelectedPointsTXT.Visible = True
            IndividualsTotalScoreLBL.Visible = True
            individualsTotalScoreTXT.Visible = True
            individualsNotesLBL.Visible = True
            individualsHideNotesBoxTXT.Visible = True

            teamDataFRM.Hide()
            loadDataGrid = False
        Else
            teamDataFRM.Hide()

            IndividualsHidePNL.Visible = False
            ListBox1.Visible = False
            individualsPlayerLBL.Visible = False
            IndividualsSelectedPointsTXT.Visible = False
            IndividualsTotalScoreLBL.Visible = False
            individualsTotalScoreTXT.Visible = False
            individualsNotesLBL.Visible = False
            individualsHideNotesBoxTXT.Visible = False
        End If

        FirstTimePNL.Visible = False
        firstTimeInfo.Visible = False
        firstTimeNotes.Visible = False
        firstTimeNotesLabel.Visible = False


        'processes for displaying the events data grid:   ###uncomment subroutine call###

        If loadDataGrid = True Then
            Console.WriteLine("CALLS populateEventDataGrid")
            Console.WriteLine("    DEBUG identified as DISPLAY Nodes so data grid view is populated")

            populateEventDataGrid()

            Console.WriteLine("FINISHED populateEventDataGrid")
        Else
            Console.WriteLine("    DEBUG identified as IGNORE Nodes so data grid view is not populated")
        End If

        Console.WriteLine("FINISHED tree node afterselect process")
        Console.WriteLine("==========================================================================")
        Console.WriteLine("")

    End Sub




    Private Sub populateEventDataGrid()

        'Team Score:
        txtTeamScoreBig.Text = "N/A"

        'Team Ranking:
        txtTeamRankBig.Text = "N/A"

        'Scores:
        Dim tempScore1 As Integer = searchForDataGridValue(1)
        Dim tempScore2 As Integer = searchForDataGridValue(3)
        Dim tempScore3 As Integer = searchForDataGridValue(5)
        Dim tempScore4 As Integer = searchForDataGridValue(7)
        Dim tempscore5 As Integer = searchForDataGridValue(9)

        txtScore1.Text = tempScore1
        txtScore2.Text = tempScore2
        txtScore3.Text = tempScore3
        txtScore4.Text = tempScore4
        txtScore5.Text = tempscore5

        'Total Score:
        Dim tempAvgScore As String = tempScore1 + tempScore2 + tempScore3 + tempScore4 + tempscore5
        txtAvgScore.Text = tempAvgScore + " points"

        'Event Names:
        cboEvent1.Text = searchForDataGridValue(2)
        cboEvent2.Text = searchForDataGridValue(4)
        cboEvent3.Text = searchForDataGridValue(6)
        cboEvent4.Text = searchForDataGridValue(8)
        cboEvent5.Text = searchForDataGridValue(10)

        'Ranks:
        findPlayerRank()

        'Points
        findPlayerPoints()

    End Sub




    Public Sub findPlayerRank()

        Dim rankVal1 As Integer = txtScore1.Text
        Dim rankVal2 As Integer = txtScore2.Text
        Dim rankVal3 As Integer = txtScore3.Text
        Dim rankVal4 As Integer = txtScore4.Text
        Dim rankVal5 As Integer = txtScore5.Text

        'Average Rank:
        Dim tempAvgRank = (rankVal1 + rankVal2 + rankVal3 + rankVal4 + rankVal5) / 5
        txtAvgRank.Text = tempAvgRank

        'total Rank:
        Dim tempTotalRank = rankVal1 + rankVal2 + rankVal3 + rankVal4 + rankVal5
        txtTotalRank.Text = tempTotalRank

        'outputs
        txtRank1.Text = rankVal1
        txtRank2.Text = rankVal2
        txtRank3.Text = rankVal3
        txtRank4.Text = rankVal4
        txtRank5.Text = rankVal5

    End Sub




    Public Sub findPlayerPoints()

        Dim pointsVal1 As Integer = txtScore1.Text
        Dim pointsVal2 As Integer = txtScore2.Text
        Dim pointsVal3 As Integer = txtScore3.Text
        Dim pointsVal4 As Integer = txtScore4.Text
        Dim pointsVal5 As Integer = txtScore5.Text

        pointsVal1 = (pointsVal1 * 10) / 2
        pointsVal2 = (pointsVal2 * 10) / 2
        pointsVal3 = (pointsVal3 * 10) / 2
        pointsVal4 = (pointsVal4 * 10) / 2
        pointsVal5 = (pointsVal5 * 10) / 2

        'Average Points:
        Dim tempTotalPoints As Integer = pointsVal1 + pointsVal2 + pointsVal3 + pointsVal4 + pointsVal5
        txtTotalPoints.Text = tempTotalPoints

        'Average Points:
        Dim tempAvgPoints As Integer = (pointsVal1 + pointsVal2 + pointsVal3 + pointsVal4 + pointsVal5) / 5
        txtAvgPoints.Text = tempAvgPoints

        Dim tempPointsVal1 As String = pointsVal1
        Dim tempPointsVal2 As String = pointsVal2
        Dim tempPointsVal3 As String = pointsVal3
        Dim tempPointsVal4 As String = pointsVal4
        Dim tempPointsVal5 As String = pointsVal5

        'outputs
        txtPoints1.Text = tempPointsVal1 + "pts"
        txtPoints2.Text = tempPointsVal2 + "pts"
        txtPoints3.Text = tempPointsVal3 + "pts"
        txtPoints4.Text = tempPointsVal4 + "pts"
        txtPoints5.Text = tempPointsVal5 + "pts"

    End Sub





    Public Function returnTeamsInfo()


        Dim fileExists As Boolean = File.Exists(indexesfiledir)

        If fileExists = True Then

            Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
            Dim countvalue As Integer = lines.Length - 1
            Dim exportArray(countvalue) As String

            Dim output1 As String
            Dim output2 As String
            Dim output3 As String
            Dim output4 As String
            Dim output5 As String

            For lineReader = 0 To countvalue

                Dim currentLine As String = lines(lineReader)
                Dim tempLineValueArray() As String = Split(currentLine, delimiter)
                Dim hideRecordCounter As Integer = 0
                Dim totalScore As Integer = 0

                Dim outScore1 As Integer = 0
                Dim outScore2 As Integer = 0
                Dim outScore3 As Integer = 0
                Dim outScore4 As Integer = 0
                Dim outScore5 As Integer = 0


                Dim tempName As String = tempLineValueArray(12)

                Dim tempScore1 As String = tempLineValueArray(1)
                Dim tempEvent1 As String = tempLineValueArray(2)
                Dim tempNumerical1 As Integer = tempScore1
                If tempEvent1 = "" Then
                    output1 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore1 = (tempNumerical1 * 10) / 2
                    outScore1 = tempScore1
                    output1 = tempScore1 + " points in " + tempEvent1 + " event  -  "
                End If



                Dim tempScore2 As String = tempLineValueArray(3)
                Dim tempEvent2 As String = tempLineValueArray(4)
                Dim tempNumerical2 As Integer = tempScore2
                If tempEvent2 = "" Then
                    output2 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore2 = (tempNumerical2 * 10) / 2
                    outScore2 = tempScore2
                    output2 = tempScore2 + " points in " + tempEvent2 + " event  -  "
                End If



                Dim tempScore3 As String = tempLineValueArray(5)
                Dim tempEvent3 As String = tempLineValueArray(6)
                Dim tempNumerical3 As Integer = tempScore3
                If tempEvent3 = "" Then
                    output3 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore3 = (tempNumerical3 * 10) / 2
                    outScore3 = tempScore3
                    output3 = tempScore3 + " points in " + tempEvent3 + " event  -  "
                End If



                Dim tempScore4 As String = tempLineValueArray(7)
                Dim tempEvent4 As String = tempLineValueArray(8)
                Dim tempNumerical4 As Integer = tempScore3
                If tempEvent4 = "" Then
                    output4 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore4 = (tempNumerical4 * 10) / 2
                    outScore4 = tempScore4
                    output4 = tempScore4 + " points in " + tempEvent4 + " event  -  "
                End If



                Dim tempScore5 As String = tempLineValueArray(9)
                Dim tempEvent5 As String = tempLineValueArray(10)
                Dim tempNumerical5 As Integer = tempScore5
                If tempEvent5 = "" Then
                    output5 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore5 = (tempNumerical5 * 10) / 2
                    outScore5 = tempScore5
                    output5 = tempScore5 + " points in " + tempEvent5 + " event  -  "
                End If


                Dim temp As String()
                totalScore = outScore1 + outScore2 + outScore3 + outScore4 + outScore5

                If hideRecordCounter = 5 Then
                    temp = {"##", "INVALID-STRING-ERROR", "##"}
                Else
                    temp = {tempName, " achieved:  ", output1, output2, output3, output4, output5, " Total Points Achieved: ", totalScore}
                End If

                Dim tempValuesCompilation As String = Join(temp, "")
                exportArray(lineReader) = tempValuesCompilation
            Next

            Return exportArray
        Else
            Console.WriteLine("  FAILURE due to fileExists is false idenified by export teams")
            Return -1
        End If


    End Function





    Public Function returnIndividualsInfo()

        Dim fileExists As Boolean = File.Exists(indexesfiledir)

        If fileExists = True Then

            Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
            Dim countvalue As Integer = lines.Length - 1
            Dim exportArray(countvalue) As String

            Dim output1 As String
            Dim output2 As String
            Dim output3 As String
            Dim output4 As String
            Dim output5 As String

            For lineReader = 0 To countvalue

                Dim currentLine As String = lines(lineReader)
                Dim tempLineValueArray() As String = Split(currentLine, delimiter)
                Dim hideRecordCounter As Integer = 0
                Dim totalScore As Integer = 0

                Dim outScore1 As Integer = 0
                Dim outScore2 As Integer = 0
                Dim outScore3 As Integer = 0
                Dim outScore4 As Integer = 0
                Dim outScore5 As Integer = 0


                Dim tempName As String = tempLineValueArray(12)

                Dim tempScore1 As String = tempLineValueArray(1)
                Dim tempEvent1 As String = tempLineValueArray(2)
                Dim tempNumerical1 As Integer = tempScore1
                If tempEvent1 = "" Then
                    output1 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore1 = (tempNumerical1 * 10) / 2
                    outScore1 = tempScore1
                    output1 = tempScore1 + " points in " + tempEvent1 + " event  -  "
                End If



                Dim tempScore2 As String = tempLineValueArray(3)
                Dim tempEvent2 As String = tempLineValueArray(4)
                Dim tempNumerical2 As Integer = tempScore2
                If tempEvent2 = "" Then
                    output2 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore2 = (tempNumerical2 * 10) / 2
                    outScore2 = tempScore2
                    output2 = tempScore2 + " points in " + tempEvent2 + " event  -  "
                End If



                Dim tempScore3 As String = tempLineValueArray(5)
                Dim tempEvent3 As String = tempLineValueArray(6)
                Dim tempNumerical3 As Integer = tempScore3
                If tempEvent3 = "" Then
                    output3 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore3 = (tempNumerical3 * 10) / 2
                    outScore3 = tempScore3
                    output3 = tempScore3 + " points in " + tempEvent3 + " event  -  "
                End If



                Dim tempScore4 As String = tempLineValueArray(7)
                Dim tempEvent4 As String = tempLineValueArray(8)
                Dim tempNumerical4 As Integer = tempScore3
                If tempEvent4 = "" Then
                    output4 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore4 = (tempNumerical4 * 10) / 2
                    outScore4 = tempScore4
                    output4 = tempScore4 + " points in " + tempEvent4 + " event  -  "
                End If



                Dim tempScore5 As String = tempLineValueArray(9)
                Dim tempEvent5 As String = tempLineValueArray(10)
                Dim tempNumerical5 As Integer = tempScore5
                If tempEvent5 = "" Then
                    output5 = ""
                    hideRecordCounter = hideRecordCounter + 1
                Else
                    tempScore5 = (tempNumerical5 * 10) / 2
                    outScore5 = tempScore5
                    output5 = tempScore5 + " points in " + tempEvent5 + " event  -  "
                End If


                Dim temp As String()
                totalScore = outScore1 + outScore2 + outScore3 + outScore4 + outScore5

                If hideRecordCounter = 5 Then
                    temp = {"##", "INVALID-STRING-ERROR", "##"}
                Else
                    temp = {tempName, " achieved:  ", output1, output2, output3, output4, output5, " Total Points Achieved: ", totalScore}
                End If

                Dim tempValuesCompilation As String = Join(temp, "")
                exportArray(lineReader) = tempValuesCompilation
            Next

            Return exportArray
        Else
            Console.WriteLine("  FAILURE due to fileExists is false idenified by export individuals")
            Return -1
        End If

    End Function




    Private Function searchForDataGridValue(targetColumn As Integer)

        Dim fileExists As Boolean = File.Exists(indexesfiledir)
        Dim countValue As Integer = lineFound

        Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
        Dim lineWrittenTo As String = lines(countValue)
        Dim tempLineValueArray() As String = Split(lineWrittenTo, delimiter)
        Dim value As String = tempLineValueArray(targetColumn)

        If fileExists = True Then
            Return value
        Else
            Console.WriteLine("  FAILURE file does not exist in the searchDataGridValue section - populating the grid view has failed")
            Return 0
        End If

    End Function




    Private Sub writeNewDataGridValueToFile(targetColumn As Integer, writeData As String)

        Dim fileExists As Boolean = File.Exists(indexesfiledir)
        Dim countValue As Integer = lineFound
        Dim debugValue As String = targetColumn

        Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
        Dim lineWrittenTo As String = lines(countValue)
        Dim tempLineValueArray() As String = Split(lineWrittenTo, delimiter)
        tempLineValueArray(targetColumn) = writeData
        Dim temp As String = String.Join("¦", tempLineValueArray)
        lines(countValue) = temp

        If fileExists = True Then
            Console.WriteLine("  DEBUG -in write section- this nodes data is recognised for column: " + debugValue + " as: " + temp)
            System.IO.File.WriteAllLines(indexesfiledir, lines)
        Else
            Console.WriteLine("  FAILURE file does not exist in the writeToSpecificDataGridValue section - csv ammendment has failed")
        End If

    End Sub




    Private Sub notesTextBox_TextChanged(sender As Object, e As EventArgs) Handles notesTextBox.TextChanged

        Console.WriteLine("--------------------------------------------------------------------------")

        Console.WriteLine("CALLS update notes process [VIA: notesbox_TextChanged]")
        updateNotes()
        Console.WriteLine("FINISHED update notes process [VIA: notesbox_TextChanged]")
        Console.WriteLine("--------------------------------------------------------------------------")
        Console.WriteLine("")

    End Sub




    '==================================================== Notes Box: =====================================================================


    Private Sub updateNotes()

        Console.WriteLine("  DEBUG initialises update notes process")

        Dim indexValue As String = findNodeIndex()
        Dim found As Boolean = checkAvaliability(indexesfiledir, indexValue, delimiter, 1)

        If found = False Then

            Console.WriteLine("  DEBUG updateNotes node confirm index value: " + indexValue)

            Console.WriteLine("CALLS arrayWorkings")

            arrayWorkings()

            Console.WriteLine("FINISHED arrayWorkings")

        End If
    End Sub




    Private Sub arrayWorkings()

        Dim fileExists As Boolean = File.Exists(indexesfiledir)
        Dim countValue As Integer = lineFound

        Dim lines() As String = System.IO.File.ReadAllLines(indexesfiledir)
        Dim lineWrittenTo As String = lines(countValue)
        Dim tempLineValueArray() As String = Split(lineWrittenTo, delimiter)

        tempLineValueArray(11) = notesTextBox.Text
        Dim temp As String = String.Join(delimiter, tempLineValueArray)
        Console.WriteLine("  DEBUG -in notes section-  this nodes data is recognised as: " + temp)

        lines(countValue) = temp 'this is where errors will be - I have chaged it from:  Dim lineData As String = indexValue + "," + notesTextBox.Text	

        If fileExists = True Then
            System.IO.File.WriteAllLines(indexesfiledir, lines)
        Else
            Console.WriteLine("  FAILURE due to fileExists is false in the updateNotes section - updating this has failed")
        End If

    End Sub




    '==================================================== Buttons =====================================================================


    Private Sub testBTN_Click(sender As Object, e As EventArgs) Handles testBTN.Click

        Console.WriteLine("DEBUG test button clicked")
        welcomeFRM.Show()
        Me.Hide()

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




    '==================================================== Data Grid Afterselects Section: =====================================================================


    'timer for textbox resets:

    Private Sub invalidScoreResetTimer1_Tick(sender As Object, e As EventArgs) Handles invalidScoreResetTimer1.Tick

        Try
            If textData1 Mod 2 = 0 Then
                Console.WriteLine("  DEBUG resetTimer1 quashed")
            End If
        Catch ex As Exception
            txtScore1.Text = "0"
            populateEventDataGrid()
        End Try

        invalidScoreResetTimer1.Stop()
    End Sub




    Private Sub invalidScoreResetTimer2_Tick(sender As Object, e As EventArgs) Handles invalidScoreResetTimer2.Tick

        Try
            If textData2 Mod 2 = 0 Then
                Console.WriteLine("  DEBUG resetTimer2 quashed")
            End If
        Catch ex As Exception
            txtScore2.Text = "0"
            populateEventDataGrid()
        End Try

        invalidScoreResetTimer2.Stop()
    End Sub




    Private Sub invalidScoreResetTimer3_Tick(sender As Object, e As EventArgs) Handles invalidScoreResetTimer3.Tick

        Try
            If textData3 Mod 2 = 0 Then
                Console.WriteLine("  DEBUG resetTimer3 quashed")
            End If
        Catch ex As Exception
            txtScore3.Text = "0"
            populateEventDataGrid()
        End Try

        invalidScoreResetTimer3.Stop()
    End Sub




    Private Sub invalidScoreResetTimer4_Tick(sender As Object, e As EventArgs) Handles invalidScoreResetTimer4.Tick

        Try
            If textData4 Mod 2 = 0 Then
                Console.WriteLine("  DEBUG resetTimer4 quashed")
            End If
        Catch ex As Exception
            txtScore4.Text = "0"
            populateEventDataGrid()
        End Try

        invalidScoreResetTimer4.Stop()
    End Sub




    Private Sub invalidScoreResetTimer5_Tick(sender As Object, e As EventArgs) Handles invalidScoreResetTimer5.Tick

        Try
            If textData5 Mod 2 = 0 Then
                Console.WriteLine("  DEBUG resetTimer5 quashed")
            End If
        Catch ex As Exception
            txtScore5.Text = "0"
            populateEventDataGrid()
        End Try

        invalidScoreResetTimer5.Stop()
    End Sub




    'scores textboxes:

    Private Sub txtScore1_TextChanged(sender As Object, e As EventArgs) Handles txtScore1.TextChanged
        If finishedLoading = True Then

            textData1 = txtScore1.Text
            Try
                If textData1 Mod 2 = 0 Then
                    Console.WriteLine("  DEBUG this is an even number")
                End If
                writeNewDataGridValueToFile(1, textData1)
                populateEventDataGrid()
            Catch ex As Exception
                invalidScoreResetTimer1.Start()
            End Try

        End If
    End Sub




    Private Sub txtScore2_TextChanged(sender As Object, e As EventArgs) Handles txtScore2.TextChanged
        If finishedLoading = True Then

            textData2 = txtScore2.Text
            Try
                If textData2 Mod 2 = 0 Then
                    Console.WriteLine("  DEBUG this is a number")
                End If
                writeNewDataGridValueToFile(3, textData2)
                populateEventDataGrid()
            Catch ex As Exception
                invalidScoreResetTimer2.Start()
            End Try

        End If
    End Sub




    Private Sub txtScore3_TextChanged(sender As Object, e As EventArgs) Handles txtScore3.TextChanged
        If finishedLoading = True Then

            textData3 = txtScore3.Text
            Try
                If textData3 Mod 2 = 0 Then
                    Console.WriteLine("  DEBUG this is a number")
                End If
                writeNewDataGridValueToFile(5, textData3)
                populateEventDataGrid()
            Catch ex As Exception
                invalidScoreResetTimer3.Start()
            End Try

        End If
    End Sub




    Private Sub txtScore4_TextChanged(sender As Object, e As EventArgs) Handles txtScore4.TextChanged
        If finishedLoading = True Then

            textData4 = txtScore4.Text
            Try
                If textData4 Mod 2 = 0 Then
                    Console.WriteLine("  DEBUG this is a number")
                End If
                writeNewDataGridValueToFile(7, textData4)
                populateEventDataGrid()
            Catch ex As Exception
                invalidScoreResetTimer4.Start()
            End Try

        End If
    End Sub




    Private Sub txtScore5_TextChanged(sender As Object, e As EventArgs) Handles txtScore5.TextChanged
        If finishedLoading = True Then

            textData5 = txtScore5.Text
            Try
                If textData5 Mod 2 = 0 Or 0.5 Then
                    Console.WriteLine("  DEBUG this is a number")
                End If
                writeNewDataGridValueToFile(9, textData5)
                populateEventDataGrid()
            Catch ex As Exception
                invalidScoreResetTimer5.Start()
            End Try

        End If
    End Sub




    'event name comboboxes:

    Private Sub cboEvent1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent1.SelectedIndexChanged, cboEvent1.TextChanged
        If finishedLoading = True Then
            Dim textData As String = cboEvent1.Text
            writeNewDataGridValueToFile(2, textData)
        End If
    End Sub



    Private Sub cboEvent2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent2.SelectedIndexChanged, cboEvent2.TextChanged
        If finishedLoading = True Then
            Dim textData As String = cboEvent2.Text
            writeNewDataGridValueToFile(4, textData)
        End If
    End Sub



    Private Sub cboEvent3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent3.SelectedIndexChanged, cboEvent3.TextChanged
        If finishedLoading = True Then
            Dim textData As String = cboEvent3.Text
            writeNewDataGridValueToFile(6, textData)
        End If
    End Sub



    Private Sub cboEvent4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent4.SelectedIndexChanged, cboEvent4.TextChanged
        If finishedLoading = True Then
            Dim textData As String = cboEvent4.Text
            writeNewDataGridValueToFile(8, textData)
        End If
    End Sub



    Private Sub cboEvent5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvent5.SelectedIndexChanged, cboEvent5.TextChanged
        If finishedLoading = True Then
            Dim textData As String = cboEvent5.Text
            writeNewDataGridValueToFile(10, textData)
        End If
    End Sub




    Public Sub reloadIndividualsData()

        Dim outputVal As String() = returnIndividualsInfo()
        Dim linesQuantity As Integer = outputVal.Length - 1
        valuesList = outputVal

        ListBox1.Items.Clear()

        For populateTextbox = 2 To linesQuantity

            Try
                Dim temp As String = outputVal(populateTextbox)
                If temp = "##INVALID-STRING-ERROR##" Then
                    Console.WriteLine("invalid data, this player was not added to overview list")
                Else
                    ListBox1.Items.Add(temp)
                End If

            Catch ex As Exception
                ListBox1.Items.Add("Error loading player")
            End Try

        Next

    End Sub



    Public Sub reloadTeamsData()

        Dim outputVal As String() = returnTeamsInfo()
        Dim linesQuantity As Integer = outputVal.Length - 1

        ListBox1.Items.Clear()

        For populateTextbox = 2 To linesQuantity

            Try
                Dim temp As String = outputVal(populateTextbox)
                Dim tempWorker As String() = Split(temp, " ")

                If tempWorker(0) = "Team" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "Team1" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "Team2" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "Team3" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "Team4" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "Team5" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team1" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team2" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team3" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team4" Then
                    ListBox1.Items.Add(temp)

                ElseIf tempWorker(0) = "team5" Then
                    ListBox1.Items.Add(temp)

                Else
                    Console.WriteLine("invalid data, this player was not added to overview list")
                End If

            Catch ex As Exception
                ListBox1.Items.Add("Error loading player")
            End Try

        Next

    End Sub




    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Try
            If ListBox1.SelectedItem.ToString Is Nothing Then

                Console.WriteLine("Error with nothing in the string")

            Else

                Dim nodeIndex As String = ListBox1.SelectedItem.ToString

                Dim temp() As String = Split(nodeIndex, " ")
                Dim tempListLength As Integer = temp.Length

                IndividualsSelectedPointsTXT.Text = temp(0)
                individualsTotalScoreTXT.Text = temp(tempListLength - 1)

            End If

        Catch ex As Exception

            IndividualsSelectedPointsTXT.Text = "ERROR"
            individualsTotalScoreTXT.Text = "ERROR"

            MessageBox.Show("Error returning a total socore", "Error", MessageBoxButtons.OK)
        End Try

    End Sub

End Class