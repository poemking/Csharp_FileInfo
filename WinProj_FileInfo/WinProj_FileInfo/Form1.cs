using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinProj_FileInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] str = { 72, 69, 76, 76, 79 }; //ASCII code
            FileStream fs = File.Create("textFiles.txt");
            fs.Write(str, 0, str.Length);
            fs.Close();
            //會產生一個.txt在debug內
            MessageBox.Show("File Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Copy("textFiles.txt", "newFiles.txt");
            if (File.Exists("newFiles.txt"))
                MessageBox.Show("newFiles.txt exists");
            else
                MessageBox.Show("newFiles.txt not exists");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("newFiles.txt"))
                MessageBox.Show("newFiles.txt exists");
            else
                MessageBox.Show("newFiles.txt not exists");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete("newFiles.txt");
            if (File.Exists("newFiles.txt"))
                MessageBox.Show("newFiles.txt exists");
            else
                MessageBox.Show("newFiles.txt not exists");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("textFiles.txt");
            FileStream fs = file.Open(FileMode.Open);
            byte[] str;
            str = new byte[file.Length];
            int count = Convert.ToInt32(file.Length);
            fs.Read(str, 0, count);
            foreach (char x in str) 
            Console.WriteLine("{0}", x);
            fs.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("newtxtFile.txt");
            FileStream fs = file.Create();
            byte[] str = { 72, 69, 76, 76, 79 };
            fs.Write(str, 0, str.Length);
            fs.Close();

            file.CopyTo("CopynewtxtFile.txt", true);
            MessageBox.Show("file copy");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("CopynewtxtFile.txt");
            file.Delete();
            if (File.Exists("CopynewtxtFile.txt"))
                MessageBox.Show("檔案存在");
            else
                MessageBox.Show("檔案不存在");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("newtxtFile.txt");
            MessageBox.Show("Length: " + file.Length);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string filePath = "myFile1.txt";
            string[] fileLines = { "Line 1", "Line 2", "Line 3" };

            File.WriteAllLines(filePath, fileLines); //寫入所有列到新檔案.

            filePath = "myFile2.txt";
            string fileContents = "I am writing this text to a file";//寫入所有文字到新檔案中.
            File.WriteAllText(filePath, fileContents);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string filePath = "myFile1.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string str in lines)
                Console.WriteLine(str);
            string strData = File.ReadAllText(filePath);
            textBox1.Text = strData;
        }
    }
}
