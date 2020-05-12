using System;
using System.Collections.Generic;
using System.Linq;

public enum Direction 
{
    // Clockwise from the top
    UP,
    RIGHT,
    DOWN,
    LEFT
}

public enum NumSquaresMoved
{
    ONE = 1,
    TWO = 2
}

/**
Represents "two squares up" or "one square left"
 */
public class DirectionalMove
{
    public Direction Dir {get;set;}
    public NumSquaresMoved Num {get;set;}
}

/**
Represents "two squares up and one square left"
 */
public class Move 
{
    public DirectionalMove FirstMove {get;set;}
    public DirectionalMove SecondMove {get;set;}
}

public class SquareLocation
{
    public int Row {get;set;}
    public int Col {get;set;}

    internal SquareLocation Apply(DirectionalMove m)
    {
        if (m.Dir == Direction.DOWN)
            Col = Col - (int)m.Num;
        else if (m.Dir == Direction.UP)
            Col = Col + (int)m.Num;
        else if (m.Dir == Direction.LEFT)
            Row = Row - (int)m.Num;
        else // RIGHT
            Row = Row + (int)m.Num;

        return this;
    }
}

public class Solution {
    HashSet<Move> PossibleMoves = new HashSet<Move>();
    public int[][] A { get; private set; }
    public int NumRows { get; private set; }
    public int NumCols { get; private set; }

    /*
        PROBLEM:
        A is a matrix of :

        N rows (first array)
        |
        |
        +----- M cols (second array)

        given a zero-indexed matrix A consisting of N rows and M columns describing a chessboard, returns the minimum number of turns that the knight
        requires to move from the upper-left square to the lower-right square. The function should return -1 if it is impossible for the knight to
        move from the upper-left square to the lower-right square.

        SOLUTION
        This is a backtracking problem with some book-keeping. We need to find all the valid routes whilst counting the number of moves for each one.
        Then we simply pick the min() value.
    */
    public int solution(int[][] A) 
    {
        this.A = A;
        NumRows = A.Length;
        NumCols = A[0].Length;

        // This is possibly overkill, in retrospect
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.UP, Num = NumSquaresMoved.TWO }, 
            SecondMove = new DirectionalMove {Dir = Direction.LEFT, Num = NumSquaresMoved.ONE } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.UP, Num = NumSquaresMoved.TWO }, 
            SecondMove = new DirectionalMove {Dir = Direction.RIGHT, Num = NumSquaresMoved.ONE } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.UP, Num = NumSquaresMoved.ONE }, 
            SecondMove = new DirectionalMove {Dir = Direction.LEFT, Num = NumSquaresMoved.TWO } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.UP, Num = NumSquaresMoved.ONE }, 
            SecondMove = new DirectionalMove {Dir = Direction.RIGHT, Num = NumSquaresMoved.TWO } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.DOWN, Num = NumSquaresMoved.ONE }, 
            SecondMove = new DirectionalMove {Dir = Direction.LEFT, Num = NumSquaresMoved.TWO } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.DOWN, Num = NumSquaresMoved.ONE }, 
            SecondMove = new DirectionalMove {Dir = Direction.RIGHT, Num = NumSquaresMoved.TWO } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.DOWN, Num = NumSquaresMoved.TWO }, 
            SecondMove = new DirectionalMove {Dir = Direction.LEFT, Num = NumSquaresMoved.ONE } });
        PossibleMoves.Add(new Move { 
            FirstMove = new DirectionalMove {Dir = Direction.DOWN, Num = NumSquaresMoved.TWO }, 
            SecondMove = new DirectionalMove {Dir = Direction.RIGHT, Num = NumSquaresMoved.ONE } });

        // Start at the Upper-left
        var location = new SquareLocation { Row = NumRows -1, Col = 0 };
        var numberOfMovesForEachValidRoute = new HashSet<int>();
        Go(0, numberOfMovesForEachValidRoute, location);

        if (numberOfMovesForEachValidRoute.Count > 0)
            return numberOfMovesForEachValidRoute.Min();
        else
            return 0;
    }

    /**
    Implements the exploring and backtracking part of the solution.
     */
    private bool Go(int numberOfMovesSoFar, HashSet<int> numberOfMovesForEachValidRoute, SquareLocation location)
    {
        // We start Upper-left
        foreach (var move in PossibleMoves)
        {
            // Move in a knightly way e.g. two down, one right
            var newLocation = location.Apply(move.FirstMove).Apply(move.SecondMove);

            if (newLocation.Col > NumCols - 1)  // TODO move this validation logic to SquareLocation class
            {
                continue; // try another move
            }
            else if (newLocation.Row > NumRows -1)  // TODO move this validation logic to SquareLocation class
            {
                continue; // try another move
            }
            else
            {
                // we're still on the board. Now see if the new location is 'blocked' 
                bool isBlocked = A[newLocation.Row][newLocation.Col] == 1;
                if (isBlocked)
                {
                    continue; // try another move
                }
                else
                {
                    // OK, we're on the board and are on an unoccupied square. Are we on the target square?
                    if (newLocation.Col == NumCols - 1 && newLocation.Row == 0)
                    {
                        numberOfMovesForEachValidRoute.Add(numberOfMovesSoFar);
                        return true;
                    }
                    else
                    {
                        // We're on an unoccupied space. Recurse all the new possible moves.
                        return Go(numberOfMovesSoFar + 1, numberOfMovesForEachValidRoute, newLocation);
                    }
                }
            }
        }

        // backtrack
        return false;
    }
}
