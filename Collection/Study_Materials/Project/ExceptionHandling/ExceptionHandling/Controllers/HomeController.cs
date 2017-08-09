using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ExceptionHandling.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            TestMethod();
            string test = string.Empty;
            try
            {
                Test();
            }
            catch (Exception e)
            {
                var tes = test[2];
            }

            return View();
        }

        public void Test()
        {
            throw new Exception();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void TestMethod()
        {
            HtmlTable htmltable = new HtmlTable();
            HtmlTableRow row = null;
            HtmlTableCell cell = null;
            var text = "2 BMW, BMW (00:08-00:09)";
            var subcount = 4;//dynamically change
            var listcount = 3;//dynamically change
            for (int i = 0; i < listcount; i++)
            {
                if (htmltable.Rows.Count == 0)
                {
                    //unit row creation
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell() { InnerHtml = text + i.ToString() };
                    row.Cells.Add(cell);
                    htmltable.Rows.Add(row);
                }
                else
                {
                    cell = new HtmlTableCell() { InnerHtml = "U" + i.ToString() };
                    htmltable.Rows[0].Cells.Add(cell);
                }

                //check rows count will less or greater
                if (htmltable.Rows.Count - 1 >= subcount)
                {
                    //add cell only
                    for (int k = 1; k <= subcount; k++)
                    {
                        cell = new HtmlTableCell();
                        htmltable.Rows[k].Cells.Add(cell);
                    }
                }


                //first time entry loop
                if (htmltable.Rows.Count == 1 && subcount > 0)
                {
                    for (int k = 0; k < subcount; k++)
                    {
                        row = new HtmlTableRow();
                        cell = new HtmlTableCell();
                        row.Cells.Add(cell);
                        htmltable.Rows.Add(row);
                    }
                }

                if (htmltable.Rows.Count - 1 < subcount)
                {
                    var diff = subcount - (htmltable.Rows.Count - 1);

                    for (int p = 1; p <= htmltable.Rows.Count - 1; p++)
                    {
                        cell = new HtmlTableCell();
                        htmltable.Rows[p].Cells.Add(cell);
                    }

                    //should add new rows for diffcount
                    for (int k = 0; k < diff; k++)
                    {
                        row = new HtmlTableRow();
                        for (int cellcount = 0; cellcount <= i; cellcount++)
                        {
                            cell = new HtmlTableCell();
                            row.Cells.Add(cell);
                        }
                        htmltable.Rows.Add(row);
                    }
                    //add cell to row 
                    //cell depends upon listcount
                }


                for (int j = 1; j <= subcount; j++)
                {
                    htmltable.Rows[j].Cells[i].InnerHtml = "sub" + j.ToString();
                }
            }

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            htmltable.RenderControl(htw);
            string content = sb.ToString();

        }

    }
}