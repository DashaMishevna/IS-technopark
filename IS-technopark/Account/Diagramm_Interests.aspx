<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diagramm_Interests.aspx.cs" Inherits="IS_technopark.Account.Diagramm_Interests" MasterPageFile="~/Site.Master"  %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="select Count(ID_Learner) as Количество, class as Класс from Learner WHERE INTERESTS Like '%Робототехника%' and 1=0 group by Class"></asp:SqlDataSource>
    <br />
    <h3 style="text-align:center"> Статистика по интересам</h3>
    <h5 style="text-align:center"> Количество проектантов, которые выбрали определенное направление в раздел интересы,  отностительно класса обучения в школе </h5>
    <div style="float:left; margin-left:0px; width: 712px;"> 
    <br />
    <br />
     <div style="margin-top:4px; float:left; width:251px; font-size:14px;">
    <asp:Label ID="Label1" runat="server" Text="Выберите направление" ForeColor="#1870b4"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  CssClass="btn btn-default" AutoPostBack="True"></asp:DropDownList>
    </div>
    <br>
    <div class="form-row" style="width:400px; margin-top:-5px">
    <asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px">
        <Series>
            <asp:Series Name="Series1" Legend="Legend1" XValueType="Int32" YValueType="Int32"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>
    </div>
    </div>

    <div style="float:right; text-align:left; margin-right:150px; margin-top:4px; font-size:14px">
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" HeaderStyle-Font-Size="12px" CellPadding="5" CellSpacing="3" GridLines="Vertical">
        <Columns>
            <asp:BoundField DataField="КОЛИЧЕСТВО" HeaderText="Количество проектантов" ReadOnly="True" SortExpression="КОЛИЧЕСТВО" >
            <HeaderStyle HorizontalAlign="Center" Width="130px" Font-Size="10pt" /> <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="КЛАСС" HeaderText="Класс" SortExpression="КЛАСС" ><HeaderStyle HorizontalAlign="Center" Width="130px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle BackColor="#1870b4" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" />
        <AlternatingRowStyle BackColor="#d2ecf9" />
        <PagerStyle BackColor="#8fc6f0" ForeColor="White" HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>
