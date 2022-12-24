using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetShop.Model
{
    public class Folder : INode
    {
        public string Name { get; set; }
        public List<INode> nodes { get; set; }
    }
}
