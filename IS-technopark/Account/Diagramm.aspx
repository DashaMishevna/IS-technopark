<%@ Page Title="Статистика" Language="C#" AutoEventWireup="true" CodeBehind="Diagramm.aspx.cs" Inherits="IS_technopark.Account.Diagramm" MasterPageFile="~/Site.Master"  %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center">Статистика по направлениям</h2>
    <h5 style="text-align:center"> Количество проектантов, которые успешно завершили проекты </h5>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Выберите год"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <div style="margin-top:4px; float:left; margin-left:150px">
    <asp:Chart ID="Chart1" runat="server" Height="450px" Width="450px">
        <Series>
        <asp:Series Name="Series1" IsValueShownAsLabel="True" Legend="Legend1"> </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" ShadowColor="LightSkyBlue"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>
         </div>
    <%--<asp:GridView ID="GridView1" runat="server">
    </asp:GridView>--%>

 <%--   <a id="toggleLink" href="javascript:void(0);" onclick="viewdiv('mydiv');" data-text-show="Спрятать блок" data-text-hide="Показать блок">Показать блок</a>
    <div id="mydiv" style="display:none;">text text text</div>

    <script>
    function viewdiv(id) {
        var el = document.getElementById(id);
        var link = document.getElementById('toggleLink');
        if (el.style.display == "block") {
            el.style.display = "none";
            link.innerText = link.getAttribute('data-text-hide');
        } else {
            el.style.display = "block";
            link.innerText = link.getAttribute('data-text-show');
        }
    }
    </script>--%>
</asp:Content>