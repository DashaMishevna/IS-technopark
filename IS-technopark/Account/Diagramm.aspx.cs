using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace IS_technopark.Account
{
    public partial class Diagramm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            Chart1.BorderlineColor = Color.Gray;
            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;

            Chart1.Titles.Add("ASP.NET Chart");
            Chart1.Titles[0].Font = new Font("Utopia", 16);

            Chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });

            //select DIR_LABORATORIES.LABORATORY from QUEUE, DIR_LABORATORIES WHERE QUEUE.ID_LABORATORIES=DIR_LABORATORIES.ID_LABORATORIES group by DIR_LABORATORIES.LABORATORY;

            //select Count(ID_queue)from QUEUE, DIR_LABORATORIES WHERE QUEUE.ID_LABORATORIES = DIR_LABORATORIES.ID_LABORATORIES group by DIR_LABORATORIES.LABORATORY;
        }
    }
}