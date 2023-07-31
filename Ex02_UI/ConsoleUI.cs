using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Ex02_Logic;
using System.Diagnostics;

namespace Ex02_UI
{
    public class ConsoleUI
    {
        private GameLogic m_GameLogic = null;

        public ConsoleUI()
        {
            m_GameLogic = new GameLogic("", "", 0, false);
        }
        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Reverse Tic Tac Toe!!!");
            Console.WriteLine("*********************************");
        }
        public void GetGameBoardSize()
        {
            int boardSize;
            bool isValidSize, quitSign = false;
            string input;

            do
            {
                Console.Write("Please enter the size of the board: ");
                input = Console.ReadLine();

                if (input == "Q")
                {
                    boardSize = 0;
                    quitSign = true;
                    break;
                }

                isValidSize = int.TryParse(input, out boardSize);

                if (isValidSize == false)
                {
                    Console.WriteLine("Error:The size must be a single integer");
                }
                else
                {
                    isValidSize = m_GameLogic.Board.TryToSetBoardSize(boardSize);
                    if (isValidSize == false)
                    {
                        Console.WriteLine("Error:The size must be between 3 to 9");
                    }
                }

            } while (isValidSize == false);

            if (quitSign == false)
            {
                m_GameLogic.Board = new GameBoard(boardSize);
            }
            else
            {
                CleanScreen();
                IsWantToKeepPlaying(true);
                return;
            }
        }
        public void GetNames(bool i_IsBotPlay)
        {
            Console.Write("Please enter the name of the first player: ");
            m_GameLogic.Player1.Name = Console.ReadLine();

            if (i_IsBotPlay == false)
            {
                Console.Write("Please enter the name of second player: ");
                m_GameLogic.Player2.Name = Console.ReadLine();
            }
            else
            {
                m_GameLogic.Player2.Name = "Computer";
            }
        }
        public void GetNumberOfPlayersAndNames()
        {
            bool isChar = false;
            bool isValidAnswer = false, quitSign = false;
            char answer;
            string strAnswer;

            do
            {
                Console.Write("Would you like to play against the computer? (y/n): ");
                strAnswer = Console.ReadLine();
                isChar = char.TryParse(strAnswer, out answer);

                if (isChar == false)
                {
                    Console.WriteLine("Error:The answer must be a character representing yes or no (e.g y/n)");
                }
                else if (isChar == true)
                {
                    if (answer == 'y' || answer == 'Y')
                    {
                        GetNames(true);
                        m_GameLogic.BotPlay = true;
                        isValidAnswer = true;
                    }
                    else if (answer == 'n' || answer == 'N')
                    {
                        GetNames(false);
                        m_GameLogic.BotPlay = false;
                        isValidAnswer = true;
                    }
                    else if (answer == 'Q')
                    {
                        quitSign = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error:The answer must be yes or no (e.g y/n)");
                    }
                }

            } while (isValidAnswer == false);

            if (quitSign == true)
            {
                CleanScreen();
                IsWantToKeepPlaying(true);
                return;
            }

        }
        public void DisplayGameBoard()
        {
            int boardSize = m_GameLogic.Board.BoardSize;
            const int NumberOfSignsPerSquare = 4;

            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("   {0}", i + 1);
            }

            Console.WriteLine();

