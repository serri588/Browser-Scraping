﻿using Parser;
using Autofac;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Core.Entities;

namespace Manager
{
    public class ApplicationManager
    {
        private Parse parser { get; set; }

        private List<JobList> JobList { get; set; }

        public Parser.WebPage ReceiveWebPage(WebBrowser webBrowser)
        {
            this.parser =  new Parse(webBrowser);

            return parser.WebPage;
        }

        public async Task<int> NewIgnoreListItem(string item)
        {
            return await parser.NewIgnoreListItem(item);
        }

    }
}