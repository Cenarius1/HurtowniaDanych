using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaDanych
{
    public class DataWarehouseManager
    {
        public List<string> LinkList;
        public void Launch()
        {
            ManageLinks();
            ManageLinks();
            ManageDB();
        }

        private void ManageLinks()
        {
            SearchCarLinkHandler searchCarLinkHandler = new SearchCarLinkHandler();
            LinkList = searchCarLinkHandler.GetLinks();
        }

        private void ManageParse()
        {

        }

        private void ManageDB()
        {

        }
    }
}