            for (int i = 0; i < boardSize; i++)
            {
                Console.Write("{0}|", i + 1);
                for (int j = 0; j < boardSize; j++)
                {
                    BoardCell cell = m_GameLogic.Board.GetCell(i, j);
                    DisplayBoardCell(cell);
                }

                Console.WriteLine();
                Console.Write(" ");

                for (int k = 0; k <= boardSize * NumberOfSignsPerSquare; k++)
                {
                    Console.Write("=");
                }

                Console.WriteLine();
            }
        }
        public void DisplayBoardCell(BoardCell i_BoardCell)
        {
            if (i_BoardCell.Cell == eCell.X)
            {
                Console.Write(" X |");
            }
            else if (i_BoardCell.Cell == eCell.O)
            {
                Console.Write(" O |");
            }
            else
            {
                Console.Write("   |");
            }
        }
        public void DisplayScores()
        {
            Console.WriteLine($"{m_GameLogic.Player1.Name}'s score: {m_GameLogic.Player1.Score}");
            Console.WriteLine($"{m_GameLogic.Player2.Name}'s score: {m_GameLogic.Player2.Score}");
        }
        public void CleanScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }
        public void CleanScreenAndDisplayBoard()
        {
            CleanScreen();
            DisplayGameBoard();
        }
        public void GetPlayerMove(out string o_Answer)
        {
            bool isValidMove = false;
            int row, col;

            do
            {
                Console.Write("Enter row and col (row,col): ");
                o_Answer = Console.ReadLine();
                isValidMove = CheckFormat(o_Answer);

                if (isValidMove == false)
                {
                    Console.WriteLine("Error:you invalid input, please try again (e.g: 1,2)");
                }

            } while (isValidMove == false);

            ConvertStringToRowAndCol(o_Answer, out row, out col);
        }
        public bool CheckFormat(string i_PlayerMoveString)
        {
            bool isValid = false;
            const int formatLength = 3;

            if (i_PlayerMoveString.Length == formatLength)
            {
                isValid = (IsNumber(i_PlayerMoveString[0]) && IsNumber(i_PlayerMoveString[2]));
            }
            else if (IsQuitSign(i_PlayerMoveString) == true)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
        public bool IsNumber(char i_Char)
        {
            return (i_Char >= '0' && i_Char <= '9');
        }
        public bool IsQuitSign(string i_PlayerMoveString)
        {
            return (i_PlayerMoveString == "Q");
        }
        public void GetPlayerMoveAndTryToPlay()
        {
            string answer;
            int row, col;
            bool isWantToQuit, isSetSucceed, isWantToPlay;

            do
            {
                GetPlayerMove(out answer);
                isWantToQuit = ConvertStringToRowAndCol(answer, out row, out col);

                if (isWantToQuit == true)
                {
                    break;
                }

                isSetSucceed = m_GameLogic.TrySetMove(row, col);

                if (isSetSucceed == false)
                {
                    Console.WriteLine("Error:You can not choose this cell,please choose another one");
                }

            } while (isWantToQuit == false && isSetSucceed == false);

            if (isWantToQuit == true)
            {
                CleanScreen();
                IsWantToKeepPlaying(false);
            }
        }
        public bool ConvertStringToRowAndCol(string i_String, out int o_Row, out int o_Col)
        {   //This method gets a string in format of (row,column) and initialize o_Row and o_Col
            //If the players entered 'Q' instead of this format it returns true and initialize
            //o_Row and o_Col with -1

            bool isWantToQuit;
            const int OneAsciiValue = 49;

            if (IsQuitSign(i_String) == true)
            {
                isWantToQuit = true;
                o_Row = -1;
                o_Col = -1;
            }
            else
            {
                isWantToQuit = false;
                o_Row = i_String[0] - OneAsciiValue;
                o_Col = i_String[2] - OneAsciiValue;
            }

            return isWantToQuit;
        }
        public void DisplayCurrentPlayerName()
        {
            if (m_GameLogic.CurrentTurn == eTurn.Player1)
            {
                Console.WriteLine($"{ m_GameLogic.Player1.Name}'s turn:");
            }
            else
            {
                Console.WriteLine($"{ m_GameLogic.Player2.Name}'s turn:");
            }
        }
        public void DisplayBotMessage()
        {
            Console.WriteLine("Computer's turn" + "\nCalculating move..");
        }
        public void DeclareWinner()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"The winner is: {m_GameLogic.Winner.Name}");
        }
        public void DeclareDraw()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("Thhere is no winner");
        }
        public void EndingActions()
        {
            Thread.Sleep(1000);
            CleanScreen();

            if (m_GameLogic.Winner != null)
            {
                DeclareWinner();
            }
            else
            {
                DeclareDraw();
            }

            DisplayScores();
        }
        public bool IsWantToKeepPlaying(bool i_ResetGame)
        {
            bool isValidAnswer = false, wantToKeepPlaying = false;
            char answer;

            do
            {
                Console.Write("Would you like to play another game? (y/n): ");
                isValidAnswer = char.TryParse(Console.ReadLine().ToLower(), out answer);

                if (isValidAnswer == false)
                {
                    Console.WriteLine("Error:The answer must be a character representing yes or no (e.g: y/n)");
                }
                else if (answer != 'y' && answer != 'n')
                {
                    isValidAnswer = false;
                    Console.WriteLine("Error:The answer must be a character representing yes or no(e.g: y/n)");
                }

            } while (isValidAnswer == false);

            if (answer == 'y')
            {
                if (i_ResetGame == true)
                {
                    CleanScreen();
                    StartGame();
                    wantToKeepPlaying = true;
                }
                else
                {
                    m_GameLogic.ClearData();
                    CleanScreenAndDisplayBoard();
                    wantToKeepPlaying = true;
                }
            }
            else if (answer == 'n')
            {
                Environment.Exit(0);
            }

            return wantToKeepPlaying;
        }
        public void StartGame()
        {
            WelcomeMessage();
            GetGameBoardSize();
            GetNumberOfPlayersAndNames();
            CleanScreenAndDisplayBoard();

            bool anotherRound = true;

            while (anotherRound == true)
            {
                while (m_GameLogic.GameOver == false && m_GameLogic.Board.IsBoardFull() == false)
                {
                    if (m_GameLogic.CurrentTurn == eTurn.Player1 || !m_GameLogic.BotPlay)
                    {
                        DisplayCurrentPlayerName();
                        GetPlayerMoveAndTryToPlay();
                    }
                    else
                    {
                        DisplayBotMessage();
                        m_GameLogic.MakeBotMove();
                    }
                    CleanScreenAndDisplayBoard();

                }

                EndingActions();
                anotherRound = IsWantToKeepPlaying(false);
            }

        }
    }
}
