using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapABC
{
    class TreeNode
    {
        
        
            public Point Data { get; set; }
            public int Link { get; set; }
            public int Size { get; set; }
            public TreeNode Parent1 { get; set; }
            public TreeNode Parent2 { get; set; }
            public List<TreeNode> Children { get; set; }

            public int Door { get; set; }




        


    }




}
