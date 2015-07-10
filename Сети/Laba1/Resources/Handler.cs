using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1.Resources
{
    class Handler
    {
        List<int> numberOfHosts = new List<int>();
        IPv4 addressRange;

        public Handler()
        {

        }

        public void Add(int count)
        {
            this.numberOfHosts.Add(count);
        }

        public void SetAddressRange(string IP, string mask)
        {
            try
            {
                this.addressRange = new IPv4(IP, mask);
            } catch
            {
                this.addressRange = null;
                MessageBox.Show("Неправильный формат адресного диапозона!!!");
            }
            uint ip = (uint)this.addressRange.GetIPAddress();
            uint Mask = (uint)this.addressRange.GetIPAddress();
            uint checkValue = ip & Mask;
            if (checkValue != 0)
            {
                this.addressRange = null;
                MessageBox.Show("Данный адрес не может являтся адресом сети!!!");
            }
            
        } 

        public void MakeNetWork()
        {
            this.numberOfHosts.Sort();
            this.numberOfHosts.Reverse();
            int count = 0;
            for (int i = 0; i < this.numberOfHosts.Count; ++i)
            {
                count += getNextPower2(this.numberOfHosts[i]);

            }
            if (count > addressRange.GetNumberOfHosts())
            {
                MessageBox.Show("Слишком много хостов в сети для введенного адресного диапозона!!!");
                return;
            }
        }

        public void Clear()
        {
            this.addressRange = null;
            this.numberOfHosts = null;
        }

        public int getNextPower2(int value)
        {
            int answer = 0;
            value += 2;
            while ((1 << answer) < value) answer++;
            return 1 << answer;
        }
    }
}
