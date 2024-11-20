using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadPriorityApp
{
    public partial class frmTrackThread : Form
    {
        public frmTrackThread()
        {
            InitializeComponent();
        }

        public static void Thread1()
        {
            for (int i = 0; i <= 2; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name + " Process "+ " = " + i);
                Thread.Sleep(500); 
            }
        }
        public static void Thread2()
        {
            for (int i = 0; i <= 5; i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine("Name of Thread: " + thread.Name +  " Process "+ " = " + i);
                Thread.Sleep(1500); 
            }
        }
        private async void btnStart_Click(object sender, EventArgs e)
        {
           
            UpdateLabel("Threads Running...");

            
            await Task.Run(() =>
            {
                Thread threadA = new Thread(Thread1)
                {
                    Name = "Thread A",
                    Priority = ThreadPriority.Highest
                };
                Thread threadB = new Thread(Thread2)
                {
                    Name = "Thread B",
                    Priority = ThreadPriority.Normal
                };
                Thread threadC = new Thread(Thread1)
                {
                    Name = "Thread C",
                    Priority = ThreadPriority.AboveNormal
                };
                Thread threadD = new Thread(Thread2)
                {
                    Name = "Thread D",
                    Priority = ThreadPriority.BelowNormal
                };

                
                Console.WriteLine(" -Thread Starts- ");
                threadA.Start();
                threadB.Start();
                threadC.Start();
                threadD.Start();

               
                threadA.Join();
                threadB.Join();
                threadC.Join();
                threadD.Join();
                Console.WriteLine(" -End of Thread- ");
            });

            
            UpdateLabel("-Thread End-");
        }

       
        private void UpdateLabel(string message)
        {
            
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    Label lblMessage = Controls["lblMessage"] as Label;
                    if (lblMessage != null)
                    {
                        lblMessage.Text = message;
                    }
                }));
            }
            else
            {
                Label lblMessage = Controls["lblMessage"] as Label;
                if (lblMessage != null)
                {
                    lblMessage.Text = message;
                }
            }
        }

    }
}





       