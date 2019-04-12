<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="IS_technopark.Account.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT FIO FROM TECHNOPARK.EMPLOYEES WHERE (POSITION = 2)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;FIO&quot;, &quot;CLASS&quot;, &quot;SHIFT&quot;, &quot;SCHOOL&quot;, &quot;INTERESTS&quot; FROM &quot;LEARNER&quot;"></asp:SqlDataSource>
    <br>
    <h2 style="text-align:center"> ГРУППЫ </h2>
<%--    <div style="float:right; text-align:left; margin-right:-100px; margin-bottom:50px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
                <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
                <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" />
                <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" />
                <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
            </Columns>
        </asp:GridView>
    </div>--%>
       <%-- <h4 style="text-align:left; font-weight:600 ">Данные о группе</h4>
        <br>--%>
        <div class="form-label-groups">
            <asp:Label ID="Label2" runat="server" Text="ФИО Преподавателя*"></asp:Label>
        </div>
        <div class="form-row-groups">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" CssClass="btn btn-default" DataTextField="FIO" DataValueField="FIO"> </asp:DropDownList>
        </div>
        <br>
        <br>
        <div class="form-label-groups">
            <asp:Label ID="Label3" runat="server" Text="Направление *"></asp:Label>
        </div>
        <div class="form-row-groups">
            <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  Height="30px" Width="225px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div class='form-label-groups'>
            <asp:Label ID="Label4" runat="server" Text="Проект *"></asp:Label>
        </div>
        <div class='form-row-groups'>
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-default" AutoPostBack="True"  Height="30px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div class='form-label-groups'>
            <asp:Label ID="Label5" runat="server" Text="Шифр группы*"></asp:Label>
        </div>
        <div class='form-row-groups'>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label-groups'>
            <asp:Label ID="Label6" runat="server" Text="Тема проекта"></asp:Label>
        </div>
        <div class='form-row-groups'>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div class='form-label-groups'>
            <asp:Label ID="Label7" runat="server" Text="Время занятий"></asp:Label>
        </div>
        <div class='form-row-groups'>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
    <br>
    <br>

   <%-- <div class="form-group" style="text-align:center; margin-bottom:-100px">
        <asp:Button ID="Button1" runat="server" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3"  />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>--%>


 </asp:Content>