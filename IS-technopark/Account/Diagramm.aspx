<%@ Page Title="Diagramm" Language="C#" AutoEventWireup="true" CodeBehind="Diagramm.aspx.cs" Inherits="IS_technopark.Account.Diagramm" MasterPageFile="~/Site.Master"  %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center"> СТАТИСТИКА</h2>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Диаграмма по направлениям" CssClass="btn btn-default" Font-Size="10pt" BackColor="#d6e9f5" ForeColor="#1e577b" />
    
    <br />
    <asp:Chart ID="Chart1" runat="server" Height="550px" Width="550px">
        <Series>
        <asp:Series Name="" Legend="Legend1"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" ShadowColor="LightSkyBlue"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="">
            </asp:Legend>
        </Legends>
    </asp:Chart>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <a id="toggleLink" href="javascript:void(0);" onclick="viewdiv('mydiv');" data-text-show="Спрятать блок" data-text-hide="Показать блок">Показать блок</a>
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
    </script>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Воронка по году" CssClass="btn btn-default" Font-Size="10pt" BackColor="#d6e9f5" ForeColor="#1e577b" />
    <asp:Button ID="Button3" runat="server" Text="Диаграмма по интересам" CssClass="btn btn-default" Font-Size="10pt" BackColor="#d6e9f5" ForeColor="#1e577b" OnClick="Button3_Click"/>
</asp:Content>