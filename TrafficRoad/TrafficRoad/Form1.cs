using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficRoad
{
    public partial class Form1 : Form

    {
        Timer time = new Timer();
        const int DIR_EST = 0;
        const int DIR_WES = 0;
        const int DIR_SOU = 0;
        const int DIR_NOR = 0;

        const int LIGHT_RED = 101;
        const int LIGHT_YELLOW = 102;
        const int LIGHT_GREEN = 103;

        const int DIR_CNT_CROSS_ROAD = 4;

        const int DIR_VERTICAL = 0;
        const int DIR_HORIZON = 1;

        int[] dirStreet;
        int[] cntCar;
        int dirCrossRoad;
        int rstTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitParam();
            dirCrossRoad = Dir_CrossRoad(DIR_VERTICAL);
            
        }
        private void InitParam() {

            dirStreet = new int[DIR_CNT_CROSS_ROAD];
            cntCar = new int[DIR_CNT_CROSS_ROAD];
        }
        int Dir_CrossRoad(int NFlag)
        //방향
        
        {
            int nRet = DIR_VERTICAL;
            return nRet;
        }
        int rk_ResultValue(int[] cmpValue, int cmpCnt, int nFlag)
        {
            double dRet = 0;
            if (cmpValue.Length != cmpCnt)
            {
                return 0;
            }
            else
            {
                Array.Sort(cmpValue); //
                switch (nFlag)
                {
                    case 0: // return Min Value
                        dRet = cmpValue[0];
                        break;
                    case 1: // return Max Value
                        dRet = cmpValue[cmpCnt - 1];
                        break;
                    case 2: // return Sum Value
                        for (int nFori = 0; nFori < cmpCnt; nFori++){
                            dRet += cmpValue[nFori];
                        }

                        break;
                    case 3: // return Average Value
                        for (int nFori = 0; nFori < cmpCnt; nFori++)
                        {
                            dRet += cmpValue[nFori];
                        }
                        dRet /= cmpCnt;
                        break;
                    case 4: // return Average Value for exception Min and Max
                        for (int nFori = 0; nFori < cmpCnt; nFori++)
                        {
                            dRet += cmpValue[nFori];
                        }
                        dRet /= cmpCnt -2 ;
                        break;
                    case 5: // return 표준편차 Value
                        break;
                    case 6: // return 중간값 Value
                        break;
                }
            }

            return (int)dRet;
        }
    }
}
