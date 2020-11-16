using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NPOI.Util;

namespace WF_CloudClient
{
    public partial class Form1 : Form
    {
        // 업로드 파일 경로
        String file_path = null;
        // 서버에 접속한다.
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.137.38"), 3333);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 업로드할 파일 선택
        private void File_Select(object sender, EventArgs e)
        {
            File_Address.Clear();
            openFileDialog1.InitialDirectory = "C:\\";
            //openFileDialog의 시작 위치를 C:\\로 설정
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;
                // 선택된 파일의 풀 경로를 불러와 저장
                File_Address.Text = file_path.Split('\\')[file_path.Split('\\').Length - 1];
                // 해당 경로에서 파일명만 추출하여 textBox에 표시
            }
        }


        // 업로드 버튼으로 업로드
        private void File_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                // FileInfo 생성
                FileInfo file = new FileInfo(file_path);
                // 파일이 존재하는지
                if (file.Exists)
                {
                    // 바이너리 버퍼
                    var binary = new byte[file.Length];
                    // 파일 IO 생성
                    using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                    {
                        // 소켓 생성
                        using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                        {
                            // 접속
                            client.Connect(ipep);

                            // 파일을 IO로 읽어온다.
                            stream.Read(binary, 0, binary.Length);

                            byte[] bytes = new byte[2];

                            client.Send(Encoding.UTF8.GetBytes("upload"));


                            client.Receive(bytes);
                            client.Send(Encoding.UTF8.GetBytes(binary.Length.ToString()));

                            client.Receive(bytes);
                            client.Send(Encoding.UTF8.GetBytes(file.Name));

                            client.Receive(bytes);
                            client.Send(binary);



                        }
                    }
                    File_load();
                }
                else
                {
                    MessageBox.Show("파일이 존재하지 않습니다.");
                    //Console.WriteLine("파일이 존재하지 않습니다.");
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("파일을 선택해 주세요.");
                //Console.WriteLine("파일을 선택해 주세요.");
            }
            catch(SocketException)
            {
                MessageBox.Show("서버와 연결되지 않았습니다.");
            }

        }


        // 파일 로드
        private void File_load_Click(object sender, EventArgs e)
        {
            File_load();
        }

        private void File_load()
        {
            try
            {
                // 소켓 생성
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // 접속
                    socket.Connect(ipep);
                    byte[] data = new byte[100];
                    // 파일을 IO로 읽어온다.
                    //stream.Read(binary, 0, binary.Length);
                    socket.Send(Encoding.UTF8.GetBytes("list"));

                    socket.Receive(data);

                    //리스트 초기화
                    listBox1.Items.Clear();

                    int list_size = BitConverter.ToInt32(data, 0) - 48;

                    socket.Send(Encoding.UTF8.GetBytes("ok"));

                    Console.WriteLine("Recieved file_count: " + list_size);

                    for (int j = 0; j < list_size; j++)
                    {
                        int size = socket.Receive(data);
                        string title = string.Empty;
                        for (int i = 0; i < size; i++)
                            title += Convert.ToChar(data[i]);
                        socket.Send(Encoding.UTF8.GetBytes("ok"));
                        listBox1.Items.Add(title);
                        Console.WriteLine("Recieved data: " + title + "\n" + title.Length);
                    }


                }

            }
            catch (SocketException)
            {
                MessageBox.Show("서버와 연결되지 않았습니다.");
                //Console.WriteLine("파일을 선택해 주세요.");
            }
            
        }

        // 파일 삭제
        private void File_delete(object sender, EventArgs e)
        {
            try
            {

                // 소켓 생성
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // 접속
                    socket.Connect(ipep);

                    socket.Send(Encoding.UTF8.GetBytes("delete"));
                    string file_name = "file";
                    byte[] data = new byte[100];
                    socket.Receive(data);
                    if (listBox1.SelectedItem != null)
                    {
                        file_name = listBox1.SelectedItem.ToString();
                    }
                    else
                    {
                        MessageBox.Show("리스트에서 파일을 선택해 주세요.");
                    }

                    socket.Send(Encoding.UTF8.GetBytes(file_name));

                    // 다시 한번 로드
                    File_load();
                }

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("파일을 선택해 주세요.");
                //Console.WriteLine("파일을 선택해 주세요.");
            }
            catch (SocketException)
            {
                MessageBox.Show("서버와 연결되지 않았습니다.");
                //Console.WriteLine("파일을 선택해 주세요.");
            }
        }

        // 파일 다운로드
        private void btn_download_Click(object sender, EventArgs e)
        {
            // 다운받을 파일의 이름
            string file_name = "file";
            // 파일 다운로드 경로
            string file_download_path = "";

            // 파일 경로 열기
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                file_download_path = fbd.SelectedPath;

            }

            try
            {
                // 소켓 생성
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // 접속
                    socket.Connect(ipep);

                    socket.Send(Encoding.UTF8.GetBytes("download"));
                    byte[] size_size = new byte[100];

                    // ok 받기
                    socket.Receive(size_size);


                    if (listBox1.SelectedItem != null)
                    {
                        // 파일 이름 가져오기
                        file_name = listBox1.SelectedItem.ToString();
                        // 파일 이름 보내기
                        socket.Send(Encoding.UTF8.GetBytes(file_name));

                        // 파일 사이즈 받기
                        int size = socket.Receive(size_size);
                        string contents = string.Empty;
                        // 숫자로 바꿀때 아스키코드로 와서 48을 빼줌
                        for (int i = 0; i < size; i++)
                        {
                            int a = Convert.ToInt32(size_size[i])-48;
                            contents += (a.ToString());
                        }

                        Console.WriteLine("contents : " + contents);

                        //byte[] data = new byte[Int32.Parse(contents)];
                        byte[] data = new byte[1460];
                        // ok 보내기
                        socket.Send(Encoding.UTF8.GetBytes("ok"));

                        byte[] c;
                        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
                        // file 내용 while
                        while (true)
                        {
                            socket.Receive(data);

                            outputStream.Write(data);

                            c = outputStream.ToByteArray();

                            Console.WriteLine("part len : " + data.Length);
                            
                            if (c.Length >= Int32.Parse(contents))
                            {
                                
                                Console.WriteLine("filedata len : " + c.Length);
                                break;
                            }
                        }

                        

                        FileStream fs = new FileStream(@file_download_path + "\\" + file_name, FileMode.OpenOrCreate, FileAccess.Write);

                        fs.Write(c, 0, Int32.Parse(contents));
                        fs.Close();

                    }
                    else
                    {
                        MessageBox.Show("리스트에서 파일을 선택해 주세요.");
                    }
                }

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("파일을 선택해 주세요.");
            }
            catch (SocketException)
            {
                MessageBox.Show("서버와 연결되지 않았습니다.");
                //Console.WriteLine("파일을 선택해 주세요.");
            }
        }

        
    }
}
