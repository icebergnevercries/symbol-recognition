using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRO_Lab3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class CharElemTemp
    {
        public double[,] MatrChEl = new double[5, 5];
        public double[,] MatrByteChEl = new double[5, 5];
        public int IforChEl;
        public int JforChEl;
        public string NameSym = " ";
        public string NameClass = " ";

        public static int index = 0;

        public double Difrent = 0;

        public static double[,] MatrDel = new double[50, 50];
        public static double[] FunctionF1 = new double[50];
    }

    public class CharElemTempDB
    {
        public double[,] MatrChElDB = new double[5, 5];
        public double[,] MatrByteChElDB = new double[5, 5];
        public int IforChElDB;
        public int JforChElDB;
        public int[] CodeChElDB = new int[8];
        public string NameSymDB = " ";
        public string NameClassDB = " ";

        public static int indexDB = 0;
    }

    public class Shablon
    {
        public double[,] MatrCE1 = new double[5, 5];
        public double[,] MatrByte1 = new double[5, 5];
        public string ShablonClass = "";

        public static int ind = 0;
    }
    
    public class Codes
    {
        public double[] Code = new double[8];
        public string NameCode = "";
        public double DifrentCode = 0;

        public static double[,] DelCode = new double[50, 50];
        public static double[] F1Code = new double[50];
        public static int indCode = 0;
    }
    public class CodesDB
    {
        public double[] CodeDB = new double[8];
        
        public static int indCodeDB = 0;
    }
    public class ShablonCode
    {
        public double[] Code1 = new double[8];
        public string NameCode1 = "";

        public static int indCode1 = 0;
    }
}
