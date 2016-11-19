'welcome to my version of Tetris. This was made as a university project. You can cheat to, you can find how to on one of the next lines
Public Class Form1
    Dim raster(10, 20) As Label
    Dim falling_block(4, 2) As Integer
    Dim falling_block_color As Color
    Dim time_lines As Integer
    Dim falling_block_pos As String
    Dim time As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'makes the raster
        For i As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
            For j As Integer = raster.GetLowerBound(1) To raster.GetUpperBound(1)
                raster(i, j) = New Label
                raster(i, j).Size = New Size(25, 25)
                raster(i, j).Name = "tile_" & i & "_" & j
                raster(i, j).Location = New Point(25 + (25 * i), 25 + (25 * j))
                raster(i, j).BackColor = Color.White
                raster(i, j).BorderStyle = BorderStyle.FixedSingle
                raster(i, j).Tag = "empty"
                Me.Controls.Add(raster(i, j))
            Next
        Next

        'starts the timer
        Timer2.Interval = 1000
        time = 181
        Timer2.Start()

        'lets the first block fall
        start_block_fall(get_block())

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'moves a block to the left on left-key press
        If e.KeyCode = Keys.Left Then
            If falling_block(0, 0) - 1 > 0 And falling_block(1, 0) - 1 > 0 And falling_block(2, 0) - 1 > 0 And falling_block(3, 0) - 1 > 0 Then
                If raster(falling_block(0, 0) - 1, falling_block(0, 1)).Tag = "empty" And raster(falling_block(1, 0) - 1, falling_block(1, 1)).Tag = "empty" And raster(falling_block(2, 0) - 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(3, 0) - 1, falling_block(3, 0)).Tag = "empty" Then
                    clear_falling_block()
                    set_falling_block(falling_block(0, 0) - 1, falling_block(0, 1), falling_block(1, 0) - 1, falling_block(1, 1), falling_block(2, 0) - 1, falling_block(2, 1), falling_block(3, 0) - 1, falling_block(3, 1), falling_block_color)
                End If
            ElseIf falling_block(0, 0) - 1 > -1 And falling_block(1, 0) - 1 > -1 And falling_block(2, 0) - 1 > -1 And falling_block(3, 0) - 1 > -1 Then
                clear_falling_block()
                set_falling_block(falling_block(0, 0) - 1, falling_block(0, 1), falling_block(1, 0) - 1, falling_block(1, 1), falling_block(2, 0) - 1, falling_block(2, 1), falling_block(3, 0) - 1, falling_block(3, 1), falling_block_color)
            End If
            'moves a block to the right on right-key press
        ElseIf e.KeyCode = Keys.Right Then
            If falling_block(0, 0) + 1 < 10 And falling_block(1, 0) + 1 < 10 And falling_block(2, 0) + 1 < 10 And falling_block(3, 0) + 1 < 10 Then
                If raster(falling_block(0, 0) + 1, falling_block(0, 1)).Tag = "empty" And raster(falling_block(1, 0) + 1, falling_block(1, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(3, 0) + 1, falling_block(3, 0)).Tag = "empty" Then
                    clear_falling_block()
                    set_falling_block(falling_block(0, 0) + 1, falling_block(0, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(3, 0) + 1, falling_block(3, 1), falling_block_color)
                End If
            ElseIf falling_block(0, 0) + 1 < 11 And falling_block(1, 0) + 1 < 11 And falling_block(2, 0) + 1 < 11 And falling_block(3, 0) + 1 < 11 Then
                clear_falling_block()
                set_falling_block(falling_block(0, 0) + 1, falling_block(0, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(3, 0) + 1, falling_block(3, 1), falling_block_color)
            End If
            'turns a block on up-key press
        ElseIf e.KeyCode = Keys.Up Then
            If falling_block_color = Color.Turquoise Then
                If falling_block_pos = "up" Then
                    If falling_block(0, 1) > 1 And falling_block(0, 1) < 19 Then
                        If raster(falling_block(1, 0), falling_block(1, 1) - 2).Tag = "empty" And raster(falling_block(1, 0), falling_block(1, 1) - 1).Tag = "empty" And raster(falling_block(1, 0), falling_block(1, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0), falling_block(1, 1) - 2, falling_block(1, 0), falling_block(1, 1) - 1, falling_block(1, 0), falling_block(1, 1), falling_block(1, 0), falling_block(1, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(0, 0) > 0 And falling_block(0, 0) < 9 Then
                        If raster(falling_block(2, 0) - 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 2, falling_block(2, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0) - 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(2, 0) + 2, falling_block(2, 1), falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            ElseIf falling_block_color = Color.Blue Then
                If falling_block_pos = "up" Then
                    If falling_block(2, 1) < 19 Then
                        If raster(falling_block(2, 0), falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0), falling_block(2, 1) - 1, falling_block(2, 0) + 1, falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1), falling_block(2, 0), falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "right"
                        End If
                    End If
                ElseIf falling_block_pos = "right" Then
                    If falling_block(2, 0) > 0 Then
                        If raster(falling_block(2, 0) - 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0) - 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(0, 1) > 0 Then
                        If raster(falling_block(1, 0), falling_block(1, 1) - 1).Tag = "empty" And raster(falling_block(1, 0) - 1, falling_block(1, 1) + 1).Tag = "empty" And raster(falling_block(1, 0), falling_block(1, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0), falling_block(1, 1) - 1, falling_block(1, 0), falling_block(1, 1), falling_block(1, 0) - 1, falling_block(1, 1) + 1, falling_block(1, 0), falling_block(1, 1) + 1, falling_block_color)
                            falling_block_pos = "left"
                        End If
                    End If
                ElseIf falling_block_pos = "left" Then
                    If falling_block(0, 0) < 9 Then
                        If raster(falling_block(1, 0) - 1, falling_block(1, 1) - 1).Tag = "empty" And raster(falling_block(1, 0) - 1, falling_block(1, 1)).Tag = "empty" And raster(falling_block(1, 0) + 1, falling_block(1, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0) - 1, falling_block(1, 1) - 1, falling_block(1, 0) - 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            ElseIf falling_block_color = Color.Orange Then
                If falling_block_pos = "up" Then
                    If falling_block(2, 1) < 19 Then
                        If raster(falling_block(2, 0), falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0), falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1), falling_block(2, 0), falling_block(2, 1) + 1, falling_block(2, 0) + 1, falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "right"
                        End If
                    End If
                ElseIf falling_block_pos = "right" Then
                    If falling_block(0, 0) > 0 Then
                        If raster(falling_block(1, 0) - 1, falling_block(1, 1)).Tag = "empty" And raster(falling_block(1, 0) + 1, falling_block(1, 1)).Tag = "empty" And raster(falling_block(1, 0) - 1, falling_block(1, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0) - 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block(1, 0) - 1, falling_block(1, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(0, 1) > 0 Then
                        If raster(falling_block(2, 0) - 1, falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0) - 1, falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1), falling_block(2, 0), falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "left"
                        End If
                    End If
                ElseIf falling_block_pos = "left" Then
                    If falling_block(2, 0) < 19 Then
                        If raster(falling_block(2, 0) - 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(2, 0) + 1, falling_block(2, 1) - 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0) - 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1) - 1, falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            ElseIf falling_block_color = Color.Green Then
                If falling_block_pos = "up" Then
                    If falling_block(3, 1) < 19 Then
                        If raster(falling_block(3, 0) + 1, falling_block(2, 1)).Tag = "empty" And raster(falling_block(3, 0) + 1, falling_block(3, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(3, 0), falling_block(3, 1) - 1, falling_block(3, 0), falling_block(3, 1), falling_block(3, 0) + 1, falling_block(3, 1), falling_block(3, 0) + 1, falling_block(3, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(1, 0) > 0 Then
                        If raster(falling_block(1, 0) + 1, falling_block(1, 1) - 1).Tag = "empty" And raster(falling_block(1, 0) - 1, falling_block(2, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0), falling_block(1, 1) - 1, falling_block(1, 0) + 1, falling_block(1, 1) - 1, falling_block(1, 0) - 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1), falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            ElseIf falling_block_color = Color.Purple Then
                If falling_block_pos = "up" Then
                    If falling_block(2, 1) < 19 Then
                        If raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0), falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "right"
                        End If
                    End If
                ElseIf falling_block_pos = "right" Then
                    If falling_block(1, 0) > 0 Then
                        If raster(falling_block(1, 0) - 1, falling_block(1, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0) - 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(1, 1) > 0 Then
                        If raster(falling_block(1, 0), falling_block(1, 1) - 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0), falling_block(1, 1) - 1, falling_block(1, 0) - 1, falling_block(1, 1), falling_block(1, 0), falling_block(1, 1), falling_block(1, 0), falling_block(1, 1) + 1, falling_block_color)
                            falling_block_pos = "left"
                        End If
                    End If
                ElseIf falling_block_pos = "left" Then
                    If falling_block(2, 0) < 9 Then
                        If raster(falling_block(2, 0) + 1, falling_block(2, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0), falling_block(2, 1) - 1, falling_block(2, 0) - 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            ElseIf falling_block_color = Color.Red Then
                If falling_block_pos = "up" Then
                    If falling_block(2, 1) < 19 Then
                        If raster(falling_block(2, 0) + 1, falling_block(2, 1) - 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(2, 0) + 1, falling_block(2, 1) - 1, falling_block(2, 0), falling_block(2, 1), falling_block(2, 0) + 1, falling_block(2, 1), falling_block(2, 0), falling_block(2, 1) + 1, falling_block_color)
                            falling_block_pos = "down"
                        End If
                    End If
                ElseIf falling_block_pos = "down" Then
                    If falling_block(1, 0) > 0 Then
                        If raster(falling_block(1, 0) - 1, falling_block(1, 1) - 1).Tag = "empty" And raster(falling_block(1, 0) + 1, falling_block(2, 1)).Tag = "empty" Then
                            clear_falling_block()
                            set_falling_block(falling_block(1, 0) - 1, falling_block(1, 1) - 1, falling_block(1, 0), falling_block(1, 1) - 1, falling_block(1, 0), falling_block(1, 1), falling_block(1, 0) + 1, falling_block(1, 1), falling_block_color)
                            falling_block_pos = "up"
                        End If
                    End If
                End If
            End If
            'move a block faster down on down-key press
        ElseIf e.KeyCode = Keys.Down Then
            block_fall()
            'yeah, some cheating too! when you press C, you can choose the next block, by typing th collor in a textbox that appears above the restartbutton
        ElseIf e.KeyCode = Keys.C Then
            TextBox1.Text = String.Empty
            Label1.Visible = False
        End If
        'you must be able to click the keys multiple times...
        e.Handled = False
    End Sub

    'decides which block is next
    Public Function get_block() As Integer
        Dim random As Random = New Random
        Dim b As Integer
        If Label1.Visible = False Then
            If TextBox1.Text = "yellow" Then
                b = 0
            ElseIf TextBox1.Text = "turquoise" Then
                b = 1
            ElseIf TextBox1.Text = "blue" Then
                b = 2
            ElseIf TextBox1.Text = "orange" Then
                b = 3
            ElseIf TextBox1.Text = "green" Then
                b = 4
            ElseIf TextBox1.Text = "purple" Then
                b = 5
            ElseIf TextBox1.Text = "red" Then
                b = 6
            Else
                b = random.Next(0, 7)
            End If
            TextBox1.Text = String.Empty
            Return b
        Else
            b = random.Next(0, 7)
            Return b
        End If
    End Function

    'makes a block and sets in at a given position
    Public Function set_falling_block(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal x3 As Integer, ByVal y3 As Integer, ByVal x4 As Integer, ByVal y4 As Integer, ByVal color As Color)
        falling_block(0, 0) = x1
        falling_block(0, 1) = y1
        falling_block(1, 0) = x2
        falling_block(1, 1) = y2
        falling_block(2, 0) = x3
        falling_block(2, 1) = y3
        falling_block(3, 0) = x4
        falling_block(3, 1) = y4
        falling_block_color = color
        raster(falling_block(0, 0), falling_block(0, 1)).BackColor = color
        raster(falling_block(1, 0), falling_block(1, 1)).BackColor = color
        raster(falling_block(2, 0), falling_block(2, 1)).BackColor = color
        raster(falling_block(3, 0), falling_block(3, 1)).BackColor = color

    End Function

    'removes block
    Public Function clear_falling_block()
        raster(falling_block(0, 0), falling_block(0, 1)).BackColor = Color.White
        raster(falling_block(1, 0), falling_block(1, 1)).BackColor = Color.White
        raster(falling_block(2, 0), falling_block(2, 1)).BackColor = Color.White
        raster(falling_block(3, 0), falling_block(3, 1)).BackColor = Color.White
    End Function

    'sets block at start position, decides the speed of the falling block
    Public Function start_block_fall(ByVal block As Integer)
        If block = 0 Then
            set_falling_block(4, 0, 5, 0, 4, 1, 5, 1, Color.Yellow)
        ElseIf block = 1 Then
            set_falling_block(3, 0, 4, 0, 5, 0, 6, 0, Color.Turquoise)
        ElseIf block = 2 Then
            set_falling_block(4, 0, 4, 1, 5, 1, 6, 1, Color.Blue)
        ElseIf block = 3 Then
            set_falling_block(5, 0, 3, 1, 4, 1, 5, 1, Color.Orange)
        ElseIf block = 4 Then
            set_falling_block(5, 0, 6, 0, 4, 1, 5, 1, Color.Green)
        ElseIf block = 5 Then
            set_falling_block(4, 0, 3, 1, 4, 1, 5, 1, Color.Purple)
        ElseIf block = 6 Then
            set_falling_block(3, 0, 4, 0, 4, 1, 5, 1, Color.Red)
        End If

        falling_block_pos = "up"

        If time_lines < 5 Then
            Timer1.Interval = 1000
            Timer1.Start()
        ElseIf time_lines < 10 Then
            Timer1.Interval = 750
            Timer1.Start()
        ElseIf time_lines < 15 Then
            Timer1.Interval = 500
            Timer1.Start()
        Else
            Timer1.Interval = 300
            Timer1.Start()
        End If

    End Function

    'lets a block fall, checks when the block can't fall anymore
    Public Function block_fall()
        If falling_block(0, 1) + 1 < 21 And falling_block(1, 1) + 1 < 21 And falling_block(2, 1) + 1 < 21 And falling_block(3, 1) + 1 < 21 Then
            If raster(falling_block(0, 0), falling_block(0, 1) + 1).Tag = "empty" And raster(falling_block(1, 0), falling_block(1, 1) + 1).Tag = "empty" And raster(falling_block(2, 0), falling_block(2, 1) + 1).Tag = "empty" And raster(falling_block(3, 0), falling_block(3, 1) + 1).Tag = "empty" Then
                clear_falling_block()
                set_falling_block(falling_block(0, 0), falling_block(0, 1) + 1, falling_block(1, 0), falling_block(1, 1) + 1, falling_block(2, 0), falling_block(2, 1) + 1, falling_block(3, 0), falling_block(3, 1) + 1, falling_block_color)
            Else
                Timer1.Stop()
                raster(falling_block(0, 0), falling_block(0, 1)).Tag = "full"
                raster(falling_block(1, 0), falling_block(1, 1)).Tag = "full"
                raster(falling_block(2, 0), falling_block(2, 1)).Tag = "full"
                raster(falling_block(3, 0), falling_block(3, 1)).Tag = "full"
                check_lines()
            End If
        Else
            Timer1.Stop()
            raster(falling_block(0, 0), falling_block(0, 1)).Tag = "full"
            raster(falling_block(1, 0), falling_block(1, 1)).Tag = "full"
            raster(falling_block(2, 0), falling_block(2, 1)).Tag = "full"
            raster(falling_block(3, 0), falling_block(3, 1)).Tag = "full"
            check_lines()
        End If
    End Function

    'checks if any lines are full and removes those lines, increments the score, decides the time-level
    Public Function check_lines()
        Dim lines As Integer = 0
        For j As Integer = raster.GetLowerBound(1) To raster.GetUpperBound(1)
            If raster(0, j).Tag = "full" And raster(1, j).Tag = "full" And raster(2, j).Tag = "full" And raster(3, j).Tag = "full" And raster(4, j).Tag = "full" And raster(5, j).Tag = "full" And raster(6, j).Tag = "full" And raster(7, j).Tag = "full" And raster(8, j).Tag = "full" And raster(9, j).Tag = "full" And raster(10, j).Tag = "full" Then
                For i As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
                    raster(i, j).BackColor = Color.White
                    raster(i, j).Tag = "empty"
                    For y As Integer = 0 To j - 1
                        raster(i, j - y).BackColor = raster(i, j - y - 1).BackColor
                        raster(i, j - y).Tag = raster(i, j - y - 1).Tag
                    Next

                    raster(i, 0).BackColor = Color.White
                    raster(i, 0).Tag = "empty"
                Next
                lines = lines + 1
                time_lines = time_lines + 1
                If time_lines = 5 Then
                    time = 136
                ElseIf time_lines = 10 Then
                    time = 91
                ElseIf time_lines = 15 Then
                    Timer2.Stop()
                    lbl_timer.Text = "No Limits"
                End If
            End If

        Next

        If lines = 1 Then
            lbl_score_count.Text = lbl_score_count.Text + 40
        ElseIf lines = 2 Then
            lbl_score_count.Text = lbl_score_count.Text + 100
        ElseIf lines = 3 Then
            lbl_score_count.Text = lbl_score_count.Text + 300
        ElseIf lines = 4 Then
            lbl_score_count.Text = lbl_score_count.Text + 1200
        End If

        If falling_block(0, 1) = 0 Then
            game_over()
        Else
            start_block_fall(get_block())
        End If
    End Function

    'displays "game over"
    Public Function game_over()
        lbl_gameOver.Visible = True
    End Function

    'lets the block fall at a certain speed
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        block_fall()
    End Sub

    'handles the restart button
    Private Sub btn_restart_Click(sender As Object, e As EventArgs) Handles btn_restart.Click
        Timer1.Stop()
        lbl_score_count.Text = 0
        For i As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
            For j As Integer = raster.GetLowerBound(1) To raster.GetUpperBound(1)
                raster(i, j).Tag = "empty"
                raster(i, j).BackColor = Color.White
            Next
        Next
        Label1.Visible = True
        lbl_gameOver.Visible = False
        time_lines = 0
        time = 181
        Timer2.Start()
        start_block_fall(get_block())
    End Sub

    'decrements the remaining time by 1, every second. Triggers game over when time is up.
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        time = time - 1
        lbl_timer.Text = time
        If time = 0 Then
            Timer1.Stop()
            Timer2.Stop()
            game_over()
        End If
    End Sub

    'handles the joker button
    Private Sub btn_joker_Click(sender As Object, e As EventArgs) Handles btn_joker.Click
        Timer1.Stop()
        Timer2.Stop()
        For i As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
            For j As Integer = raster.GetLowerBound(1) To raster.GetUpperBound(1)
                AddHandler raster(i, j).Click, AddressOf onLabelClick
            Next
        Next
    End Sub

    'removes the line of the clicked label
    Private Sub onLabelClick(ByVal sender As Label, ByVal e As EventArgs)
        sender.Tag = "clicked"
        For i As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
            For j As Integer = raster.GetLowerBound(1) To raster.GetUpperBound(1)
                If raster(i, j).Tag = "clicked" Then
                    For a As Integer = raster.GetLowerBound(0) To raster.GetUpperBound(0)
                        raster(a, j).BackColor = Color.White
                        raster(a, j).Tag = "empty"
                        For y As Integer = 0 To j - 1
                            raster(a, j - y).BackColor = raster(a, j - y - 1).BackColor
                            raster(a, j - y).Tag = raster(a, j - y - 1).Tag
                        Next

                        raster(a, 0).BackColor = Color.White
                        raster(a, 0).Tag = "empty"
                    Next
                    time_lines = time_lines + 1
                    lbl_score_count.Text = lbl_score_count.Text + 40
                    If time_lines = 5 Then
                        time = 136
                    ElseIf time_lines = 10 Then
                        time = 91
                    ElseIf time_lines = 15 Then
                        Timer2.Stop()
                        lbl_timer.Text = "No Limits"
                    End If
                End If
            Next
        Next
        btn_joker.Enabled = False
        Timer2.Start()
        Timer1.Start()
    End Sub
End Class
