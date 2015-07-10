using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Management;
namespace OOP_labx
{
    public partial class Form1 : Form
    {
        private Encryption encryption;
        private event EventHandler trustListChange;
        
        delegate void Update();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            byte[] key = new byte[] { 234, 31, 171, 226, 84, 49, 187, 207, 32, 22, 185, 136, 124, 140, 21, 9, 187, 102, 253, 47, 53, 137, 135, 83, 238, 171, 47, 155, 35, 189, 232, 39 };
            byte[] IV = new byte[] { 186, 240, 111, 137, 246, 117, 36, 141, 89, 205, 4, 148, 129, 94, 101, 157 };
            encryption = new Encryption(key, IV);
            ProcessHandler.EventCreater();
            ProcessHandler.eventStartWatcher.EventArrived += new EventArrivedEventHandler(NewProcess);
            ProcessHandler.eventEndWatcher.EventArrived += new EventArrivedEventHandler(EndProcess);
            trustListChange += AutoSave;
            AutoLoad(sender,e);
            UpdateLB();
          
        }

        private bool CheckTrustList(string name)
        {
            foreach (string item in lbTrustedProcesses.Items)
            {
                if (item == name) return true;
            }
            return false;
        }

        private void NewProcess(object obj, EventArrivedEventArgs e)
        {
            int processId = int.Parse(e.NewEvent.Properties["ProcessId"].Value.ToString());
            ProcessData process = ProcessHandler.GetData(processId);
            if (processId == 0 || CheckTrustList(process.Name) || process.Name == null)
            {
                //UpdateLB();
                return;
            }
            DialogResult result = MessageBox.Show("Do u want remove new process " + process.Name, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProcessHandler.KillProcess(process.Id);
                UpdateLB();
            }
            
        }

        private void EndProcess(object obj, EventArrivedEventArgs e)
        {
            UpdateLB();
        }

        private void bProcessList_Click(object sender, EventArgs e)
        {
            UpdateLB();
        }

        private void bAddToTrusted_Click(object sender, EventArgs e)
        {
            object processName = lbProcesses.SelectedItem;
            if (processName != null)
                lbTrustedProcesses.Items.Add(processName.ToString());
            //trustListChange(sender, e);            
        }

        private void AutoSave(object sender, EventArgs e)
        {
            string filePath = "C:\\trust.txt";
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (string value in lbTrustedProcesses.Items)
            {
                //streamWriter.WriteLine(ProcessHandler.ConvertDataToString(value));
                byte[] codedProcess = encryption.EncryptStringToBytes_Aes(ProcessHandler.ConvertDataToString(value));
                for (int i=0;i<codedProcess.Length;i++)
                {
                    string temp = Convert.ToString(codedProcess[i], 16);
                    if (temp.Length == 1) temp = "0" + temp;
                    streamWriter.Write(temp);
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }
        private void AutoLoad(object sender, EventArgs e)
        {
            string filePath = "C:\\trust.txt";
            StreamReader streamReader = new StreamReader(filePath);
            string inputStr;
            while (!streamReader.EndOfStream)
            {
                List<byte> lBytes = new List<byte>();
                string str = streamReader.ReadLine();
                for (int i = 0; i < str.Length - 1; i += 2)
                {
                    string temp = str[i].ToString() + str[i + 1].ToString();
                    lBytes.Add(Convert.ToByte(temp, 16));
                }
                byte[] tempBytes = lBytes.ToArray();
                string datastring = encryption.DecryptStringFromBytes_Aes(tempBytes);
                ProcessData processData = ProcessHandler.ConvertStringToData(datastring);
                lbTrustedProcesses.Items.Add(processData.Name);
            }
            streamReader.Close();
        }

        private void bKillProcess_Click(object sender, EventArgs e)
        {
            object processName = lbProcesses.SelectedItem;
            if (processName != null)
            {
                lbProcesses.Items.Remove(processName);
                ProcessHandler.KillProcess(ProcessHandler.GetData(processName.ToString()).Id);
            }
        }

        private void bRemoveFromTrustProcess_Click(object sender, EventArgs e)
        {
            object processName = lbTrustedProcesses.SelectedItem;
            if (processName !=null)
            lbTrustedProcesses.Items.Remove(processName);
            //trustListChange(sender, e);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessHandler.eventEndWatcher.Stop();
            ProcessHandler.eventStartWatcher.Stop();
            trustListChange(sender, e);
        }

        private void UpdateLB()
        {
            if (this.lbProcesses.InvokeRequired)
            {
                Update d = new Update(UpdateLB);
                this.Invoke(d);
            }
            else
            {
                List<ProcessData> processes = ProcessHandler.GetProcessList();
                lbProcesses.Items.Clear();
                foreach (ProcessData item in processes)
                {
                    lbProcesses.Items.Add(item.Name);
                }
            }
        }

        private void bAddToAutorun_Click(object sender, EventArgs e)
        {
            string path = Application.ExecutablePath;
            ProcessHandler.AddToAutorun(path);
        }

        private void bRemoveFromAutorun_Click(object sender, EventArgs e)
        {
            ProcessHandler.RemoveFromAutorun();
        }

    }
}
