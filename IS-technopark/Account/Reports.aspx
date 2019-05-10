<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="IS_technopark.Account.Reports" MasterPageFile="~/Site.Master"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center">ОСВОБОЖДЕНИЕ</h2>
    <br>
    <br>
    <h4 style="text-align:left; font-weight:600 ">Поиск группы по шифру</h4>
    <asp:Label ID="Label1" runat="server" Text="Введите шифр" style="width:200px; height:30px; font-size:16px; margin-right: 10px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:10px;"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Выбрать"  CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" Height="33px" style="text-align:center" OnClick="Button2_Click" />
    <br>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.GROUPS.TITLE, TECHNOPARK.LEARNER.FIO, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.GROUPS.PROJECT_THEME, TECHNOPARK.EMPLOYEES.FIO AS EXPR1, TECHNOPARK.GROUPS.D_CONFERENCE FROM TECHNOPARK.EMPLOYEES INNER JOIN TECHNOPARK.GROUPS ON TECHNOPARK.EMPLOYEES.ID_EMPLOYEES = TECHNOPARK.GROUPS.ID_EMPLOYEES INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.GROUPS.TITLE = TECHNOPARK.QUEUE.TITLE_G INNER JOIN TECHNOPARK.LEARNER ON TECHNOPARK.QUEUE.ID_LEARNER_Q = TECHNOPARK.LEARNER.ID_LEARNER"></asp:SqlDataSource>
    <br>
    <asp:Label ID="Label5" runat="server" Text="Данные группы" style="width:200px; height:30px; font-size:16px; margin-right: 10px" Font-Italic="False" Font-Bold="True"></asp:Label>
    <br>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="30px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" />
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
            <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" />
            <asp:BoundField DataField="PROJECT_THEME" HeaderText="PROJECT_THEME" SortExpression="PROJECT_THEME" />
            <asp:BoundField DataField="EXPR1" HeaderText="EXPR1" SortExpression="EXPR1" />
            <asp:BoundField DataField="D_CONFERENCE" HeaderText="D_CONFERENCE" SortExpression="D_CONFERENCE" />
        </Columns>
    </asp:GridView>
    <br>
    <br>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" OnInit="ReportViewer1_Init" >
        <LocalReport ReportPath="Account\Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet2" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="SelectList" TypeName="IS_technopark.Account.Reports"></asp:ObjectDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>

<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

</asp:Content>