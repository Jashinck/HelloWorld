using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileStreamDev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\DevCode";
            ofd.Title = "Please Chose File";
            ofd.Filter = "TextFile|*.txt|All File|*.*";
            ofd.ShowDialog();

            if(ofd.FileName=="Null")
            {
                return;
            }
            else
            {
                txtSource.Text = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\DevCode";
            sfd.Title = "Please Chose FileIndex";
            sfd.Filter = "TextFile|*.txt|All File|*.*";
            sfd.ShowDialog();
            
            if(sfd.FileName=="Null")
            {
                return;
            }
            else
            {
                txtTarget.Text = sfd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fsRead = new FileStream(txtSource.Text, FileMode.Open, FileAccess.Read))
            {
                //获得当前读取的文件的总字节长度
                // MessageBox.Show(fsRead.Length.ToString());

                //设置进度条的最大值
                progressBar1.Maximum = (int)fsRead.Length;

                //创建负责写入的流
                using (FileStream fsWrite = new FileStream(txtTarget.Text, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    //创建缓冲区
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    //通过循环不停的读取和写入
                    while (true)
                    {
                        //本次读取实际读取到的有效字节数
                        int r = fsRead.Read(buffer, 0, buffer.Length);
                        //读完了

                        if (r <= 0)
                        {
                            break;
                        }
                        //读一次 写一次
                        fsWrite.Write(buffer, 0, r);
                        progressBar1.Value += r;// (int)fsWrite.Length;

                    }
                }
                MessageBox.Show("复制成功!!!");
            }
        }
    }
}
