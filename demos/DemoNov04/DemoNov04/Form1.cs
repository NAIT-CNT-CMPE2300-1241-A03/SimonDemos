//Dictionary Demo
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace DemoNov04
{
    public partial class Form1 : Form
    {
        Dictionary<Point, int> _dic = new Dictionary<Point, int>();
        CDrawer _drawer = new CDrawer();
        
        public Form1()
        {
            InitializeComponent();
            _drawer.Scale = 100;
            _drawer.MouseMoveScaled += _drawer_MouseMoveScaled;
        }

        private void _drawer_MouseMoveScaled(Point pos, CDrawer dr)
        {
            if (_dic.ContainsKey(pos))
                _dic[pos]++;
            else
                _dic.Add(pos, 1);
            //_dic[pos] = 1;
            Render();
        }
        private void Render()
        {
            _drawer.Clear();
            foreach(KeyValuePair<Point,int> kvp in _dic)
            {
                _drawer.AddRectangle(kvp.Key.X, kvp.Key.Y, 1, 1, RandColor.GetColor());
                _drawer.AddText($"{kvp.Value}", 20, kvp.Key.X, kvp.Key.Y, 1, 1, Color.Black);
            }
        }
    }
}
