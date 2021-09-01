using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agayanolja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


        private void button16_Click(object sender, EventArgs e) //입력버튼
        {

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            int[] randnum = new int[10];
            Random rand = new Random();

            double result = 0;
            int cnt = 0;
            int success = 10;

            String[] symbol = { "+", "-", "*", "/" };


            while (success > 0)
            {
                for (int i = 0; i < randnum.Length; i++)
                {
                    randnum[i] = rand.Next(0, 100);

                }
                int intoRandA = rand.Next(10);

                int intoRandB = rand.Next(10);
                /*for (int i = 0; i < 10; i++)
                {
                    intoRandA = rand.Next(0, 10);
                    intoRandB = rand.Next(0, 10);
                }*/
                int symbolRand = rand.Next(4);


                String user_value = textBox1.Text;

                switch (symbolRand)
                {

                    case 0:
                        label1.Text = randnum[intoRandA].ToString() + "+" + randnum[intoRandB].ToString();
                        result = randnum[intoRandA] + randnum[intoRandB];

                        if (user_value.Equals(textBox1.Text))
                        {
                            textBox3.Text = "success!";
                            success--;
                            cnt++;
                        }
                        else
                        {
                            textBox1.Text = null;
                            textBox3.Text = "Try again";
                            cnt++;
                        }
                        break;
                    case 1:

                        if (randnum[intoRandA] < randnum[intoRandB])
                        {
                            int temp = randnum[intoRandA];
                            randnum[intoRandA] = randnum[intoRandB];
                            randnum[intoRandB] = temp;
                        }
                        else
                        {
                            label1.Text = randnum[intoRandA].ToString() + "-" + randnum[intoRandB].ToString();
                            result = randnum[intoRandA] - randnum[intoRandB];


                            if (user_value.Equals(textBox1.Text))
                            {
                                textBox3.Text = "success!";
                                success--;
                                cnt++;
                            }
                            else
                            {
                                textBox1.Text = null;
                                textBox3.Text = "Try again";
                                cnt++;
                            }

                        }
                        break;


                    case 2:
                        if (randnum[intoRandA] >= 10  || randnum[intoRandB] >= 10)
                        {
                            for (int i = 0; i > 10; i++)
                            {
                                randnum[i] = rand.Next(0, 10);

                            }
                            label1.Text = randnum[intoRandA].ToString() + "*" + randnum[intoRandB].ToString();
                            result = randnum[intoRandA] * randnum[intoRandB];

                        }
                        else
                        {
                            label1.Text = randnum[intoRandA].ToString() + "*" + randnum[intoRandB].ToString();
                            result = randnum[intoRandA] * randnum[intoRandB];

                            if (user_value.Equals(textBox1.Text))
                            {
                                textBox3.Text = "success!";
                                success--;
                                cnt++;
                            }
                            else
                            {
                                textBox1.Text = null;
                                textBox3.Text = "Try again";
                                cnt++;
                            }
                        }
                        break;
                    case 3:
                        //1. randnum[intorandB]가 0이라면 intorandB 랜덤값 다시 추출
                        //2. randnum[intorandA]<randnum[intorandB] => 둘의 위치 바꿔주기
                        //3. result의 값이 소수점 둘째자리가 넘어간다면 둘째자리까지 끊어주기
                        if (randnum[intoRandB] == 0)
                        {
                            randnum[intoRandB] = rand.Next(10);
                            
                        }
                        else
                        {
                            if (randnum[intoRandA] < randnum[intoRandB])
                            {
                                int temp = randnum[intoRandA];
                                randnum[intoRandA] = randnum[intoRandB];
                                randnum[intoRandB] = temp;
                                label1.Text = randnum[intoRandA].ToString() + "/" + randnum[intoRandB].ToString();
                                result = randnum[intoRandA] * randnum[intoRandB];
                                result = Math.Truncate(result * 100) / 100;

                            }
                            else
                            {
                                label1.Text = randnum[intoRandA].ToString() + "/" + randnum[intoRandB].ToString();
                                result = randnum[intoRandA] * randnum[intoRandB];
                                result = Math.Truncate(result * 100) / 100;

                            }
                        }
                        break;
                }
            }
        }


       

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void enter_btn_Click(object sender, EventArgs e)
        {

        }
    }

}

