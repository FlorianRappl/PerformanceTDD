using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
    public class RestService : IRestService
    {
        public MyData XMLData(String id)
        {
            return new MyData { Text = "Returning XML-Data for ID " + id, Id = Int32.Parse(id) };
        }

        public MyData JSONData(String id)
        {
            return new MyData { Text = "Returning JSON-Data for ID " + id, Id = Int32.Parse(id) };
        }
    }
}
