using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agayanolja
{
    public partial class Form1 : Form
    {
        clsConnet_Client clsConnetClient = new clsConnet_Client();
        StreamWriter sw; 

        int[] randnum = new int[10];
        Random rand = new Random();
        
        String[] symbol = { "+", "-", "*", "/" };

        private bool bTimerFlag = false;

        private bool bGameSatatFlag = false;

        private bool TimerFlag = false;
        private double result = 0; //정답
        private double user_result = 0; //사용자입력
        private int Success = 10; //정답수
        private int cnt = 0; //문제시도횟수
        private bool NextQuizFlag = false; //문제출력
        private bool GameStart = false;
        private bool pass = false;

        bool bConnetSucessFlag = false;


        private const int BTN_FALG_INIT = 0; //초기상태
        private const int BTN_FLAG_START = 1; //시작버튼 
        private const int BTN_FLAG_NEXT_QUIZ = 2; //시작버튼 
        private const int BTN_FLAG_INPUT = 3; //정답입력
        private const int BTN_FLAG_RESULT = 4; //정답확인
        private const int BTN_FLAG_MEMORY = 5; //정답확인
        private const int BTN_FLAG_CLOSE = 6; //종료


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process(BTN_FALG_INIT);
            Prog_Init();

            clsConnetClient.Connet();
        }
        private void Prog_Init()
        {
            GameStart = false; //시작버튼 비활성
            NextQuizFlag = false;
            pass = false;

            timer1.Enabled = true;
            TimerFlag = false;
            timer1.Interval = 1000;

            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Success;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            //프로그래스바에 1/10~10/10 나타내기
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void point_btn_click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false)
                textBox1.Text += ".";
            else
                textBox1.Text += "0.";

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_btn_Click(object sender, EventArgs e)
        {

            Process(BTN_FLAG_START);
            Process(BTN_FLAG_NEXT_QUIZ);

        }
        private void Input_Click(object sender, EventArgs e)
        {
            Process(BTN_FLAG_INPUT);
            Process(BTN_FLAG_RESULT);
            if(Success != 0)
            {
                Process(BTN_FLAG_NEXT_QUIZ);
            }
            else
            {               
                Btn_Enable(false);
                label1.Text = "";
                textBox1.Text = "";
                result_box.Text = "";
               
            }
        }

        void Btn_Enable(bool bFlag)
        {
            start_btn.Enabled = !bFlag;
            input_btn.Enabled = bFlag;
            result_check_btn.Enabled = !bFlag;

            button0.Enabled = bFlag;
            button1.Enabled = bFlag;
            button2.Enabled = bFlag;
            button3.Enabled = bFlag;
            button4.Enabled = bFlag;
            button5.Enabled = bFlag;
            button6.Enabled = bFlag;
            button7.Enabled = bFlag;
            button8.Enabled = bFlag;
            button9.Enabled = bFlag;
            point_btn.Enabled = bFlag;
            delete.Enabled = bFlag;
        }

        void Process(int nStateFlag)
        {
            switch(nStateFlag)
            {
                case BTN_FALG_INIT:
                    Btn_Enable(false);
                    result_check_btn.Enabled = false;

                    break;
                case BTN_FLAG_START:
                    Btn_Enable(true);
                    Success = 10;

                    break;
                case BTN_FLAG_NEXT_QUIZ:
                    Success--;
                    
                    textBox1.Text = "";
                    NextQuiz();
                    break;
                case BTN_FLAG_INPUT:
                    if (textBox1.Text != "")
                    {
                        user_result = Convert.ToDouble(textBox1.Text);
                    }

                    progressBar1.PerformStep();
                    break;
                case BTN_FLAG_RESULT:
                    ResultQuiz(intoRandA, intoRandB, symbolRand);
                    break;
                    

            }
        }
        

        private void result_check_btn_Click(object sender, EventArgs e)
        {
            string strRstValue;

            int cnt_Pst = cnt * 10;
            string date = DateTime.Now.ToString();

            strRstValue = date + "/" + "정답률 " + cnt_Pst.ToString() + "%";
            clsConnetClient.Send(strRstValue);
            
            sw = File.CreateText(date + (".txt"));
            sw.WriteLine(strRstValue);
            sw.Flush();
          
            


            MessageBox.Show( " 정답률 =>" + cnt_Pst + "%");
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //Proc_Flow(BTN_FLAG_CLOSE);
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_label.Text = DateTime.Now.ToString();

            
        }
        double intoRandA = 0;
        double intoRandB = 0;
        double symbolRand = 0;

        private void NextQuiz()
        {
            intoRandA = rand.Next(10);
            Thread.Sleep(5);
            intoRandB = rand.Next(10); 
            Thread.Sleep(5);
            symbolRand = rand.Next(4); //symbol[]의 배열 랜덤부여
            Thread.Sleep(5);

            switch(symbolRand)
            {
                case 0:
                    label1.Text = intoRandA.ToString() + "+" + intoRandB.ToString();

                    break;
                case 1:
                    if (intoRandA < intoRandB)
                    {
                        double temp;
                        temp = intoRandA;
                        intoRandA = intoRandB;
                        intoRandB = temp;
                    }

                    label1.Text = intoRandA.ToString() + "-" + intoRandB.ToString();

                    break;
                case 2:
                    label1.Text = intoRandA.ToString() + "*" + intoRandB.ToString();

                    break;
                case 3:
                    if (intoRandB == 0 || intoRandA ==0)
                    {
                        intoRandA = rand.Next(1, 10);
                        intoRandB = rand.Next(1,10);
                    }


                    if (intoRandA < intoRandB)
                    {
                        double temp;
                        temp = intoRandA;
                        intoRandA = intoRandB;
                        intoRandB = temp;
                    }

                   
                    label1.Text = intoRandA.ToString() + "/" + intoRandB.ToString();

                    break;

            }
            
            

         }

        void ResultQuiz(double dNum1, double dNum2, double dSymbol)
        {
            

            switch (dSymbol)
            {

                case 0:
                    result = dNum1 + dNum2;
                    if (user_result == result)
                    {
                        
                        cnt++;
                        result_box.Text = "SUCCESS!";
                    }
                    else
                    {
                       
                        result_box.Text = "Fail";
                    }

                   
                    break;
                case 1:
                    
                    result = dNum1 - dNum2;
                    if (user_result == result)
                    {
                       
                        cnt++;
                        result_box.Text = "SUCCESS!";
                    }
                    else
                    {
                        
                        result_box.Text = "Fail";
                    }

                    break;
                case 2:

                    
                    result = dNum1 * dNum2;
                    if (user_result == result)
                    {
                        
                        cnt++;
                        result_box.Text = "SUCCESS!";
                    }
                    else
                    {
                        
                        result_box.Text = "Fail";
                    }
                    break;
                case 3:
                    //1. randnum[intorandB]가 0이라면 intorandB 랜덤값 다시 추출
                    //2. randnum[intorandA]<randnum[intorandB] => 둘의 위치 바꿔주기
                    //3. result의 값이 소수점은 첫째자리까지만

                    
                    result = dNum1 / dNum2;
                    result = (double)(Math.Truncate(result * 10) / 10);


                    if (user_result == result)
                    {
                    
                        cnt++;
                        result_box.Text = "SUCCESS!";
                    }
                    else 
                    {
                      
                        result_box.Text = "Fail";
                    }

                    break;
            }
        }

     
    }
      
    
       
}
     


    internal class Form_Result
    {
    }

