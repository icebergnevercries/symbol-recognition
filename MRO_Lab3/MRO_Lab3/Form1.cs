using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRO_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TableSymbols.RowCount = 9;
            TableSymbols.Rows[0].Cells[0].Value = "R1";
            TableSymbols.Rows[1].Cells[0].Value = "R2";
            TableSymbols.Rows[2].Cells[0].Value = "R3";
            TableSymbols.Rows[3].Cells[0].Value = "Z1";
            TableSymbols.Rows[4].Cells[0].Value = "Z2";
            TableSymbols.Rows[5].Cells[0].Value = "Z3";
            TableSymbols.Rows[6].Cells[0].Value = "W1";
            TableSymbols.Rows[7].Cells[0].Value = "W2";
            TableSymbols.Rows[8].Cells[0].Value = "W3";

            ConfirmSymbols.RowCount = 9;
            ConfirmSymbols.Rows[0].Cells[0].Value = "R1";
            ConfirmSymbols.Rows[1].Cells[0].Value = "R2";
            ConfirmSymbols.Rows[2].Cells[0].Value = "R3";
            ConfirmSymbols.Rows[3].Cells[0].Value = "Z1";
            ConfirmSymbols.Rows[4].Cells[0].Value = "Z2";
            ConfirmSymbols.Rows[5].Cells[0].Value = "Z3";
            ConfirmSymbols.Rows[6].Cells[0].Value = "W1";
            ConfirmSymbols.Rows[7].Cells[0].Value = "W2";
            ConfirmSymbols.Rows[8].Cells[0].Value = "W3";
        }
        #region Данные
        int[,] wind = new int[5, 5] { {1,1,1,1,1 },
                                       {1,3,3,3,1 },
                                       {1,3,5,3,1 },
                                       {1,3,3,3,1 },
                                       {1,1,1,1,1 } };
        Bitmap image = new Bitmap(20, 20);
        bool flagfortablesymbols = false;
        CharElemTemp[] CharElemObj = new CharElemTemp[50];
        CharElemTempDB[] CharElemObjDB = new CharElemTempDB[50];
        Shablon[] shab = new Shablon[20];
        Codes[] codeObj = new Codes[50];
        ShablonCode[] shabcode = new ShablonCode[20];
        CodesDB[] codeObjDB = new CodesDB[50];
        #endregion
        int[,] MatrByteFun(Bitmap IMAGE)
        {
            int[,] Matr = new int[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (IMAGE.GetPixel(i, j).ToArgb() == Color.Black.ToArgb())
                    {
                        Matr[i, j] = 1;
                    }
                    else
                    {
                        Matr[i, j] = 0;
                    }
                }
            }
            return Matr;
        }
        double[,] MatrResFun(int[,] MATR, int[,] WIND)
        {
            double[,] evkl = new double[20, 20];
            #region Матрица результативности
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    #region 1
                    if (i - 2 >= 0 && j - 2 >= 0 && i + 2 < 20 && j + 2 < 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 2
                    if (i - 2 >= 0 && i + 2 < 20 && j - 2 == -2)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((0 - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 >= 0 && i + 2 < 20 && j - 2 == -1)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 3
                    if (i + 2 == 20 && j - 2 == -1)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 20 && j - 2 == -2)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                              Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                              Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((0 - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                              Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                              Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 21 && j - 2 == -1)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                              Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                              Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                              Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((0 - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                              Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 21 && j - 2 == -2)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((0 - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((0 - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 4
                    if (i + 2 == 20 && j - 2 >= 0 && j + 2 < 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 21 && j - 2 >= 0 && j + 2 < 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((MATR[i - 2, j + 2] - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((0 - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 5
                    if (i + 2 == 20 && j + 2 == 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 20 && j + 2 == 21)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((0 - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 21 && j + 2 == 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((0 - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i + 2 == 21 && j + 2 == 21)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((0 - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((0 - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((0 - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 6
                    if (i - 2 >= 0 && i + 2 < 20 && j + 2 == 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((MATR[i - 2, j + 1] - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 >= 0 && i + 2 < 20 && j + 2 == 21)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((MATR[i - 2, j - 2] - WIND[0, 0]), 2) + Math.Pow((MATR[i - 2, j - 1] - WIND[0, 1]), 2) + Math.Pow((MATR[i - 2, j] - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((0 - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 7
                    if (i - 2 == -1 && j + 2 == 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -1 && j + 2 == 21)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                                Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                                Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((0 - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                                Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                                Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -2 && j + 2 == 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                                Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((0 - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                                Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                                Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                                Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -2 && j + 2 == 21)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                                 Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((0 - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                                 Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((0 - WIND[2, 3]), 2) + Math.Pow((0 - WIND[2, 4]), 2) +
                                                 Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((0 - WIND[3, 3]), 2) + Math.Pow((0 - WIND[3, 4]), 2) +
                                                 Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((0 - WIND[4, 3]), 2) + Math.Pow((0 - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 8
                    if (i - 2 == -1 && j - 2 >= 0 && j + 2 < 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((MATR[i - 1, j - 2] - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -2 && j - 2 >= 0 && j + 2 < 20)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((0 - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((MATR[i, j - 2] - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((MATR[i + 1, j - 2] - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((MATR[i + 2, j - 2] - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    #endregion

                    #region 9
                    if (i - 2 == -2 && j - 2 == -2)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((0 - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((0 - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -2 && j - 2 == -1)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((0 - WIND[1, 2]), 2) + Math.Pow((0 - WIND[1, 3]), 2) + Math.Pow((0 - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -1 && j - 2 == -2)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((0 - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((0 - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((0 - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((0 - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    if (i - 2 == -1 && j - 2 == -1)
                    {
                        evkl[i, j] = Math.Round(Math.Sqrt(Math.Pow((0 - WIND[0, 0]), 2) + Math.Pow((0 - WIND[0, 1]), 2) + Math.Pow((0 - WIND[0, 2]), 2) + Math.Pow((0 - WIND[0, 3]), 2) + Math.Pow((0 - WIND[0, 4]), 2) +
                                               Math.Pow((0 - WIND[1, 0]), 2) + Math.Pow((MATR[i - 1, j - 1] - WIND[1, 1]), 2) + Math.Pow((MATR[i - 1, j] - WIND[1, 2]), 2) + Math.Pow((MATR[i - 1, j + 1] - WIND[1, 3]), 2) + Math.Pow((MATR[i - 1, j + 2] - WIND[1, 4]), 2) +
                                               Math.Pow((0 - WIND[2, 0]), 2) + Math.Pow((MATR[i, j - 1] - WIND[2, 1]), 2) + Math.Pow((MATR[i, j] - WIND[2, 2]), 2) + Math.Pow((MATR[i, j + 1] - WIND[2, 3]), 2) + Math.Pow((MATR[i, j + 2] - WIND[2, 4]), 2) +
                                               Math.Pow((0 - WIND[3, 0]), 2) + Math.Pow((MATR[i + 1, j - 1] - WIND[3, 1]), 2) + Math.Pow((MATR[i + 1, j] - WIND[3, 2]), 2) + Math.Pow((MATR[i + 1, j + 1] - WIND[3, 3]), 2) + Math.Pow((MATR[i + 1, j + 2] - WIND[3, 4]), 2) +
                                               Math.Pow((0 - WIND[4, 0]), 2) + Math.Pow((MATR[i + 2, j - 1] - WIND[4, 1]), 2) + Math.Pow((MATR[i + 2, j] - WIND[4, 2]), 2) + Math.Pow((MATR[i + 2, j + 1] - WIND[4, 3]), 2) + Math.Pow((MATR[i + 2, j + 2] - WIND[4, 4]), 2)), 3);
                    }
                    #endregion
                }
            }
            #endregion
            return evkl;
        }
        void PrimaryProvision(int[,] WIND, int[,] MATRBYTE)
        {
            Maska.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Maska.Rows[j].Cells[i].Value = WIND[i, j];
                }
            }

            MatrByteSymbol.RowCount = 20;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    MatrByteSymbol.Rows[j].Cells[i].Value = MATRBYTE[i, j];
                }
            }
        }
        void CharElemFun(double[,] MATRRES, int[,] MATRBYTE, string str)
        {
            int i_min1 = 0, i_min2 = 0, i_min3 = 0;
            int j_min1 = 0, j_min2 = 0, j_min3 = 0;
            double min1 = 20, min2 = 20, min3 = 20;
            double[,] Min1Matr = new double[5, 5];
            double[,] Min2Matr = new double[5, 5];
            double[,] Min3Matr = new double[5, 5];
            double[,] Min1MatrRes = new double[5, 5];
            double[,] Min2MatrRes = new double[5, 5];
            double[,] Min3MatrRes = new double[5, 5];
            double[,] MatrResSym = MATRRES;
            int[,] MatrByteSym = MATRBYTE;
            MatrRes.RowCount = 20;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    MatrRes.Rows[j].Cells[i].Value = MATRRES[i, j];
                    if (min1 > MatrResSym[i, j])
                    {
                        min1 = MatrResSym[i, j];
                        i_min1 = i;
                        j_min1 = j;
                    }
                }
            }
            for (int k = -2; k < 3; k++)
            {
                for (int g = -2; g < 3; g++)
                {
                    Min1Matr[2 + k, 2 + g] = MatrResSym[i_min1 + k, j_min1 + g];
                    Min1MatrRes[2 + k, 2 + g] = MatrByteSym[i_min1 + k, j_min1 + g];
                    MatrResSym[i_min1 + k, j_min1 + g] = 20;
                    MatrRes.Rows[j_min1 + k].Cells[i_min1 + g].Style.BackColor = Color.Red;
                    MatrByteSymbol.Rows[j_min1 + k].Cells[i_min1 + g].Style.BackColor = Color.Red;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (min2 > MatrResSym[i, j])
                    {
                        min2 = MatrResSym[i, j];
                        i_min2 = i;
                        j_min2 = j;
                    }
                }
            }
            for (int k = -2; k < 3; k++)
            {
                for (int g = -2; g < 3; g++)
                {
                    Min2Matr[2 + k, 2 + g] = MatrResSym[i_min2 + k, j_min2 + g];
                    Min2MatrRes[2 + k, 2 + g] = MatrByteSym[i_min2 + k, j_min2 + g];
                    MatrResSym[i_min2 + k, j_min2 + g] = 20;
                    MatrRes.Rows[j_min2 + k].Cells[i_min2 + g].Style.BackColor = Color.Green;
                    MatrByteSymbol.Rows[j_min2 + k].Cells[i_min2 + g].Style.BackColor = Color.Green;
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (min3 > MatrResSym[i, j])
                    {
                        min3 = MatrResSym[i, j];
                        i_min3 = i;
                        j_min3 = j;
                    }
                }
            }
            for (int k = -2; k < 3; k++)
            {
                for (int g = -2; g < 3; g++)
                {
                    Min3Matr[2 + k, 2 + g] = MatrResSym[i_min3 + k, j_min3 + g];
                    Min3MatrRes[2 + k, 2 + g] = MatrByteSym[i_min3 + k, j_min3 + g];
                    MatrResSym[i_min3 + k, j_min3 + g] = 20;
                    MatrRes.Rows[j_min3 + k].Cells[i_min3 + g].Style.BackColor = Color.Blue;
                    MatrByteSymbol.Rows[j_min3 + k].Cells[i_min3 + g].Style.BackColor = Color.Blue;
                }
            }

            MatrChE1.RowCount = 5;
            ByteChE1.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MatrChE1.Rows[j].Cells[i].Value = Min1Matr[i, j];
                    ByteChE1.Rows[j].Cells[i].Value = Min1MatrRes[i, j];
                }
            }
            MatrChE2.RowCount = 5;
            ByteChE2.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MatrChE2.Rows[j].Cells[i].Value = Min2Matr[i, j];
                    ByteChE2.Rows[j].Cells[i].Value = Min2MatrRes[i, j];
                }
            }
            MatrChE3.RowCount = 5;
            ByteChE3.RowCount = 5;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MatrChE3.Rows[j].Cells[i].Value = Min3Matr[i, j];
                    ByteChE3.Rows[j].Cells[i].Value = Min3MatrRes[i, j];
                }
            }

            CharElemObj[CharElemTemp.index] = new CharElemTemp();
            CharElemObj[CharElemTemp.index].NameSym = str;
            CharElemObj[CharElemTemp.index].NameClass = CharElemTemp.index.ToString();
            CharElemObj[CharElemTemp.index].MatrChEl = Min1Matr;
            CharElemObj[CharElemTemp.index].MatrByteChEl = Min1MatrRes;
            CharElemObj[CharElemTemp.index].IforChEl = i_min1;
            CharElemObj[CharElemTemp.index].JforChEl = j_min1;
            CharElemTemp.index++;
            CharElemObjDB[CharElemTempDB.indexDB] = new CharElemTempDB();
            CharElemObjDB[CharElemTempDB.indexDB].NameSymDB = str;
            CharElemObjDB[CharElemTempDB.indexDB].NameClassDB = CharElemTempDB.indexDB.ToString();
            CharElemObjDB[CharElemTempDB.indexDB].MatrChElDB = Min1Matr;
            CharElemObjDB[CharElemTempDB.indexDB].MatrByteChElDB = Min1MatrRes;
            CharElemObjDB[CharElemTempDB.indexDB].IforChElDB = i_min1;
            CharElemObjDB[CharElemTempDB.indexDB].JforChElDB = j_min1;
            CharElemTempDB.indexDB++;

            CharElemObj[CharElemTemp.index] = new CharElemTemp();
            CharElemObj[CharElemTemp.index].NameSym = str;
            CharElemObj[CharElemTemp.index].NameClass = CharElemTemp.index.ToString();
            CharElemObj[CharElemTemp.index].MatrChEl = Min2Matr;
            CharElemObj[CharElemTemp.index].MatrByteChEl = Min2MatrRes;
            CharElemObj[CharElemTemp.index].IforChEl= i_min2;
            CharElemObj[CharElemTemp.index].JforChEl = j_min2;
            CharElemTemp.index++;
            CharElemObjDB[CharElemTempDB.indexDB] = new CharElemTempDB();
            CharElemObjDB[CharElemTempDB.indexDB].NameSymDB = str;
            CharElemObjDB[CharElemTempDB.indexDB].NameClassDB = CharElemTempDB.indexDB.ToString();
            CharElemObjDB[CharElemTempDB.indexDB].MatrChElDB = Min2Matr;
            CharElemObjDB[CharElemTempDB.indexDB].MatrByteChElDB = Min2MatrRes;
            CharElemObjDB[CharElemTempDB.indexDB].IforChElDB = i_min2;
            CharElemObjDB[CharElemTempDB.indexDB].JforChElDB = j_min2;
            CharElemTempDB.indexDB++;

            CharElemObj[CharElemTemp.index] = new CharElemTemp();
            CharElemObj[CharElemTemp.index].NameSym = str;
            CharElemObj[CharElemTemp.index].NameClass = CharElemTemp.index.ToString();
            CharElemObj[CharElemTemp.index].MatrChEl = Min3Matr;
            CharElemObj[CharElemTemp.index].MatrByteChEl = Min3MatrRes;
            CharElemObj[CharElemTemp.index].IforChEl = i_min3;
            CharElemObj[CharElemTemp.index].JforChEl = j_min3;
            CharElemTemp.index++;
            CharElemObjDB[CharElemTempDB.indexDB] = new CharElemTempDB();
            CharElemObjDB[CharElemTempDB.indexDB].NameSymDB = str;
            CharElemObjDB[CharElemTempDB.indexDB].NameClassDB = CharElemTempDB.indexDB.ToString();
            CharElemObjDB[CharElemTempDB.indexDB].MatrChElDB = Min3Matr;
            CharElemObjDB[CharElemTempDB.indexDB].MatrByteChElDB = Min3MatrRes;
            CharElemObjDB[CharElemTempDB.indexDB].IforChElDB = i_min3;
            CharElemObjDB[CharElemTempDB.indexDB].JforChElDB = j_min3;
            CharElemTempDB.indexDB++;
        }
        void Clean()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    MatrRes.Rows[j].Cells[i].Style.BackColor = Color.White;
                    MatrByteSymbol.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
        }
        int[] GetObjNum(string STR)
        {
            int num = 0;
            int num1 = 0;
            int a = 0;
            int s = 0;
            for (int i = 0; i < STR.Length; i++)
            {
                if (STR[i] == '-')
                {
                    num++;
                    a = 0;
                }
                else
                { a++; }
                if (a > 1)
                { s++; }
            }            
            int[] elem = new int[STR.Length - num - s];
            int index = 0;            
            string str = "";
            for (int i = 0; i < STR.Length; i++)
            {
                if (num == 0)
                {
                    elem[index] = Convert.ToInt32(STR);
                }
                else
                {
                    if (num == num1)
                    {
                        str += STR[i];
                        if (i == STR.Length - 1)
                            elem[index] = Convert.ToInt32(str);
                    }
                    else
                    {
                        if (STR[i] == '-')
                        {
                            elem[index] = Convert.ToInt32(str);
                            index++;
                            str = "";
                            num1++;
                        }
                        else
                        {
                            str += STR[i];
                        }
                    }
                }                                                            
            }
            return elem;
        }
        double[,] GetMatrByte(int[] mass)
        {
            double[,] matrbyte = new double[5, 5];
            double buff = 0;
            for (int n = 0; n < 5; n++)
            {
                for (int m = 0; m < 5; m++)
                {
                    buff = 0;
                    for (int i = 0; i < mass.Length; i++)
                    {
                        buff += CharElemObjDB[mass[i]].MatrByteChElDB[n, m];
                    }
                    matrbyte[n, m] = buff / mass.Length;
                }
            }
            return matrbyte;
        }
        void CodesChEl(string STR)
        {
            int[] indexes = new int[3];
            int[,] code = new int[3,8];
            int num = 0;
            for(int i = 0; i < CharElemTempDB.indexDB; i++)
            {
                if ((CharElemObjDB[i] != null) && (CharElemObjDB[i].NameSymDB == STR))
                {
                    indexes[num] = i;
                    num++;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j != i)
                    {
                        int dI = Math.Abs(CharElemObjDB[indexes[j]].IforChElDB - CharElemObjDB[indexes[i]].IforChElDB);
                        int dJ = Math.Abs(CharElemObjDB[indexes[j]].JforChElDB - CharElemObjDB[indexes[i]].JforChElDB);
                        if ((CharElemObjDB[indexes[i]].IforChElDB < CharElemObjDB[indexes[j]].IforChElDB) && (CharElemObjDB[indexes[i]].JforChElDB >= CharElemObjDB[indexes[j]].JforChElDB))
                        {
                            //1 и 2 четверти
                            if ((dJ / dI >= 0) && (dJ / dI < 1))
                            {
                                code[i, 0] = 1;
                            }
                            if (dJ / dI >= 1)
                            {
                                code[i, 1] = 1;
                            }
                        }
                        if ((CharElemObjDB[indexes[i]].IforChElDB >= CharElemObjDB[indexes[j]].IforChElDB) && (CharElemObjDB[indexes[i]].JforChElDB > CharElemObjDB[indexes[j]].JforChElDB))
                        {
                            //3 и 4 четверти
                            if ((dI / dJ >= 0) && (dI / dJ < 1))
                            {
                                code[i, 2] = 1;
                            }
                            if (dI / dJ >= 1)
                            {
                                code[i, 3] = 1;
                            }
                        }
                        if ((CharElemObjDB[indexes[i]].IforChElDB > CharElemObjDB[indexes[j]].IforChElDB) && (CharElemObjDB[indexes[i]].JforChElDB <= CharElemObjDB[indexes[j]].JforChElDB))
                        {
                            //5 и 6 четверти
                            if ((dJ / dI >= 0) && (dJ / dI < 1))
                            {
                                code[i, 4] = 1;
                            }
                            if (dJ / dI >= 1)
                            {
                                code[i, 5] = 1;
                            }
                        }
                        if ((CharElemObjDB[indexes[i]].IforChElDB <= CharElemObjDB[indexes[j]].IforChElDB) && (CharElemObjDB[indexes[i]].JforChElDB < CharElemObjDB[indexes[j]].JforChElDB))
                        {
                            //7 и 8 четверти
                            if ((dI / dJ >= 0) && (dI / dJ < 1))
                            {
                                code[i, 6] = 1;
                            }
                            if (dI / dJ >= 1)
                            {
                                code[i, 7] = 1;
                            }
                        }
                    }                    
                }
            }
            codeObj[Codes.indCode] = new Codes();
            codeObjDB[CodesDB.indCodeDB] = new CodesDB();
            for (int i = 0; i < 8; i++)
            {
                CharElemObjDB[indexes[0]].CodeChElDB[i] = code[0, i];
                CodeChE1.Rows[0].Cells[i].Value = code[0, i];
                codeObj[Codes.indCode].Code[i] = code[0, i];
                codeObjDB[CodesDB.indCodeDB].CodeDB[i] = code[0, i];
                codeObj[Codes.indCode].NameCode = Codes.indCode.ToString();
            }
            Codes.indCode++;
            CodesDB.indCodeDB++;
            codeObj[Codes.indCode] = new Codes();
            codeObjDB[CodesDB.indCodeDB] = new CodesDB();
            for (int i = 0; i < 8; i++)
            {
                CharElemObjDB[indexes[1]].CodeChElDB[i] = code[1, i];
                CodeChE2.Rows[0].Cells[i].Value = code[1, i];
                codeObj[Codes.indCode].Code[i] = code[1, i];
                codeObjDB[CodesDB.indCodeDB].CodeDB[i] = code[1, i];
                codeObj[Codes.indCode].NameCode = Codes.indCode.ToString();
            }            
            Codes.indCode++;
            CodesDB.indCodeDB++;
            codeObj[Codes.indCode] = new Codes();
            codeObjDB[CodesDB.indCodeDB] = new CodesDB();
            for (int i = 0; i < 8; i++)
            {
                CharElemObjDB[indexes[2]].CodeChElDB[i] = code[2, i];
                CodeChE3.Rows[0].Cells[i].Value = code[2, i];
                codeObj[Codes.indCode].Code[i] = code[2, i];
                codeObjDB[CodesDB.indCodeDB].CodeDB[i] = code[2, i];
                codeObj[Codes.indCode].NameCode = Codes.indCode.ToString();
            }            
            Codes.indCode++;
            CodesDB.indCodeDB++;
        }
        double[] lala(string STR)
        {
            int[] mass = GetObjNum(STR);
            double[] Num = new double[8];
            double[] Num1 = new double[8];
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Num[j] += codeObjDB[mass[i]].CodeDB[j];
                }
            }
            for (int j = 0; j < 8; j++)
            {
                Num1[j] = Num[j] / mass.Length;
            }
            return Num1;
        }
        int[] GetCommon(int num)
        {
            int[] common = new int[2];
            for (int i = 0; i < Shablon.ind; i++)
            {
                int[] mass1 = GetObjNum(shab[i].ShablonClass);
                for (int j = 0; j < mass1.Length; j++)
                {
                    if (mass1[j] == num)
                    {
                        common[0] = i+1;
                        break;
                    }
                }
            }
            for (int i = 0; i < ShablonCode.indCode1; i++)
            {
                int[] mass2 = GetObjNum(shabcode[i].NameCode1);
                for (int j = 0; j < mass2.Length; j++)
                {
                    if (mass2[j] == num)
                    {
                        common[1] = i+1;
                        break;
                    }
                }
            }
            return common;
        }

        private void TableSymbols_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (flagfortablesymbols)
                Clean();
            Graphics gr = DrawSymbol.CreateGraphics();
            if (e.RowIndex == 0)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\R1.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "R1");
                CodesChEl("R1");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 1)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\R2.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "R2");
                CodesChEl("R2");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 2)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\R3.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "R3");
                CodesChEl("R3");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 3)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\Z1.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "Z1");
                CodesChEl("Z1");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 4)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\Z2.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "Z2");
                CodesChEl("Z2");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 5)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\Z3.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "Z3");
                CodesChEl("Z3");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 6)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\W1.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "W1");
                CodesChEl("W1");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 7)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\W2.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "W2");
                CodesChEl("W2");
                DrawSymbol.Image = image;
            }
            if (e.RowIndex == 8)
            {
                image = (Bitmap)Image.FromFile(@"F:\учеба\(лабы)МРО\Laba 3\MRO_Lab3\W3.bmp");
                PrimaryProvision(wind, MatrByteFun(image));
                CharElemFun(MatrResFun(MatrByteFun(image), wind), MatrByteFun(image), "W3");
                CodesChEl("W3");
                DrawSymbol.Image = image;
            }
            flagfortablesymbols = true;
        }

        private void ConfirmSymbols_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TableRecognition.ColumnCount = Shablon.ind + 1;
            TableRecognition.RowCount = ShablonCode.indCode1 + 1;
            for (int i = 0; i < ShablonCode.indCode1 + 1; i++)
            {
                for (int j = 0; j < Shablon.ind + 1; j++)
                {
                    if (i > 0 && j == 0)
                    {
                        TableRecognition.Rows[i].Cells[j].Value = shabcode[i - 1].NameCode1;
                    }
                    if (j > 0 && i == 0)
                    {
                        TableRecognition.Rows[i].Cells[j].Value = shab[j - 1].ShablonClass;
                    }
                }
            }

            if (e.RowIndex == 0)
            {
                int[] m0 = GetCommon(0);
                int[] m1 = GetCommon(1);
                int[] m2 = GetCommon(2);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 1)
            {
                int[] m0 = GetCommon(3);
                int[] m1 = GetCommon(4);
                int[] m2 = GetCommon(5);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 2)
            {
                int[] m0 = GetCommon(6);
                int[] m1 = GetCommon(7);
                int[] m2 = GetCommon(8);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 3)
            {
                int[] m0 = GetCommon(9);
                int[] m1 = GetCommon(10);
                int[] m2 = GetCommon(11);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 4)
            {
                int[] m0 = GetCommon(12);
                int[] m1 = GetCommon(13);
                int[] m2 = GetCommon(14);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 5)
            {
                int[] m0 = GetCommon(15);
                int[] m1 = GetCommon(16);
                int[] m2 = GetCommon(17);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 6)
            {
                int[] m0 = GetCommon(18);
                int[] m1 = GetCommon(19);
                int[] m2 = GetCommon(20);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 7)
            {
                int[] m0 = GetCommon(21);
                int[] m1 = GetCommon(22);
                int[] m2 = GetCommon(23);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
            if (e.RowIndex == 8)
            {
                int[] m0 = GetCommon(24);
                int[] m1 = GetCommon(25);
                int[] m2 = GetCommon(26);
                for (int i = 1; i < ShablonCode.indCode1 + 1; i++)
                {
                    for (int j = 1; j < Shablon.ind + 1; j++)
                    {
                        if ((m0[1] == i && m0[0] == j) || (m1[1] == i && m1[0] == j) || (m2[1] == i && m2[0] == j))
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 1;
                        }
                        else
                        {
                            TableRecognition.Rows[i].Cells[j].Value = 0;
                        }
                    }
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            #region Разбиение на классы
            TableUnite.RowCount = CharElemTempDB.indexDB - 2;
            for (int index = 0; index < CharElemTempDB.indexDB - 2; index++)
            {
                TableUnite.Rows[index].Cells[0].Value = CharElemTempDB.indexDB - index;
                TableUnite.Rows[index].Cells[1].Value = "";

                #region Вывод в таблицу классов
                for (int i = 0; i < CharElemTemp.index; i++)
                {
                    if (CharElemObj[i] != null)
                    {
                        TableUnite.Rows[index].Cells[1].Value += "(" + CharElemObj[i].NameClass + ")";
                    }
                }

                int NumClass = 0;
                for (int i = 0; i < CharElemTemp.index - 2; i++)
                {
                    if (CharElemObj[i] != null)
                    {
                        CharElemTemp.FunctionF1[index] += CharElemObj[i].Difrent;
                        NumClass++;
                    }
                }
                TableUnite.Rows[index].Cells[2].Value = Math.Round((CharElemTemp.FunctionF1[index] / NumClass), 3);
                #endregion

                #region Составляем матрицу разности
                for (int i = 0; i < CharElemTemp.index; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (CharElemObj[i] != null && CharElemObj[j] != null && i != j)
                        {
                            double del = 0;
                            for (int k = 0; k < 5; k++)
                            {
                                for (int g = 0; g < 5; g++)
                                {
                                    del += Math.Pow(CharElemObj[i].MatrChEl[k, g] - CharElemObj[j].MatrChEl[k, g], 2);
                                }
                            }
                            CharElemTemp.MatrDel[i, j] = Math.Sqrt(del);
                        }
                        else
                        {
                            CharElemTemp.MatrDel[i, j] = -1;
                            CharElemTemp.MatrDel[j, i] = -1;
                        }
                    }
                }

                //if (flag)
                //{
                //    CharElemTemp.StDel = CharElemTemp.Del;
                //    flag = false;
                //}
                #endregion

                #region Находим минимум
                double min = 500;
                int indI = 30;
                int indJ = 30;
                for (int i = 0; i < CharElemTemp.index; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if ((CharElemObj[i] != null) && (CharElemObj[j] != null) && (i != j) && (CharElemTemp.MatrDel[i, j] != -1) && (CharElemTemp.MatrDel[i, j] < min))
                        {
                            min = CharElemTemp.MatrDel[i, j];
                            indI = i;
                            indJ = j;
                        }
                    }
                }
                #endregion

                #region Записываем новые матрицы ХЭ и байтов
                if (CharElemObj[indI] != null && CharElemObj[indJ] != null)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int g = 0; g < 5; g++)
                        {
                            CharElemObj[indI].MatrChEl[k, g] = (CharElemObj[indI].MatrChEl[k, g] + CharElemObj[indJ].MatrChEl[k, g]) / 2;
                            CharElemObj[indI].MatrByteChEl[k, g] = (CharElemObj[indI].MatrByteChEl[k, g] + CharElemObj[indJ].MatrByteChEl[k, g]) / 2;
                        }
                    }
                    CharElemObj[indI].Difrent = min;
                    CharElemObj[indI].NameClass = CharElemObj[indI].NameClass + "-" + CharElemObj[indJ].NameClass;
                    CharElemObj[indJ] = null;
                }
                #endregion
                #endregion  
                int AAA = 0;
                for (int u = 0; u < CharElemTemp.index; u++)
                {
                    if (CharElemObj[u] != null)
                    {
                        AAA++;
                    }
                }
                if (AAA == 8)
                {
                    for (int u1 = 0; u1 < CharElemTemp.index; u1++)
                    {
                        if (CharElemObj[u1] != null)
                        {
                            shab[Shablon.ind] = new Shablon();
                            shab[Shablon.ind].MatrCE1 = CharElemObj[u1].MatrChEl;
                            shab[Shablon.ind].MatrByte1 = CharElemObj[u1].MatrByteChEl;
                            shab[Shablon.ind].ShablonClass = CharElemObj[u1].NameClass;
                            Shablon.ind++;
                        }
                    }
                }
            }
                     
        }
        private void ButtonForShablon_Click(object sender, EventArgs e)
        {
            Graphics gr0 = Etalon1.CreateGraphics();
            Graphics gr1 = Etalon2.CreateGraphics();
            Graphics gr2 = Etalon3.CreateGraphics();
            Graphics gr3 = Etalon4.CreateGraphics();
            Graphics gr4 = Etalon5.CreateGraphics();
            Graphics gr5 = Etalon6.CreateGraphics();
            Graphics gr6 = Etalon7.CreateGraphics();
            Graphics gr7 = Etalon8.CreateGraphics();
            double[,] matr1 = new double[5,5];
            double[,] matr2 = new double[5, 5];
            double[,] matr3 = new double[5, 5];
            double[,] matr4 = new double[5, 5];
            double[,] matr5 = new double[5, 5];
            double[,] matr6 = new double[5, 5];
            double[,] matr7 = new double[5, 5];
            double[,] matr8 = new double[5, 5];
            Color col0 = Color.White;
            Color col1 = Color.White;
            Color col2 = Color.White;
            Color col3 = Color.White;
            Color col4 = Color.White;
            Color col5 = Color.White;
            Color col6 = Color.White;
            Color col7 = Color.White;
            if (shab[0] != null)
                matr1 = GetMatrByte(GetObjNum(shab[0].ShablonClass));
            if (shab[1] != null)
                matr2 = GetMatrByte(GetObjNum(shab[1].ShablonClass));
            if (shab[2] != null)
                matr3 = GetMatrByte(GetObjNum(shab[2].ShablonClass));
            if (shab[3] != null)
                matr4 = GetMatrByte(GetObjNum(shab[3].ShablonClass));
            if (shab[4] != null)
                matr5 = GetMatrByte(GetObjNum(shab[4].ShablonClass));
            if (shab[5] != null)
                matr6 = GetMatrByte(GetObjNum(shab[5].ShablonClass));
            if (shab[6] != null)
                matr7 = GetMatrByte(GetObjNum(shab[6].ShablonClass));
            if (shab[7] != null)
                matr8 = GetMatrByte(GetObjNum(shab[7].ShablonClass));
            for (int k = 0; k < 5; k++)
            {
                for (int n = 0; n < 5; n++)
                {
                    if (shab[0] != null)
                        col0 = Color.FromArgb(Convert.ToInt32(-255 * matr1[k, n] + 255), Convert.ToInt32(-255 * matr1[k, n] + 255), Convert.ToInt32(-255 * matr1[k, n] + 255));
                    if (shab[1] != null)
                        col1 = Color.FromArgb(Convert.ToInt32(-255 * matr2[k, n] + 255), Convert.ToInt32(-255 * matr2[k, n] + 255), Convert.ToInt32(-255 * matr2[k, n] + 255));
                    if (shab[2] != null)
                        col2 = Color.FromArgb(Convert.ToInt32(-255 * matr3[k, n] + 255), Convert.ToInt32(-255 * matr3[k, n] + 255), Convert.ToInt32(-255 * matr3[k, n] + 255));
                    if (shab[3] != null)
                        col3 = Color.FromArgb(Convert.ToInt32(-255 * matr4[k, n] + 255), Convert.ToInt32(-255 * matr4[k, n] + 255), Convert.ToInt32(-255 * matr4[k, n] + 255));
                    if (shab[4] != null)
                        col4 = Color.FromArgb(Convert.ToInt32(-255 * matr5[k, n] + 255), Convert.ToInt32(-255 * matr5[k, n] + 255), Convert.ToInt32(-255 * matr5[k, n] + 255));
                    if (shab[5] != null)
                        col5 = Color.FromArgb(Convert.ToInt32(-255 * matr6[k, n] + 255), Convert.ToInt32(-255 * matr6[k, n] + 255), Convert.ToInt32(-255 * matr6[k, n] + 255));
                    if (shab[6] != null)
                        col6 = Color.FromArgb(Convert.ToInt32(-255 * matr7[k, n] + 255), Convert.ToInt32(-255 * matr7[k, n] + 255), Convert.ToInt32(-255 * matr7[k, n] + 255));
                    if (shab[7] != null)
                        col7 = Color.FromArgb(Convert.ToInt32(-255 * matr8[k, n] + 255), Convert.ToInt32(-255 * matr8[k, n] + 255), Convert.ToInt32(-255 * matr8[k, n] + 255));
                    if (shab[0] != null)
                        label1.Text = shab[0].ShablonClass;
                    if (shab[1] != null)
                        label2.Text = shab[1].ShablonClass;
                    if (shab[2] != null)
                        label3.Text = shab[2].ShablonClass;
                    if (shab[3] != null)
                        label4.Text = shab[3].ShablonClass;
                    if (shab[4] != null)
                        label5.Text = shab[4].ShablonClass;
                    if (shab[5] != null)
                        label6.Text = shab[5].ShablonClass;
                    if (shab[6] != null)
                        label17.Text = shab[6].ShablonClass;
                    if (shab[7] != null)
                        label18.Text = shab[7].ShablonClass;
                    SolidBrush br0 = new SolidBrush(col0);
                    SolidBrush br1 = new SolidBrush(col1);
                    SolidBrush br2 = new SolidBrush(col2);
                    SolidBrush br3 = new SolidBrush(col3);
                    SolidBrush br4 = new SolidBrush(col4);
                    SolidBrush br5 = new SolidBrush(col5);
                    SolidBrush br6 = new SolidBrush(col6);
                    SolidBrush br7 = new SolidBrush(col7);
                    if (shab[0] != null)
                        gr0.FillRectangle(br0, k * 5, n * 5, 5, 5);
                    if (shab[1] != null)
                        gr1.FillRectangle(br1, k * 5, n * 5, 5, 5);
                    if (shab[2] != null)
                        gr2.FillRectangle(br2, k * 5, n * 5, 5, 5);
                    if (shab[3] != null)
                        gr3.FillRectangle(br3, k * 5, n * 5, 5, 5);
                    if (shab[4] != null)
                        gr4.FillRectangle(br4, k * 5, n * 5, 5, 5);
                    if (shab[5] != null)
                        gr5.FillRectangle(br5, k * 5, n * 5, 5, 5);
                    if (shab[6] != null)
                        gr6.FillRectangle(br6, k * 5, n * 5, 5, 5);
                    if (shab[7] != null)
                        gr7.FillRectangle(br7, k * 5, n * 5, 5, 5);
                }
            }
        }
                
        private void StartCode_Click(object sender, EventArgs e)
        {
            #region Разбиение на классы
            TableUniteCode.RowCount = Codes.indCode - 2;
            for (int index = 0; index < Codes.indCode - 2; index++)
            {
                TableUniteCode.Rows[index].Cells[0].Value = Codes.indCode - index;
                TableUniteCode.Rows[index].Cells[1].Value = "";

                #region Вывод в таблицу классов 
                for (int i = 0; i < Codes.indCode; i++)
                {
                    if (codeObj[i] != null)
                    {
                        TableUniteCode.Rows[index].Cells[1].Value += "(" + codeObj[i].NameCode + ")";
                    }
                }

                int NumClass = 0;
                for (int i = 0; i < Codes.indCode - 2; i++)
                {
                    if (codeObj[i] != null)
                    {
                        Codes.F1Code[index] += codeObj[i].DifrentCode;
                        NumClass++;
                    }
                }
                TableUniteCode.Rows[index].Cells[2].Value = Math.Round((Codes.F1Code[index] / NumClass), 3); //получаемое значение F1
                #endregion 

                #region Составляем матрицу разности
                for (int i = 0; i < Codes.indCode; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (codeObj[i] != null && codeObj[j] != null && i != j)
                        {
                            double del = 0;
                            for (int k = 0; k < 8; k++)
                            {
                                del += Math.Abs(codeObj[i].Code[k] - codeObj[j].Code[k]);
                            }
                            Codes.DelCode[i, j] = del;
                            Codes.DelCode[j, i] = del;
                        }
                        else
                        {
                            Codes.DelCode[i, j] = -1;
                            Codes.DelCode[j, i] = -1;
                        }
                    }
                }
                #endregion

                #region Находим минимум
                double min = 500;
                int indI = 40;
                int indJ = 40;
                for (int i = 0; i < Codes.indCode; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if ((codeObj[i] != null) && (codeObj[j] != null) && (i != j) && (Codes.DelCode[i, j] != -1) && (Codes.DelCode[i, j] < min))
                        {
                            min = Codes.DelCode[i, j];
                            indI = i;
                            indJ = j;
                        }
                    }
                }
                #endregion

                #region Записываем новые матрицы ХЭ и байтов
                if (codeObj[indI] != null && codeObj[indJ] != null)
                {                    
                    codeObj[indI].DifrentCode = min;
                    codeObj[indI].NameCode = codeObj[indI].NameCode + "-" + codeObj[indJ].NameCode;

                    codeObj[indI].Code = lala(codeObj[indI].NameCode);
                    
                    //int[] mass = GetObjNum(codeObj[indI].NameCode);
                    //double[] mass1 = new double[8];
                    //for (int g = 0; g < mass.Length; g++)
                    //{
                    //    for (int k = 0; k < 8; k++)
                    //    {
                    //        mass1[k] += CharElemObjDB[mass[g]].CodeChElDB[k];
                    //    }
                    //}

                    //for (int k = 0; k < 8; k++)
                    //{
                    //    codeObj[indI].Code[k] = mass1[k] / mass.Length;
                    //}

                    codeObj[indJ] = null;
                }
                #endregion

                #endregion 
                int AAA = 0;
                for (int u = 0; u < Codes.indCode; u++)
                {
                    if (codeObj[u] != null)
                    {
                        AAA++;
                    }
                }
                if (AAA == 13)
                {
                    for (int u1 = 0; u1 < Codes.indCode; u1++)
                    {
                        if (codeObj[u1] != null)
                        {
                            shabcode[ShablonCode.indCode1] = new ShablonCode();

                            shabcode[ShablonCode.indCode1].Code1 = codeObj[u1].Code;
                            shabcode[ShablonCode.indCode1].NameCode1 = codeObj[u1].NameCode;
                            ShablonCode.indCode1++;
                        }
                    }
                }
            }
            
        }
        private void ButtonForShablonCode_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (shabcode[0] != null)
                    dataGridView1.Rows[0].Cells[i].Value = Math.Round(shabcode[0].Code1[i], 3);
                if (shabcode[1] != null)
                    dataGridView2.Rows[0].Cells[i].Value = Math.Round(shabcode[1].Code1[i], 3);
                if (shabcode[2] != null)
                    dataGridView3.Rows[0].Cells[i].Value = Math.Round(shabcode[2].Code1[i], 3);
                if (shabcode[3] != null)
                    dataGridView4.Rows[0].Cells[i].Value = Math.Round(shabcode[3].Code1[i], 3);
                if (shabcode[4] != null)
                    dataGridView5.Rows[0].Cells[i].Value = Math.Round(shabcode[4].Code1[i], 3);
                if (shabcode[5] != null)
                    dataGridView6.Rows[0].Cells[i].Value = Math.Round(shabcode[5].Code1[i], 3);
                if (shabcode[6] != null)
                    dataGridView7.Rows[0].Cells[i].Value = Math.Round(shabcode[6].Code1[i], 3);
                if (shabcode[7] != null)
                    dataGridView8.Rows[0].Cells[i].Value = Math.Round(shabcode[7].Code1[i], 3);
                if (shabcode[8] != null)
                    dataGridView9.Rows[0].Cells[i].Value = Math.Round(shabcode[8].Code1[i], 3);
                if (shabcode[9] != null)
                    dataGridView10.Rows[0].Cells[i].Value = Math.Round(shabcode[9].Code1[i], 3);
            }
            if (shabcode[0] != null)
                label7.Text = shabcode[0].NameCode1;
            if (shabcode[1] != null)
                label8.Text = shabcode[1].NameCode1;
            if (shabcode[2] != null)
                label9.Text = shabcode[2].NameCode1;
            if (shabcode[3] != null)
                label10.Text = shabcode[3].NameCode1;
            if (shabcode[4] != null)
                label11.Text = shabcode[4].NameCode1;
            if (shabcode[5] != null)
                label12.Text = shabcode[5].NameCode1;
            if (shabcode[6] != null)
                label13.Text = shabcode[6].NameCode1;
            if (shabcode[7] != null)
                label14.Text = shabcode[7].NameCode1;
            if (shabcode[8] != null)
                label15.Text = shabcode[8].NameCode1;
            if (shabcode[9] != null)
                label16.Text = shabcode[9].NameCode1;
        }        
    }
}
