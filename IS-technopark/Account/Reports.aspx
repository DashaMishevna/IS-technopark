<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="IS_technopark.Account.Reports" MasterPageFile="~/Site.Master"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>

</asp:Content>