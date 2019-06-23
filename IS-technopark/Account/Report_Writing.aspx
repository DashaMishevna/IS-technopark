<%@ Page Language="C#" Title="Запись на проект" AutoEventWireup="true" CodeBehind="Report_Writing.aspx.cs" Inherits="IS_technopark.Account.Report_Writing" MasterPageFile="~/Site.Master"%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center">ОТЧЕТ - ЗАПИСЬ НА ПРОЕКТ</h2>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;TITLE&quot; FROM &quot;DIR_PROJECTS&quot;"></asp:SqlDataSource>
    <br>
    <br>
    <div style="margin-left:245px" >
    <rsweb:ReportViewer ID="ReportViewer_Writing" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="695px" Height="750px" >
        <LocalReport ReportPath="Account\Writing.rdlc">
            <DataSources>
             <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
         </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </div>
    

</asp:Content>