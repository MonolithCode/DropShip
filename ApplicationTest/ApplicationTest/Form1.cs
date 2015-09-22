﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EbayModule;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Extensions;
using EbayModule.view;

namespace ApplicationTest
{
    public partial class Form1 : Form
    {
        public IEbayService Service;

        public Form1()
        {
            InitializeComponent();
            Service = new EbayService("Lunchbox-ba44-4393-a8b7-4d3e3e15af5b", "dc4ad018-7461-4a1b-bf30-aeeb02472561", "617cc402-f344-4014-a371-a38b35a2af39","AgAAAA**AQAAAA**aAAAAA**7iQxVA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhCZSEoQydj6x9nY+seQ**y+sBAA**AAMAAA**UWXWs911deeY+IEdv4CAIoibqS+dhtEQsp8s7vLI3mX0w7Jn3aVT8fp3puozeGIfUz9BHk2h02sfqsTq7JBRVyQDjB5hKiHB55JlE0I9nk448KB+NByG9o0jChcqTrcFx3v+klrWgNZTRkdD0H/XRXpNP7IfAI20EmjRiNs7Cp0ldJtKnSAXW0Q5VoQOTMjJipLggMeQ/5ZfXRR80IQmPy76wcgZazVzhQtehFA5WE5lU/2xslaKFIAzc2L57U5h9gIDuqPdMY946Vu4cHBAnmdJSDk6qJDctf+07AISHlltQ67eYqsV8AB00ZGZPSKbB2qlbWNKLsBcpATCXD8cBVy0C2Oqk9HjiIuTMsLfkXbnZGwfpqVpHIO1hwwKwndfOf8y9NRUgPuKnyRiAlp+xakL2G6zDX/ytfFzJklwUVlF6YwOofxnWJauOf9Jz0wircIJdh+Wjj7/uPRpyN9zsi3UhxRuqPaD5/31VFAtZ2PTkCHUoFVXI4xNX9HKVi+/1Plj6k2o0tXDOsFaVs157rDyX/EH3GSUU6BQ2ZNlF4PLT85BS/ZvWpqMRMqvEyuqlBAQiwhAgH1NVqvs3SE1UjhxVE3bJFE3cjpxJIuf6/8udkwb42J16A2OLNEZDaGkgZgkVr67k39+M7FmqZ61MaisKoUyHeBVOqL76idsN4jyZ0kcAOhIB5ljmT32Uoya08iWJF5gi92z0eR0pRGjEmANaR112BxewTcWg2TO1BpjIecT5O/o+ZX83+c2N74y",
                "Lunchboxcode-Lunchbox-ba44-4-bsyng", "AgAAAA**AQAAAA**aAAAAA**7iQxVA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhCZSEoQydj6x9nY+seQ**y+sBAA**AAMAAA**UWXWs911deeY+IEdv4CAIoibqS+dhtEQsp8s7vLI3mX0w7Jn3aVT8fp3puozeGIfUz9BHk2h02sfqsTq7JBRVyQDjB5hKiHB55JlE0I9nk448KB+NByG9o0jChcqTrcFx3v+klrWgNZTRkdD0H/XRXpNP7IfAI20EmjRiNs7Cp0ldJtKnSAXW0Q5VoQOTMjJipLggMeQ/5ZfXRR80IQmPy76wcgZazVzhQtehFA5WE5lU/2xslaKFIAzc2L57U5h9gIDuqPdMY946Vu4cHBAnmdJSDk6qJDctf+07AISHlltQ67eYqsV8AB00ZGZPSKbB2qlbWNKLsBcpATCXD8cBVy0C2Oqk9HjiIuTMsLfkXbnZGwfpqVpHIO1hwwKwndfOf8y9NRUgPuKnyRiAlp+xakL2G6zDX/ytfFzJklwUVlF6YwOofxnWJauOf9Jz0wircIJdh+Wjj7/uPRpyN9zsi3UhxRuqPaD5/31VFAtZ2PTkCHUoFVXI4xNX9HKVi+/1Plj6k2o0tXDOsFaVs157rDyX/EH3GSUU6BQ2ZNlF4PLT85BS/ZvWpqMRMqvEyuqlBAQiwhAgH1NVqvs3SE1UjhxVE3bJFE3cjpxJIuf6/8udkwb42J16A2OLNEZDaGkgZgkVr67k39+M7FmqZ61MaisKoUyHeBVOqL76idsN4jyZ0kcAOhIB5ljmT32Uoya08iWJF5gi92z0eR0pRGjEmANaR112BxewTcWg2TO1BpjIecT5O/o+ZX83+c2N74y", Modes.Sandbox, SiteCodeType.UK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] mews = new string[1];
            mews[0] = @"C:\Users\Aaron\Downloads\WIN_20150618_192413.JPG";
            Service.Sales.ProductManagement.ImageManager.UpLoadPictureFile(PhotoDisplayCodeType.CustomCode, @"C:\Users\Aaron\Downloads\WIN_20150618_192413.JPG");
            Service.Sales.GetMyEbayListings(OrderStatusFilterCodeType.All);
        }
    }
}
