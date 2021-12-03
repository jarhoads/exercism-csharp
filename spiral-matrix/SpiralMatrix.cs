using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int fillLen = size;
        int currRow = 0;
        int currCol = 0;
        int total = size * size;
        int currVal = 1;

        int[,] mtx = new int[size, size];

        while (currVal <= total)
        {
            FillRow(mtx, fillLen, currRow, currCol, currVal);
            currCol += (fillLen - 1);
            currVal += fillLen;
            currRow++;
            fillLen--;

            if (currVal < total)
            {
                FillCol(mtx, fillLen, currRow, currCol, currVal);
                currVal += fillLen;
                currRow += (fillLen - 1);
                currCol--;
            }

            if(currVal < total)
            {
                FilleRowRev(mtx, fillLen, currRow, currCol, currVal);
                currVal += fillLen;
                currCol -= (fillLen - 1);
                currRow--;
                fillLen--;
            }

            if (currVal < total)
            {
                FillColRev(mtx, fillLen, currRow, currCol, currVal);
                currVal += fillLen;
                currCol++;
                currRow -= (fillLen - 1);
            }
        }

        return mtx;
    }

    public static void FillRow(int[,] arr, int len, int row, int col, int beginVal)
    {
        for (int i=col; i<(col+len); i++)
        {
            arr[row, i] = beginVal;
            beginVal++;                
        }
    }

    public static void FilleRowRev(int[,] arr, int len, int row, int col, int beginVal)
    {
        for (int i=col; i>(col-len); i--)
        {
            arr[row, i] = beginVal;
            beginVal++;                
        }
    }

    public static void FillCol(int[,] arr, int len, int row, int col, int beginVal)
    {
        for (int i=row; i<(row+len); i++)
        {
            arr[i, col] = beginVal;
            beginVal++;                
        }
    }

    public static void FillColRev(int[,] arr, int len, int row, int col, int beginVal)
    {
        for (int i=row; i>(row-len); i--)
        {
            arr[i, col] = beginVal;
            beginVal++;                
        }
    }
}
