<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Diagramm_Interests.aspx.cs" Inherits="IS_technopark.Account.Diagramm_Interests" MasterPageFile="~/Site.Master"  %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="select Count(ID_Learner) as Количество, class as Класс from Learner WHERE INTERESTS Like '%Робототехника%' group by Class"></asp:SqlDataSource>
    <br />
    <h3 style="text-align:center"> Статистика</h3>
    <h5 style="text-align:center"> Количество проектаннтов, которые выбрали определенное навтравление в отностительно класса обучения в школе </h5>
    <div style="float:left; margin-left:0px; width: 712px;"> 
    <br />
    <br />
     <div style="margin-top:4px; float:left; width:251px; font-size:14px;">
    <asp:Label ID="Label1" runat="server" Text="Выберите направление"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"  CssClass="btn btn-default" AutoPostBack="True"></asp:DropDownList>
    </div>
    <br>
    <div class="form-row" style="width:400px; margin-top:-5px">
    <asp:Chart ID="Chart1" runat="server" Height="340px" Width="380px">
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

    <div style="float:right; text-align:left; margin-right:200px; margin-top:4px; font-size:14px">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="КОЛИЧЕСТВО" HeaderText="Количество" ReadOnly="True" SortExpression="КОЛИЧЕСТВО" />
            <asp:BoundField DataField="КЛАСС" HeaderText="Класс" SortExpression="КЛАСС" />
        </Columns>
        </asp:GridView>
    </div>
</asp:Content>
