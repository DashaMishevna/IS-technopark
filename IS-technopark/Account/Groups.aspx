<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="IS_technopark.Account.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT FIO FROM TECHNOPARK.EMPLOYEES WHERE (POSITION = 2)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_PROJECTS.TITLE  FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <br>
    <h2 style="text-align:center"> ГРУППЫ </h2>
    <div style="float:right; text-align:left; margin-right:-150px; font-size:12px">
        <br>
        <br>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" HeaderStyle-Width="205px" />
                <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="ДАТА РЕГИСТРАЦИИ" SortExpression="DATE_REGISTRATION" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="120px"/>
                <asp:BoundField DataField="CLASS" HeaderText="КЛАСС" SortExpression="CLASS" HeaderStyle-Width="60"/>
                <asp:BoundField DataField="SHIFT" HeaderText="СМЕНА" SortExpression="SHIFT" HeaderStyle-Width="60"/>
                <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" />
                <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" HeaderStyle-Width="235px"/>
            </Columns>
        </asp:GridView>
    </div>

    <div style="float:left; margin-left:-170px;"> 
        <h4 style="text-align:left; font-weight:600 ">Данные о группе</h4>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label2" runat="server" Text="ФИО Преподавателя*"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" CssClass="btn btn-default" DataTextField="FIO" DataValueField="FIO"> </asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label3" runat="server" Text="Направление *"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  Height="30px" Width="225px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label4" runat="server" Text="Проект *"></asp:Label>
        </div>
        <div class='form-row'style="width:300px;" >
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="btn btn-default" AutoPostBack="True"  Height="30px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label5" runat="server" Text="Шифр группы*"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;"> 
            <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label6" runat="server" Text="Тема проекта"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label7" runat="server" Text="Время занятий"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label8" runat="server" Text="Интересы"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3" CssClass="btn btn-default" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"> </asp:DropDownList>
        </div>
        <br>
        <br>
 </div>

    <div class="form-group" style=" text-align:center; margin-top:500px">
        <asp:Button ID="Button1" runat="server" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3"  />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>


 </asp:Content>