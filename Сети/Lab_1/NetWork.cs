using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class NetWork
    {
        Dictionary<uint, SubNet> subNets = new Dictionary<uint, SubNet>();
        List<Router> routers = new List<Router>();

        public NetWork()
        {
            
        }

        public bool Check(uint addressRange, uint mask, List<int> hostsNumber)
        {
            uint count = 0;
            foreach (var item in hostsNumber)
            {
                count += (uint) 1 << NearPow2(item + 3);
            }
            uint maxValue = (~mask) + 1;
            if (maxValue < count) return false;
            return true;
        }

        public bool Build(uint addressRange, uint mask, List<int> hostsHumber)
        {
            if ((addressRange & mask) != addressRange) return false;
            bool ok = Check(addressRange, mask, hostsHumber);
            if (!ok) return false;
            List<int> revIndex = new List<int>(), used = new List<int>();
            for (int i = 0; i < hostsHumber.Count; i++)
            {
                revIndex.Add(i);
                used.Add(0);
            }
            for (int i = 0; i < hostsHumber.Count; ++i)
            {
                int index = -1;
                for (int j = 0; j < hostsHumber.Count; j++)
                {
                    if (used[j] == 1) continue;
                    if (used[j] == 0 && index == -1) index = j;
                    if (hostsHumber[j] > hostsHumber[index]) index = j;
                }
                used[index] = 1;
                revIndex[i] = index;
            }
            uint currentAdressRange = addressRange;
            for (int i = 0; i < revIndex.Count; ++i)
            {
                int item = hostsHumber[revIndex[i]];
                uint count = (uint)1 << NearPow2(item + 3);
                uint currentMask = ~(count - 1);
                this.subNets.Add(currentAdressRange, new SubNet(currentAdressRange, currentMask, (uint)item, "SubNet " + ((revIndex[i]) + 1)));
                currentAdressRange += count;
            }
            List<SubNet> subnets = new List<SubNet>();
            foreach (var item in this.subNets)
            {
                subnets.Add(item.Value);
            }
            this.routers.Add(new Router(subnets));
            return true;
        }

        public int NearPow2(int value)
        {
            int answer = 0;
            while (((uint) 1 << answer) < value) answer++;
            return answer;
        }

        public string ShowInfoAboutSubNets()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Сеть состоит из " + this.subNets.Count + " подсетей:\n\n\n");
            foreach (var item in subNets)
            {
                builder.Append(item.Value.GetInfo() + "\n\n");
            }
            return builder.ToString();
        }

        public void ShowRouterTable(int index)
        {
            
        }

        public Router GetRouter(int index)
        {
            return this.routers[index];
        }

        public int CountRouter
        {
            get { return this.routers.Count; }
            set { }
        }
    }
}
