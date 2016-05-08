using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FailoverCompare
{
    internal class PageScrapper
    {

        private PageScrapper()
        { }

        private PageScrapper _instance;
        public PageScrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PageScrapper();
                }

                return _instance;
            }
        }

    }
}
