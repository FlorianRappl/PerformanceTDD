using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace Performance
{
    public partial class ItemView : Form
    {
        Byte[] myData;

        //Any cache without a discard policy is a memory leak
        static Dictionary<String, Int32[]> myCache;
        static Random ran;

        static ItemView()
        {
            myCache = new Dictionary<String, Int32[]>();
            ran = new Random();
        }

        public ItemView()
        {
            InitializeComponent();
            myData = new Byte[5000000];

            for (var i = 0; i < myData.Length; i++)
                myData[i] = (Byte)ran.Next(0, 256);

            AddToCache(DateTime.Now.Second.ToString("00"));
        }

        static void AddToCache(String parameter)
        {
            myCache[parameter] = new Int32[1000000];
        }
    }
}
