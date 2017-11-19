using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string group_name;
        private string group_header;
        private string group_footer;

        public GroupData(string group_name, string group_header, string group_footer)
        {
            this.Group_name = group_name;
            this.Group_header = group_header;
            this.Group_footer = group_footer;
        }

        public string Group_name { get => group_name; set => group_name = value; }
        public string Group_header { get => group_header; set => group_header = value; }
        public string Group_footer { get => group_footer; set => group_footer = value; }
    }
}
